// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.OpenAI.FineTuning;

internal partial class AzureFineTuningClient : FineTuningClient
{
    public override async Task<FineTuningJobOperation> CreateFineTuningJobAsync(
        BinaryContent content,
        bool waitUntilCompleted,
        RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateFineTuningJobRequest(content, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);

        using JsonDocument doc = JsonDocument.Parse(response.Content);
        string jobId = doc.RootElement.GetProperty("id"u8).GetString();
        string status = doc.RootElement.GetProperty("status"u8).GetString();

        AzureFineTuningJobOperation operation = new(Pipeline, _endpoint, jobId, status, response, _apiVersion);
        return await operation.WaitUntilAsync(waitUntilCompleted, options).ConfigureAwait(false);
    }

    public override FineTuningJobOperation CreateFineTuningJob(
        BinaryContent content,
        bool waitUntilCompleted,
        RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateFineTuningJobRequest(content, options);
        PipelineResponse response = Pipeline.ProcessMessage(message, options);

        using JsonDocument doc = JsonDocument.Parse(response.Content);
        string jobId = doc.RootElement.GetProperty("id"u8).GetString();
        string status = doc.RootElement.GetProperty("status"u8).GetString();

        AzureFineTuningJobOperation operation = new(Pipeline, _endpoint, jobId, status, response, _apiVersion);
        return operation.WaitUntil(waitUntilCompleted, options);
    }

    public override AsyncCollectionResult GetJobsAsync(string after, int? limit, RequestOptions options)
    {
        return new AsyncFineTuningJobCollectionResult(this, Pipeline, options, limit, after);
    }

    public override CollectionResult GetJobs(string after, int? limit, RequestOptions options)
    {
        return new FineTuningJobCollectionResult(this, Pipeline, options, limit, after);
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

    private static bool TryGetLastId(ClientResult previous, out string lastId)
    {
        Argument.AssertNotNull(previous, nameof(previous));

        using JsonDocument json = JsonDocument.Parse(previous.GetRawResponse().Content);
        if (!json.RootElement.GetProperty("has_more"u8).GetBoolean())
        {
            lastId = null;
            return false;
        }

        if (json?.RootElement.TryGetProperty("data", out JsonElement dataElement) == true
            && dataElement.EnumerateArray().LastOrDefault().TryGetProperty("id", out JsonElement idElement) == true)
        {
            lastId = idElement.GetString();
            return true;
        }

        lastId = null;
        return false;
    }
}
