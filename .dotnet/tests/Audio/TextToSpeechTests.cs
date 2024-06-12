using NUnit.Framework;
using OpenAI.Audio;
using OpenAI.Tests.Utility;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Audio;

[TestFixture(true)]
[TestFixture(false)]
public partial class TextToSpeechTests : SyncAsyncTestBase
{
    public TextToSpeechTests(bool isAsync)
        : base(isAsync)
    {
    }

    [Test]
    public async Task BasicTextToSpeechWorks()
    {
        AudioClient client = new("tts-1");

        BinaryData audio = IsAsync
            ? await client.GenerateSpeechFromTextAsync("Hello, world! This is a test.", GeneratedSpeechVoice.Shimmer)
            : client.GenerateSpeechFromText("Hello, world! This is a test.", GeneratedSpeechVoice.Shimmer);

        Assert.That(audio, Is.Not.Null);
        ValidateGeneratedAudio(audio, "hello");
    }

    [Test]
    [TestCase(null)]
    [TestCase(GeneratedSpeechFormat.Mp3)]
    [TestCase(GeneratedSpeechFormat.Opus)]
    [TestCase(GeneratedSpeechFormat.Aac)]
    [TestCase(GeneratedSpeechFormat.Flac)]
    [TestCase(GeneratedSpeechFormat.Wav)]
    [TestCase(GeneratedSpeechFormat.Pcm)]
    public async Task OutputFormatWorks(GeneratedSpeechFormat? responseFormat)
    {
        AudioClient client = new("tts-1");

        SpeechGenerationOptions options = responseFormat == null
            ? new()
            : new() { ResponseFormat = responseFormat };

        BinaryData audio = IsAsync
            ? await client.GenerateSpeechFromTextAsync("Hello, world!", GeneratedSpeechVoice.Alloy, options)
            : client.GenerateSpeechFromText("Hello, world!", GeneratedSpeechVoice.Alloy, options);

        Assert.That(audio, Is.Not.Null);
    }

    [Test]
    public async Task StreamingTextToSpeechWorks()
    {
        AudioClient client = new("tts-1");

        const string input = """
            Hello, world! This is a brief test to see how well chunked audio streaming works.
            """;
        const GeneratedSpeechVoice voice = GeneratedSpeechVoice.Echo;

        List<TimeSpan> chunkTimes = [];
        using MemoryStream chunkedOutputStream = new();

        Stopwatch stopwatch = Stopwatch.StartNew();

        if (IsAsync)
        {
            await foreach (BinaryData audioChunk in client.GenerateSpeechFromTextStreamingAsync(input, voice))
            {
                chunkedOutputStream.Write(audioChunk.ToArray());
                chunkTimes.Add(stopwatch.Elapsed);
            }
        }
        else
        {
            foreach (BinaryData audioChunk in client.GenerateSpeechFromTextStreaming(input, voice))
            {
                chunkedOutputStream.Write(audioChunk.ToArray());
                chunkTimes.Add(stopwatch.Elapsed);
            }
        }

        Assert.That(chunkTimes, Has.Count.GreaterThan(10));
        Assert.That(chunkTimes[^1] - chunkTimes[0], Is.GreaterThan(TimeSpan.FromMilliseconds(200)));

        chunkedOutputStream.Position = 0;

        AudioClient validationClient = new("whisper-1");

        AudioTranscription transcription = validationClient.TranscribeAudio(chunkedOutputStream, "chunked_audio.mp3");
        Assert.That(transcription.Text?.ToLower(), Does.Contain("hello"));
        Assert.That(transcription.Text?.ToLower(), Does.Contain("chunked audio"));
    }

    private void ValidateGeneratedAudio(BinaryData audio, string expectedSubstring)
    {
        AudioClient client = GetTestClient<AudioClient>(TestScenario.Transcription);
        AudioTranscription transcription = client.TranscribeAudio(audio.ToStream(), "hello_world.wav");

        Assert.That(transcription.Text.ToLowerInvariant(), Contains.Substring(expectedSubstring));
    }
}
