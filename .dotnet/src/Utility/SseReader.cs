using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI;

internal sealed class SseReader : IDisposable, IAsyncDisposable
{
    private readonly Stream _stream;
    private readonly StreamReader _reader;
    private bool _disposedValue;

    public SseReader(Stream stream)
    {
        _stream = stream;
        _reader = new StreamReader(stream);
    }

    /// <summary>
    /// Synchronously retrieves the next server-sent event from the underlying stream, blocking until a new event is
    /// available and returning null once no further data is present on the stream.
    /// </summary>
    /// <param name="cancellationToken"> An optional cancellation token that can abort subsequent reads. </param>
    /// <returns>
    ///     The next <see cref="ServerSentEvent"/> in the stream, or null once no more data can be read from the stream.
    /// </returns>
    public IEnumerable<ServerSentEvent> GetEvents(CancellationToken cancellationToken = default)
    {
        List<ServerSentEventField> fields = [];

        while (!cancellationToken.IsCancellationRequested)
        {
            string line = _reader.ReadLine();
            if (line == null)
            {
                // A null line indicates end of input
                yield break;
            }
            else if (line.Length == 0)
            {
                // An empty line should dispatch an event for pending accumulated fields
                ServerSentEvent nextEvent = new(fields);
                fields = [];
                yield return nextEvent;
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

        yield break;
    }

    /// <summary>
    /// Asynchronously retrieves the next server-sent event from the underlying stream, blocking until a new event is
    /// available and returning null once no further data is present on the stream.
    /// </summary>
    /// <param name="cancellationToken"> An optional cancellation token that can abort subsequent reads. </param>
    /// <returns>
    ///     The next <see cref="ServerSentEvent"/> in the stream, or null once no more data can be read from the stream.
    /// </returns>
    public async IAsyncEnumerable<ServerSentEvent> GetEventsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        List<ServerSentEventField> fields = [];

        while (!cancellationToken.IsCancellationRequested)
        {
            string line = await _reader.ReadLineAsync().ConfigureAwait(false);
            if (line == null)
            {
                // A null line indicates end of input
                yield break;
            }
            else if (line.Length == 0)
            {
                // An empty line should dispatch an event for pending accumulated fields
                ServerSentEvent nextEvent = new(fields);
                fields = [];
                yield return nextEvent;
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

        yield break;
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
                _reader.Dispose();
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