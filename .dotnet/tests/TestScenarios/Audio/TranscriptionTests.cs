using NUnit.Framework;
using OpenAI.Audio;
using OpenAI.Tests.Utility;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Audio;

[TestFixture(true)]
[TestFixture(false)]
public partial class TranscriptionTests : SyncAsyncTestBase
{
    public TranscriptionTests(bool isAsync)
        : base(isAsync)
    {
    }

    public enum AudioSourceKind
    {
        UsingStream,
        UsingFilePath,
    }

    [Test]
    [TestCase(AudioSourceKind.UsingStream)]
    [TestCase(AudioSourceKind.UsingFilePath)]
    public async Task TranscriptionWorks(AudioSourceKind audioSourceKind)
    {
        AudioClient client = GetTestClient();
        string filename = "hello_world.m4a";
        string path = Path.Combine("Assets", filename);
        AudioTranscription transcription = null;

        if (audioSourceKind == AudioSourceKind.UsingStream)
        {
            using FileStream inputStream = File.OpenRead(path);

            transcription = IsAsync
                ? await client.TranscribeAudioAsync(inputStream, filename)
                : client.TranscribeAudio(inputStream, filename);
        }
        else if (audioSourceKind == AudioSourceKind.UsingFilePath)
        {
            transcription = IsAsync
                ? await client.TranscribeAudioAsync(path)
                : client.TranscribeAudio(path);
        }

        Assert.That(transcription, Is.Not.Null);
        Assert.That(transcription.Text.ToLowerInvariant(), Contains.Substring("hello"));
    }

    [Test]
    [TestCase(AudioTimestampGranularities.Default)]
    [TestCase(AudioTimestampGranularities.Word)]
    [TestCase(AudioTimestampGranularities.Segment)]
    [TestCase(AudioTimestampGranularities.Word | AudioTimestampGranularities.Segment)]
    public async Task TimestampsWork(AudioTimestampGranularities granularityFlags)
    {
        AudioClient client = GetTestClient();

        using FileStream inputStream = File.OpenRead(Path.Combine("Assets", "hello_world.m4a"));

        AudioTranscriptionOptions options = new()
        {
            ResponseFormat = AudioTranscriptionFormat.Verbose,
            Temperature = 0.4f,
            Granularities = granularityFlags,
        };

        AudioTranscription transcription = IsAsync
            ? await client.TranscribeAudioAsync(inputStream, "hello_world.m4a", options)
            : client.TranscribeAudio(inputStream, "hello_world.m4a", options);

        Assert.That(transcription, Is.Not.Null);

        IReadOnlyList<TranscribedWord> words = transcription.Words;
        IReadOnlyList<TranscribedSegment> segments = transcription.Segments;

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
            Assert.That(segments[i].TokenIds, Is.Not.Null.And.Not.Empty);
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
    public async Task BadTranscriptionRequest()
    {
        AudioClient client = GetTestClient();

        string path = Path.Combine("Assets", "hello_world.m4a");

        AudioTranscriptionOptions options = new AudioTranscriptionOptions()
        {
            Language = "this should cause an error"
        };

        Exception caughtException = null;

        try
        {
            _ = IsAsync
                ? await client.TranscribeAudioAsync(path, options)
                : client.TranscribeAudio(path, options);
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
