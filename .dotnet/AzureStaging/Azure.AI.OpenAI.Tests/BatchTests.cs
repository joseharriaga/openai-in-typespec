// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using OpenAI.Batch;

namespace Azure.AI.OpenAI.Tests;

public class BatchTests
{
    [Test]
    public void CanCreateClient()
    {
        AzureOpenAIClient client = new();
        BatchClient batchClient = client.GetBatchClient("gpt-4");
        Assert.That(batchClient, Is.Not.Null);
    }
}