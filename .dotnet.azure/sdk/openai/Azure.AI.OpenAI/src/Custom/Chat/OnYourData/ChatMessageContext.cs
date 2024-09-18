using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureChatMessageContext")]
public partial class ChatMessageContext
{
    /// <summary> Summary information about documents retrieved by the data retrieval operation. </summary>
    [CodeGenMember("AllRetrievedDocuments")]
    public ChatRetrievedDocument RetrievedDocuments { get; }
}
