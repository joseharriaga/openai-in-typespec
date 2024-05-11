// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Identity;
using OpenAI.Chat;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics;

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
        Assert.That(thrownException.Message, Does.Contain("invalid subscription key"));
        Assert.That(thrownException.Message, Does.Not.Contain(mockKey));
    }

    [Test]
    public void DefaultAzureCredentialWorks()
    {
        string endpointFromEnvironment = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT");
        Uri endpoint = new(endpointFromEnvironment);
        TokenCredential credential = new DefaultAzureCredential();
        AzureOpenAIClient client = new(endpoint, credential);
        ChatClient chatClient = client.GetChatClient("gpt-35-turbo");
        ChatCompletion chatCompletion = chatClient.CompleteChat("Hello, world!");
        Assert.That(chatCompletion?.Content, Is.Not.Null);
        chatCompletion = chatClient.CompleteChat("Hello again, world!");
        Assert.That(chatCompletion?.Content, Is.Not.Null);
    }

    [Test]
    public async Task StreamingChatAsync()
    {
        string endpointFromEnvironment = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT");
        string keyFromEnvironment = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY");

        AzureOpenAIClient topLevelClient = new(new Uri(endpointFromEnvironment), new ApiKeyCredential(keyFromEnvironment));
        ChatClient chatClient = topLevelClient.GetChatClient("gpt-35-turbo");

        TimeSpan? firstTokenReceiptTime = null;
        TimeSpan? latestTokenReceiptTime = null;
        Stopwatch stopwatch = Stopwatch.StartNew();

        AsyncResultCollection<StreamingChatUpdate> streamingResult
            = chatClient.CompleteChatStreamingAsync("What are the best pizza toppings? Give me a breakdown on the reasons.");
        Assert.That(streamingResult, Is.InstanceOf<AsyncResultCollection<StreamingChatUpdate>>());
        int updateCount = 0;
        ChatTokenUsage usage = null;

        await foreach (StreamingChatUpdate chatUpdate in streamingResult)
        {
            firstTokenReceiptTime ??= stopwatch.Elapsed;
            latestTokenReceiptTime = stopwatch.Elapsed;
            usage ??= chatUpdate.TokenUsage;
            Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds);
            updateCount++;
        }

        Assert.That(updateCount, Is.GreaterThan(1));
        Assert.That(latestTokenReceiptTime - firstTokenReceiptTime > TimeSpan.FromMilliseconds(500));
        Assert.That(usage, Is.Not.Null);
        Assert.That(usage?.InputTokens, Is.GreaterThan(0));
        Assert.That(usage?.OutputTokens, Is.GreaterThan(0));
        Assert.That(usage.InputTokens + usage.OutputTokens, Is.EqualTo(usage.TotalTokens));

        // Validate that network stream was disposed - this will show up as the
        // the raw response holding an empty content stream.
        PipelineResponse response = streamingResult.GetRawResponse();
        Assert.That(response.ContentStream.Length, Is.EqualTo(0));
    }

}