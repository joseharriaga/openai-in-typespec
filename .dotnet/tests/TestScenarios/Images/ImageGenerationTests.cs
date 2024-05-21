using NUnit.Framework;
using OpenAI.Images;
using OpenAI.Tests.Utility;
using System;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Images;

[TestFixture(true)]
[TestFixture(false)]
public partial class ImageGenerationTests : SyncAsyncTestBase
{
    public ImageGenerationTests(bool isAsync)
    : base(isAsync)
    {
    }

    [Test]
    public async Task BasicGenerationWorks()
    {
        ImageClient client = new("dall-e-3");

        string prompt = "An isolated stop sign.";

        GeneratedImage image = IsAsync
            ? await client.GenerateImageAsync(prompt)
            : client.GenerateImage(prompt);
        Assert.That(image.ImageUri, Is.Not.Null);
        Assert.That(image.ImageBytes, Is.Null);

        Console.WriteLine(image.ImageUri.AbsoluteUri);
    }

    [Test]
    public async Task GenerationWithOptionsWorks()
    {
        ImageClient client = GetTestClient();

        string prompt = "An isolated stop sign.";

        ImageGenerationOptions options = new()
        {
            Quality = GeneratedImageQuality.Standard,
            Style = GeneratedImageStyle.Natural,
        };

        GeneratedImage image = IsAsync
            ? await client.GenerateImageAsync(prompt, options)
            : client.GenerateImage(prompt, options);
        Assert.That(image.ImageUri, Is.Not.Null);
    }

    private static ImageClient GetTestClient() => GetTestClient<ImageClient>(TestScenario.Images);
}
