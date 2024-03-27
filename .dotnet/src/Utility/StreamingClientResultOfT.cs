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
    private bool _disposedValue { get; set; }

    private StreamingClientResult() { }

    private StreamingClientResult(ClientResult rawResult)
    {
        _rawResult = rawResult;
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
    {

    }
}