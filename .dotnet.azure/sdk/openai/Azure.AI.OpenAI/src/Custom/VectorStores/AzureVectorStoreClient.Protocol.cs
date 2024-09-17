// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.VectorStores;

internal partial class AzureVectorStoreClient : VectorStoreClient
{
    public override IAsyncEnumerable<ClientResult> GetVectorStoresAsync(int? limit, string order, string after, string before, RequestOptions options)
    {
        AzureVectorStoresPageEnumerator enumerator = new(Pipeline, _endpoint, limit, order, after, before, _apiVersion, options);
        return PageCollectionHelpers.CreateAsync(enumerator);
    }

    public override IEnumerable<ClientResult> GetVectorStores(int? limit, string order, string after, string before, RequestOptions options)
    {
        AzureVectorStoresPageEnumerator enumerator = new(Pipeline, _endpoint, limit, order, after, before, _apiVersion,options);
        return PageCollectionHelpers.Create(enumerator);
    }

    internal override async Task<ClientResult> GetVectorStoreAsync(string vectorStoreId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        using PipelineMessage message = CreateGetVectorStoreRequest(vectorStoreId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    internal override ClientResult GetVectorStore(string vectorStoreId, RequestOptions options)
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

    public override IAsyncEnumerable<ClientResult> GetFileAssociationsAsync(string vectorStoreId, int? limit, string order, string after, string before, string filter, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        AzureVectorStoreFilesPageEnumerator enumerator = new(Pipeline, _endpoint, vectorStoreId, limit, order, after, before, filter, _apiVersion, options);
        return PageCollectionHelpers.CreateAsync(enumerator);
    }

    public override IEnumerable<ClientResult> GetFileAssociations(string vectorStoreId, int? limit, string order, string after, string before, string filter, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        AzureVectorStoreFilesPageEnumerator enumerator = new(Pipeline, _endpoint, vectorStoreId, limit, order, after, before, filter, _apiVersion, options);
        return PageCollectionHelpers.Create(enumerator);
    }

    public override async Task<AddFileToVectorStoreOperation> AddFileToVectorStoreAsync(string vectorStoreId, BinaryContent content, bool waitUntilCompleted, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateVectorStoreFileRequest(vectorStoreId, content, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        VectorStoreFileAssociation value = VectorStoreFileAssociation.FromResponse(response);

        AzureAddFileToVectorStoreOperation operation = new(Pipeline, _endpoint, ClientResult.FromValue(value, response), _apiVersion);
        return await operation.WaitUntilAsync(waitUntilCompleted, options).ConfigureAwait(false);
    }

    public override AddFileToVectorStoreOperation AddFileToVectorStore(string vectorStoreId, BinaryContent content, bool waitUntilCompleted, RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateVectorStoreFileRequest(vectorStoreId, content, options);
        PipelineResponse response = Pipeline.ProcessMessage(message, options);
        VectorStoreFileAssociation value = VectorStoreFileAssociation.FromResponse(response);

        AzureAddFileToVectorStoreOperation operation = new(Pipeline, _endpoint, ClientResult.FromValue(value, response), _apiVersion);
        return operation.WaitUntil(waitUntilCompleted, options);
    }

    public override async Task<ClientResult> RemoveFileFromStoreAsync(string vectorStoreId, string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateDeleteVectorStoreFileRequest(vectorStoreId, fileId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult RemoveFileFromStore(string vectorStoreId, string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateDeleteVectorStoreFileRequest(vectorStoreId, fileId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    public override async Task<CreateBatchFileJobOperation> CreateBatchFileJobAsync(
        string vectorStoreId,
        BinaryContent content,
        bool waitUntilCompleted,
        RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateVectorStoreFileBatchRequest(vectorStoreId, content, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        VectorStoreBatchFileJob job = VectorStoreBatchFileJob.FromResponse(response);

        AzureCreateBatchFileJobOperation operation = new(Pipeline, _endpoint, ClientResult.FromValue(job, response), _apiVersion);
        return await operation.WaitUntilAsync(waitUntilCompleted, options).ConfigureAwait(false);
    }

    public override CreateBatchFileJobOperation CreateBatchFileJob(
        string vectorStoreId,
        BinaryContent content,
        bool waitUntilCompleted,
        RequestOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateVectorStoreFileBatchRequest(vectorStoreId, content, options);
        PipelineResponse response = Pipeline.ProcessMessage(message, options);
        VectorStoreBatchFileJob job = VectorStoreBatchFileJob.FromResponse(response);

        AzureCreateBatchFileJobOperation operation = new(Pipeline, _endpoint, ClientResult.FromValue(job, response), _apiVersion);
        return operation.WaitUntil(waitUntilCompleted, options);
    }

    private new PipelineMessage CreateGetVectorStoreRequest(string vectorStoreId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateModifyVectorStoreRequest(string vectorStoreId, BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId)
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateDeleteVectorStoreRequest(string vectorStoreId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("DELETE")
            .WithPath("vector_stores", vectorStoreId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateCreateVectorStoreFileRequest(string vectorStoreId, BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId, "files")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    private new PipelineMessage CreateDeleteVectorStoreFileRequest(string vectorStoreId, string fileId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("DELETE")
            .WithPath("vector_stores", vectorStoreId, "files", fileId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

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
