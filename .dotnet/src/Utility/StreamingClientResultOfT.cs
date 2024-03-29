using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;

namespace OpenAI;

#pragma warning disable CS1591 // public XML comments

/// <summary>
/// Represents an operation response with streaming content that can be deserialized and enumerated while the response
/// is still being received.
/// </summary>
/// <typeparam name="T"> The data type representative of distinct, streamable items. </typeparam>
// TODO: Revisit the IDisposable question
public abstract class StreamingClientResult<T> : ClientResult, IAsyncEnumerable<T>
    // TODO: Note that constraining the T means the implementation can use
    // ModelReaderWriter for deserialization.
    where T : IPersistableModel<T>
{
    protected StreamingClientResult(PipelineResponse response) : base(response)
    {
    }

    // Note that if the implementation disposes the stream, the caller can only
    // enumerate the results once.  I think this makes sense, but we should
    // make sure architects agree.
    public abstract IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default);
}

#pragma warning restore CS1591 // public XML comments