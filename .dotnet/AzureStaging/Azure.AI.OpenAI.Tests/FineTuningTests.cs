// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using OpenAI.FineTuning;

namespace Azure.AI.OpenAI.Tests;

public class FineTuningTests
{
    [Test]
    public void CanCreateClient()
    {
        AzureOpenAIClient client = new();
        FineTuningClient fineTuningClient = client.GetFineTuningClient();
        Assert.That(fineTuningClient, Is.Not.Null);
    }
}