// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Custom.FineTuning;
using OpenAI.FineTuning;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.FineTuning;

/// <summary>
/// The scenario client used for fine-tuning operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
internal partial class AzureFineTuningClient : FineTuningClient
{
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    internal AzureFineTuningClient(
        ClientPipeline pipeline,
        Uri endpoint,
        AzureOpenAIClientOptions options)
            : base(pipeline, endpoint, options)
    {
        options ??= new();
        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    protected AzureFineTuningClient()
    { }

    internal override CreateJobOperation CreateJobOperation(string jobId, string status, PipelineResponse response)
    {
        return new AzureCreateJobOperation(Pipeline, _endpoint, jobId, status, response, _apiVersion);
    }

    internal override PipelineMessage CreateCreateFineTuningJobRequest(BinaryContent content, RequestOptions options)
    => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
        .WithMethod("POST")
        .WithPath("fine_tuning", "jobs")
        .WithContent(content, "application/json")
        .WithAccept("application/json")
        .WithOptions(options)
        .Build();

    internal override PipelineMessage CreateGetPaginatedFineTuningJobsRequest(string after, int? limit, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("fine_tuning", "jobs")
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("limit", limit)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateRetrieveFineTuningJobRequest(string fineTuningJobId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("fine_tuning", "jobs", fineTuningJobId)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}
