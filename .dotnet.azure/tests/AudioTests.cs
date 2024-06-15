// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Identity;
using OpenAI.Audio;
using OpenAI.Chat;
using System.ClientModel;

namespace Azure.AI.OpenAI.Tests;

public class AudioTests : TestBase<AudioClient>
{
    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<AudioClient>());

    [Test]
    public void TranscriptionWorks()
    {
        AudioClient audioClient = GetTestClient("whisper");
        AudioTranscription transcription = audioClient.TranscribeAudio(
            Path.Combine("Assets", "hello_world.m4a"));
        Assert.That(transcription?.Text, Is.Not.Null.Or.Empty);
    }

    [Test]
    public void TranslationWorks()
    {
        AudioClient audioClient = GetTestClient("whisper");
        AudioTranslation translation = audioClient.TranslateAudio(
            Path.Combine("Assets", "french.wav"));
        Assert.That(translation?.Text, Is.Not.Null.Or.Empty);
    }

    [Test]
    public void TextToSpeechWorks()
    {
        AudioClient audioClient = GetTestClient("tts");
        BinaryData ttsData = audioClient.GenerateSpeechFromText(
            "hello, world!",
            GeneratedSpeechVoice.Alloy);
        Assert.That(ttsData, Is.Not.Null);
    }
}