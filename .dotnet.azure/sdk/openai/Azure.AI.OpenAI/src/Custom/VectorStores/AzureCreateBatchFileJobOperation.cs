using Azure.Core;
using System.ClientModel.Primitives;
using System.ClientModel;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.VectorStores;

[Experimental("OPENAI001")]
public partial class AzureCreateBatchFileJobOperation : CreateBatchFileJobOperation
{
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;
    private readonly string _apiVersion;
    private readonly string _vectorStoreId;
    private readonly string _batchId;

    internal AzureCreateBatchFileJobOperation(
        ClientPipeline pipeline,
        Uri endpoint,
        ClientResult<VectorStoreBatchFileJob> result,
        string apiVersion)
        : base(pipeline, endpoint, result)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        _apiVersion = apiVersion;

        _vectorStoreId = Value.VectorStoreId;
        _batchId = Value.BatchId;
    }
}
