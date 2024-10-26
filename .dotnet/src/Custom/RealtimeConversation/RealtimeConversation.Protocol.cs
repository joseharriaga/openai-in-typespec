using System;
using System.ClientModel.Primitives;
using System.ClientModel.Primitives.TwoWayClient;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.RealtimeConversation;

public partial class RealtimeConversation : TwoWayConnectionResult
{
    protected ClientWebSocket _clientWebSocket;

    private readonly SemaphoreSlim _clientSendSemaphore = new(initialCount: 1, maxCount: 1);
    private readonly object _singleReceiveLock = new();

    private AsyncWebsocketMessageCollectionResult _receiveCollectionResult;

    // TODO: The client should open the connection when the session is created.
    //       This method doesn't need to be exposed publicly.
    internal virtual async Task ConnectAsync(RequestOptions options)
    {
        _clientWebSocket.Options.AddSubProtocol("realtime");
        await _clientWebSocket.ConnectAsync(_endpoint, options?.CancellationToken ?? default)
            .ConfigureAwait(false);
    }

    internal virtual void Connect(RequestOptions options)
    {
        // TODO: we should avoid sync-over-async where we can.
        ConnectAsync(options).Wait();
    }

    // TODO: What is the analog of a protocol method for a WebSocket subclient?
    //       Is it at this level - that you can send any message across the
    //       connection?
    public virtual async Task SendCommandAsync(BinaryData data, RequestOptions options)
    {
        Argument.AssertNotNull(data, nameof(data));

        _parentClient?.RaiseOnSendingCommand(this, data);

        ArraySegment<byte> messageBytes = new(data.ToArray());

        CancellationToken cancellationToken = options?.CancellationToken ?? default;

        await _clientSendSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            await _clientWebSocket.SendAsync(
                messageBytes,
                WebSocketMessageType.Text, // TODO: extensibility for binary messages -- via "content"?
                endOfMessage: true,
                cancellationToken)
                    .ConfigureAwait(false);
        }
        finally
        {
            _clientSendSemaphore.Release();
        }
    }

    public virtual void SendCommand(BinaryData data, RequestOptions options)
    {
        // ClientWebSocket does **not** include a synchronous Send()
        SendCommandAsync(data, options).Wait();
    }

    //// TODO: since service response is exposed to end-users at the protocol layer,
    ////       we probably want a better name.  Should we have an equivalent of
    ////       ClientResult, e.g. that wraps a raw response?
    ////       Could the two-way service message inherit from PipelineResponse?
    ////       If it did, we could return ClientResult here and GetRawResponse
    ////       would return a websocket-specific subtype...
    //public virtual IAsyncEnumerable<TwoWayResult> GetResponsesAsync()
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

    //public virtual IEnumerable<TwoWayResult> GetResponses()
    //{
    //    throw new NotImplementedException();
    //}

    // TODO: disposal moves to the base type
    //public void Dispose()
    //{
    //    _clientWebSocket?.Dispose();
    //}
}
