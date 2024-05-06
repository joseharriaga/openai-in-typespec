namespace OpenAI.Batch;

[CodeGenModel("BatchStatus")]
public readonly partial struct BatchStatus {}

[CodeGenModel("BatchErrors")]
internal partial class InternalBatchErrors {}

[CodeGenModel("BatchRequestCounts")]
internal readonly partial struct InternalBatchRequestCounts {}

[CodeGenModel("ListBatchesResponse")]
internal partial class InternalListBatchesResponse {}

[CodeGenModel("ListBatchesResponseObject")]
internal readonly partial struct InternalListBatchesResponseObject {}
