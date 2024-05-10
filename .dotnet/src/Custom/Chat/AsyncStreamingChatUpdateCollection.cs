using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.Chat;

internal class AsyncStreamingChatUpdateCollection : AsyncResultCollection<StreamingChatUpdate>
{
    private readonly Func<Task<ClientResult>> _getResultAsync;

    public AsyncStreamingChatUpdateCollection(Func<Task<ClientResult>> getResultAsync) : base()
    {
        Argument.AssertNotNull(getResultAsync, nameof(getResultAsync));

        _getResultAsync = getResultAsync;
    }

    public override IAsyncEnumerator<StreamingChatUpdate> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        return new AsyncStreamingChatUpdateEnumerator(_getResultAsync, this, cancellationToken);
    }

    private sealed class AsyncStreamingChatUpdateEnumerator : IAsyncEnumerator<StreamingChatUpdate>
    {
        private const string _terminalData = "[DONE]";

        private readonly Func<Task<ClientResult>> _getResultAsync;
        private readonly AsyncStreamingChatUpdateCollection _enumerable;
        private readonly CancellationToken _cancellationToken;

        // These enumerators represent what is effectively a doubly-nested
        // loop over the outer event collection and the inner update collection,
        // i.e.:
        //   foreach (var sse in _events) {
        //       // get _updates from sse event
        //       foreach (var update in _updates) { ... }
        //   }
        private IAsyncEnumerator<ServerSentEvent>? _events;
        private IEnumerator<StreamingChatUpdate>? _updates;

        private StreamingChatUpdate? _current;
        private bool _started;

        public AsyncStreamingChatUpdateEnumerator(Func<Task<ClientResult>> getResultAsync, AsyncStreamingChatUpdateCollection enumerable, CancellationToken cancellationToken)
        {
            Debug.Assert(getResultAsync is not null);
            Debug.Assert(enumerable is not null);

            _getResultAsync = getResultAsync!;
            _enumerable = enumerable!;
            _cancellationToken = cancellationToken;
        }

        StreamingChatUpdate IAsyncEnumerator<StreamingChatUpdate>.Current
            => _current!;

        async ValueTask<bool> IAsyncEnumerator<StreamingChatUpdate>.MoveNextAsync()
        {
            if (_events is null && _started)
            {
                throw new ObjectDisposedException(nameof(AsyncStreamingChatUpdateEnumerator));
            }

            _cancellationToken.ThrowIfCancellationRequested();
            _events ??= await CreateEventEnumeratorAsync().ConfigureAwait(false);
            _started = true;

            if (_updates is not null && _updates.MoveNext())
            {
                _current = _updates.Current;
                return true;
            }

            if (await _events.MoveNextAsync().ConfigureAwait(false))
            {
                if (_events.Current.Data == _terminalData)
                {
                    _current = default;
                    return false;
                }

                using JsonDocument doc = JsonDocument.Parse(_events.Current.Data);
                var updates = StreamingChatUpdate.DeserializeStreamingChatUpdates(doc.RootElement);
                _updates = updates.GetEnumerator();

                if (_updates.MoveNext())
                {
                    _current = _updates.Current;
                    return true;
                }
            }

            _current = default;
            return false;
        }

        private async Task<IAsyncEnumerator<ServerSentEvent>> CreateEventEnumeratorAsync()
        {
            ClientResult result = await _getResultAsync().ConfigureAwait(false);
            PipelineResponse response = result.GetRawResponse();
            _enumerable.SetRawResponse(response);

            if (response.ContentStream is null)
            {
                throw new ArgumentException("Unable to create result from response with null ContentStream", nameof(response));
            }

            AsyncServerSentEventEnumerable enumerable = new(response.ContentStream);
            return enumerable.GetAsyncEnumerator(_cancellationToken);
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore().ConfigureAwait(false);

            GC.SuppressFinalize(this);
        }

        private async ValueTask DisposeAsyncCore()
        {
            if (_events is not null)
            {
                await _events.DisposeAsync().ConfigureAwait(false);
                _events = null;

                // Dispose the response content stream so we don't leave the
                // unbuffered network stream open.
                PipelineResponse response = _enumerable.GetRawResponse();

                if (response.ContentStream is IAsyncDisposable asyncDisposable)
                {
                    await asyncDisposable.DisposeAsync().ConfigureAwait(false);
                }
                else if (response.ContentStream is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
        }
    }
}
