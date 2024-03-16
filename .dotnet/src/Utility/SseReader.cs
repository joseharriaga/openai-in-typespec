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

    public SseEvent? TryGetNextEvent()
    {
        List<SseEventField> fields = [];

        while (true)
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
                SseEvent nextEvent = new(fields);
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
                fields.Add(new SseEventField(line));
            }
        }
    }

    public async Task<SseEvent?> TryGetNextEventAsync(CancellationToken cancellationToken = default)
    {
        List<SseEventField> fields = [];

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
                SseEvent nextEvent = new(fields);
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
                fields.Add(new SseEventField(line));
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