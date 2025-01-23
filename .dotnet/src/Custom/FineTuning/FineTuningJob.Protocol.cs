﻿using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

#nullable enable

namespace OpenAI.FineTuning;

/// <summary>
/// A long-running operation for creating a new model from a given dataset.
/// </summary>
[Experimental("OPENAI001")]
public partial class FineTuningJob : OperationResult
{
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;

    /// <inheritdoc/>
    public override ContinuationToken? RehydrationToken { get; protected set; }

    /// <summary>
    /// Recreates a <see cref="FineTuningJob"/> from a rehydration token.
    /// </summary>
    /// <param name="client"> The <see cref="FineTuningClient"/> used to obtain the job status from the service. </param>
    /// <param name="rehydrationToken"> The rehydration token corresponding to the job to rehydrate. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </         param>
    /// <returns> The rehydrated LRO <see cref="FineTuningJob"/>. </returns>
    /// <exception cref="ArgumentNullException"> <paramref name="client"/> or <paramref name="rehydrationToken"/> is null. </exception>
    public static FineTuningJob Rehydrate(FineTuningClient client, ContinuationToken rehydrationToken, RequestOptions options)
    {
        Argument.AssertNotNull(client, nameof(client));
        Argument.AssertNotNull(rehydrationToken, nameof(rehydrationToken));

        FineTuningJobToken token = FineTuningJobToken.FromToken(rehydrationToken);

        ClientResult result = client.GetJob(token.JobId, options);
        PipelineResponse response = result.GetRawResponse();

        return client.CreateJobFromResponse(response);
    }

    /// <inheritdoc cref="Rehydrate(FineTuningClient, ContinuationToken, RequestOptions)"/>
    public static async Task<FineTuningJob> RehydrateAsync(FineTuningClient client, ContinuationToken rehydrationToken, RequestOptions options)
    {
        Argument.AssertNotNull(client, nameof(client));
        Argument.AssertNotNull(rehydrationToken, nameof(rehydrationToken));

        FineTuningJobToken token = FineTuningJobToken.FromToken(rehydrationToken);

        ClientResult result = await client.GetJobAsync(token.JobId, options).ConfigureAwait(false);
        PipelineResponse response = result.GetRawResponse();

        return client.CreateJobFromResponse(response);
    }

    /// <summary>
    /// Recreates a <see cref="FineTuningJob"/> from a fine tuning job id.
    /// </summary>
    /// <param name="client"> The <see cref="FineTuningClient"/> used to obtain the job status from the service. </param>
    /// <param name="JobId"> The id of the fine tuning job to rehydrate.</param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <returns> The rehydrated LRO <see cref="FineTuningJob"/>. </returns>
    /// <exception cref="ArgumentNullException"> <paramref name="client"/> or <paramref name="JobId"/> is null. </exception>
    public static FineTuningJob Rehydrate(FineTuningClient client, string JobId, RequestOptions options)
    {
        Argument.AssertNotNull(client, nameof(client));
        Argument.AssertNotNull(JobId, nameof(JobId));

        ClientResult result = client.GetJob(JobId, options);
        PipelineResponse response = result.GetRawResponse();

        return client.CreateJobFromResponse(response);
    }

    /// <inheritdoc cref="Rehydrate(FineTuningClient, string, RequestOptions)"/>/>
    public static async Task<FineTuningJob> RehydrateAsync(FineTuningClient client, string JobId, RequestOptions options)
    {
        Argument.AssertNotNull(client, nameof(client));
        Argument.AssertNotNull(JobId, nameof(JobId));

        ClientResult result = await client.GetJobAsync(JobId, options).ConfigureAwait(false);
        PipelineResponse response = result.GetRawResponse();

        return client.CreateJobFromResponse(response);
    }


    /// <inheritdoc/>
    public override async ValueTask<ClientResult> UpdateStatusAsync(RequestOptions? options)
    {
        options ??= new RequestOptions();
        ClientResult result = await GetJobAsync(options).ConfigureAwait(false);
        var response = result.GetRawResponse();
        SetRawResponse(response);
        using JsonDocument doc = JsonDocument.Parse(response.Content);
        string status = doc.RootElement.GetProperty("status"u8).GetString()!;
        HasCompleted = GetHasCompleted(status);
        return result;
    }

    /// <inheritdoc/>
    public override ClientResult UpdateStatus(RequestOptions? options)
    {
        options ??= new RequestOptions();
        ClientResult result = GetJob(options);
        var response = result.GetRawResponse();
        SetRawResponse(response);
        using JsonDocument doc = JsonDocument.Parse(response.Content);
        string status = doc.RootElement.GetProperty("status"u8).GetString()!;
        HasCompleted = GetHasCompleted(status);
        return result;
    }

    internal async Task<FineTuningJob> WaitUntilAsync(bool waitUntilCompleted, RequestOptions options)
    {
        if (!waitUntilCompleted) return this;
        await WaitForCompletionAsync(options?.CancellationToken ?? default).ConfigureAwait(false);
        return this;
    }

    internal FineTuningJob WaitUntil(bool waitUntilCompleted, RequestOptions options)
    {
        if (!waitUntilCompleted) return this;
        WaitForCompletion(options?.CancellationToken ?? default);
        return this;
    }

    /// <summary>
    /// [Protocol Method] Get info about a fine-tuning job.
    ///
    /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
    /// </summary>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    internal virtual async Task<ClientResult> GetJobAsync(RequestOptions options)
    {
        using PipelineMessage message = FineTuningClient.GetJobPipelineMessage(_pipeline, _endpoint, JobId, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    // CUSTOM:
    // - Renamed.
    // - Edited doc comment.
    /// <summary>
    /// [Protocol Method] Get info about a fine-tuning job.
    ///
    /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
    /// </summary>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    internal virtual ClientResult GetJob(RequestOptions options)
    {
        using PipelineMessage message = FineTuningClient.GetJobPipelineMessage(_pipeline, _endpoint, JobId, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    /// <summary>
    /// [Protocol Method] Immediately cancel a fine-tune job.
    /// </summary>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult> CancelAsync(RequestOptions options)
    {
        using PipelineMessage message = CancelPipelineMessage(JobId, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <summary>
    /// [Protocol Method] Immediately cancel a fine-tune job.
    /// </summary>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult Cancel(RequestOptions options)
    {
        using PipelineMessage message = CancelPipelineMessage(JobId, options);
        PipelineResponse response = _pipeline.ProcessMessage(message, options);
        return ClientResult.FromResponse(response);
    }

    /// <summary>
    /// [Protocol Method] Get status updates (events) for a fine-tuning job.
    /// </summary>
    /// <param name="after"> Identifier for the last event from the previous pagination request. </param>
    /// <param name="limit"> Number of events to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual AsyncCollectionResult GetEventsAsync(string? after, int? limit, RequestOptions options)
    {
        return new AsyncFineTuningEventCollectionResult(this, options, limit, after);
    }

    /// <inheritdoc cref="GetEventsAsync(string?, int?, RequestOptions)"/>
    public virtual CollectionResult GetEvents(string? after, int? limit, RequestOptions options)
    {
        return new FineTuningEventCollectionResult(this, options, limit, after);
    }

    /// <summary>
    /// [Protocol Method] List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="after"> Identifier for the last checkpoint ID from the previous pagination request. </param>
    /// <param name="limit"> Number of checkpoints to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual AsyncCollectionResult GetCheckpointsAsync(string? after, int? limit, RequestOptions? options)
    {
        return new AsyncFineTuningCheckpointCollectionResult(this, options, limit, after);
    }

    /// <summary>
    /// [Protocol Method] List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="after"> Identifier for the last checkpoint ID from the previous pagination request. </param>
    /// <param name="limit"> Number of checkpoints to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual CollectionResult GetCheckpoints(string? after, int? limit, RequestOptions? options)
    {
        return new FineTuningCheckpointCollectionResult(this, options, limit, after);
    }

    /// <summary>
    /// [Protocol Method] List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="after"> Identifier for the last checkpoint ID from the previous pagination request. </param>
    /// <param name="limit"> Number of checkpoints to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    internal virtual async Task<ClientResult> GetCheckpointsPageAsync(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = GetCheckpointsPipelineMessage(JobId, after, limit, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <summary>
    /// [Protocol Method] List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="after"> Identifier for the last checkpoint ID from the previous pagination request. </param>
    /// <param name="limit"> Number of checkpoints to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    internal virtual ClientResult GetPageCheckpoints(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = GetCheckpointsPipelineMessage(JobId, after, limit, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    /// <summary>
    /// [Protocol Method] List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="after"> Identifier for the last checkpoint ID from the previous pagination request. </param>
    /// <param name="limit"> Number of checkpoints to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    internal virtual ClientResult GetCheckpointsPage(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = GetCheckpointsPipelineMessage(JobId, after, limit, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    internal virtual async Task<ClientResult> GetEventsPageAsync(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = GetEventsPipelineMessage(JobId, after, limit, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    internal virtual ClientResult GetEventsPage(string? after, int? limit, RequestOptions? options)
    {
        using PipelineMessage message = GetEventsPipelineMessage(JobId, after, limit, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    internal virtual PipelineMessage CancelPipelineMessage(string JobId, RequestOptions? options)
    {
        var message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier200;
        var request = message.Request;
        request.Method = "POST";
        var uri = new ClientUriBuilder();
        uri.Reset(_endpoint);
        uri.AppendPath("/fine_tuning/jobs/", false);
        uri.AppendPath(JobId, true);
        uri.AppendPath("/cancel", false);
        request.Uri = uri.ToUri();
        request.Headers.Set("Accept", "application/json");
        message.Apply(options);
        return message;
    }

    internal virtual PipelineMessage GetCheckpointsPipelineMessage(string JobId, string? after, int? limit, RequestOptions? options)
    {
        var message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier200;
        var request = message.Request;
        request.Method = "GET";

        var uriBuilder = new UriBuilder(_endpoint);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        
        uriBuilder.Path += "fine_tuning/jobs/" + JobId + "/checkpoints";

        if (after != null)
        {
            query["after"] = after;
        }
        if (limit != null)
        {
            query["limit"] = limit.ToString();
        }
        uriBuilder.Query = query.ToString();
        request.Uri = uriBuilder.Uri;
        request.Headers.Set("Accept", "application/json");
        message.Apply(options);
        return message;
    }

    internal virtual PipelineMessage GetEventsPipelineMessage(string jobId, string? after, int? limit, RequestOptions? options)
    {
        var message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier200;
        var request = message.Request;
        request.Method = "GET";
        var uri = new ClientUriBuilder();
        uri.Reset(_endpoint);
        uri.AppendPath("/fine_tuning/jobs/", false);
        uri.AppendPath(jobId, true);
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
