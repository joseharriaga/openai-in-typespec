// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using OpenAI.Assistants;

namespace Azure.AI.OpenAI.Tests;

#pragma warning disable OPENAI001

public class AssistantTests
{
    [Test]
    public void CanCreateClient()
    {
        AzureOpenAIClient client = new();
        AssistantClient assistantClient = client.GetAssistantClient();
        Assert.That(assistantClient, Is.Not.Null);
    }
}