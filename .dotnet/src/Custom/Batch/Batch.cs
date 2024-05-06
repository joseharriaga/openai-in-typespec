using System.Collections.Generic;

namespace OpenAI.Batch;

[CodeGenModel("Batch")]
public partial class Batch
{
    // Customization: collapse intermediate layers for errors and request counts,
    // exposing the inner data directly
    
    [CodeGenMember("Errors")]
    private readonly InternalBatchErrors _internalErrors;

    [CodeGenMember("RequestCounts")]
    private readonly InternalBatchRequestCounts _internalRequestCounts;

    /// <summary> Gets the errors. </summary>
    public IReadOnlyList<BatchError> Errors => _internalErrors?.Data ?? [];

    /// <inheritdoc cref="InternalBatchRequestCounts.Completed"/>
    public int CompletedRequests => _internalRequestCounts.Completed;

    /// <inheritdoc cref="InternalBatchRequestCounts.Failed"/>
    public int FailedRequests => _internalRequestCounts.Failed;

    /// <inheritdoc cref="InternalBatchRequestCounts.Total"/>
    public int TotalRequests => _internalRequestCounts.Total;

    // Customization: internal visibility, as this property holds no additional utility in a
    // strongly-typed context.
    internal string Object { get; }
}
