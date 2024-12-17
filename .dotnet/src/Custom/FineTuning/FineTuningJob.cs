﻿using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.FineTuning;

/// <summary>
/// A long-running operation for creating a new model from a given dataset.
/// </summary>
public partial class FineTuningJob : OperationResult
{
    public string? Value = null;

    public string JobId { get; private set; } = null!;
    public string BaseModel { get; private set; } = null!;
    public DateTimeOffset? EstimatedFinishAt { get; private set; }
    public string ValidationFileId { get; private set; } = null!;
    public string TrainingFileId { get; private set; } = null!;
    public IReadOnlyList<string> ResultFileIds { get; private set; } = null!;
    public FineTuningStatus Status { get; private set; }

    public FineTuningHyperparameters Hyperparameters { get; private set; } = default;
    public IReadOnlyList<FineTuningIntegration> Integrations { get; private set; } = null!;
    public int? BillableTrainedTokens { get; private set; }
    public string? UserProvidedSuffix { get; private set; }
    public int? Seed { get; private set; }

    /// <summary>
    /// Creates a new <see cref="FineTuningJob"/> from a <see cref="PipelineResponse"/>.
    /// </summary>
    /// <param name="pipeline"></param>
    /// <param name="endpoint"></param>
    /// <param name="response"></param>
    internal FineTuningJob(
            ClientPipeline pipeline,
            Uri endpoint,
            PipelineResponse response) : base(response)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        var job = (InternalFineTuningJob)ClientResult.FromResponse(response);
        CopyLocalParameters(response, job);
    }

    /// <summary>
    /// Creates a new <see cref="FineTuningJob"/> from a <see cref="InternalFineTuningJob"/>.
    /// Pipeline response is saved but not used for inferring job data. Response could be a page of values.
    /// </summary>
    /// <param name="pipeline"></param>
    /// <param name="endpoint"></param>
    /// <param name="job"></param>
    /// <param name="response"></param>
    internal FineTuningJob(
            ClientPipeline pipeline,
            Uri endpoint,
            InternalFineTuningJob job,
            PipelineResponse response) : base(response)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        CopyLocalParameters(response, job);
    }

    private void CopyLocalParameters(PipelineResponse response, InternalFineTuningJob job)
    {
        Value = job.FineTunedModel;

        BaseModel = job.BaseModel;
        EstimatedFinishAt = job.EstimatedFinishAt;
        Hyperparameters = job.Hyperparameters;
        Integrations = job.Integrations;
        JobId = job.JobId;
        RehydrationToken = new FineTuningJobToken(job.JobId);
        ResultFileIds = job.ResultFileIds;
        Seed = job.Seed;
        Status = job.Status;
        TrainingFileId = job.TrainingFileId;
        UserProvidedSuffix = job.UserProvidedSuffix;
        ValidationFileId = job.ValidationFileId;

        HasCompleted = GetHasCompleted(Status);
        SetRawResponse(response);
    }

    private static bool GetHasCompleted(FineTuningStatus status)
    {
        return status == FineTuningStatus.Succeeded ||
            status == FineTuningStatus.Failed ||
            status == FineTuningStatus.Cancelled;
    }

    /// <summary>
    /// Get status updates (events) for a fine-tuning job.
    /// </summary>
    /// <param name="options"> Filter parameters via <see cref="ListEventsOptions"/>. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual AsyncCollectionResult<FineTuningEvent> GetEventsAsync(ListEventsOptions options, CancellationToken cancellationToken = default)
    {
        options ??= new ListEventsOptions();
        return (AsyncCollectionResult<FineTuningEvent>)GetEventsAsync(options.AfterEventId, options.PageSize, cancellationToken.ToRequestOptions());
    }

    /// <inheritdoc cref="GetEventsAsync(ListEventsOptions, CancellationToken)"/>
    public virtual CollectionResult<FineTuningEvent> GetEvents(ListEventsOptions options, CancellationToken cancellationToken = default)
    {
        options ??= new ListEventsOptions();
        return (CollectionResult<FineTuningEvent>)GetEvents(options.AfterEventId, options.PageSize, cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="options"> Filter parameters via <see cref="ListCheckpointsOptions"/>. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual AsyncCollectionResult<FineTuningCheckpoint> GetCheckpointsAsync(ListCheckpointsOptions? options = null, CancellationToken cancellationToken = default)
    {
        options ??= new ListCheckpointsOptions();
        return (AsyncCollectionResult<FineTuningCheckpoint>)GetCheckpointsAsync(options.AfterCheckpointId, options.PageSize, cancellationToken.ToRequestOptions());

    }

    /// <summary>
    /// List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="options"> Filter parameters via <see cref="ListCheckpointsOptions"/>. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual CollectionResult<FineTuningCheckpoint> GetCheckpoints(ListCheckpointsOptions? options = null, CancellationToken cancellationToken = default)
    {
        options ??= new ListCheckpointsOptions();
        return (CollectionResult<FineTuningCheckpoint>)GetCheckpoints(options.AfterCheckpointId, options.PageSize, cancellationToken.ToRequestOptions());
    }

    /// <summary>
    /// Recreates a <see cref="FineTuningJob"/> from a rehydration token.
    /// </summary>
    /// <param name="client"> The <see cref="FineTuningClient"/> used to obtain the LRO status from the service. </param>
    /// <param name="rehydrationToken"> The rehydration token corresponding to the job to rehydrate. </param>
    /// <param name="cancellationToken"> A token that can be used to cancel the request. </param>
    /// <returns> The rehydrated LRO <see cref="FineTuningJob"/>. </returns>
    /// <exception cref="ArgumentNullException"> <paramref name="client"/> or <paramref name="rehydrationToken"/> is null. </exception>
    public static FineTuningJob Rehydrate(FineTuningClient client, ContinuationToken rehydrationToken, CancellationToken cancellationToken = default)
    {
        return Rehydrate(client, rehydrationToken, cancellationToken.ToRequestOptions());
    }


    /// <inheritdoc cref="Rehydrate(FineTuningClient, ContinuationToken, CancellationToken)"/>"
    public static async Task<FineTuningJob> RehydrateAsync(FineTuningClient client, ContinuationToken rehydrationToken, CancellationToken cancellationToken = default)
    {
        return await RehydrateAsync(client, rehydrationToken, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
    }

    /// <summary>
    /// Recreates a <see cref="FineTuningJob"/> from a fine tuning job id.
    /// </summary>
    /// <param name="client"> The <see cref="FineTuningClient"/> used to obtain the LRO status from the service. </param>
    /// <param name="JobId"> The id of the fine tuning job to rehydrate.</param>
    /// <param name="cancellationToken"> A token that can be used to cancel the request. </param>
    /// <returns> The rehydrated LRO <see cref="FineTuningJob"/>. </returns>
    public static FineTuningJob Rehydrate(FineTuningClient client, string JobId, CancellationToken cancellationToken = default)
    {
        return Rehydrate(client, JobId, cancellationToken.ToRequestOptions());
    }

    /// <inheritdoc cref="Rehydrate(FineTuningClient, string, CancellationToken)" />
    public static async Task<FineTuningJob> RehydrateAsync(FineTuningClient client, string JobId, CancellationToken cancellationToken = default)
    {
        return await RehydrateAsync(client, JobId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async ValueTask<ClientResult> UpdateStatusAsync(CancellationToken cancellationToken = default)
    {
        ClientResult result = await GetJobAsync(cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        var response = result.GetRawResponse();
        CopyLocalParameters(response, (InternalFineTuningJob)ClientResult.FromResponse(response));
        return result;
    }

    /// <inheritdoc/>
    public ClientResult UpdateStatus(CancellationToken cancellationToken = default)
    {
        ClientResult result = GetJob(cancellationToken.ToRequestOptions());
        var response = result.GetRawResponse();
        CopyLocalParameters(response, (InternalFineTuningJob)ClientResult.FromResponse(response));
        return result;
    }

    /// <summary>
    /// [Protocol Method] Immediately cancel a fine-tune job, and update parameters (such as status) of the LRO.
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult CancelAndUpdate(CancellationToken cancellationToken = default)
    {
        using PipelineMessage message = CancelPipelineMessage(JobId, cancellationToken.ToRequestOptions());
        PipelineResponse response = _pipeline.ProcessMessage(message, cancellationToken.ToRequestOptions());
        CopyLocalParameters(response, (InternalFineTuningJob)ClientResult.FromResponse(response));
        return ClientResult.FromResponse(response);
    }

    /// <summary>
    /// [Protocol Method] Immediately cancel a fine-tune job.
    /// </summary>
    /// <param name="cancellationToken"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult> CancelAndUpdateAsync(CancellationToken cancellationToken = default)
    {
        using PipelineMessage message = CancelPipelineMessage(JobId, cancellationToken.ToRequestOptions());
        PipelineResponse response = await _pipeline.ProcessMessageAsync(message, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        CopyLocalParameters(response, (InternalFineTuningJob)ClientResult.FromResponse(response));
        return ClientResult.FromResponse(response);
    }

    override public async ValueTask WaitForCompletionAsync(CancellationToken cancellationToken = default)
    {
        while (!HasCompleted)
        {
            var delay = GetDelay();

            await Task.Delay(delay, cancellationToken).ConfigureAwait(false);

            await UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
        }
    }

    override public void WaitForCompletion(CancellationToken cancellationToken = default)
    {
        while (!HasCompleted)
        {
            TimeSpan delay = GetDelay();

            if (!cancellationToken.CanBeCanceled)
            {
                Thread.Sleep(delay);
            }
            else if (cancellationToken.WaitHandle.WaitOne(delay))
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            UpdateStatus(cancellationToken);
        }
    }
    private TimeSpan GetDelay()
    {
        if (EstimatedFinishAt.HasValue)
        {
            return EstimatedFinishAt.Value - DateTimeOffset.UtcNow;
        }
        return Status == FineTuningStatus.Running
            ? TimeSpan.FromSeconds(30)
            : TimeSpan.FromSeconds(1);
    }

}