using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenAI.Batch;

/// <summary> The service client for OpenAI batch operations. </summary>
public partial class BatchClient
{
    private readonly OpenAIClientConnector _clientConnector;
    private Internal.Batch Shim => _clientConnector.InternalClient.GetBatchClient();

    /// <summary>
    /// Initializes a new instance of <see cref="BatchClient"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    ///     If an endpoint is not provided, the client will use the <c>OPENAI_ENDPOINT</c> environment variable if it
    ///     defined and otherwise use the default OpenAI v1 endpoint.
    /// </para>
    /// <para>
    ///    If an authentication credential is not defined, the client use the <c>OPENAI_API_KEY</c> environment variable
    ///    if it is defined.
    /// </para>
    /// </remarks>
    /// <param name="credential">The API key used to authenticate with the service endpoint.</param>
    /// <param name="options">Additional options to customize the client.</param>
    public BatchClient(ApiKeyCredential credential = default, OpenAIClientOptions options = null)
    {
        _clientConnector = new(model: null, credential, options);
    }

    /// <summary>
    /// Creates a new batch operation.
    /// </summary>
    /// <param name="inputFileId"> The previously uploaded ID of a file, in JSON-L format, to use as batch input. </param>
    /// <param name="endpoint"> The API endpoint to use for the batch. </param>
    /// <param name="completionTimeframe"> The completion timeframe to request for the batch operation. </param>
    /// <param name="metadata"> An optional set of metadata for the batch operation. </param>
    /// <returns> The created batch operation information. </returns>
    public virtual ClientResult<BatchInfo> CreateBatch(
        string inputFileId,
        BatchOperationEndpoint endpoint,
        BatchCompletionTimeframe completionTimeframe,
        IDictionary<string, string> metadata = null)
    {
        Internal.Models.CreateBatchRequest internalRequest = new(
            inputFileId,
            endpoint.ToString(),
            completionTimeframe.ToString(),
            metadata,
            serializedAdditionalRawData: null);
        ClientResult<Internal.Models.BatchResponse> internalResponse = Shim.CreateBatch(internalRequest);
        return ClientResult.FromValue(new BatchInfo(internalResponse.Value), internalResponse.GetRawResponse());
    }

    /// <summary>
    /// Creates a new batch operation.
    /// </summary>
    /// <param name="inputFileId"> The previously uploaded ID of a file, in JSON-L format, to use as batch input. </param>
    /// <param name="endpoint"> The API endpoint to use for the batch. </param>
    /// <param name="completionTimeframe"> The completion timeframe to request for the batch operation. </param>
    /// <param name="metadata"> An optional set of metadata for the batch operation. </param>
    /// <returns> The created batch operation information. </returns>
    public virtual async Task<ClientResult<BatchInfo>> CreateBatchAsync(
        string inputFileId,
        BatchOperationEndpoint endpoint,
        BatchCompletionTimeframe completionTimeframe,
        IDictionary<string, string> metadata = null)
    {
        Internal.Models.CreateBatchRequest internalRequest = new(
            inputFileId,
            endpoint.ToString(),
            completionTimeframe.ToString(),
            metadata,
            serializedAdditionalRawData: null);
        ClientResult<Internal.Models.BatchResponse> internalResponse = await Shim.CreateBatchAsync(internalRequest).ConfigureAwait(false);
        return ClientResult.FromValue(new BatchInfo(internalResponse.Value), internalResponse.GetRawResponse());
    }

    /// <summary>
    /// Gets information about a previously created batch operation.
    /// </summary>
    /// <param name="batchId"> The ID of the batch operation to retrieve information about. </param>
    /// <returns> The requested batch operation information. </returns>
    public virtual ClientResult<BatchInfo> GetBatch(string batchId)
    {
        ClientResult<Internal.Models.BatchResponse> internalResponse = Shim.RetrieveBatch(batchId);
        return ClientResult.FromValue(new BatchInfo(internalResponse.Value), internalResponse.GetRawResponse());
    }

    /// <summary>
    /// Gets information about a previously created batch operation.
    /// </summary>
    /// <param name="batchId"> The ID of the batch operation to retrieve information about. </param>
    /// <returns> The requested batch operation information. </returns>
    public virtual async Task<ClientResult<BatchInfo>> GetBatchAsync(string batchId)
    {
        ClientResult<Internal.Models.BatchResponse> internalResponse = await Shim.RetrieveBatchAsync(batchId).ConfigureAwait(false);
        return ClientResult.FromValue(new BatchInfo(internalResponse.Value), internalResponse.GetRawResponse());
    }

    /// <summary>
    /// Cancels an in-progress batch operation.
    /// </summary>
    /// <param name="batchId"> The ID of the batch operation to cancel. </param>
    public virtual void CancelBatch(string batchId)
    {
        _ = Shim.CancelBatch(batchId);
    }

    /// <summary>
    /// Cancels an in-progress batch operation.
    /// </summary>
    /// <param name="batchId"> The ID of the batch operation to cancel. </param>
    public virtual async Task CancelBatchAsync(string batchId)
    {
        _ = await Shim.CancelBatchAsync(batchId).ConfigureAwait(false);
    }
}
