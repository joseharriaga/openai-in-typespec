// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Staging.Audio;
using Azure.AI.OpenAI.Staging.Chat;
using Azure.AI.OpenAI.Staging.Embeddings;
using Azure.AI.OpenAI.Staging.FineTuning;
using Azure.AI.OpenAI.Staging.Images;
using Azure.Core;
using OpenAI;
using OpenAI.Assistants;
using OpenAI.Audio;
using OpenAI.Chat;
using OpenAI.Embeddings;
using OpenAI.Files;
using OpenAI.FineTuning;
using OpenAI.Images;
using OpenAI.ModelManagement;
using OpenAI.Moderations;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Staging;

public partial class AzureOpenAIClient : OpenAIClient
{
    protected static new internal RequestOptions DefaultRequestOptions => OpenAIClient.DefaultRequestOptions;
    protected static new internal PipelineMessageClassifier PipelineMessageClassifier200 => OpenAIClient.PipelineMessageClassifier200;

    public AzureOpenAIClient(ApiKeyCredential credential = null, AzureOpenAIClientOptions options = null)
        : base(CreatePipeline(credential, options), options)
    { }

    [Experimental("OPENAI001")]
    public override AssistantClient GetAssistantClient()
    {
        throw new NotImplementedException();
    }

    public override AudioClient GetAudioClient(string deploymentName)
    {
        return new AzureAudioClient(
            deploymentName,
            Pipeline,
            _cachedOptions?.Endpoint ?? GetConfiguredEndpoint(),
            _cachedOptions as AzureOpenAIClientOptions);
    }

    public override ChatClient GetChatClient(string deploymentName)
    {
        return new AzureChatClient(
            deploymentName,
            Pipeline,
            _cachedOptions?.Endpoint ?? GetConfiguredEndpoint(),
            _cachedOptions as AzureOpenAIClientOptions);
    }

    public override EmbeddingClient GetEmbeddingClient(string deploymentName)
    {
        return new AzureEmbeddingClient(
            deploymentName,
            Pipeline,
            _cachedOptions?.Endpoint ?? GetConfiguredEndpoint(),
            _cachedOptions as AzureOpenAIClientOptions);
    }

    public override FileClient GetFileClient()
    {
        throw new NotImplementedException();
    }

    public override FineTuningClient GetFineTuningClient()
    {
        return new AzureFineTuningClient(
            Pipeline,
            _cachedOptions?.Endpoint ?? GetConfiguredEndpoint(),
            _cachedOptions as AzureOpenAIClientOptions);
    }

    public override ImageClient GetImageClient(string deploymentName)
    {
        return new AzureImageClient(
            deploymentName,
            Pipeline,
            _cachedOptions?.Endpoint ?? GetConfiguredEndpoint(),
            _cachedOptions as AzureOpenAIClientOptions);
    }

    public override ModelManagementClient GetModelManagementClient()
    {
        throw new NotSupportedException($"Azure OpenAI does not support the OpenAI model management API. "
            + "Please use the Azure AI Services Account Management API to interact with Azure OpenAI model deployments.");
    }

    public override ModerationClient GetModerationClient()
    {
        throw new NotSupportedException($"Azure OpenAI does not support the OpenAI moderations API. "
            + "Please refer to the documentation on Microsoft's Responsible AI embedded content filters to learn "
            + "more about Azure OpenAI's content filter policies and response annotations.");
    }

    private static ClientPipeline CreatePipeline(PipelinePolicy authenticationPolicy, OpenAIClientOptions options = null)
        => ClientPipeline.Create(
            options ?? new(),
            perCallPolicies: [],
            perTryPolicies: [authenticationPolicy],
            beforeTransportPolicies: []);

    internal static ClientPipeline CreatePipeline(ApiKeyCredential credential, OpenAIClientOptions options = null)
    {
        credential ??= GetConfiguredKeyCredential();
        return CreatePipeline(ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(credential, "api-key"), options);
    }

    internal static ClientPipeline CreatePipeline(TokenCredential credential, OpenAIClientOptions options = null)
    {
        // To do: proper token conversion from Azure.Core to System.ClientModel
        throw new NotImplementedException();
    }

    internal static ApiKeyCredential GetConfiguredKeyCredential()
    {
        return new(Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY"));
    }
    internal static Uri GetConfiguredEndpoint(AzureOpenAIClientOptions options = null)
    {
        if (options?.Endpoint is not null)
        {
            return options.Endpoint;
        }

        string configuredEndpoint = null;
        // To do: IConfiguration
        configuredEndpoint ??= Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT");
        if (configuredEndpoint is null)
        {
            throw new ArgumentNullException(
                $"An Azure OpenAI resource endpoint URI must be provided via the client constructor, application "
                + "configuration, or AZURE_OPENAI_ENDPOINT environment variable.");
        }
        return new(configuredEndpoint);
    }
}