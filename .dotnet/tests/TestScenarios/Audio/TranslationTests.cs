﻿using NUnit.Framework;
using OpenAI.Audio;
using System.ClientModel;
using System.IO;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Audio;

public partial class TranslationTests
{
    [Test]
    public void BasicTranslationWorks()
    {
        AudioClient client = GetTestClient();
        using FileStream inputStream = File.OpenRead(Path.Combine("Assets", "french.wav"));
        ClientResult<AudioTranslation> translationResult = client.TranslateAudio(inputStream, "french.wav");
        Assert.That(translationResult.Value, Is.Not.Null);
        // Assert.That(translationResult.Value.Text.ToLowerInvariant(), Contains.Substring("hello"));
    }

    private static AudioClient GetTestClient() => GetTestClient<AudioClient>(TestScenario.Transcription);
}
