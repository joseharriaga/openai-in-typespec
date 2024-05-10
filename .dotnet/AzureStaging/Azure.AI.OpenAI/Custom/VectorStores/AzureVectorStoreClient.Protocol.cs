// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI;
using OpenAI.VectorStores;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.VectorStores;

internal partial class AzureVectorStoreClient : VectorStoreClient
{
    public override async Task<ClientResult> GetVectorStoresAsync(int? limit, string order, string after, string before, RequestOptions options)
    {
        using PipelineMessage message = CreateGetVectorStoresRequest(limit, order, after, before, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult GetVectorStores(int? limit, string order, string after, string before, RequestOptions options)
    {
        using PipelineMessage message = CreateGetVectorStoresRequest(limit, order, after, before, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> CreateVectorStoreAsync(BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateVectorStoreRequest(content, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult CreateVectorStore(BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateVectorStoreRequest(content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> GetVectorStoreAsync(string vectorStoreId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        using PipelineMessage message = CreateGetVectorStoreRequest(vectorStoreId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult GetVectorStore(string vectorStoreId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        using PipelineMessage message = CreateGetVectorStoreRequest(vectorStoreId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> ModifyVectorStoreAsync(string vectorStoreId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateModifyVectorStoreRequest(vectorStoreId, content, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult ModifyVectorStore(string vectorStoreId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateModifyVectorStoreRequest(vectorStoreId, content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> DeleteVectorStoreAsync(string vectorStoreId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        using PipelineMessage message = CreateDeleteVectorStoreRequest(vectorStoreId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult DeleteVectorStore(string vectorStoreId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        using PipelineMessage message = CreateDeleteVectorStoreRequest(vectorStoreId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> GetVectorStoreFilesAsync(string vectorStoreId, int? limit, string order, string after, string before, string filter, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        using PipelineMessage message = CreateGetVectorStoreFilesRequest(vectorStoreId, limit, order, after, before, filter, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult GetVectorStoreFiles(string vectorStoreId, int? limit, string order, string after, string before, string filter, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        using PipelineMessage message = CreateGetVectorStoreFilesRequest(vectorStoreId, limit, order, after, before, filter, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> CreateVectorStoreFileAsync(string vectorStoreId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateVectorStoreFileRequest(vectorStoreId, content, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult CreateVectorStoreFile(string vectorStoreId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateVectorStoreFileRequest(vectorStoreId, content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> GetVectorStoreFileAsync(string vectorStoreId, string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateGetVectorStoreFileRequest(vectorStoreId, fileId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult GetVectorStoreFile(string vectorStoreId, string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateGetVectorStoreFileRequest(vectorStoreId, fileId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> DeleteVectorStoreFileAsync(string vectorStoreId, string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateDeleteVectorStoreFileRequest(vectorStoreId, fileId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult DeleteVectorStoreFile(string vectorStoreId, string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateDeleteVectorStoreFileRequest(vectorStoreId, fileId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> CreateVectorStoreFileBatchAsync(string vectorStoreId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateVectorStoreFileBatchRequest(vectorStoreId, content, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult CreateVectorStoreFileBatch(string vectorStoreId, BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateVectorStoreFileBatchRequest(vectorStoreId, content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> GetVectorStoreFileBatchAsync(string vectorStoreId, string batchId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateGetVectorStoreFileBatchRequest(vectorStoreId, batchId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult GetVectorStoreFileBatch(string vectorStoreId, string batchId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateGetVectorStoreFileBatchRequest(vectorStoreId, batchId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> CancelVectorStoreFileBatchAsync(string vectorStoreId, string batchId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateCancelVectorStoreFileBatchRequest(vectorStoreId, batchId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult CancelVectorStoreFileBatch(string vectorStoreId, string batchId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateCancelVectorStoreFileBatchRequest(vectorStoreId, batchId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<ClientResult> GetFilesInVectorStoreBatchesAsync(string vectorStoreId, string batchId, int? limit, string order, string after, string before, string filter, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateGetFilesInVectorStoreBatchesRequest(vectorStoreId, batchId, limit, order, after, before, filter, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult GetFilesInVectorStoreBatches(string vectorStoreId, string batchId, int? limit, string order, string after, string before, string filter, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateGetFilesInVectorStoreBatchesRequest(vectorStoreId, batchId, limit, order, after, before, filter, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    private PipelineMessage CreateGetVectorStoresRequest(int? limit, string order, string after, string before, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores")
            .WithOptionalQueryParameter("limit", limit)
            .WithOptionalQueryParameter("order", order)
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("before", before)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateCreateVectorStoreRequest(BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateGetVectorStoreRequest(string vectorStoreId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateModifyVectorStoreRequest(string vectorStoreId, BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId)
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateDeleteVectorStoreRequest(string vectorStoreId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("DELETE")
            .WithPath("vector_stores", vectorStoreId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateGetVectorStoreFilesRequest(string vectorStoreId, int? limit, string order, string after, string before, string filter, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId, "files")
            .WithOptionalQueryParameter("limit", limit)
            .WithOptionalQueryParameter("order", order)
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("before", before)
            .WithOptionalQueryParameter("filter", filter)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateCreateVectorStoreFileRequest(string vectorStoreId, BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId, "files")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateGetVectorStoreFileRequest(string vectorStoreId, string fileId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId, "files", fileId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateDeleteVectorStoreFileRequest(string vectorStoreId, string fileId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("DELETE")
            .WithPath("vector_stores", vectorStoreId, "files", fileId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateCreateVectorStoreFileBatchRequest(string vectorStoreId, BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId, "file_batches")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateGetVectorStoreFileBatchRequest(string vectorStoreId, string batchId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId, "file_batches", batchId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateCancelVectorStoreFileBatchRequest(string vectorStoreId, string batchId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId, "file_batches", batchId, "cancel")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private PipelineMessage CreateGetFilesInVectorStoreBatchesRequest(string vectorStoreId, string batchId, int? limit, string order, string after, string before, string filter, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId, "file_batches", batchId, "files")
            .WithOptionalQueryParameter("limit", limit)
            .WithOptionalQueryParameter("order", order)
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("before", before)
            .WithOptionalQueryParameter("filter", filter)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}
