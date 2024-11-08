using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
[CodeGenModel("RealtimeResponseCreatedCommand")]
public partial class ConversationResponseStartedResponse
{
    [CodeGenMember("Response")]
    internal readonly InternalRealtimeResponse _internalResponse;
}
