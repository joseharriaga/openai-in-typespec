using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;

namespace OpenAI.Chat;

// TODO: implement

internal class AsyncStreamingChatUpdateCollection : AsyncClientResultCollection<StreamingChatUpdate>
{
    // TODO: pass 
    public AsyncStreamingChatUpdateCollection(PipelineResponse response, CancellationToken cancellationToken) : base(response)
    {
    }

    public override IAsyncEnumerator<StreamingChatUpdate> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
