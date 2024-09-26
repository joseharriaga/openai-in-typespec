﻿using System.ClientModel.Primitives;
using System.ClientModel;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.VectorStores;
[Experimental("OPENAI001")]
public partial class AzureAddFileToVectorStoreOperation : AddFileToVectorStoreOperation
{
    private readonly string _apiVersion;
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;
    internal AzureAddFileToVectorStoreOperation(
        ClientPipeline pipeline,
        Uri endpoint,
        ClientResult<VectorStoreFileAssociation> result,
        string apiVersion)
        : base(pipeline, endpoint, result)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        _apiVersion = apiVersion;
    }
}
