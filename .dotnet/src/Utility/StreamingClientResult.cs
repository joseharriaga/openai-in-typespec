using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
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
    private ClientResult _rawResult { get; }
    private IAsyncEnumerable<T> _asyncEnumerableSource { get; }
    private bool _disposedValue { get; set; }

    private StreamingClientResult() { }

    private StreamingClientResult(
        ClientResult rawResult,
        Func<ClientResult, IAsyncEnumerable<T>> asyncEnumerableProcessor)
    {
        _rawResult = rawResult;
        _asyncEnumerableSource = asyncEnumerableProcessor.Invoke(rawResult);
    }

    /// <summary>
    /// Creates a new instance of <see cref="StreamingClientResult{T}"/> using the provided underlying HTTP response. The
    /// provided function will be used to resolve the response into an asynchronous enumeration of streamed response
    /// items.
    /// </summary>
    /// <param name="result">The HTTP response.</param>
    /// <param name="asyncEnumerableProcessor">
    /// The function that will resolve the provided response into an IAsyncEnumerable.
    /// </param>
    /// <returns>
    /// A new instance of <see cref="StreamingClientResult{T}"/> that will be capable of asynchronous enumeration of
    /// <typeparamref name="T"/> items from the HTTP response.
    /// </returns>
    internal static StreamingClientResult<T> CreateFromResponse(
        ClientResult result,
        Func<ClientResult, IAsyncEnumerable<T>> asyncEnumerableProcessor)
    {
        return new(result, asyncEnumerableProcessor);
    }

    /// <summary>
    /// Gets the underlying <see cref="PipelineResponse"/> instance that this <see cref="StreamingClientResult{T}"/> may enumerate
    /// over.
    /// </summary>
    /// <returns> The <see cref="PipelineResponse"/> instance attached to this <see cref="StreamingClientResult{T}"/>. </returns>
    public PipelineResponse GetRawResponse() => _rawResult.GetRawResponse();

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
                _rawResult?.GetRawResponse()?.Dispose();
            }
            _disposedValue = true;
        }
    }

    IAsyncEnumerator<T> IAsyncEnumerable<T>.GetAsyncEnumerator(CancellationToken cancellationToken)
        => _asyncEnumerableSource.GetAsyncEnumerator(cancellationToken);
}