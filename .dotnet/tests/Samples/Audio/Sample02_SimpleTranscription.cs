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
        public void Sample02_SimpleTranscription()
        {
            AudioClient client = new("whisper-1", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            string filePath = Path.Combine("Assets", "speed-talking.wav");
            using FileStream fileStream = File.OpenRead(filePath);

            AudioTranscription transcription = client.TranscribeAudio(fileStream);

            Console.WriteLine($"{transcription.Text}");
        }
    }
}
