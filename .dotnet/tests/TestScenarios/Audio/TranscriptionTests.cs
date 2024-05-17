using NUnit.Framework;
using OpenAI.Audio;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Audio;

public partial class TranscriptionTests
{
    public enum AudioSourceKind
    {
        UsingStream,
        UsingFilePath,
    }

    public enum SyncOrAsync
    {
        Sync,
        Async,
    }

    [Test]
    [TestCase(AudioSourceKind.UsingStream, SyncOrAsync.Sync)]
    [TestCase(AudioSourceKind.UsingStream, SyncOrAsync.Async)]
    [TestCase(AudioSourceKind.UsingFilePath, SyncOrAsync.Sync)]
    [TestCase(AudioSourceKind.UsingFilePath, SyncOrAsync.Async)]
    public async Task TranscriptionWorks(AudioSourceKind audioSourceKind, SyncOrAsync syncOrAsync)
    {
        AudioClient client = GetTestClient();
        string filename = "hello_world.m4a";
        string path = Path.Combine("Assets", filename);
        AudioTranscription transcription = null;
        if (audioSourceKind == AudioSourceKind.UsingStream)
        {
            using FileStream inputStream = File.OpenRead(path);
            transcription = syncOrAsync switch
            {
                SyncOrAsync.Sync => client.TranscribeAudio(inputStream, filename),
                SyncOrAsync.Async => await client.TranscribeAudioAsync(inputStream, filename),
                _ => throw new ArgumentException(nameof(syncOrAsync)),
            };
        }
        else if (audioSourceKind == AudioSourceKind.UsingFilePath)
        {
            transcription = syncOrAsync switch
            {
                SyncOrAsync.Sync => client.TranscribeAudio(path),
                SyncOrAsync.Async => await client.TranscribeAudioAsync(path),
                _ => throw new ArgumentException(nameof(syncOrAsync)),
            };
        }
        Assert.That(transcription, Is.Not.Null);
        Assert.That(transcription.Text.ToLowerInvariant(), Contains.Substring("hello"));
    }

    [Test]
    [TestCase(AudioTimestampGranularities.Default)]
    [TestCase(AudioTimestampGranularities.Word)]
    [TestCase(AudioTimestampGranularities.Segment)]
    [TestCase(AudioTimestampGranularities.Word | AudioTimestampGranularities.Segment)]
    public void TimestampsWork(AudioTimestampGranularities granularityFlags)
    {
        AudioClient client = GetTestClient();
        using FileStream inputStream = File.OpenRead(Path.Combine("Assets", "hello_world.m4a"));
        ClientResult<AudioTranscription> transcriptionResult = client.TranscribeAudio(inputStream, "hello_world.m4a", new AudioTranscriptionOptions()
        {
             ResponseFormat = AudioTranscriptionFormat.Verbose,
             Temperature = 0.4f,
             Granularities = granularityFlags,
        });
        Assert.That(transcriptionResult.Value, Is.Not.Null);

        Console.WriteLine(transcriptionResult.GetRawResponse().Content.ToString());

        IReadOnlyList<TranscribedWord> words = transcriptionResult.Value.Words;
        IReadOnlyList<TranscribedSegment> segments = transcriptionResult.Value.Segments;

        bool wordTimestampsPresent = words?.Count > 0;
        bool segmentTimestampsPresent = segments?.Count > 0;

        bool wordTimestampsExpected = granularityFlags.HasFlag(AudioTimestampGranularities.Word);
        bool segmentTimestampsExpected = granularityFlags.HasFlag(AudioTimestampGranularities.Segment)
            || granularityFlags == AudioTimestampGranularities.Default;

        Assert.That(wordTimestampsPresent, Is.EqualTo(wordTimestampsExpected));
        Assert.That(segmentTimestampsPresent, Is.EqualTo(segmentTimestampsExpected));

        for (int i = 0; i < (words?.Count ?? 0); i++)
        {
            if (i > 0)
            {
                Assert.That(words[i].Start, Is.GreaterThanOrEqualTo(words[i - 1].End));
            }
            Assert.That(words[i].End, Is.GreaterThan(words[i].Start));
            Assert.That(string.IsNullOrEmpty(words[i].Word), Is.False);
        }

        for (int i = 0; i < (segments?.Count ?? 0); i++)
        {
            if (i > 0)
            {
                Assert.That(segments[i].Id, Is.GreaterThan(segments[i - 1].Id));
                Assert.That(segments[i].SeekOffset, Is.GreaterThan(0));
                Assert.That(segments[i].Start, Is.GreaterThanOrEqualTo(segments[i - 1].End));
            }
            Assert.That(segments[i].End, Is.GreaterThan(segments[i].Start));
            Assert.That(string.IsNullOrEmpty(segments[i].Text), Is.False);
            Assert.That(segments[i].TokenIds, Is.Not.Null.Or.Empty);
            foreach (int tokenId in segments[i].TokenIds)
            {
                Assert.That(tokenId, Is.GreaterThan(0));
            }
            Assert.That(segments[i].Temperature, Is.LessThan(-0.001f).Or.GreaterThan(0.001f));
            Assert.That(segments[i].AverageLogProbability, Is.LessThan(-0.001f).Or.GreaterThan(0.001f));
            Assert.That(segments[i].CompressionRatio, Is.LessThan(-0.001f).Or.GreaterThan(0.001f));
            Assert.That(segments[i].NoSpeechProbability, Is.LessThan(-0.001f).Or.GreaterThan(0.001f));
        }
    }

    [Test]
    public void BadTranscriptionRequest()
    {
        AudioClient client = GetTestClient();
        string path = Path.Combine("Assets", "hello_world.m4a");

        Exception caughtException = null;
        try
        {
            _ = client.TranscribeAudio(path, new AudioTranscriptionOptions()
            {
                Language = "this should cause an error"
            });
        }
        catch (Exception ex)
        {
            caughtException = ex;
        }
        Assert.That(caughtException, Is.InstanceOf<ClientResultException>());
        Assert.That(caughtException.Message?.ToLower(), Contains.Substring("invalid language"));
    }

    private static AudioClient GetTestClient() => GetTestClient<AudioClient>(TestScenario.Transcription);
}
