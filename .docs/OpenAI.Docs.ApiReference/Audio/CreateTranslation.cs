using NUnit.Framework;

#region usings
using System;

using OpenAI.Audio;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class AudioDocs
{
    [Test]
    public void CreateTranslation()
    {
        #region logic

        string audioFilePath = "audio.mp3";

        AudioClient client = new(
            model: "whisper-1",
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        AudioTranslation translation = client.TranslateAudio(audioFilePath);

        Console.WriteLine($"{translation.Text}");

        #endregion
    }
}
