﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Embeddings;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Embeddings;

/// <summary>
/// The scenario client used for embedding operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
internal partial class AzureEmbeddingClient : EmbeddingClient
{
    private readonly AzureOpenAIPipelineMessageBuilder _messageBuilder;

    internal AzureEmbeddingClient(ClientPipeline pipeline, string deploymentName, Uri endpoint, AzureOpenAIClientOptions options)
        : base(pipeline, model: deploymentName, new OpenAIClientOptions() { Endpoint = endpoint })
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
        Argument.AssertNotNull(endpoint, nameof(endpoint));

        _messageBuilder = new(pipeline, endpoint, options?.Version ?? ServiceVersion.Default, deploymentName);
    }

    protected AzureEmbeddingClient()
    { }
}
