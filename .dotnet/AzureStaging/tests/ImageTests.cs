// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.AI.OpenAI.Images;
using Azure.Core;
using OpenAI.Images;
using System.ClientModel;

namespace Azure.AI.OpenAI.Tests;

public class ImageTests : TestBase<ImageClient>
{
    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient<TokenCredential>(), Is.InstanceOf<ImageClient>());

    [Test]
    public void CanCreateSimpleImage()
    {
        ImageClient client = GetTestClient();
        GeneratedImage image = client.GenerateImage("a small watermelon", new()
        {
            Quality = GeneratedImageQuality.Standard,
            Size = GeneratedImageSize.W1024xH1024,
            User = "test_user",
            ResponseFormat = GeneratedImageFormat.Bytes,
        });
        Assert.That(image, Is.Not.Null);
        Assert.That(image.ImageBytes, Is.Not.Null);
    }

    [Test]
    public void CanGetContentFilterResults()
    {
        ImageClient client = GetTestClient();
        ClientResult<GeneratedImage> imageResult = client.GenerateImage("a small watermelon", new()
        {
            Quality = GeneratedImageQuality.Standard,
            Size = GeneratedImageSize.W1024xH1024,
            User = "test_user",
            ResponseFormat = GeneratedImageFormat.Uri,
        });
        GeneratedImage image = imageResult.Value;
        Assert.That(image, Is.Not.Null);
        Assert.That(image.ImageUri, Is.Not.Null);
        Console.WriteLine($"RESPONSE--\n{imageResult.GetRawResponse().Content}");
#pragma warning disable OPENAI002
        ImagePromptContentFilterResult promptResults = image.GetPromptContentFilterResults();
        ImageResponseContentFilterResult responseResults = image.GetResponseContentFilterResults();
        Assert.That(promptResults?.Sexual?.Severity, Is.EqualTo("safe"));
        Assert.That(responseResults?.Sexual?.Severity, Is.EqualTo("safe"));
#pragma warning restore
    }
}