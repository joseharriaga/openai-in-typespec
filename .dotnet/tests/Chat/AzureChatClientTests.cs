using Azure.AI.OpenAI;
using Azure.AI.OpenAI.Chat;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenAI.Chat;
using OpenAI.Tests.Utility;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Chat;

[TestFixture(true)]
[TestFixture(false)]
public partial class AzureChatClientTests : SyncAsyncTestBase
{
    public AzureChatClientTests(bool isAsync)
        : base(isAsync)
    {
    }

    public enum ClientCreationStrategy
    {
        TopLevelExplicit,
        TopLevelImplicit,
        ScenarioExplicit,
        ScenarioImplicit,
    }

    [Test]
    [TestCase(ClientCreationStrategy.TopLevelExplicit)]
    [TestCase(ClientCreationStrategy.TopLevelImplicit)]
    [TestCase(ClientCreationStrategy.ScenarioExplicit)]
    [TestCase(ClientCreationStrategy.ScenarioImplicit)]
    public async Task HelloWorld(ClientCreationStrategy creationStrategy)
    {
        ChatClient client = CreateAzureClient(creationStrategy);
        ChatCompletion completion = IsAsync
            ? await client.CompleteChatAsync(["Hello, assistant!"])
            : client.CompleteChat(["Hello, assistant!"]);
        Assert.That(completion?.Content?[0]?.Text, Is.Not.Null.And.Not.Empty);
    }

    private static ChatClient CreateAzureClient(ClientCreationStrategy creationStrategy)
    {
        string endpointFromEnvironment = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT");
        string apiKeyFromEnvironment = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY");
        string apiVersionFromEnvironment = Environment.GetEnvironmentVariable("OPENAI_API_VERSION");

        if (creationStrategy == ClientCreationStrategy.TopLevelExplicit)
        {
            AzureOpenAIClient azureOpenAIClient = new(
                new Uri(endpointFromEnvironment),
                apiVersionFromEnvironment,
                new ApiKeyCredential(apiKeyFromEnvironment));
            return azureOpenAIClient.GetChatClient("gpt-35-turbo");
        }
        else if (creationStrategy == ClientCreationStrategy.TopLevelImplicit)
        {
            AzureOpenAIClient azureOpenAIClient = new();
            return azureOpenAIClient.GetChatClient("gpt-35-turbo");
        }
        else if (creationStrategy == ClientCreationStrategy.ScenarioExplicit)
        {
            AzureChatClient chatClient = new(
                new Uri(endpointFromEnvironment),
                "gpt-35-turbo",
                apiVersionFromEnvironment,
                new ApiKeyCredential(apiKeyFromEnvironment));
            return chatClient;
        }
        else if (creationStrategy == ClientCreationStrategy.ScenarioImplicit)
        {
            AzureChatClient chatClient = new("gpt-35-turbo");
            return chatClient;
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}
