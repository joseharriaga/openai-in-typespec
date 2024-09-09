﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
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
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    internal AzureVectorStoreClient(
        ClientPipeline pipeline,
        Uri endpoint,
        AzureOpenAIClientOptions options)
            : base(pipeline, endpoint, options)
    {
        options ??= new();
        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    protected AzureVectorStoreClient()
    { }

    internal override CreateVectorStoreOperation CreateCreateVectorStoreOperation(ClientResult<VectorStore> result)
    {
        return new AzureCreateVectorStoreOperation(Pipeline, _endpoint, result, _apiVersion);
    }

    internal override AddFileToVectorStoreOperation CreateAddFileToVectorStoreOperation(ClientResult<VectorStoreFileAssociation> result)
    {
        return new AzureAddFileToVectorStoreOperation(Pipeline, _endpoint, result, _apiVersion);
    }

    internal override CreateBatchFileJobOperation CreateBatchFileJobOperation(ClientResult<VectorStoreBatchFileJob> result)
    {
        return new AzureCreateBatchFileJobOperation(Pipeline, _endpoint, result, _apiVersion);
    }

    internal override PipelineMessage CreateGetVectorStoreFileRequest(string vectorStoreId, string fileId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId, "files", fileId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateCreateVectorStoreRequest(BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateCreateVectorStoreFileBatchRequest(string vectorStoreId, BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId, "file_batches")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetVectorStoreFileBatchRequest(string vectorStoreId, string batchId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId, "file_batches", batchId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();


}
