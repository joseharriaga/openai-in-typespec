using System;
using NUnit.Framework;

using System.IO;
using OpenAI.Audio;

namespace OpenAI.Docs.ApiReference;
public partial class CreateTranscriptionApiReference {

    [Test]
    public void CreateTranscription()
    {
		AudioClient client = new(
		    model: "whisper-1",
		    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		string filePath = Path.Combine("speech.mp3");
		AudioTranscription transcription = client.TranscribeAudio(
		    filePath,
		    new() {
		        ResponseFormat = AudioTranscriptionFormat.Verbose,
		        TimestampGranularities = AudioTimestampGranularities.Word
		    }
		);
		
		Console.WriteLine($"{transcription.Text}");
		
		
		// DO NOT INCLUDE IN DOCS FROM THIS POINT ONWARDS
		// The output is: The quick brown fox jumped over the lazy dog.
		
		Console.Read();

	}
}
