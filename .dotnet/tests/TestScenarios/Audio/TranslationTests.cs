using NUnit.Framework;
using OpenAI.Audio;
using System;
using System.ClientModel;
using System.IO;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Audio;

public partial class TranslationTests
{
    public enum AudioSourceKind
    {
        UsingStream,
        UsingFilePath,
    }

    public enum SyncOrAsync
    {
        Sync,
        Async,
    }

    [Test]
    [TestCase(AudioSourceKind.UsingStream, SyncOrAsync.Sync)]
    [TestCase(AudioSourceKind.UsingStream, SyncOrAsync.Async)]
    [TestCase(AudioSourceKind.UsingFilePath, SyncOrAsync.Sync)]
    [TestCase(AudioSourceKind.UsingFilePath, SyncOrAsync.Async)]
    public async Task TranslationWorks(AudioSourceKind audioSourceKind, SyncOrAsync syncOrAsync)
    {
        AudioClient client = GetTestClient();
        string filename = "french.wav";
        string path = Path.Combine("Assets", filename);
        AudioTranslation translation = null;
        if (audioSourceKind == AudioSourceKind.UsingStream)
        {
            using FileStream audio = File.OpenRead(path);
            translation = syncOrAsync switch
            {
                SyncOrAsync.Sync => client.TranslateAudio(audio, filename),
                SyncOrAsync.Async => await client.TranslateAudioAsync(audio, filename),
                _ => throw new ArgumentException(nameof(syncOrAsync)),
            };
        }
        else if (audioSourceKind == AudioSourceKind.UsingFilePath)
        {
            translation = syncOrAsync switch
            {
                SyncOrAsync.Sync => client.TranslateAudio(path),
                SyncOrAsync.Async => await client.TranslateAudioAsync(path),
                _ => throw new ArgumentException(nameof(syncOrAsync)),
            };
        }
        Assert.That(translation?.Text, Is.Not.Null);
    }

    private static AudioClient GetTestClient() => GetTestClient<AudioClient>(TestScenario.Transcription);
}
