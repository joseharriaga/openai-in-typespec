using System.ClientModel;
using System.ClientModel.Primitives;

#nullable enable

namespace Azure.AI.OpenAI.VectorStores;
public partial class AzureCreateBatchFileJobOperation
{
    public override IAsyncEnumerable<ClientResult> GetFilesInBatchAsync(int? limit, string? order, string? after, string? before, string? filter, RequestOptions? options)
    {
        AzureVectorStoreFileBatchesPageEnumerator enumerator = new(_pipeline, _endpoint, _vectorStoreId, _batchId, limit, order, after, before, filter, _apiVersion, options);
        return PageCollectionHelpers.CreateAsync(enumerator);
    }

    public override IEnumerable<ClientResult> GetFilesInBatch(int? limit, string? order, string? after, string? before, string? filter, RequestOptions? options)
    {
        AzureVectorStoreFileBatchesPageEnumerator enumerator = new(_pipeline, _endpoint, _vectorStoreId, _batchId, limit, order, after, before, filter, _apiVersion, options);
        return PageCollectionHelpers.Create(enumerator);
    }

    internal override PipelineMessage CreateCancelVectorStoreFileBatchRequest(string vectorStoreId, string batchId, RequestOptions? options)
        => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId, "file_batches", batchId, "cancel")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}
