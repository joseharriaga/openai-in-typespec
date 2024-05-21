using NUnit.Framework;
using OpenAI.Audio;
using OpenAI.Tests.Utility;
using System.IO;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Audio;

[TestFixture(true)]
[TestFixture(false)]
public partial class TranslationTests : SyncAsyncTestBase
{
    public TranslationTests(bool isAsync)
    : base(isAsync)
    {
    }

    public enum AudioSourceKind
    {
        UsingStream,
        UsingFilePath,
    }

    [Test]
    [TestCase(AudioSourceKind.UsingStream)]
    [TestCase(AudioSourceKind.UsingStream)]
    [TestCase(AudioSourceKind.UsingFilePath)]
    [TestCase(AudioSourceKind.UsingFilePath)]
    public async Task TranslationWorks(AudioSourceKind audioSourceKind)
    {
        AudioClient client = GetTestClient();

        string filename = "french.wav";
        string path = Path.Combine("Assets", filename);
        AudioTranslation translation = null;

        if (audioSourceKind == AudioSourceKind.UsingStream)
        {
            using FileStream audio = File.OpenRead(path);

            translation = IsAsync
                ? await client.TranslateAudioAsync(audio, filename)
                : client.TranslateAudio(audio, filename);
        }
        else if (audioSourceKind == AudioSourceKind.UsingFilePath)
        {
            translation = IsAsync
                ? await client.TranslateAudioAsync(path)
                : client.TranslateAudio(path);
        }

        Assert.That(translation?.Text, Is.Not.Null);
    }

    private static AudioClient GetTestClient() => GetTestClient<AudioClient>(TestScenario.Transcription);
}
