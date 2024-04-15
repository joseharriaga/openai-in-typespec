using System;
using System.Collections.Generic;

namespace OpenAI.Batch;

/// <summary>
/// Represents information about a batch operation.
/// </summary>
public partial class BatchInfo
{
    private Internal.Models.BatchResponse _internalResponse;

    /// <inheritdoc cref="Internal.Models.BatchResponse.Id"/>
    public string Id => _internalResponse.Id;

    /// <inheritdoc cref="Internal.Models.BatchResponse.Endpoint"/>
    public BatchOperationEndpoint Endpoint => _internalResponse.Endpoint;

    /// <inheritdoc cref="Internal.Models.BatchResponse.Errors"/>
    public IReadOnlyList<BatchErrorInfo> Errors { get; }

    /// <inheritdoc cref="Internal.Models.BatchResponse.InputFileId"/>
    public string InputFileId => _internalResponse.InputFileId;

    /// <inheritdoc cref="Internal.Models.BatchResponse.CompletionWindow"/>
    public BatchCompletionTimeframe CompletionTimeframe => _internalResponse.CompletionWindow;

    /// <inheritdoc cref="Internal.Models.BatchResponse.Status"/>
    public string Status => _internalResponse.Status;

    /// <inheritdoc cref="Internal.Models.BatchResponse.OutputFileId"/>
    public string OutputFileId => _internalResponse.OutputFileId;

    /// <inheritdoc cref="Internal.Models.BatchResponse.ErrorFileId"/>
    public string ErrorFileId => _internalResponse.ErrorFileId;

    /// <inheritdoc cref="Internal.Models.BatchResponse.CreatedAt"/>
    public DateTimeOffset CreatedAt => _internalResponse.CreatedAt;

    /// <inheritdoc cref="Internal.Models.BatchResponse.InProgressAt"/>
    public DateTimeOffset? InProgressAt => _internalResponse.InProgressAt;

    /// <inheritdoc cref="Internal.Models.BatchResponse.ExpiresAt"/>
    public DateTimeOffset? ExpiresAt => _internalResponse.ExpiresAt;

    /// <inheritdoc cref="Internal.Models.BatchResponse.FinalizingAt"/>
    public DateTimeOffset? FinalizingAt => _internalResponse.FinalizingAt;

    /// <inheritdoc cref="Internal.Models.BatchResponse.CompletedAt"/>
    public DateTimeOffset? CompletedAt => _internalResponse.CompletedAt;

    /// <inheritdoc cref="Internal.Models.BatchResponse.FailedAt"/>
    public DateTimeOffset? FailedAt => _internalResponse.FailedAt;

    /// <inheritdoc cref="Internal.Models.BatchResponse.ExpiredAt"/>
    public DateTimeOffset? ExpiredAt => _internalResponse.ExpiredAt;

    /// <inheritdoc cref="Internal.Models.BatchResponse.CancellingAt"/>
    public DateTimeOffset? CancellingAt => _internalResponse.CancellingAt;

    /// <inheritdoc cref="Internal.Models.BatchResponse.CancelledAt"/>
    public DateTimeOffset? CancelledAt => _internalResponse.CancelledAt;

    /// <inheritdoc cref="Internal.Models.BatchResponseRequestCounts.Total"/>
    public int TotalRequestCount { get; }

    /// <inheritdoc cref="Internal.Models.BatchResponseRequestCounts.Completed"/>
    public int CompletedRequestCount { get; }

    /// <inheritdoc cref="Internal.Models.BatchResponseRequestCounts.Failed"/>
    public int FailedRequestCount { get; }

    /// <inheritdoc cref="Internal.Models.BatchResponse.Metadata"/>
    public IReadOnlyDictionary<string, string> Metadata => _internalResponse.Metadata;

    internal BatchInfo(Internal.Models.BatchResponse internalResponse)
    {
        _internalResponse = internalResponse;

        List<BatchErrorInfo> errors = new();
        foreach (Internal.Models.BatchResponseErrorsDatum internalErrorDatum in internalResponse.Errors?.Data ?? [])
        {
            errors.Add(new(internalErrorDatum.Code, internalErrorDatum.Message, internalErrorDatum.Param, (int?)internalErrorDatum.Line));
        }
        Errors = errors;

        TotalRequestCount = (int)internalResponse.RequestCounts.Total;
        CompletedRequestCount = (int)internalResponse.RequestCounts.Completed;
        FailedRequestCount = (int)internalResponse.RequestCounts.Failed;
    }
}
