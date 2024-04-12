using NUnit.Framework;
using OpenAI.Audio;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Audio;

public partial class TranscriptionTests
{
    [Test]
    public void BasicTranscriptionWorks()
    {
        AudioClient client = GetTestClient();
        using FileStream inputStream = File.OpenRead(Path.Combine("Assets", "hello_world.m4a"));
        ClientResult<AudioTranscription> transcriptionResult = client.TranscribeAudio(inputStream, "hello_world.m4a");
        Assert.That(transcriptionResult.Value, Is.Not.Null);
        Assert.That(transcriptionResult.Value.Text.ToLowerInvariant(), Contains.Substring("hello"));
    }

    [Test]
    [TestCase(AudioTimestampGranularity.Default)]
    [TestCase(AudioTimestampGranularity.Word)]
    [TestCase(AudioTimestampGranularity.Segment)]
    [TestCase(AudioTimestampGranularity.Word | AudioTimestampGranularity.Segment)]
    public void TimestampsWork(AudioTimestampGranularity granularityFlags)
    {
        AudioClient client = GetTestClient();
        using FileStream inputStream = File.OpenRead(Path.Combine("Assets", "hello_world.m4a"));
        ClientResult<AudioTranscription> transcriptionResult = client.TranscribeAudio(inputStream, "hello_world.m4a", new AudioTranscriptionOptions()
        {
             ResponseFormat = AudioTranscriptionFormat.Verbose,
             Temperature = 0.4f,
             TimestampGranularityFlags = granularityFlags,
        });
        Assert.That(transcriptionResult.Value, Is.Not.Null);

        Console.WriteLine(transcriptionResult.GetRawResponse().Content.ToString());

        IReadOnlyList<TranscribedWord> words = transcriptionResult.Value.Words;
        IReadOnlyList<TranscribedSegment> segments = transcriptionResult.Value.Segments;

        bool wordTimestampsPresent = words?.Count > 0;
        bool segmentTimestampsPresent = segments?.Count > 0;

        bool wordTimestampsExpected = granularityFlags.HasFlag(AudioTimestampGranularity.Word);
        bool segmentTimestampsExpected = granularityFlags.HasFlag(AudioTimestampGranularity.Segment)
            || granularityFlags == AudioTimestampGranularity.Default;

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

    private static AudioClient GetTestClient() => GetTestClient<AudioClient>(TestScenario.Transcription);
}
