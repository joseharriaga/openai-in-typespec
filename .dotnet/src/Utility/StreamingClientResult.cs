using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;

namespace OpenAI;

/// <summary>
/// Represents an operation response with streaming content that can be deserialized and enumerated while the response
/// is still being received.
/// </summary>
/// <typeparam name="T"> The data type representative of distinct, streamable items. </typeparam>
public class StreamingClientResult<T>
    : IDisposable
    , IAsyncEnumerable<T>
{
    private readonly PipelineResponse _baseResponse;
    private readonly IAsyncEnumerable<T> _asyncEnumerable;
    private bool _disposedValue;

    /// <summary>
    /// Gets the underlying <see cref="PipelineResponse"/> that contains headers and other response-wide information.
    /// </summary>
    /// <returns>
    /// The <see cref="PipelineResponse"/> instance used in this <see cref="StreamingClientResult{T}"/>.
    /// </returns>
    public PipelineResponse GetRawResponse() => _baseResponse;

    private StreamingClientResult() { }

    private StreamingClientResult(
        PipelineResponse response,
        Func<Stream, IAsyncEnumerable<T>> asyncEnumerableProcessor)
    {
        _baseResponse = response;
        _asyncEnumerable = asyncEnumerableProcessor.Invoke(_baseResponse.ContentStream);
    }

    /// <summary>
    /// Creates a new instance of <see cref="StreamingClientResult{T}"/> that will yield items of the specified type
    /// <typeparamref name="T"/> as they become available via server-sent event JSON data on the available
    /// <see cref="PipelineResponse.ContentStream"/>. This overload supports deserializing multiple instaces of
    /// <typeparamref name="T"/> per server-sent event using the provided multi-element deserialization delegate.
    /// </summary>
    /// <param name="response"> The base <see cref="PipelineResponse"/> for this result instance. </param>
    /// <param name="multiElementJsonDeserializerFunc">
    /// The delegate that will be used to extract a collection of elements from each incoming JSON data payload.
    /// </param>
    /// <param name="cancellationToken">
    /// The optional cancellation token used to control the enumeration.
    /// </param>
    /// <returns> A new instance of <see cref="StreamingClientResult{T}"/>. </returns>
    public static StreamingClientResult<T> Create(
        PipelineResponse response,
        Func<JsonElement, IEnumerable<T>> multiElementJsonDeserializerFunc,
        CancellationToken cancellationToken = default)
    {
        return new(response, (stream)
            => EnumerateFromSseJsonStream(stream, multiElementJsonDeserializerFunc, cancellationToken));
    }

    /// <summary>
    /// Creates a new instance of <see cref="StreamingClientResult{T}"/> that will yield items of the specified type
    /// <typeparamref name="T"/> as they become available via server-sent event JSON data on the available
    /// <see cref="PipelineResponse.ContentStream"/>. This overload uses <see cref="ModelReaderWriter"/> via the
    /// <see cref="IJsonModel{T}"/> interface and only supports single-item deserialization per server-sent event data
    /// payload.
    /// </summary>
    /// <param name="response"> The base <see cref="PipelineResponse"/> for this result instance. </param>
    /// <param name="cancellationToken">
    /// The optional cancellation token used to control the enumeration.
    /// </param>
    /// <returns> A new instance of <see cref="StreamingClientResult{T}"/>. </returns>
    public static StreamingClientResult<U> Create<U>(
        PipelineResponse response,
        CancellationToken cancellationToken = default)
            where U : IJsonModel<U>
    {
        return new(response, (stream) => EnumerateFromSseJsonStream<U>(
            stream,
            (sseChunkElement) =>
            {
                BinaryData sseData = BinaryData.FromObjectAsJson(sseChunkElement.GetRawText());
                return [ModelReaderWriter.Read<U>(sseData)];
            },
            cancellationToken));
    }

    private static async IAsyncEnumerable<U> EnumerateFromSseJsonStream<U>(
        Stream contentStream,
        Func<JsonElement, IEnumerable<U>> multiElementJsonDeserializerFunc,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        try
        {
            using SseReader sseReader = new(contentStream);
            while (!cancellationToken.IsCancellationRequested)
            {
                ServerSentEvent? sseEvent = await sseReader
                    .TryGetNextEventAsync(cancellationToken)
                    .ConfigureAwait(false);
                if (sseEvent is null)
                {
                    break;
                }
                else
                {
                    if (IsWellKnownDoneToken(sseEvent.Value.Data)) continue;
                    using JsonDocument sseDocument = JsonDocument.Parse(sseEvent.Value.Data);
                    IEnumerable<U> sseDataItems = multiElementJsonDeserializerFunc.Invoke(sseDocument.RootElement);
                    foreach (U item in sseDataItems)
                    {
                        yield return item;
                    }
                }
            }
        }
        finally
        {
            // Always dispose the stream immediately once enumeration is complete for any reason
            contentStream.Dispose();
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc/>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _baseResponse?.Dispose();
            }
            _disposedValue = true;
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

    IAsyncEnumerator<T> IAsyncEnumerable<T>.GetAsyncEnumerator(CancellationToken cancellationToken)
        => _asyncEnumerable.GetAsyncEnumerator(cancellationToken);
}
