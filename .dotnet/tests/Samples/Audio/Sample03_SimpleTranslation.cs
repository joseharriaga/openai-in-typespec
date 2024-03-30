using NUnit.Framework;
using OpenAI.Audio;
using System;
using System.IO;

namespace OpenAI.Samples
{
    public partial class AudioSamples
    {
        [Test]
        [Ignore("Compilation validation only")]
        public void Sample03_SimpleTranslation()
        {
            AudioClient client = new("whisper-1", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            string filePath = Path.Combine("Assets", "french.wav");
            using FileStream fileStream = File.OpenRead(filePath);

            AudioTranslation translation = client.TranslateAudio(fileStream);

            Console.WriteLine($"{translation.Text}");
        }
    }
}
