// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Staging;
using Azure.AI.OpenAI.Staging.Chat;
using OpenAI.Chat;
using System.ClientModel;

namespace Azure.AI.OpenAI.Tests.Staging;

public class ChatTests
{
    [Test]
    public void HelloWorldChatWithTopLevelClient()
    {
        AzureOpenAIClient client = new();
        ChatClient chatClient = client.GetChatClient("gpt-35-turbo");
        ClientResult<ChatCompletion> chatCompletion = chatClient.CompleteChat("hello, world!");
        Assert.That(chatCompletion?.Value, Is.Not.Null);
    }

    [Test]
    public void HelloWorldChatWithTopLevelClientNoImplicitEnvironment()
    {
        string endpointFromEnvironment = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT");
        string keyFromEnvironment = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY");

        AzureOpenAIClient topLevelClient = new(new Uri(endpointFromEnvironment), new ApiKeyCredential(keyFromEnvironment));
        ChatClient chatClient = topLevelClient.GetChatClient("gpt-35-turbo");
        ChatCompletion chatCompletion = chatClient.CompleteChat("hello, world!");
        Assert.That(chatCompletion?.Content, Is.Not.Null);
    }
}