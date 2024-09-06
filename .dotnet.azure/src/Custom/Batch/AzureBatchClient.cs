// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using OpenAI.Batch;

namespace Azure.AI.OpenAI.Batch;

/// <summary>
/// The scenario client used for Files operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
internal partial class AzureBatchClient : BatchClient
{
    private readonly Uri _endpoint;
    private readonly string _deploymentName;
    private readonly string _apiVersion;

    internal AzureBatchClient(
        ClientPipeline pipeline,
        string deploymentName,
        Uri endpoint,
        AzureOpenAIClientOptions options)
            : base(pipeline, endpoint, options)
    {
        options ??= new();
        Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
        _deploymentName = deploymentName;
        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    protected AzureBatchClient()
    { }

    internal override CreateBatchOperation CreateBatchOperation(string batchId, string status, PipelineResponse response)
    {
        return new AzureCreateBatchOperation(Pipeline, _endpoint, batchId, status, response, _deploymentName, _apiVersion);
    }

    internal override PipelineMessage CreateCreateBatchRequest(BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("POST")
            .WithPath("batches")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetBatchesRequest(string after, int? limit, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("GET")
            .WithPath("batches")
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("limit", limit)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateRetrieveBatchRequest(string batchId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("GET")
            .WithPath("batches", batchId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateCancelBatchRequest(string batchId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithMethod("POST")
            .WithPath("batches", batchId, "cancel")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}
