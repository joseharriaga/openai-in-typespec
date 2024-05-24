﻿using NUnit.Framework;
using OpenAI.Audio;
using System;

namespace OpenAI.Samples;

public partial class AudioSamples
{
    [Test]
    // [Ignore("Compilation validation only")]
    public void Sample02_SimpleTranscription()
    {
        AudioClient client = new(
            "whisper-1",
            // This is the default key used and the line can be omitted
            Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

        AudioTranscriptionOptions options = new()
        {
            ResponseFormat = AudioTranscriptionFormat.Verbose,
            Granularities = AudioTimestampGranularities.Word | AudioTimestampGranularities.Segment,
        };
        AudioTranscription transcription = client.TranscribeAudio("recorded-talking.m4a", options);

        Console.WriteLine($"[TRANSCRIPTION]: {transcription.Text}");
        Console.WriteLine($"[WORDS]:");
        foreach (TranscribedWord wordItem in transcription.Words)
        {
            Console.WriteLine($"  {wordItem.Word,10}: {wordItem.Start.TotalMilliseconds,4:0} - {wordItem.End.TotalMilliseconds,4:0}");
        }
        Console.WriteLine($"[SEGMENTS]:");
        foreach (TranscribedSegment segmentItem in transcription.Segments)
        {
            Console.WriteLine($"  {segmentItem.Id,10}: {segmentItem.Text}: "
                + $"{segmentItem.Start.TotalMilliseconds,4:0} - {segmentItem.End.TotalMilliseconds,4:0}");
        }
    }
}
