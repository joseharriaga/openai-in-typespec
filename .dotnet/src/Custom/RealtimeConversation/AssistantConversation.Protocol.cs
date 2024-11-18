using System;
using System.ClientModel;
using System.ClientModel.Primitives.FullDuplexMessaging;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.RealtimeConversation;

public partial class AssistantConversation : DuplexConnectionResult
{
    private readonly ClientWebSocket? _clientWebSocket;

    private readonly SemaphoreSlim? _clientSendSemaphore = new(initialCount: 1, maxCount: 1);
    private readonly object? _singleReceiveLock = new();

    private AsyncWebsocketMessageCollectionResult? _receiveCollectionResult;

    //public Task ConfigureSessionAsync(BinaryContent content, DuplexRequestOptions? options = default)
    //{
    //    throw new NotImplementedException();
    //}

    //public void ConfigureSession(BinaryContent content, DuplexRequestOptions? options = default)
    //{
    //    throw new NotImplementedException();
    //}

    public Task CreateResponseAsync(BinaryContent content, DuplexRequestOptions? options = default)
    {
        throw new NotImplementedException();
    }

    public void CreateResponse(BinaryContent content, DuplexRequestOptions? options = default)
    {
        throw new NotImplementedException();
    }

    //// TODO: The client should open the connection when the session is created.
    ////       This method doesn't need to be exposed publicly.
    //internal virtual async Task ConnectAsync(RequestOptions options)
    //{
    //    await _clientWebSocket.ConnectAsync(_endpoint, options?.CancellationToken ?? default)
    //        .ConfigureAwait(false);
    //}

    //internal virtual void Connect(RequestOptions options)
    //{
    //    // TODO: we should avoid sync-over-async where we can.
    //    ConnectAsync(options).Wait();
    //}

    // TODO: What is the analog of a protocol method for a WebSocket subclient?
    //       Is it at this level - that you can send any message across the
    //       connection?
    // TODO: Do we want to enable sending arbitrary messages over the connection?
    //       If so, would this go on the base type?  Or would we recommend using
    //       the pipeline directly for that?  How would that work with the
    //       receive loop if using the pipeline directly was the story?
    //internal virtual Task SendCommandAsync(BinaryData data, RequestOptions options)
    //{
    //    throw new NotImplementedException();

    //    //Argument.AssertNotNull(data, nameof(data));

    //    //_parentClient?.RaiseOnSendingCommand(this, data);

    //    //ArraySegment<byte> messageBytes = new(data.ToArray());

    //    //CancellationToken cancellationToken = options?.CancellationToken ?? default;

    //    //await _clientSendSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
    //    //try
    //    //{
    //    //    await _clientWebSocket.SendAsync(
    //    //        messageBytes,
    //    //        WebSocketMessageType.Text, // TODO: extensibility for binary messages -- via "content"?
    //    //        endOfMessage: true,
    //    //        cancellationToken)
    //    //            .ConfigureAwait(false);
    //    //}
    //    //finally
    //    //{
    //    //    _clientSendSemaphore.Release();
    //    //}
    //}

    //internal virtual void SendCommand(BinaryData data, RequestOptions options)
    //{
    //    // ClientWebSocket does **not** include a synchronous Send()
    //    SendCommandAsync(data, options).Wait();
    //}

    //// TODO: since service response is exposed to end-users at the protocol layer,
    ////       we probably want a better name.  Should we have an equivalent of
    ////       ClientResult, e.g. that wraps a raw response?
    ////       Could the two-way service message inherit from PipelineResponse?
    ////       If it did, we could return ClientResult here and GetRawResponse
    ////       would return a websocket-specific subtype...
    //public virtual IAsyncEnumerable<DuplexClientResult> GetResponsesAsync()
    //{
    //    // TODO: is there an equivalent of RequestOptions for two-way pipeline?
    //    //       - we would need it for CancellationToken, modification of pipeline
    //    //         per message sent, e.g. ...

    //    throw new NotImplementedException();

    //    //lock (_singleReceiveLock)
    //    //{
    //    //    _receiveCollectionResult ??= new(_clientWebSocket, options?.CancellationToken ?? default);
    //    //}
    //    //await foreach (ClientResult result in _receiveCollectionResult)
    //    //{
    //    //    BinaryData incomingMessage = result?.GetRawResponse()?.Content;
    //    //    if (incomingMessage is not null)
    //    //    {
    //    //        _parentClient?.RaiseOnReceivingCommand(this, incomingMessage);
    //    //    }
    //    //    yield return result;
    //    //}
    //}

    //public virtual IEnumerable<DuplexClientResult> GetResponses()
    //{
    //    throw new NotImplementedException();
    //}

    // TODO: disposal moves to the base type
    //public void Dispose()
    //{
    //    _clientWebSocket?.Dispose();
    //}
}
