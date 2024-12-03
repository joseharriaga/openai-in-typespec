using System.ClientModel;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.RealtimeConversation;

internal partial class AsyncWebsocketMessageCollectionResult : AsyncCollectionResult<ClientResult?>
{
    private readonly int _heartbeatms;
    private readonly WebSocket _webSocket;
    private readonly CancellationToken _cancellationToken;

    public AsyncWebsocketMessageCollectionResult(
        int heartbeatms,
        WebSocket webSocket,
        CancellationToken cancellationToken)
    {
        Argument.AssertNotNull(webSocket, nameof(webSocket));

        _heartbeatms = heartbeatms;
        _webSocket = webSocket;
        _cancellationToken = cancellationToken;
    }

    public override ContinuationToken? GetContinuationToken(ClientResult page)

        // Continuation is not supported for SSE streams.
        => null;

    public override async IAsyncEnumerable<ClientResult?> GetRawPagesAsync()
    {
        await using IAsyncEnumerator<ClientResult?> enumerator = new AsyncWebsocketMessageResultEnumerator(_heartbeatms, _webSocket, _cancellationToken);
        while (await enumerator.MoveNextAsync().ConfigureAwait(false))
        {
            yield return enumerator.Current;
        }
    }

    protected override async IAsyncEnumerable<ClientResult> GetValuesFromPageAsync(ClientResult page)
    {
        await Task.FromResult(Task.CompletedTask);
        yield return page;
    }
}
