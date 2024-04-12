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
        public async Task Sample02_SimpleTranscriptionAsync()
        {
            AudioClient client = new("whisper-1", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            string filePath = Path.Combine("Assets", "speed-talking.wav");
            using FileStream fileStream = File.OpenRead(filePath);

            AudioTranscription transcription = await client.TranscribeAudioAsync(fileStream, "speed-talking.wav");

            Console.WriteLine($"{transcription.Text}");
        }
    }
}
