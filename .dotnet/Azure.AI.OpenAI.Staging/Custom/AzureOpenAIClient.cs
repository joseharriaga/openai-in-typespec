// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Staging.Chat;
using Azure.AI.OpenAI.Staging.Embeddings;
using Azure.Core;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Embeddings;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Staging;

public partial class AzureOpenAIClient : OpenAIClient
{
    public AzureOpenAIClient(ApiKeyCredential credential = null, AzureOpenAIClientOptions options = null)
        : base(CreatePipeline(credential, options), options)
    { }

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