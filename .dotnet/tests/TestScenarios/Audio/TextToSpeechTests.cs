using NUnit.Framework;
using OpenAI.Audio;
using System;
using System.ClientModel;

namespace OpenAI.Tests.Audio;

public partial class TextToSpeechTests
{
    [Test]
    public void BasicTextToSpeechWorks()
    {
        AudioClient client = new("tts-1");
        ClientResult<BinaryData> result = client.GenerateSpeechFromText("Hello, world! This is a test.", GeneratedSpeechVoice.Shimmer);
        BinaryData audio = result.Value;
        
        Assert.NotNull(audio);
    }

    [Test]
    [TestCase(null)]
    [TestCase(GeneratedSpeechFormat.Mp3)]
    [TestCase(GeneratedSpeechFormat.Aac)]
    [TestCase(GeneratedSpeechFormat.Opus)]
    [TestCase(GeneratedSpeechFormat.Flac)]
    public void OutputFormatWorks(GeneratedSpeechFormat? responseFormat)
    {
        AudioClient client = new("tts-1");
        SpeechGenerationOptions options = responseFormat == null
            ? new()
            : new() { ResponseFormat = responseFormat };

        ClientResult<BinaryData> result = client.GenerateSpeechFromText("Hello, world!", GeneratedSpeechVoice.Alloy, options);
        BinaryData audio = result.Value;

        Assert.NotNull(audio);
    }
}
