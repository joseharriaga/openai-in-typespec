using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
[CodeGenModel("RealtimeServerEventResponseCreated")]
public partial class ConversationResponseStartedUpdate
{
    [CodeGenMember("Response")]
    internal readonly InternalRealtimeResponse _internalResponse;
}
