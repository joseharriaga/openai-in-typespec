// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI.Batch;

namespace Azure.AI.OpenAI.Batch;

internal partial class AzureBatchClient : BatchClient
{
    public override async Task<CreateBatchOperation> CreateBatchAsync(BinaryContent content, bool waitUntilCompleted, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateBatchRequest(content, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);

        using JsonDocument doc = JsonDocument.Parse(response.Content);
        string batchId = doc.RootElement.GetProperty("id"u8).GetString();
        string status = doc.RootElement.GetProperty("status"u8).GetString();

        CreateBatchOperation operation = new(Pipeline, _endpoint, batchId, status, response);
        return await operation.WaitUntilAsync(waitUntilCompleted, options).ConfigureAwait(false);
    }

    public override CreateBatchOperation CreateBatch(BinaryContent content, bool waitUntilCompleted, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateBatchRequest(content, options);
        PipelineResponse response = Pipeline.ProcessMessage(message, options);

        using JsonDocument doc = JsonDocument.Parse(response.Content);
        string batchId = doc.RootElement.GetProperty("id"u8).GetString();
        string status = doc.RootElement.GetProperty("status"u8).GetString();

        CreateBatchOperation operation = new(Pipeline, _endpoint, batchId, status, response);
        return operation.WaitUntil(waitUntilCompleted, options);
    }

    public override async Task<ClientResult> GetBatchesAsync(string after, int? limit, RequestOptions options)
    {
        using PipelineMessage message = CreateGetBatchesRequest(after, limit, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public override ClientResult GetBatches(string after, int? limit, RequestOptions options)
    {
        using PipelineMessage message = CreateGetBatchesRequest(after, limit, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    internal override async Task<ClientResult> GetBatchAsync(string batchId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateRetrieveBatchRequest(batchId, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    internal override ClientResult GetBatch(string batchId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        using PipelineMessage message = CreateRetrieveBatchRequest(batchId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }
}
