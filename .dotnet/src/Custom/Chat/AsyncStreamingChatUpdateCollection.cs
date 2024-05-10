using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Chat;

// TODO: implement

internal class AsyncStreamingChatUpdateCollection : AsyncClientResultCollection<StreamingChatUpdate>
{
    private readonly Func<Task<ClientResult>> _getResultAsync;

    public AsyncStreamingChatUpdateCollection(Func<Task<ClientResult>> getResultAsync) : base()
    {
        _getResultAsync = getResultAsync;
    }

    public override IAsyncEnumerator<StreamingChatUpdate> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
