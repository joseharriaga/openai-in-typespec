// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI;
using OpenAI.FineTuning;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text;

namespace Azure.AI.OpenAI.Staging.FineTuning;

public partial class AzureFineTuningClient : FineTuningClient
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult CreateJob(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateJobCreationRequestMessage(content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> CreateJobAsync(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateJobCreationRequestMessage(content, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult GetJob(string fineTuningJobId, RequestOptions options)
    {
        using PipelineMessage message = CreateJobRetrievalRequestMessage(fineTuningJobId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> GetJobAsync(string fineTuningJobId, RequestOptions options)
    {
        using PipelineMessage message = CreateJobRetrievalRequestMessage(fineTuningJobId, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult GetJobs(string after, int? limit, RequestOptions options)
    {
        using PipelineMessage message = CreateJobListingRequestMessage(after, limit, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> GetJobsAsync(string after, int? limit, RequestOptions options)
    {
        using PipelineMessage message = CreateJobListingRequestMessage(after, limit, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult GetJobEvents(string fineTuningJobId, string after, int? limit, RequestOptions options)
    {
        using PipelineMessage message = CreateJobEventListingRequestMessage(fineTuningJobId, after, limit, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> GetJobEventsAsync(string fineTuningJobId, string after, int? limit, RequestOptions options)
    {
        using PipelineMessage message = CreateJobEventListingRequestMessage(fineTuningJobId, after, limit, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ClientResult CancelJob(string fineTuningJobId, RequestOptions options)
    {
        using PipelineMessage message = CreateJobCancellationRequestMessage(fineTuningJobId, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override async Task<ClientResult> CancelJobAsync(string fineTuningJobId, RequestOptions options)
    {
        using PipelineMessage message = CreateJobCancellationRequestMessage(fineTuningJobId, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    private PipelineMessage CreateFineTuningPipelineMessage(
        string operation,
        string requestMethod,
        BinaryContent content,
        string listAfter,
        int? listLimit,
        RequestOptions options = null)
    {
        PipelineMessage message = Pipeline.CreateMessage();
        message.ResponseClassifier = AzureOpenAIClient.PipelineMessageClassifier200;
        PipelineRequest request = message.Request;
        request.Method = requestMethod;
        UriBuilder uriBuilder = new(_endpoint.AbsoluteUri);
        StringBuilder path = new();
        path.Append($"openai/fine_tuning/jobs/{operation}");
        uriBuilder.Path += path.ToString();
        uriBuilder.Query += $"?api-version={_apiVersion}";
        if (listAfter is not null)
        {
            uriBuilder.Query += $"&after={listAfter}";
        }
        if (listLimit is not null)
        {
            uriBuilder.Query += $"&limit={listLimit.Value}";
        }
        request.Uri = uriBuilder.Uri;
        request.Headers.Set("Accept", "application/json");
        if (content is not null)
        {
            request.Headers.Set("Content-Type", "application/json");
        }
        request.Content = content;
        message.Apply(options ?? null);
        return message;
    }

    private PipelineMessage CreateJobCreationRequestMessage(BinaryContent content, RequestOptions options)
        => CreateFineTuningPipelineMessage("", "POST", content, null, null, options);

    private PipelineMessage CreateJobListingRequestMessage(string after, int? limit, RequestOptions options)
        => CreateFineTuningPipelineMessage("", "GET", null, after, limit, options);

    private PipelineMessage CreateJobRetrievalRequestMessage(string jobId, RequestOptions options)
        => CreateFineTuningPipelineMessage($"{jobId}", "GET", null, null, null, options);

    private PipelineMessage CreateJobEventListingRequestMessage(string jobId, string after, int? limit, RequestOptions options)
        => CreateFineTuningPipelineMessage($"{jobId}/events", "GET", null, after, limit, options);

    private PipelineMessage CreateJobCancellationRequestMessage(string jobId, RequestOptions options)
        => CreateFineTuningPipelineMessage($"{jobId}/cancel", "POST", null, null, null, options);
}
