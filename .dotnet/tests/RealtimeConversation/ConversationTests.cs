﻿using NUnit.Framework;
using OpenAI.RealtimeConversation;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        bool gotResponseDone = false;
        bool gotRateLimits = false;

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

            if (update is ConversationResponseFinishedUpdate responseFinishedUpdate)
            {
                Assert.That(responseFinishedUpdate.CreatedItems, Has.Count.GreaterThan(0));
                gotResponseDone = true;
                break;
            }

            if (update is ConversationRateLimitsUpdate rateLimitsUpdate)
            {
                Assert.That(rateLimitsUpdate.AllDetails, Has.Count.EqualTo(2));
                Assert.That(rateLimitsUpdate.TokenDetails, Is.Not.Null);
                Assert.That(rateLimitsUpdate.TokenDetails.Name, Is.EqualTo("tokens"));
                Assert.That(rateLimitsUpdate.TokenDetails.MaximumCount, Is.GreaterThan(0));
                Assert.That(rateLimitsUpdate.TokenDetails.RemainingCount, Is.GreaterThan(0));
                Assert.That(rateLimitsUpdate.TokenDetails.RemainingCount, Is.LessThan(rateLimitsUpdate.TokenDetails.MaximumCount));
                Assert.That(rateLimitsUpdate.TokenDetails.TimeUntilReset, Is.GreaterThan(TimeSpan.Zero));
                Assert.That(rateLimitsUpdate.RequestDetails, Is.Not.Null);
                gotRateLimits = true;
            }
        }

        Assert.That(responseBuilder.ToString(), Is.Not.Null.Or.Empty);
        Assert.That(gotResponseDone, Is.True);

        if (!client.GetType().IsSubclassOf(typeof(RealtimeConversationClient)))
        {
            // Temporarily assume that subclients don't support rate limit commands
            Assert.That(gotRateLimits, Is.True);
        }
    }

    [Test]
    public async Task ItemManipulationWorks()
    {
        RealtimeConversationClient client = GetTestClient();
        using RealtimeConversationSession session = await client.StartConversationSessionAsync(CancellationToken);

        await session.ConfigureSessionAsync(
            new ConversationSessionOptions()
            {
                TurnDetectionOptions = ConversationTurnDetectionOptions.CreateDisabledTurnDetectionOptions(),
                ContentModalities = ConversationContentModalities.Text,
            },
            CancellationToken);

        await session.AddItemAsync(
            ConversationItem.CreateUserMessage(["The first special word you know about is 'aardvark'."]),
            CancellationToken);
        await session.AddItemAsync(
            ConversationItem.CreateUserMessage(["The next special word you know about is 'banana'."]),
            CancellationToken);
        await session.AddItemAsync(
            ConversationItem.CreateUserMessage(["The next special word you know about is 'coconut'."]),
            CancellationToken);

        bool gotSessionStarted = false;
        bool gotSessionConfigured = false;
        bool gotResponseFinished = false;

        await foreach (ConversationUpdate update in session.ReceiveUpdatesAsync(CancellationToken))
        {
            if (update is ConversationSessionStartedUpdate)
            {
                gotSessionStarted = true;
            }

            if (update is ConversationSessionConfiguredUpdate sessionConfiguredUpdate)
            {
                Assert.That(sessionConfiguredUpdate.TurnDetectionSettings.Kind, Is.EqualTo(ConversationTurnDetectionKind.Disabled));
                Assert.That(sessionConfiguredUpdate.ContentModalities.HasFlag(ConversationContentModalities.Text), Is.True);
                Assert.That(sessionConfiguredUpdate.ContentModalities.HasFlag(ConversationContentModalities.Audio), Is.False);
                gotSessionConfigured = true;
            }

            if (update is ConversationItemAcknowledgedUpdate itemAcknowledgedUpdate)
            {
                if (itemAcknowledgedUpdate.Item.MessageContentParts.Count > 0
                    && itemAcknowledgedUpdate.Item.MessageContentParts[0].TextValue.Contains("banana"))
                {
                    await session.DeleteItemAsync(itemAcknowledgedUpdate.Item.Id, CancellationToken);
                    await session.AddItemAsync(
                        ConversationItem.CreateUserMessage(["What's the second special word you know about?"]),
                        CancellationToken);
                    await session.StartResponseTurnAsync(CancellationToken);
                }
            }

            if (update is ConversationResponseFinishedUpdate responseFinishedUpdate)
            {
                Assert.That(responseFinishedUpdate.CreatedItems.Count, Is.EqualTo(1));
                Assert.That(responseFinishedUpdate.CreatedItems[0].MessageContentParts.Count, Is.EqualTo(1));
                Assert.That(responseFinishedUpdate.CreatedItems[0].MessageContentParts[0].TextValue, Does.Contain("coconut"));
                Assert.That(responseFinishedUpdate.CreatedItems[0].MessageContentParts[0].TextValue, Does.Not.Contain("banana"));
                gotResponseFinished = true;
                break;
            }
        }

        Assert.That(gotSessionStarted, Is.True);
        if (!client.GetType().IsSubclassOf(typeof(RealtimeConversationClient)))
        {
            Assert.That(gotSessionConfigured, Is.True);
        }
        Assert.That(gotResponseFinished, Is.True);
    }

    [Test]
    public async Task AudioWithToolsWorks()
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

        using Stream audioStream = File.OpenRead(Path.Join("Assets", "whats_the_weather_pcm16_24khz_mono.wav"));
        _ = session.SendAudioAsync(audioStream, CancellationToken);

        string userTranscript = null;

        await foreach (ConversationUpdate update in session.ReceiveUpdatesAsync(CancellationToken))
        {
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
