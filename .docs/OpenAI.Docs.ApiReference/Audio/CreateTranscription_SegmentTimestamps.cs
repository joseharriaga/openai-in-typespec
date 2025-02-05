using NUnit.Framework;

#region usings
using System;

using OpenAI.Audio;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class AudioDocs
{
    [Test]
    public void CreateTranscription_SegmentTimestamps()
    {
        #region logic

        string audioFilePath = "audio.mp3";

        AudioClient client = new(
            model: "whisper-1",
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        AudioTranscriptionOptions options = new()
        {
            ResponseFormat = AudioTranscriptionFormat.Verbose,
            TimestampGranularities = AudioTimestampGranularities.Segment,
        };

        AudioTranscription transcription = client.TranscribeAudio(audioFilePath, options);

        Console.WriteLine($"{transcription.Text}");

        #endregion
    }
}
