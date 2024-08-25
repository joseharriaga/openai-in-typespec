// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.VectorStores;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.VectorStores;

/// <summary>
/// The scenario client used for vector store operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
[Experimental("OPENAI001")]
internal partial class AzureVectorStoreClient : VectorStoreClient
{
    private readonly ServiceVersion _apiVersion;
    private readonly Uri _endpoint;
    private readonly AzureOpenAIPipelineMessageBuilder _messageBuilder;

    internal AzureVectorStoreClient(ClientPipeline pipeline, Uri endpoint, AzureOpenAIClientOptions options)
        : base(pipeline, new OpenAIClientOptions() { Endpoint = endpoint })
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        Argument.AssertNotNull(endpoint, nameof(endpoint));

        _endpoint = endpoint;
        _apiVersion = options?.Version ?? ServiceVersion.Default;
        _messageBuilder = new(pipeline, _endpoint, _apiVersion);
    }

    protected AzureVectorStoreClient()
    { }
}
