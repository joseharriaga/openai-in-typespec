using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Chat;

#nullable enable

internal class StreamingChatResult : StreamingClientResult<StreamingChatUpdate>
{
    public StreamingChatResult(ClientResult result) : base(result)
    {

    }

    public override IAsyncEnumerator<StreamingChatUpdate> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }


    private class StreamingClientResultEnumerator : IAsyncEnumerator<StreamingChatUpdate>
    {
        private readonly SseReader _sseReader;

        private List<StreamingChatUpdate>? _currentUpdates;
        private int _currentUpdateIndex;

        public StreamingClientResultEnumerator(Stream stream)
        {
            _sseReader = new(stream);
        }

        public StreamingChatUpdate Current => throw new NotImplementedException();

        public async ValueTask<bool> MoveNextAsync()
        {
            // TODO: How to handle the CancellationToken?

            if (_currentUpdates is not null && _currentUpdateIndex < _currentUpdates.Count)
            {
                _currentUpdateIndex++;
                return true;
            }

            // We either don't have any stored updates, or we've exceeded the
            // count of the ones we have.  Get the next set.

            // TODO: Call different configure await variant in this context, or no?
            SseLine? sseEvent = await _sseReader.TryReadSingleFieldEventAsync().ConfigureAwait(false);
            if (sseEvent is null)
            {
                // TODO: does this mean we're done or not?
                return false;
            }

            ReadOnlyMemory<char> name = sseEvent.Value.FieldName;
            if (!name.Span.SequenceEqual("data".AsSpan()))
            {
                throw new InvalidDataException();
            }

            ReadOnlyMemory<char> value = sseEvent.Value.FieldValue;
            if (value.Span.SequenceEqual("[DONE]".AsSpan()))
            {
                // enumerator semantics are that MoveNextAsync returns false when done.
                return false;
            }

            // TODO:optimize performance using Utf8JsonReader?
            using JsonDocument sseMessageJson = JsonDocument.Parse(value);
            _currentUpdates = StreamingChatUpdate.DeserializeStreamingChatUpdates(sseMessageJson.RootElement);
            return true;
        }

        public ValueTask DisposeAsync()
        {
            // TODO: revisit per platforms where async dispose is available.
            _sseReader?.Dispose();
            return new ValueTask();
        }
    }
}
