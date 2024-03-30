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
internal class StreamingEventResult<T> : StreamingClientResult<T>
{
    private IAsyncEnumerable<T> _asyncEnumerableSource { get; }
    
    private StreamingEventResult(PipelineResponse response,
        Func<PipelineResponse, IAsyncEnumerable<T>> asyncEnumerableProcessor) 
        : base(response) 
    {
        _asyncEnumerableSource = asyncEnumerableProcessor.Invoke(response);
    }

    internal static StreamingEventResult<T> CreateFromResponse(
        PipelineResponse response,
        Func<PipelineResponse, IAsyncEnumerable<T>> asyncEnumerableProcessor)
    {
        return new(response, asyncEnumerableProcessor);
    }

    // TODO: Handle disposal via Enumerator?  Validate that this will work.
    // If it doesn't, we likely need to implement IDisposable or IAsyncDisposable
    // on StreamingClientResult<T>.

    public override IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        => _asyncEnumerableSource.GetAsyncEnumerator(cancellationToken);
}
