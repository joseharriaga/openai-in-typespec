﻿using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Chat;

public partial class ChatClientTests
{
    [Test]
    public void HelloWorldChat()
    {
        ChatClient client = GetTestClient<ChatClient>(TestScenario.Chat); // new("gpt-3.5-turbo");
        Assert.That(client, Is.InstanceOf<ChatClient>());
        ClientResult<ChatCompletion> result = client.CompleteChat("Hello, world!");
        Assert.That(result, Is.InstanceOf<ClientResult<ChatCompletion>>());
        Assert.That(result.Value.Content?.ContentKind, Is.EqualTo(ChatMessageContentKind.Text));
        Assert.That(result.Value.Content.ToText().Length, Is.GreaterThan(0));
    }

    [Test]
    public void HelloWorldWithTopLevelClient()
    {
        OpenAIClient client = new(credential: new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
        ChatClient chatClient = client.GetChatClient("gpt-3.5-turbo");
        ClientResult<ChatCompletion> result = chatClient.CompleteChat("Hello, world!");
        Assert.That(result, Is.InstanceOf<ClientResult<ChatCompletion>>());
        Assert.That(result.Value.Content.ToString().Length, Is.GreaterThan(0));
    }
    [Test]
    public void MultiMessageChat()
    {
        ChatClient client = new("gpt-3.5-turbo");
        ClientResult<ChatCompletion> result = client.CompleteChat(
        [
            new ChatRequestSystemMessage("You are a helpful assistant. You always talk like a pirate."),
            new ChatRequestUserMessage("Hello, assistant! Can you help me train my parrot?"),
        ]);
        Assert.That(new string[] { "aye", "arr", "hearty" }.Any(pirateWord => result.Value.Content.ToString().ToLowerInvariant().Contains(pirateWord)));
    }

    [Test]
    public async Task StreamingChat()
    {
        ChatClient client = GetTestClient();

        TimeSpan? firstTokenReceiptTime = null;
        TimeSpan? latestTokenReceiptTime = null;
        Stopwatch stopwatch = Stopwatch.StartNew();

        StreamingClientResult<StreamingChatUpdate> streamingResult
            = client.CompleteChatStreaming("What are the best pizza toppings? Give me a breakdown on the reasons.");
        Assert.That(streamingResult, Is.InstanceOf<StreamingClientResult<StreamingChatUpdate>>());
        int updateCount = 0;
        ChatTokenUsage usage = null;

        await foreach (StreamingChatUpdate chatUpdate in streamingResult)
        {
            firstTokenReceiptTime ??= stopwatch.Elapsed;
            latestTokenReceiptTime = stopwatch.Elapsed;
            usage ??= chatUpdate.TokenUsage;
            updateCount++;
        }
        Assert.That(updateCount, Is.GreaterThan(1));
        Assert.That(latestTokenReceiptTime - firstTokenReceiptTime > TimeSpan.FromMilliseconds(500));
        Assert.That(usage, Is.Not.Null);
        Assert.That(usage?.InputTokens, Is.GreaterThan(0));
        Assert.That(usage?.OutputTokens, Is.GreaterThan(0));
        Assert.That(usage.InputTokens + usage.OutputTokens, Is.EqualTo(usage.TotalTokens));
    }

    [Test]
    public void TwoTurnChat()
    {
        ChatClient client = GetTestClient();

        List<ChatRequestMessage> messages =
        [
            ChatRequestMessage.CreateUserMessage("What are ten of the most common colors, including the brightest and darkest?"),
        ];
        ClientResult<ChatCompletion> firstResult = client.CompleteChat(messages);
        Assert.That(firstResult?.Value, Is.Not.Null);
        Assert.That(firstResult.Value.Content.ToString().ToLowerInvariant(), Contains.Substring("white"));
        Assert.That(firstResult.Value.Content.ToString().ToLowerInvariant(), Contains.Substring("black"));
        messages.Add(new ChatRequestAssistantMessage(firstResult.Value));
        messages.Add(new ChatRequestUserMessage("Which of those are considered brightest, aligning with hexadecimal rgb notation?"));
        ClientResult<ChatCompletion> secondResult = client.CompleteChat(messages);
        Assert.That(secondResult?.Value, Is.Not.Null);
        Assert.That(secondResult.Value.Content.ToString().ToLowerInvariant(), Contains.Substring("white"));
        Assert.That(secondResult.Value.Content.ToString().ToLowerInvariant(), Does.Not.Contains("black"));
    }

    [Test]
    public void AuthFailure()
    {
        ChatClient client = new("gpt-3.5-turbo", new ApiKeyCredential("not-a-real-key"));
        Exception caughtException = null;
        try
        {
            _ = client.CompleteChat("Uh oh, this isn't going to work with that key");
        }
        catch (Exception ex)
        {
            caughtException = ex;
        }
        var clientResultException = caughtException as ClientResultException;
        Assert.That(clientResultException, Is.Not.Null);
        Assert.That(clientResultException.Status, Is.EqualTo((int)HttpStatusCode.Unauthorized));
    }

    private static ChatClient GetTestClient(string overrideModel = null) => GetTestClient<ChatClient>(TestScenario.Chat, overrideModel);
}
