using NUnit.Framework;
using OpenAI.RealtimeConversation;
using System;
using System.Buffers;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Tests.Conversation;

#pragma warning disable OPENAI002

[TestFixture(true)]
[TestFixture(false)]
public class ConversationTests : ConversationTestFixtureBase
{
    public ConversationTests(bool isAsync) : base(isAsync) { }

    [Test]
    public async Task CanConfigureSession()
    {
        RealtimeConversationClient client = GetTestClient();
        using RealtimeConversationSession session = await client.StartConversationSessionAsync(CancellationToken);

        await session.ConfigureSessionAsync(
            new ConversationSessionOptions()
            {
                Instructions = "You are a helpful assistant.",
                TurnDetectionOptions = ConversationTurnDetectionOptions.CreateDisabledTurnDetectionOptions(),
                OutputAudioFormat = ConversationAudioFormat.G711Ulaw
            },
            CancellationToken);

        await session.StartResponseTurnAsync(CancellationToken);

        List<ConversationUpdate> receivedUpdates = [];

        await foreach (ConversationUpdate update in session.ReceiveUpdatesAsync(CancellationToken))
        {
            receivedUpdates.Add(update);
            
            if (update is ConversationErrorUpdate errorUpdate)
            {
                Assert.That(errorUpdate.Kind, Is.EqualTo(ConversationUpdateKind.Error));
                Assert.Fail($"Error: {ModelReaderWriter.Write(errorUpdate)}");
            }
            else if (update is ConversationResponseFinishedUpdate turnFinishedUpdate)
            {
                break;
            }
        }

        List<T> GetReceivedUpdates<T>() where T : ConversationUpdate
            => receivedUpdates.Select(update => update as T)
                .Where(update => update is not null)
                .ToList();

        Assert.That(GetReceivedUpdates<ConversationSessionStartedUpdate>(), Has.Count.EqualTo(1));
        Assert.That(GetReceivedUpdates<ConversationResponseStartedUpdate>(), Has.Count.EqualTo(1));
        Assert.That(GetReceivedUpdates<ConversationResponseFinishedUpdate>(), Has.Count.EqualTo(1));
        Assert.That(GetReceivedUpdates<ConversationItemStartedUpdate>(), Has.Count.EqualTo(1));
        Assert.That(GetReceivedUpdates<ConversationItemFinishedUpdate>(), Has.Count.EqualTo(1));
    }

    [Test]
    public async Task TextOnlyWorks()
    {
        RealtimeConversationClient client = GetTestClient();
        using RealtimeConversationSession session = await client.StartConversationSessionAsync(CancellationToken);
        await session.AddItemAsync(
            ConversationItem.CreateUserMessage(["Hello, world!"]),
            cancellationToken: CancellationToken);
        await session.StartResponseTurnAsync(CancellationToken);

        StringBuilder responseBuilder = new();

        await foreach (ConversationUpdate update in session.ReceiveUpdatesAsync(CancellationToken))
        {
            if (update is ConversationSessionStartedUpdate sessionStartedUpdate)
            {
                Assert.That(sessionStartedUpdate.SessionId, Is.Not.Null.And.Not.Empty);
            }
            if (update is ConversationTextDeltaUpdate textDeltaUpdate)
            {
                responseBuilder.Append(textDeltaUpdate.Delta);
            }

            if (update is ConversationItemAcknowledgedUpdate itemAddedUpdate)
            {
                Assert.That(itemAddedUpdate.Item is not null);
            }

            if (update is ConversationRateLimitsUpdatedUpdate)
            {
                break;
            }
        }

        Assert.That(responseBuilder.ToString(), Is.Not.Null.Or.Empty);
    }

    public enum TestAudioSendType
    {
        WithAudioStreamHelper,
        WithManualAudioChunks
    }

    private class TestDelayedFileReadStream : FileStream
    {
        private readonly TimeSpan _delayBetweenReads;
        private readonly int _readsBeforeDelay;
        private int _readsPerformed;

        public TestDelayedFileReadStream(
            string path,
            TimeSpan delayBetweenReads,
            int readsBeforeDelay = 0)
                : base(path, FileMode.Open, FileAccess.Read)
        {
            _delayBetweenReads = delayBetweenReads;
            _readsBeforeDelay = readsBeforeDelay;
            _readsPerformed = 0;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (++_readsPerformed > _readsBeforeDelay)
            {
                System.Threading.Thread.Sleep((int)_delayBetweenReads.TotalMilliseconds);
            }
            return base.Read(buffer, offset, count);
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            if (++_readsPerformed > _readsBeforeDelay)
            {
                await Task.Delay(_delayBetweenReads);
            }
            return await base.ReadAsync(buffer, offset, count, cancellationToken);
        }
    }

    [Test]
    public async Task AudioStreamConvenienceBlocksCorrectly()
    {
        RealtimeConversationClient client = GetTestClient();
        using RealtimeConversationSession session = await client.StartConversationSessionAsync(CancellationToken);

        string inputAudioFilePath = Path.Join("Assets", "whats_the_weather_pcm16_24khz_mono.wav");
        using TestDelayedFileReadStream delayedStream = new(inputAudioFilePath, TimeSpan.FromMilliseconds(200), readsBeforeDelay: 2);
        _ = session.SendAudioAsync(delayedStream, CancellationToken);

        bool gotSpeechStarted = false;

        await foreach (ConversationUpdate update in session.ReceiveUpdatesAsync(CancellationToken))
        {
            if (update is ConversationInputSpeechStartedUpdate)
            {
                gotSpeechStarted = true;
                Assert.ThrowsAsync<InvalidOperationException>(
                    async () =>
                    {
                        using MemoryStream dummyStream = new();
                        await session.SendAudioAsync(dummyStream, CancellationToken);
                    },
                    "Sending a Stream while another Stream is being sent should throw!");
                Assert.ThrowsAsync<InvalidOperationException>(
                    async () =>
                    {
                        BinaryData dummyData = BinaryData.FromString("hello, world! this isn't audio.");
                        await session.SendAudioAsync(dummyData, CancellationToken);
                    },
                    "Sending BinaryData while a Stream is being sent should throw!");
                break;
            }
        }

        Assert.That(gotSpeechStarted, Is.True);
    }

    [Test]
    [TestCase(TestAudioSendType.WithAudioStreamHelper)]
    [TestCase(TestAudioSendType.WithManualAudioChunks)]
    public async Task AudioWithToolsWorks(TestAudioSendType audioSendType)
    {
        RealtimeConversationClient client = GetTestClient();
        using RealtimeConversationSession session = await client.StartConversationSessionAsync(CancellationToken);

        ConversationFunctionTool getWeatherTool = new()
        {
            Name = "get_weather_for_location",
            Description = "gets the weather for a location",
            Parameters = BinaryData.FromString("""
            {
                "type": "object",
                "properties": {
                "location": {
                    "type": "string",
                    "description": "The city and state e.g. San Francisco, CA"
                },
                "unit": {
                    "type": "string",
                    "enum": [
                    "c",
                    "f"
                    ]
                }
                },
                "required": [
                "location",
                "unit"
                ]
            }
            """)
        };

        ConversationSessionOptions options = new()
        {
            Instructions = "Call provided tools if appropriate for the user's input.",
            Voice = ConversationVoice.Alloy,
            Tools = { getWeatherTool },
            InputTranscriptionOptions = new ConversationInputTranscriptionOptions()
            {
                Model = "whisper-1"
            },
        };

        await session.ConfigureSessionAsync(options, CancellationToken);

        _ = Task.Run(async () =>
        {
            string inputAudioFilePath = Path.Join("Assets", "whats_the_weather_pcm16_24khz_mono.wav");
            if (audioSendType == TestAudioSendType.WithAudioStreamHelper)
            {
                using Stream audioStream = File.OpenRead(inputAudioFilePath);
                await session.SendAudioAsync(audioStream, CancellationToken);
            }
            else if (audioSendType == TestAudioSendType.WithManualAudioChunks)
            {
                byte[] allAudioBytes = await File.ReadAllBytesAsync(inputAudioFilePath, CancellationToken);
                const int audioSendBufferLength = 8 * 1024;
                byte[] audioSendBuffer = ArrayPool<byte>.Shared.Rent(audioSendBufferLength);
                for (int readPos = 0; readPos < allAudioBytes.Length; readPos += audioSendBufferLength)
                {
                    int nextSegmentLength = Math.Min(audioSendBufferLength, allAudioBytes.Length - readPos);
                    ArraySegment<byte> nextSegment = new(allAudioBytes, readPos, nextSegmentLength);
                    await session.SendAudioAsync(BinaryData.FromBytes(nextSegment), CancellationToken);
                }
            }
        });

        string userTranscript = null;

        await foreach (ConversationUpdate update in session.ReceiveUpdatesAsync(CancellationToken))
        {
            Assert.That(update.EventId, Is.Not.Null.And.Not.Empty);

            if (update is ConversationSessionStartedUpdate sessionStartedUpdate)
            {
                Assert.That(sessionStartedUpdate.SessionId, Is.Not.Null.And.Not.Empty);
                Assert.That(sessionStartedUpdate.Model, Is.Not.Null.And.Not.Empty);
                Assert.That(sessionStartedUpdate.ContentModalities.HasFlag(ConversationContentModalities.Text));
                Assert.That(sessionStartedUpdate.ContentModalities.HasFlag(ConversationContentModalities.Audio));
                Assert.That(sessionStartedUpdate.Voice.ToString(), Is.Not.Null.And.Not.Empty);
                Assert.That(sessionStartedUpdate.Temperature, Is.GreaterThan(0));
            }

            if (update is ConversationInputTranscriptionFinishedUpdate  inputTranscriptionCompletedUpdate)
            {
                userTranscript = inputTranscriptionCompletedUpdate.Transcript;
            }

            if (update is ConversationItemFinishedUpdate itemFinishedUpdate
                && itemFinishedUpdate.FunctionCallId is not null)
            {
                Assert.That(itemFinishedUpdate.FunctionName, Is.EqualTo(getWeatherTool.Name));

                ConversationItem functionResponse = ConversationItem.CreateFunctionCallOutput(
                    itemFinishedUpdate.FunctionCallId,
                    "71 degrees Fahrenheit, sunny");
                await session.AddItemAsync(functionResponse, CancellationToken);
            }

            if (update is ConversationResponseFinishedUpdate turnFinishedUpdate)
            {
                if (turnFinishedUpdate.CreatedItems.Any(item => !string.IsNullOrEmpty(item.FunctionCallId)))
                {
                    await session.StartResponseTurnAsync(CancellationToken);
                }
                else
                {
                    break;
                }
            }
        }

        Assert.That(userTranscript, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public async Task CanDisableVoiceActivityDetection()
    {
        RealtimeConversationClient client = GetTestClient();
        using RealtimeConversationSession session = await client.StartConversationSessionAsync(CancellationToken);

        await session.ConfigureSessionAsync(
            new()
            {
                TurnDetectionOptions = ConversationTurnDetectionOptions.CreateDisabledTurnDetectionOptions(),
            },
            CancellationToken);

        const string folderName = "Assets";
        const string fileName = "whats_the_weather_pcm16_24khz_mono.wav";
#if NET6_0_OR_GREATER
        using Stream audioStream = File.OpenRead(Path.Join(folderName, fileName));
#else
        using Stream audioStream = File.OpenRead($"{folderName}\\{fileName}");
#endif
        await session.SendAudioAsync(audioStream, CancellationToken);

        await session.AddItemAsync(ConversationItem.CreateUserMessage(["Hello, assistant!"]), CancellationToken);

        await foreach (ConversationUpdate update in session.ReceiveUpdatesAsync(CancellationToken))
        {
            if (update is ConversationErrorUpdate errorUpdate)
            {
                Assert.Fail($"Error received: {ModelReaderWriter.Write(errorUpdate)}");
            }

            if (update is ConversationInputSpeechStartedUpdate
                or ConversationInputSpeechFinishedUpdate
                or ConversationInputTranscriptionFinishedUpdate 
                or ConversationInputTranscriptionFailedUpdate
                or ConversationResponseStartedUpdate
                or ConversationResponseFinishedUpdate)
            {
                Assert.Fail($"Shouldn't receive any VAD events or response creation!");
            }

            if (update is ConversationItemAcknowledgedUpdate itemAcknowledgedUpdate
                && itemAcknowledgedUpdate.Item.MessageRole == ConversationMessageRole.User)
            {
                break;
            }
        }
    }
}
