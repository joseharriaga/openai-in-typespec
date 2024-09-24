using System.ClientModel;
using System.ClientModel.Primitives;

#nullable enable

namespace Azure.AI.OpenAI.VectorStores;
public partial class AzureCreateBatchFileJobOperation
{
    internal override PipelineMessage CreateCancelVectorStoreFileBatchRequest(string vectorStoreId, string batchId, RequestOptions? options)
        => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint, _apiVersion)
            .WithMethod("POST")
            .WithPath("vector_stores", vectorStoreId, "file_batches", batchId, "cancel")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}
