// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using OpenAI.Images;

namespace Azure.AI.OpenAI.Tests;

public class ImageTests
{
    [Test]
    public void CanCreateClient()
    {
        AzureOpenAIClient client = new();
        ImageClient imageClient = client.GetImageClient("dall-e-3");
        Assert.That(imageClient, Is.Not.Null);
    }
}