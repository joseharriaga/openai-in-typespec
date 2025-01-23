using System;
using NUnit.Framework;

using System.IO;
using OpenAI.Audio;

namespace OpenAI.Docs.ApiReference;
public partial class CreateTranslationApiReference {

    [Test]
    public void CreateTranslation()
    {
		AudioClient client = new(
		    model: "whisper-1",
		    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		string filePath = Path.Combine("speech.mp3");
		AudioTranslation translation = client.TranslateAudio(filePath);
		
		Console.WriteLine($"{translation.Text}");
		
		
		// DO NOT INCLUDE IN DOCS FROM THIS POINT ONWARDS
		// The output is: Hello. My name is Wolfgang and I come from Germany. Where are you going today?
		
		Console.Read();

	}
}
