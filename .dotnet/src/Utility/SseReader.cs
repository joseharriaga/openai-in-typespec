using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI;

#nullable enable

// TODO: Can this type move its Dispose implementation into the 
// Enumerator?
internal sealed class AsyncSseReader : IAsyncEnumerable<ServerSentEvent>, IDisposable, IAsyncDisposable
{
    private readonly Stream _stream;
    
    private bool _disposedValue;

    public AsyncSseReader(Stream stream)
    {
        _stream = stream;
    }

    // TODO: Provide sync version
    //// TODO: reuse code across sync and async.

    ///// <summary>
    ///// Synchronously retrieves the next server-sent event from the underlying stream, blocking until a new event is
    ///// available and returning null once no further data is present on the stream.
    ///// </summary>
    ///// <param name="cancellationToken"> An optional cancellation token that can abort subsequent reads. </param>
    ///// <returns>
    /////     The next <see cref="ServerSentEvent"/> in the stream, or null once no more data can be read from the stream.
    ///// </returns>
    //public IEnumerable<ServerSentEvent> GetEvents(CancellationToken cancellationToken = default)
    //{
    //    List<ServerSentEventField> fields = [];

    //    while (!cancellationToken.IsCancellationRequested)
    //    {
    //        string line = _reader.ReadLine();
    //        if (line == null)
    //        {
    //            // A null line indicates end of input
    //            yield break;
    //        }
    //        else if (line.Length == 0)
    //        {
    //            // An empty line should dispatch an event for pending accumulated fields
    //            ServerSentEvent nextEvent = new(fields);
    //            fields = [];
    //            yield return nextEvent;
    //        }
    //        else if (line[0] == ':')
    //        {
    //            // A line beginning with a colon is a comment and should be ignored
    //            continue;
    //        }
    //        else
    //        {
    //            // Otherwise, process the the field + value and accumulate it for the next dispatched event
    //            fields.Add(new ServerSentEventField(line));
    //        }
    //    }

    //    yield break;
    //}

    ///// <summary>
    ///// Asynchronously retrieves the next server-sent event from the underlying stream, blocking until a new event is
    ///// available and returning null once no further data is present on the stream.
    ///// </summary>
    ///// <param name="cancellationToken"> An optional cancellation token that can abort subsequent reads. </param>
    ///// <returns>
    /////     The next <see cref="ServerSentEvent"/> in the stream, or null once no more data can be read from the stream.
    ///// </returns>
    //public async IAsyncEnumerable<ServerSentEvent> GetEventsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    //{
    //    List<ServerSentEventField> fields = [];

    //    while (!cancellationToken.IsCancellationRequested)
    //    {
    //        string line = await _reader.ReadLineAsync().ConfigureAwait(false);
    //        if (line == null)
    //        {
    //            // A null line indicates end of input
    //            yield break;
    //        }
    //        else if (line.Length == 0)
    //        {
    //            // An empty line should dispatch an event for pending accumulated fields
    //            ServerSentEvent nextEvent = new(fields);
    //            fields = [];
    //            yield return nextEvent;
    //        }
    //        else if (line[0] == ':')
    //        {
    //            // A line beginning with a colon is a comment and should be ignored
    //            continue;
    //        }
    //        else
    //        {
    //            // Otherwise, process the the field + value and accumulate it for the next dispatched event
    //            fields.Add(new ServerSentEventField(line));
    //        }
    //    }

    //    yield break;
    //}

    public IAsyncEnumerator<ServerSentEvent> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        return new AsyncSseReaderEnumerator(_stream);
    }

    private class AsyncSseReaderEnumerator : IAsyncEnumerator<ServerSentEvent>
    {
        private readonly Stream _stream;
        private readonly StreamReader _reader;

        private ServerSentEvent? _current;

        public AsyncSseReaderEnumerator(Stream stream)
        {
            _stream = stream;
            _reader = new StreamReader(stream);
        }

        // TODO: recall proper semantics for Current and fix null issues.
        public ServerSentEvent Current => _current!.Value;

        public async ValueTask<bool> MoveNextAsync()
        {
            // TODO: don't reallocate every call to MoveNext
            // TODO: UTF-8 all the way down possible here?
            List<ServerSentEventField> fields = [];

            // TODO: How to handle the CancellationToken?

            // TODO: Call different ConfigureAwait variant in this context, or no?
            while (true)
            {
                string line = await _reader.ReadLineAsync().ConfigureAwait(false);

                if (line == null)
                {
                    // A null line indicates end of input
                    return false;
                }

                // TODO: another way to rework this for perf, clarity, or is
                // this optimal?
                else if (line.Length == 0)
                {
                    // An empty line should dispatch an event for pending accumulated fields
                    ServerSentEvent nextEvent = new(fields);
                    fields = [];
                    _current = nextEvent;
                    return true;
                }
                else if (line[0] == ':')
                {
                    // A line beginning with a colon is a comment and should be ignored
                    continue;
                }
                else
                {
                    // Otherwise, process the the field + value and accumulate it for the next dispatched event
                    fields.Add(new ServerSentEventField(line));
                }
            }
        }

        public ValueTask DisposeAsync()
        {
            // TODO: revisit per platforms where async dispose is available.
            _stream?.Dispose();
            _reader?.Dispose();
            return new ValueTask();
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _stream.Dispose();
            }

            _disposedValue = true;
        }
    }

    ValueTask IAsyncDisposable.DisposeAsync()
    {
        // TODO: revisit per platforms where async dispose is available.
        return new ValueTask();
    }
}