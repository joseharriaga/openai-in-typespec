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
        using SseReader reader = new SseReader(stream);

        await foreach (ServerSentEvent sseEvent in reader.GetEventsAsync(cancellationToken))
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
        // TODO: Make faster than LINQ.
        return _wellKnownTokens.Any(token => data.Span.SequenceEqual(token.Span));
    }
}