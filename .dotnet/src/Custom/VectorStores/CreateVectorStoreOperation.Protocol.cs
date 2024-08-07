using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.VectorStores;

public partial class CreateVectorStoreOperation : OperationResult
{
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;

    private readonly string _vectorStoreId;

    private PollingInterval? _pollingInterval;

    /// <inheritdoc/>
    public override ContinuationToken? RehydrationToken { get; protected set; }

    /// <inheritdoc/>
    public override bool IsCompleted { get; protected set; }

    /// <summary>
    /// [Protocol Method] Retrieves a vector store.
    /// </summary>
    /// <param name="vectorStoreId"> The ID of the vector store to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<ClientResult> GetVectorStoreAsync(string vectorStoreId, RequestOptions? options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        using PipelineMessage message = CreateGetVectorStoreRequest(vectorStoreId, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <summary>
    /// [Protocol Method] Retrieves a vector store.
    /// </summary>
    /// <param name="vectorStoreId"> The ID of the vector store to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult GetVectorStore(string vectorStoreId, RequestOptions? options)
    {
        Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

        using PipelineMessage message = CreateGetVectorStoreRequest(vectorStoreId, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    internal PipelineMessage CreateGetVectorStoreRequest(string vectorStoreId, RequestOptions? options)
    {
        var message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier200;
        var request = message.Request;
        request.Method = "GET";
        var uri = new ClientUriBuilder();
        uri.Reset(_endpoint);
        uri.AppendPath("/vector_stores/", false);
        uri.AppendPath(vectorStoreId, true);
        request.Uri = uri.ToUri();
        request.Headers.Set("Accept", "application/json");
        message.Apply(options);
        return message;
    }

    private static PipelineMessageClassifier? _pipelineMessageClassifier200;
    private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
}
