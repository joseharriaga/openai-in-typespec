// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using OpenAI.Embeddings;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Staging.Embeddings;

public partial class AzureEmbeddingClient : EmbeddingClient
{
    private readonly string _apiVersion;

    public AzureEmbeddingClient(
        string deploymentName,
        Uri endpoint = null,
        ApiKeyCredential credential = null,
        AzureOpenAIClientOptions options = null)
            : this(
                  deploymentName,
                  AzureOpenAIClient.CreatePipeline(credential),
                  endpoint ?? AzureOpenAIClient.GetConfiguredEndpoint(options),
                  options)
    {}

    public AzureEmbeddingClient(
        string deploymentName,
        Uri endpoint,
        TokenCredential credential,
        AzureOpenAIClientOptions options = null)
            : this(
                  deploymentName,
                  AzureOpenAIClient.CreatePipeline(credential),
                  endpoint ?? AzureOpenAIClient.GetConfiguredEndpoint(options),
                  options)
    {}

    protected internal AzureEmbeddingClient(
        string deploymentName,
        ClientPipeline pipeline,
        Uri endpoint,
        AzureOpenAIClientOptions options)
            : base(pipeline, model: deploymentName, credential: null, endpoint)
    {
        _apiVersion = options?.ApiVersion ?? AzureOpenAIClientOptions.AzureOpenAIServiceApiVersion.Latest;
    }

    protected AzureEmbeddingClient()
    { }
}
