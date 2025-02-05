using NUnit.Framework;

#region usings
using System;
using System.IO;

using OpenAI.Audio;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class AudioDocs
{
    [Test]
    public void CreateSpeech()
    {
        #region logic

        AudioClient client = new(
            model: "tts-1",
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        BinaryData speech = client.GenerateSpeech(
            text: "The quick brown fox jumped over the lazy dog.",
            voice: GeneratedSpeechVoice.Alloy
        );

        using FileStream stream = File.OpenWrite("speech.mp3");
        speech.ToStream().CopyTo(stream);

        #endregion
    }
}
