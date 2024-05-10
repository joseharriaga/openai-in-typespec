using System;
using System.ClientModel;
using System.Collections.Generic;

namespace OpenAI.Chat;

// TODO: implement

internal class StreamingChatUpdateCollection : ClientResultCollection<StreamingChatUpdate>
{
    private readonly Func<ClientResult> _getResult;
    
    public StreamingChatUpdateCollection(Func<ClientResult> getResult) : base()
    {
        _getResult = getResult;
    }

    public override IEnumerator<StreamingChatUpdate> GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
