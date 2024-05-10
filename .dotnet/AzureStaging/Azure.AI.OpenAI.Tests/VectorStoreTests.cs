// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using OpenAI.VectorStores;

namespace Azure.AI.OpenAI.Tests;

public class VectorStoreTests
{
    [Test]
    public void CanCreateClient()
    {
        AzureOpenAIClient client = new();
        VectorStoreClient vectorStoreClient = client.GetVectorStoreClient();
        Assert.That(vectorStoreClient, Is.Not.Null);
    }
}