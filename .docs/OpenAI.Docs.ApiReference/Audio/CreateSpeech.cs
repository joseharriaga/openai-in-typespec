using NUnit.Framework;

#region usings
using System;
using System.IO;

using OpenAI.Audio;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateSpeechApiReference {

    [Test]
    public void CreateSpeech()
    {
		AudioClient client = new(
		    model: "tts-1", 
		    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		var response = client.GenerateSpeech(
		    "The quick brown fox jumped over the lazy dog.", 
		    GeneratedSpeechVoice.Alloy
		);
		
		string filePath = Path.Combine("speech.mp3");
		using (var fileWriter = new BinaryWriter(File.Open(filePath, FileMode.Create))) {
		    fileWriter.Write(response.Value);
		}

	}
}
