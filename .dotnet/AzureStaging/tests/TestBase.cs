// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Identity;
using OpenAI.Assistants;
using OpenAI.Audio;
using OpenAI.Batch;
using OpenAI.Chat;
using OpenAI.Embeddings;
using OpenAI.Files;
using OpenAI.FineTuning;
using OpenAI.Images;
using OpenAI.Tests;
using OpenAI.VectorStores;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Net;
using System.Security.Cryptography;
using System.Text.Json;

namespace Azure.AI.OpenAI.Tests;

public class TestBase<TClient>
{
    internal TestConfig TestConfig { get; }

    protected TestBase()
    {
        TestConfig = new TestConfig();
    }

    internal AzureOpenAIClient GetTestTopLevelClient(TestClientOptions options = null)
        => GetExplicitTestTopLevelClient<TClient, ApiKeyCredential>(options);
    internal AzureOpenAIClient GetTestTopLevelClient<TCredential>(TestClientOptions options = null)
        => GetExplicitTestTopLevelClient<TClient, TCredential>(options);
    private AzureOpenAIClient GetExplicitTestTopLevelClient<TForExplicitClient,TCredential>(TestClientOptions options = null, bool honorParentClient = true)
    {
        // If the top-level client is being requested on behalf of another client (e.g. a file client for resources to
        // use with an assistant client), then we'll ensure we match the configuration of the dependent client to its
        // progenitor.
        if (honorParentClient && options?.ParentClientObject is not null)
        {
            return options.ParentClientObject switch
            {
#pragma warning disable OPENAI001
                AssistantClient => GetExplicitTestTopLevelClient<AssistantClient, TCredential>(options, false),
#pragma warning restore
                BatchClient => GetExplicitTestTopLevelClient<BatchClient, TCredential>(options, false),
                ChatClient => GetExplicitTestTopLevelClient<ChatClient, TCredential>(options, false),
                EmbeddingClient => GetExplicitTestTopLevelClient<EmbeddingClient, TCredential>(options, false),
                FileClient => GetExplicitTestTopLevelClient<FileClient, TCredential>(options, false),
                FineTuningClient => GetExplicitTestTopLevelClient<FineTuningClient, TCredential>(options, false),
                ImageClient => GetExplicitTestTopLevelClient<ImageClient, TCredential>(options, false),
#pragma warning disable OPENAI001
                VectorStoreClient => GetExplicitTestTopLevelClient<VectorStoreClient, TCredential>(options, false),
#pragma warning restore
                _ => throw new NotImplementedException()
            };
        }

        Uri endpoint = TestConfig.GetEndpointFor<TForExplicitClient>();

        ApiKeyCredential apiKeyCredential = typeof(TCredential) == typeof(ApiKeyCredential)
            ? TestConfig.GetApiKeyFromEnvironmentFor<TForExplicitClient>()
            : null;
        TokenCredential tokenCredential = typeof(TCredential) == typeof(TokenCredential)
            ? new DefaultAzureCredential()
            : null;

        options ??= new();
        Action<PipelineRequest> requestAction = options.ShouldOutputRequests ? DumpRequest : null;
        Action<PipelineResponse> responseAction = options.ShouldOutputResponses ? DumpResponse : null;
        options.AddPolicy(new TestPipelinePolicy(requestAction, responseAction), PipelinePosition.PerCall);

        AzureOpenAIClient client =
            typeof(TCredential) == typeof(ApiKeyCredential)
                ? new(endpoint, apiKeyCredential, options)
            : (typeof(TCredential) == typeof(TokenCredential))
                ? new(endpoint, tokenCredential, options)
            : throw new NotImplementedException();

        return client;
    }

    internal TClient GetTestClient(string overrideDeploymentName, TestClientOptions options = null)
        => GetExplicitTestClient<TClient, ApiKeyCredential>(overrideDeploymentName, options);
    internal TClient GetTestClient(TestClientOptions options = null)
        => GetExplicitTestClient<TClient, ApiKeyCredential>(null, options);
    internal TClient GetTestClient<TCredential>(TestClientOptions options = null)
        => GetExplicitTestClient<TClient, TCredential>(null, options);
    internal TChildClient GetChildTestClient<TChildClient>(TClient parentClient)
        => GetExplicitTestClient<TChildClient, ApiKeyCredential>(null, new() { ParentClientObject = parentClient });
    private TExplicitClient GetExplicitTestClient<TExplicitClient,TCredential>(string overrideDeploymentName = null, TestClientOptions options = null)
    {
        AzureOpenAIClient topLevelClient = GetExplicitTestTopLevelClient<TExplicitClient,TCredential>(options);
        string GetDeployment() => overrideDeploymentName ?? TestConfig.GetDeploymentNameFor<TExplicitClient>();
        object clientObject = null;
        switch (typeof(TExplicitClient).Name)
        {
#pragma warning disable OPENAI001
            case nameof(AssistantClient):
                clientObject = topLevelClient.GetAssistantClient();
                break;
#pragma warning restore
            case nameof(AudioClient):
                clientObject = topLevelClient.GetAudioClient(GetDeployment());
                break;
            case nameof(BatchClient):
                clientObject = topLevelClient.GetBatchClient(GetDeployment());
                break;
            case nameof(ChatClient):
                clientObject = topLevelClient.GetChatClient(GetDeployment());
                break;
            case nameof(EmbeddingClient):
                clientObject = topLevelClient.GetEmbeddingClient(GetDeployment());
                break;
            case nameof(FileClient):
                clientObject = topLevelClient.GetFileClient();
                break;
            case nameof(FineTuningClient):
                clientObject = topLevelClient.GetFineTuningClient();
                break;
            case nameof(ImageClient):
                clientObject = topLevelClient.GetImageClient(GetDeployment());
                break;
#pragma warning disable OPENAI001
            case nameof(VectorStoreClient):
                clientObject = topLevelClient.GetVectorStoreClient();
                break;
#pragma warning restore
            default: throw new NotImplementedException($"Test client helpers not yet implemented for {typeof(TExplicitClient)}");
        };
        return (TExplicitClient)clientObject;
    }

    private static void DumpRequest(PipelineRequest request)
    {
        Console.WriteLine($"--- New request ---");
        IEnumerable<string> headerPairs = request.Headers?
            .Select(header => $"{header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}");
        string headers = string.Join(',', headerPairs);
        Console.WriteLine($"Headers: {headers}");
        Console.WriteLine($"{request.Method} URI: {request?.Uri}");
        if (request.Content is not null)
        {
            using MemoryStream stream = new();
            request.Content.WriteTo(stream, default);
            stream.Position = 0;
            using StreamReader reader = new(stream);
            Console.WriteLine(reader.ReadToEnd());
        }
    }

    private static void DumpResponse(PipelineResponse response)
    {
        Console.WriteLine($"--- Response --- <dump not yet implemented>");
    }

    protected void ValidateById<T>(string id)
    {
        Assert.That(id, Is.Not.Null.Or.Empty);
        switch (typeof(T).Name)
        {
            case nameof(Assistant): _assistantIdsToDelete.Add(id); break;
            case nameof(AssistantThread): _threadIdsToDelete.Add(id); break;
            case nameof(OpenAIFileInfo): _fileIdsToDelete.Add(id); break;
            case nameof(ThreadRun): break;
            case nameof(VectorStore): _vectorStoreIdsToDelete.Add(id); break;
            default: throw new NotImplementedException();
        }
    }

    protected void ValidateById<T>(string id, string parentId)
    {
        Assert.That(id, Is.Not.Null.Or.Empty);
        Assert.That(parentId, Is.Not.Null.Or.Empty);
        switch (typeof(T).Name)
        {
            case nameof(ThreadMessage):
                _threadIdsWithMessageIdsToDelete.Add((parentId, id));
                break;
            default:
                throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Performs basic, invariant validation of a target that was just instantiated from its corresponding origination
    /// mechanism. If applicable, the instance is recorded into the test run for cleanup of persistent resources.
    /// </summary>
    /// <typeparam name="T"> Instance type being validated. </typeparam>
    /// <param name="target"> The instance to validate. </param>
    /// <exception cref="NotImplementedException"> The provided instance type isn't supported. </exception>
    protected void Validate<T>(T target)
    {
        if (target is ThreadMessage message)
        {
            ValidateById<ThreadMessage>(message.Id, message.ThreadId);
        }
        else
        {
            ValidateById<T>(target switch
            {
                Assistant assistant => assistant.Id,
                AssistantThread thread => thread.Id,
                OpenAIFileInfo file => file.Id,
                ThreadRun run => run.Id,
                VectorStore store => store.Id,
                _ => throw new NotImplementedException(),
            });
        }
    }

    [TearDown]
    protected void Cleanup()
    {
        AzureOpenAIClient topLevelCleanupClient = GetTestTopLevelClient(new()
        {
            ShouldOutputRequests = false,
            ShouldOutputResponses = false,
        });
#pragma warning disable OPENAI001
        AssistantClient client = topLevelCleanupClient.GetAssistantClient();
        VectorStoreClient vectorStoreClient = topLevelCleanupClient.GetVectorStoreClient();
#pragma warning restore
        FileClient fileClient = topLevelCleanupClient.GetFileClient();
        RequestOptions requestOptions = new() { ErrorOptions = ClientErrorBehaviors.NoThrow, };
        foreach ((string threadId, string messageId) in _threadIdsWithMessageIdsToDelete)
        {
            Console.WriteLine($"Cleanup: {messageId} -> {client.DeleteMessage(threadId, messageId, requestOptions)?.GetRawResponse().Status}");
        }
        foreach (string assistantId in _assistantIdsToDelete)
        {
            Console.WriteLine($"Cleanup: {assistantId} -> {client.DeleteAssistant(assistantId, requestOptions)?.GetRawResponse().Status}");
        }
        foreach (string threadId in _threadIdsToDelete)
        {
            Console.WriteLine($"Cleanup: {threadId} -> {client.DeleteThread(threadId, requestOptions)?.GetRawResponse().Status}");
        }
        foreach (string vectorStoreId in _vectorStoreIdsToDelete)
        {
            Console.WriteLine($"Cleanup: {vectorStoreId} => {vectorStoreClient.DeleteVectorStore(vectorStoreId, requestOptions)?.GetRawResponse().Status}");
        }
        foreach (string fileId in _fileIdsToDelete)
        {
            Console.WriteLine($"Cleanup: {fileId} -> {fileClient.DeleteFile(fileId, requestOptions)?.GetRawResponse().Status}");
        }
        _threadIdsWithMessageIdsToDelete.Clear();
        _assistantIdsToDelete.Clear();
        _threadIdsToDelete.Clear();
        _vectorStoreIdsToDelete.Clear();
        _fileIdsToDelete.Clear();
    }

    private readonly List<string> _assistantIdsToDelete = [];
    private readonly List<string> _threadIdsToDelete = [];
    private readonly List<(string, string)> _threadIdsWithMessageIdsToDelete = [];
    private readonly List<string> _fileIdsToDelete = [];
    private readonly List<string> _vectorStoreIdsToDelete = [];
}

internal class TestClientOptions : AzureOpenAIClientOptions
{
    public bool ShouldOutputRequests { get; init; } = true;
    public bool ShouldOutputResponses { get; init; } = true;
    public object ParentClientObject { get; init; }
}