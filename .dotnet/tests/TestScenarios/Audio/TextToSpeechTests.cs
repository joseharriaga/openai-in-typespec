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
        ClientResult<BinaryData> result = client.GenerateSpeechFromText("Hello, world! This is a test.", TextToSpeechVoice.Shimmer);
        BinaryData audio = result.Value;
        
        Assert.NotNull(audio);
    }

    [Test]
    [TestCase(null)]
    [TestCase(AudioDataFormat.Mp3)]
    [TestCase(AudioDataFormat.Aac)]
    [TestCase(AudioDataFormat.Opus)]
    [TestCase(AudioDataFormat.Flac)]
    public void OutputFormatWorks(AudioDataFormat? responseFormat)
    {
        AudioClient client = new("tts-1");
        TextToSpeechOptions options = responseFormat == null
            ? new()
            : new() { ResponseFormat = responseFormat };

        ClientResult<BinaryData> result = client.GenerateSpeechFromText("Hello, world!", TextToSpeechVoice.Alloy, options);
        BinaryData audio = result.Value;

        Assert.NotNull(audio);
    }
}
