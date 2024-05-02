// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Staging;
using Azure.AI.OpenAI.Staging.Chat;
using OpenAI.Chat;
using System.ClientModel;

namespace Azure.AI.OpenAI.Tests.Staging;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void HelloWorldChat()
    {
        AzureChatClient client = new("gpt-35-turbo");
        ClientResult<ChatCompletion> chatCompletion = client.CompleteChat("hello, world!");
        Assert.That(chatCompletion?.Value, Is.Not.Null);
    }

    [Test]
    public void HelloWorldChatWithTopLevelClient()
    {
        AzureOpenAIClient client = new();
        ChatClient chatClient = client.GetChatClient("gpt-35-turbo");
        ClientResult<ChatCompletion> chatCompletion = chatClient.CompleteChat("hello, world!");
        Assert.That(chatCompletion?.Value, Is.Not.Null);
    }

}