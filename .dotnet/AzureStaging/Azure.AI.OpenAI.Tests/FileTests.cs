// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using OpenAI.Files;

namespace Azure.AI.OpenAI.Tests;

public class FileTests
{
    [Test]
    public void CanCreateClient()
    {
        AzureOpenAIClient client = new();
        FileClient fileClient = client.GetFileClient();
        Assert.That(fileClient, Is.Not.Null);
    }
}