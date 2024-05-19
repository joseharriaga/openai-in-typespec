// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Identity;
using OpenAI.Chat;
using System.ClientModel;

namespace Azure.AI.OpenAI.Tests;

public class ChatTests : TestBase<ChatClient>
{
    [Test]
    public void HelloWorldChatWithTopLevelClient()
    {
        ChatClient chatClient = GetTestClient();
        ClientResult<ChatCompletion> chatCompletion = chatClient.CompleteChat("hello, world!");
        Assert.That(chatCompletion?.Value, Is.Not.Null);
    }

    [Test]
    public void BadKeyGivesHelpfulError()
    {
        string endpointFromEnvironment = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT");
        Uri endpoint = new(endpointFromEnvironment);
        string mockKey = "not-a-valid-key-and-should-still-be-sanitized";
        ApiKeyCredential credential = new(mockKey);
        AzureOpenAIClient topLevelClient = new(endpoint, credential);
        ChatClient chatClient = topLevelClient.GetChatClient("gpt-35-turbo");
        Exception thrownException = null;
        try
        {
            _ = chatClient.CompleteChat("oops, this won't work with that key!");
        }
        catch (Exception ex)
        {
            thrownException = ex;
        }
        Assert.That(thrownException, Is.InstanceOf<ClientResultException>());
        Assert.That(thrownException.Message, Does.Contain("invalid subscription key"));
        Assert.That(thrownException.Message, Does.Not.Contain(mockKey));
    }

    [Test]
    public void DefaultAzureCredentialWorks()
    {
        ChatClient chatClient = GetTestClient<TokenCredential>();
        ChatCompletion chatCompletion = chatClient.CompleteChat("Hello, world!");
        Assert.That(chatCompletion?.Content, Is.Not.Null);
        chatCompletion = chatClient.CompleteChat("Hello again, world!");
        Assert.That(chatCompletion?.Content, Is.Not.Null);
    }
}