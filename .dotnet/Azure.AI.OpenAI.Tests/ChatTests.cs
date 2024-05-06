// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI;
using Azure.AI.OpenAI.Chat;
using OpenAI.Chat;
using System.ClientModel;

namespace Azure.AI.OpenAI.Tests;

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
        Assert.That(thrownException.Message, Does.Contain("API key"));
        Assert.That(thrownException.Message, Does.Not.Contain(mockKey));
    }
}