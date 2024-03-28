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
    private static ReadOnlyMemory<char>[] _wellKnownTokens =
        [
            "[DONE]".AsMemory(),
        ];

    internal static async IAsyncEnumerable<T> EnumerateFromSseJsonStream(
        Stream stream,
        Func<ReadOnlyMemory<char>, JsonElement, IEnumerable<T>> multiElementDeserializer,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        using AsyncSseReader reader = new AsyncSseReader(stream);

        await foreach (ServerSentEvent sseEvent in reader.GetEventsAsync(cancellationToken))
        {
            // TODO: does `continue` mean we keep reading from the Stream after
            // the [DONE] event?  If so, figure out if this is what we want here.
            if (IsWellKnownDoneToken(sseEvent.Data)) continue;

            // TODO: Make faster with Utf8JsonReader, IModel?
            using JsonDocument sseDocument = JsonDocument.Parse(sseEvent.Data);

            foreach (T item in multiElementDeserializer(sseEvent.EventName, sseDocument.RootElement))
            {
                yield return item;
            }
        }
    }

    private static bool IsWellKnownDoneToken(ReadOnlyMemory<char> data)
    {
        // TODO: Make faster than LINQ.
        return _wellKnownTokens.Any(token => data.Span.SequenceEqual(token.Span));
    }
}