using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
[CodeGenModel("RealtimeResponseItemCreatedCommand")]
public partial class ConversationItemAcknowledgedResponse
{
    [CodeGenMember("Item")]
    public ConversationItem Item { get; }
}
