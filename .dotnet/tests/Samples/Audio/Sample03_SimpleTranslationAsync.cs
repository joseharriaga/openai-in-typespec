using NUnit.Framework;
using OpenAI.Audio;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OpenAI.Samples
{
    public partial class AudioSamples
    {
        [Test]
        [Ignore("Compilation validation only")]
        public async Task Sample03_SimpleTranslationAsync()
        {
            AudioClient client = new("whisper-1", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            string filePath = Path.Combine("Assets", "french.wav");
            using FileStream fileStream = File.OpenRead(filePath);

            AudioTranslation translation = await client.TranslateAudioAsync(fileStream);

            Console.WriteLine($"{translation.Text}");
        }
    }
}
