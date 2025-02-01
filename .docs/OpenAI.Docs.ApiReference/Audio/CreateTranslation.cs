using NUnit.Framework;

#region usings
using System;
using System.IO;

using OpenAI.Audio;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateTranslationApiReference {

    [Test]
    public void CreateTranslation()
    {
        #region logic
        
		AudioClient client = new(
		    model: "whisper-1",
		    apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		string filePath = Path.Combine("speech.mp3");
		AudioTranslation translation = client.TranslateAudio(filePath);
		
		Console.WriteLine($"{translation.Text}");

        #endregion

        Console.Read();

	}
}
