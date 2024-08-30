﻿using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.FineTuning;

internal partial class FineTuningJobEventsPageEnumerator : PageResultEnumerator
{
    protected readonly ClientPipeline _pipeline;
    protected readonly Uri _endpoint;

    private readonly string _jobId;
    private readonly int? _limit;
    private readonly RequestOptions _options;

    private string _after;

    public FineTuningJobEventsPageEnumerator(
        ClientPipeline pipeline,
        Uri endpoint,
         string jobId, string after, int? limit,
        RequestOptions options)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;

        _jobId = jobId;
        _after = after;
        _limit = limit;
        _options = options;
    }

    public override async Task<ClientResult> GetFirstAsync()
        => await GetJobEventsAsync(_jobId, _after, _limit, _options).ConfigureAwait(false);

    public override ClientResult GetFirst()
        => GetJobEvents(_jobId, _after, _limit, _options);

    public override async Task<ClientResult> GetNextAsync(ClientResult result)
    {
        _after = FineTuningClient.GetStartOfNextPage(result);
        return await GetJobEventsAsync(_jobId, _after, _limit, _options).ConfigureAwait(false);
    }

    public override ClientResult GetNext(ClientResult result)
    {
        _after = FineTuningClient.GetStartOfNextPage(result);
        return GetJobEvents(_jobId, _after, _limit, _options);
    }

    public override bool HasNext(ClientResult result)
    {
        PipelineResponse response = result.GetRawResponse();

        using JsonDocument doc = JsonDocument.Parse(response.Content);
        bool hasMore = doc.RootElement.GetProperty("has_more"u8).GetBoolean();

        return hasMore;
    }

    internal virtual async Task<ClientResult> GetJobEventsAsync(string jobId, string after, int? limit, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

        using PipelineMessage message = CreateGetFineTuningEventsRequest(jobId, after, limit, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    internal virtual ClientResult GetJobEvents(string jobId, string after, int? limit, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

        using PipelineMessage message = CreateGetFineTuningEventsRequest(jobId, after, limit, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    internal virtual PipelineMessage CreateGetFineTuningEventsRequest(string fineTuningJobId, string after, int? limit, RequestOptions options)
    {
        var message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier200;
        var request = message.Request;
        request.Method = "GET";
        var uri = new ClientUriBuilder();
        uri.Reset(_endpoint);
        uri.AppendPath("/fine_tuning/jobs/", false);
        uri.AppendPath(fineTuningJobId, true);
        uri.AppendPath("/events", false);
        if (after != null)
        {
            uri.AppendQuery("after", after, true);
        }
        if (limit != null)
        {
            uri.AppendQuery("limit", limit.Value, true);
        }
        request.Uri = uri.ToUri();
        request.Headers.Set("Accept", "application/json");
        message.Apply(options);
        return message;
    }

    private static PipelineMessageClassifier? _pipelineMessageClassifier200;
    private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
}
