using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI;

internal sealed class SseReader : IDisposable
{
    private readonly Stream _stream;
    private readonly StreamReader _reader;
    private bool _disposedValue;

    public SseReader(Stream stream)
    {
        _stream = stream;
        _reader = new StreamReader(stream);
    }

    public ServerSentEvent? TryGetNextEvent(CancellationToken cancellationToken = default)
    {
        List<ServerSentEventField> fields = [];

        while (!cancellationToken.IsCancellationRequested)
        {
            string line = _reader.ReadLine();
            if (line == null)
            {
                // A null line indicates end of input
                return null;
            }
            else if (line.Length == 0)
            {
                // An empty line should dispatch an event for pending accumulated fields
                ServerSentEvent nextEvent = new(fields);
                fields = [];
                return nextEvent;
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

        return null;
    }

    public async Task<ServerSentEvent?> TryGetNextEventAsync(CancellationToken cancellationToken = default)
    {
        List<ServerSentEventField> fields = [];

        while (!cancellationToken.IsCancellationRequested)
        {
            string line = await _reader.ReadLineAsync().ConfigureAwait(false);
            if (line == null)
            {
                // A null line indicates end of input
                return null;
            }
            else if (line.Length == 0)
            {
                // An empty line should dispatch an event for pending accumulated fields
                ServerSentEvent nextEvent = new(fields);
                fields = [];
                return nextEvent;
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

        return null;
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
}