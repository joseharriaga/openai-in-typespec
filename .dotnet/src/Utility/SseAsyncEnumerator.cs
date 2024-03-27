using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;

namespace OpenAI;

internal static class SseAsyncEnumerator<T>
{
    internal static async IAsyncEnumerable<T> EnumerateFromSseStream(
        Stream stream,
        Func<JsonElement, IEnumerable<T>> multiElementDeserializer,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        try
        {
            using SseReader sseReader = new(stream);
            while (!cancellationToken.IsCancellationRequested)
            {

                
            }
        }
        finally
        {
            // Always dispose the stream immediately once enumeration is complete for any reason
            stream.Dispose();
        }
    }
}