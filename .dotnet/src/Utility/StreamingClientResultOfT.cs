using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI;

#pragma warning disable CS1591 // public XML comments

/// <summary>
/// Represents an operation response with streaming content that can be deserialized and enumerated while the response
/// is still being received.
/// </summary>
/// <typeparam name="T"> The data type representative of distinct, streamable items. </typeparam>
public abstract class StreamingClientResult<T> : IDisposable, IAsyncEnumerable<T>
{
    private ClientResult _rawResult { get; }
    private bool _disposedValue { get; set; }

    private StreamingClientResult() { }

    // TODO: Should constructor take PipelineResponse instead?
    protected StreamingClientResult(ClientResult rawResult)
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

    public abstract IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default);

}

#pragma warning restore CS1591 // public XML comments