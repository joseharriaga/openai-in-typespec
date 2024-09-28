using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.VectorStores;
internal partial class AzureAddFileToVectorStoreOperation : AddFileToVectorStoreOperation
{
    internal override PipelineMessage CreateGetVectorStoreFileRequest(string vectorStoreId, string fileId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId, "files", fileId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}
