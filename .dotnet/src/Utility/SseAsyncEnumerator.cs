using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;

namespace OpenAI;

internal static class SseAsyncEnumerator<T>
{
    internal static async IAsyncEnumerable<ServerSentEvent> EnumerateServerSentEvents(
        Stream stream,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        try
        {
            using SseReader sseReader = new(stream);
            while (!cancellationToken.IsCancellationRequested)
            {
                ServerSentEvent? sseEvent = await sseReader.TryGetNextEventAsync(cancellationToken).ConfigureAwait(false);
                if (sseEvent is null)
                {
                    break;
                }
                else
                {
                    yield return sseEvent.Value;
                }
            }
        }
        finally
        {
            // Always dispose the stream immediately once enumeration is complete for any reason
            stream.Dispose();
        }
    }

    internal static async IAsyncEnumerable<T> EnumerateFromSseJsonStream(
        Stream stream,
        Func<ReadOnlyMemory<char>, JsonElement, IEnumerable<T>> multiElementDeserializer,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await foreach (ServerSentEvent sseEvent in EnumerateServerSentEvents(stream, cancellationToken))
        {
            if (IsWellKnownDoneToken(sseEvent.Data)) continue;
            using JsonDocument sseDocument = JsonDocument.Parse(sseEvent.Data);
            foreach (T item in multiElementDeserializer(sseEvent.EventName, sseDocument.RootElement))
            {
                yield return item;
            }
        }
    }

    private static bool IsWellKnownDoneToken(ReadOnlyMemory<char> data)
    {
        ReadOnlyMemory<char>[] wellKnownTokens =
        [
            "[DONE]".AsMemory(),
        ];
        return wellKnownTokens.Any(token => data.Span.SequenceEqual(token.Span));
    }
}