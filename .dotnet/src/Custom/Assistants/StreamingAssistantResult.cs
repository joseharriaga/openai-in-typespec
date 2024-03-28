using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Assistants;

#nullable enable

internal class StreamingAssistantResult : StreamingClientResult<StreamingUpdate>
{
    public StreamingAssistantResult(PipelineResponse response) : base(response)
    {
    }

    public override IAsyncEnumerator<StreamingUpdate> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        // Note: this implementation disposes the stream after the caller has
        // enumerated the elements obtained from the stream.  That is to say,
        // the `await foreach` loop can only happen once -- if it is tried a
        // second time, the caller will get an ObjectDisposedException trying
        // to access a disposed Stream.
        using PipelineResponse response = GetRawResponse();

        // Extract the content stream from the response to obtain dispose
        // ownership of it.  This means the content stream will not be disposed
        // when the response is disposed.
        Stream contentStream = response.ContentStream ?? throw new InvalidOperationException("Cannot enumerate null response ContentStream.");
        response.ContentStream = null;

        return new ChatUpdateEnumerator(contentStream);
    }

    private class ChatUpdateEnumerator : IAsyncEnumerator<StreamingUpdate>
    {
        private readonly IAsyncEnumerator<ServerSentEvent> _sseEvents;

        private List<StreamingUpdate>? _currentUpdates;
        private int _currentUpdateIndex;

        public ChatUpdateEnumerator(Stream stream)
        {
            AsyncSseReader reader = new AsyncSseReader(stream);

            // TODO: Pass CancellationToken.
            _sseEvents = reader.GetAsyncEnumerator();
        }

        public StreamingUpdate Current => throw new NotImplementedException();

        public async ValueTask<bool> MoveNextAsync()
        {
            // TODO: Can we wrap the boilerplate parts of this up into a special SSE base type for this?
            // would that be public/internal/instantiated based on configuration given to the
            // generator from the TSP?

            // Still have leftovers from the last event we pulled from the reader.
            if (_currentUpdates is not null && _currentUpdateIndex < _currentUpdates.Count)
            {
                _currentUpdateIndex++;
                return true;
            }

            // We either don't have any stored updates, or we've exceeded the
            // count of the ones we have.  Get the next set.

            // TODO: Call different configure await variant in this context, or no?
            if (!await _sseEvents.MoveNextAsync().ConfigureAwait(false))
            {
                // Done with events from the stream.
                return false;
            }

            ServerSentEvent ssEvent = _sseEvents.Current;

            // TODO: optimize
            BinaryData data = BinaryData.FromString(new string(ssEvent.Data.ToArray()));

            // TODO: don't instantiate every time.
            StreamingUpdateCollection justToCreate = new StreamingUpdateCollection();

            _currentUpdates = justToCreate.Create(data, ModelReaderWriterOptions.Json);
            _currentUpdateIndex = 0;

            return true;
        }

        public ValueTask DisposeAsync()
        {
            // TODO: revisit per platforms where async dispose is available.
            _sseEvents?.DisposeAsync();
            return new ValueTask();
        }
    }
}