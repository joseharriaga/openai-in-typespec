using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.FineTuning;

/// <summary>
/// A long-running operation for creating a new model from a given dataset.
/// </summary>
public partial class FineTuningJobOperation : OperationResult
{
    public FineTuningJob Value => FineTuningJob.FromResponse(GetRawResponse());
    public bool HasValue = true;

    /// <summary>
    /// Updates the status of the operation.
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <returns> The freshly fetched <see cref="ClientResult{FineTuningJob}"/> object. </returns>
    public async ValueTask<ClientResult<FineTuningJob>> UpdateStatusAsync(CancellationToken cancellationToken = default)
    {
        ClientResult result = await GetJobAsync(cancellationToken.ToRequestOptions()).ConfigureAwait(false);

        SetRawResponse(result.GetRawResponse());

        return (ClientResult<FineTuningJob>)result;
    }

    /// <summary>
    /// Re-fetches the latest information about the operation.
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <returns> The freshly fetched <see cref="ClientResult{FineTuningJob}"/> object. </returns>
    public ClientResult<FineTuningJob> UpdateStatus(CancellationToken cancellationToken = default)
    {
        ClientResult result = GetJob(cancellationToken.ToRequestOptions());

        SetRawResponse(result.GetRawResponse());

        return (ClientResult<FineTuningJob>)result;
    }

    private static bool GetHasCompleted(string? status)
    {
        return status == FineTuningJobStatus.Succeeded ||
            status == FineTuningJobStatus.Failed ||
            status == FineTuningJobStatus.Cancelled;
    }

    /// <summary>
    /// Get info about a fine-tuning job.
    /// 
    /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token to use. </param>"
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult<FineTuningJob>> GetJobAsync(CancellationToken cancellationToken = default)
    {
        using PipelineMessage message = CreateRetrieveFineTuningJobRequest(_jobId, cancellationToken.ToRequestOptions());
        return (ClientResult<FineTuningJob>)ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, cancellationToken.ToRequestOptions()).ConfigureAwait(false));
    }

    /// <summary>
    /// Get info about a fine-tuning job.
    ///
    /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token to use. </param>"
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult<FineTuningJob> GetJob(CancellationToken cancellationToken = default)
    {
        using PipelineMessage message = CreateRetrieveFineTuningJobRequest(_jobId, cancellationToken.ToRequestOptions());
        var rawResponse = _pipeline.ProcessMessage(message, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(FineTuningJob.FromResponse(rawResponse), rawResponse);
    }

    /// <summary>
    /// Immediately cancel a fine-tune job.
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult<FineTuningJob>> CancelAsync(CancellationToken cancellationToken = default)
    {
        using PipelineMessage message = CreateCancelFineTuningJobRequest(_jobId, cancellationToken.ToRequestOptions());
        var rawResponse = await _pipeline.ProcessMessageAsync(message, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue(FineTuningJob.FromResponse(rawResponse), rawResponse);
    }

    /// <summary>
    /// Immediately cancel a fine-tune job.
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult<FineTuningJob> Cancel(CancellationToken cancellationToken = default)
    {
        var method = CreateCancelFineTuningJobRequest;
        PipelineMessage message;
        return NewMethod(method, out message, cancellationToken);
    }

    private ClientResult<FineTuningJob> NewMethod(Func<string, RequestOptions?, PipelineMessage> method, out PipelineMessage message, CancellationToken cancellationToken)
    {
        message = method(_jobId, cancellationToken.ToRequestOptions());
        var rawResponse = _pipeline.ProcessMessage(message, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(FineTuningJob.FromResponse(rawResponse), rawResponse);
    }

    /// <summary>
    /// Get status updates for a fine-tuning job.
    /// </summary>
    /// <param name="options"> Filter parameters via <see cref="ListEventsOptions"/>. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual AsyncCollectionResult<FineTuningJobEvent> GetJobEventsAsync(ListEventsOptions options, CancellationToken cancellationToken = default)
    {
        return new AsyncFineTuningJobEventCollectionResult(this, cancellationToken.ToRequestOptions(), options.PageSize, options.After);
    }

    /// <summary>
    /// Get status updates for a fine-tuning job.
    /// </summary>
    /// <param name="options"> Filter parameters via <see cref="ListEventsOptions"/>. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual CollectionResult<FineTuningJobEvent> GetJobEvents(ListEventsOptions options, CancellationToken cancellationToken = default)
    {
        return new FineTuningJobEventCollectionResult(this, cancellationToken.ToRequestOptions(), options.PageSize, options.After);
    }

    /// <summary>
    /// List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="options"> Filter parameters via <see cref="ListCheckpointsOptions"/>. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual AsyncCollectionResult<FineTuningJobCheckpoint> GetJobCheckpointsAsync(ListCheckpointsOptions? options = null, CancellationToken cancellationToken = default)
    {
        options ??= new ListCheckpointsOptions();
        return new AsyncFineTuningJobCheckpointCollectionResult(this, cancellationToken.ToRequestOptions(), options.PageSize, options.AfterCheckpointId);
    }

    /// <summary>
    /// List the checkpoints for a fine-tuning job.
    /// </summary>
    /// <param name="options"> Filter parameters via <see cref="ListCheckpointsOptions"/>. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual CollectionResult<FineTuningJobCheckpoint> GetJobCheckpoints(ListCheckpointsOptions? options = null, CancellationToken cancellationToken = default)
    {
        options ??= new ListCheckpointsOptions();
        return new FineTuningJobCheckpointCollectionResult(this, cancellationToken.ToRequestOptions(), options.PageSize, options.AfterCheckpointId);
    }

    /// <summary>
    /// Recreates a <see cref="FineTuningJobOperation"/> from a rehydration token.
    /// </summary>
    /// <param name="client"> The <see cref="FineTuningClient"/> used to obtain the operation status from the service. </param>
    /// <param name="rehydrationToken"> The rehydration token corresponding to the operation to rehydrate. </param>
    /// <param name="cancellationToken"> A token that can be used to cancel the request. </param>
    /// <returns> The rehydrated operation <see cref="FineTuningJobOperation"/>. </returns>
    /// <exception cref="ArgumentNullException"> <paramref name="client"/> or <paramref name="rehydrationToken"/> is null. </exception>
    public static FineTuningJobOperation Rehydrate(FineTuningClient client, ContinuationToken rehydrationToken, CancellationToken cancellationToken = default)
    {
        return Rehydrate(client, rehydrationToken, cancellationToken.ToRequestOptions());
    }


    /// <inheritdoc cref="Rehydrate(FineTuningClient, ContinuationToken, CancellationToken)"/>"
    public static async Task<FineTuningJobOperation> RehydrateAsync(FineTuningClient client, ContinuationToken rehydrationToken, CancellationToken cancellationToken = default)
    {
        return await RehydrateAsync(client, rehydrationToken, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
    }

    /// <summary>
    /// Recreates a <see cref="FineTuningJobOperation"/> from a fine tuning job id.
    /// </summary>
    /// <param name="client"> The <see cref="FineTuningClient"/> used to obtain the operation status from the service. </param>
    /// <param name="fineTuningJobId"> The id of the fine tuning job to rehydrate.</param>
    /// <param name="cancellationToken"> A token that can be used to cancel the request. </param>
    /// <returns> The rehydrated operation <see cref="FineTuningJobOperation"/>. </returns>
    public static FineTuningJobOperation Rehydrate(FineTuningClient client, string fineTuningJobId, CancellationToken cancellationToken = default)
    {
        return Rehydrate(client, fineTuningJobId, cancellationToken.ToRequestOptions());
    }

    /// <inheritdoc cref="Rehydrate(FineTuningClient, string, CancellationToken)" />
    public static async Task<FineTuningJobOperation> RehydrateAsync(FineTuningClient client, string fineTuningJobId, CancellationToken cancellationToken = default)
    {
        return await RehydrateAsync(client, fineTuningJobId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
    }


}