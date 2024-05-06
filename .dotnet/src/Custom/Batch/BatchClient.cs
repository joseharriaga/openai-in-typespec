using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenAI.Batch;

[CodeGenClient("Batches")]
[CodeGenSuppress("BatchClient", typeof(ClientPipeline), typeof(ApiKeyCredential), typeof(Uri))]
[CodeGenSuppress("CreateBatch", typeof(string), typeof(BatchOperationEndpoint), typeof(BatchCompletionTimeframe), typeof(IDictionary<string, string>))]
[CodeGenSuppress("CreateBatchAsync", typeof(string), typeof(BatchOperationEndpoint), typeof(BatchCompletionTimeframe), typeof(IDictionary<string, string>))]
[CodeGenSuppress("RetrieveBatch", typeof(string))]
[CodeGenSuppress("RetrieveBatchAsync", typeof(string))]
[CodeGenSuppress("RetrieveBatch", typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("RetrieveBatchAsync", typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("CancelBatch", typeof(string))]
[CodeGenSuppress("CancelBatchAsync", typeof(string))]
[CodeGenSuppress("GetBatches", typeof(string), typeof(int?))]
[CodeGenSuppress("GetBatchesAsync", typeof(string), typeof(int?))]
public partial class BatchClient
{
    /// <summary>
    /// Initializes a new instance of <see cref="BatchClient"/> that will use an API key when authenticating.
    /// </summary>
    /// <param name="credential"> The API key used to authenticate with the service endpoint. </param>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="ArgumentNullException"> The provided <paramref name="credential"/> was null. </exception>
    public BatchClient(ApiKeyCredential credential, OpenAIClientOptions options = null)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(credential, requireExplicitCredential: true), options),
              OpenAIClient.GetEndpoint(options),
              options) 
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="BatchClient"/> that will use an API key from the OPENAI_API_KEY
    /// environment variable when authenticating.
    /// </summary>
    /// <remarks>
    /// To provide an explicit credential instead of using the environment variable, use an alternate constructor like
    /// <see cref="BatchClient(ApiKeyCredential,OpenAIClientOptions)"/>.
    /// </remarks>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="InvalidOperationException"> The OPENAI_API_KEY environment variable was not found. </exception>
    public BatchClient(OpenAIClientOptions options = null)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(), options),
              OpenAIClient.GetEndpoint(options),
              options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="BatchClient"/>.
    /// </summary>
    /// <param name="pipeline"> The client pipeline to use. </param>
    /// <param name="endpoint"> The endpoint to use. </param>
    protected internal BatchClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
    }

    /// <summary> Creates and executes a batch from an uploaded file of requests. </summary>
    /// <param name="inputFileId">
    /// The ID of an uploaded file that contains requests for the new batch.
    ///
    /// See [upload file](/docs/api-reference/files/create) for how to upload a file.
    ///
    /// Your input file must be formatted as a [JSONL file](/docs/api-reference/batch/requestInput), and must be uploaded with the purpose `batch`.
    /// </param>
    /// <param name="endpoint"> The endpoint to be used for all requests in the batch. Currently `/v1/chat/completions` and `/v1/embeddings` are supported. </param>
    /// <param name="completionWindow"> The time frame within which the batch should be processed. Currently only `24h` is supported. </param>
    /// <param name="metadata"> Optional custom metadata for the batch. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="inputFileId"/> or <paramref name="endpoint"/> is null. </exception>
    /// <remarks> Create batch. </remarks>
    public virtual async Task<ClientResult<Batch>> CreateBatchAsync(string inputFileId, BatchOperationEndpoint endpoint, BatchCompletionTimeframe completionWindow, IDictionary<string, string> metadata = null)
    {
        Argument.AssertNotNull(inputFileId, nameof(inputFileId));
        Argument.AssertNotNull(endpoint, nameof(endpoint));

        InternalCreateBatchRequest internalCreateBatchRequest = new InternalCreateBatchRequest(inputFileId, endpoint, completionWindow, metadata ?? new ChangeTrackingDictionary<string, string>(), null);
        ClientResult result = await CreateBatchAsync(internalCreateBatchRequest.ToBinaryContent(), null).ConfigureAwait(false);
        return ClientResult.FromValue(Batch.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> Creates and executes a batch from an uploaded file of requests. </summary>
    /// <param name="inputFileId">
    /// The ID of an uploaded file that contains requests for the new batch.
    ///
    /// See [upload file](/docs/api-reference/files/create) for how to upload a file.
    ///
    /// Your input file must be formatted as a [JSONL file](/docs/api-reference/batch/requestInput), and must be uploaded with the purpose `batch`.
    /// </param>
    /// <param name="endpoint"> The endpoint to be used for all requests in the batch. Currently `/v1/chat/completions` and `/v1/embeddings` are supported. </param>
    /// <param name="completionWindow"> The time frame within which the batch should be processed. Currently only `24h` is supported. </param>
    /// <param name="metadata"> Optional custom metadata for the batch. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="inputFileId"/> or <paramref name="endpoint"/> is null. </exception>
    /// <remarks> Create batch. </remarks>
    public virtual ClientResult<Batch> CreateBatch(string inputFileId, BatchOperationEndpoint endpoint, BatchCompletionTimeframe completionWindow, IDictionary<string, string> metadata = null)
    {
        Argument.AssertNotNull(inputFileId, nameof(inputFileId));
        Argument.AssertNotNull(endpoint, nameof(endpoint));

        InternalCreateBatchRequest internalCreateBatchRequest = new InternalCreateBatchRequest(inputFileId, endpoint, completionWindow, metadata ?? new ChangeTrackingDictionary<string, string>(), null);
        ClientResult result = CreateBatch(internalCreateBatchRequest.ToBinaryContent(), null);
        return ClientResult.FromValue(Batch.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> List your organization's batches. </summary>
    /// <param name="previousId"> A cursor for use in pagination. `after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
    /// <param name="resultLimit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
    /// <remarks> List batches. </remarks>
    public virtual async Task<ListQueryPage<Batch>> GetBatchesAsync(
        string previousId = null,
        int? resultLimit = null)
    {
        ClientResult protocolResult = await GetBatchesAsync(previousId, resultLimit, (RequestOptions)null).ConfigureAwait(false);
        PipelineResponse rawResponse = protocolResult.GetRawResponse();
        ListQueryPage<Batch> batches = ListQueryPage<Batch>.FromResponse(rawResponse);
        return ClientResult.FromValue(batches, rawResponse);
    }

    /// <summary> List your organization's batches. </summary>
    /// <param name="previousId"> A cursor for use in pagination. `after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
    /// <param name="resultLimit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
    /// <remarks> List batches. </remarks>
    public virtual ListQueryPage<Batch> GetBatches(
        string previousId = null,
        int? resultLimit = null)
    {
        ClientResult protocolResult = GetBatches(previousId, resultLimit, (RequestOptions)null);
        PipelineResponse rawResponse = protocolResult.GetRawResponse();
        ListQueryPage<Batch> batches = ListQueryPage<Batch>.FromResponse(rawResponse);
        return ClientResult.FromValue(batches, rawResponse);
    }

    /// <summary> Retrieves a batch. </summary>
    /// <param name="batchId"> The ID of the batch to retrieve. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="batchId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="batchId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <remarks> Retrieve batch. </remarks>
    public virtual async Task<ClientResult<Batch>> GetBatchAsync(string batchId)
    {
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        ClientResult result = await GetBatchAsync(batchId, null).ConfigureAwait(false);
        return ClientResult.FromValue(Batch.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> Retrieves a batch. </summary>
    /// <param name="batchId"> The ID of the batch to retrieve. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="batchId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="batchId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <remarks> Retrieve batch. </remarks>
    public virtual ClientResult<Batch> GetBatch(string batchId)
    {
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        ClientResult result = GetBatch(batchId, null);
        return ClientResult.FromValue(Batch.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> Cancels an in-progress batch. </summary>
    /// <param name="batchId"> The ID of the batch to cancel. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="batchId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="batchId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <remarks> Cancel batch. </remarks>
    public virtual async Task<ClientResult<Batch>> CancelBatchAsync(string batchId)
    {
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        ClientResult result = await CancelBatchAsync(batchId, null).ConfigureAwait(false);
        return ClientResult.FromValue(Batch.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> Cancels an in-progress batch. </summary>
    /// <param name="batchId"> The ID of the batch to cancel. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="batchId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="batchId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <remarks> Cancel batch. </remarks>
    public virtual ClientResult<Batch> CancelBatch(string batchId)
    {
        Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

        ClientResult result = CancelBatch(batchId, null);
        return ClientResult.FromValue(Batch.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }
}
