using Azure.AI.OpenAI;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Azure.AI.OpenAI.VectorStores;

internal partial class AzureCreateVectorStoreOperation
{
    internal override PipelineMessage CreateGetVectorStoreRequest(string vectorStoreId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("vector_stores", vectorStoreId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}
