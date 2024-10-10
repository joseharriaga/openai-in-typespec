using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

/// <summary>
/// The update (response command) of type <c>error</c>, which is received when a problem is encountered while
/// processing a request command or generating another response command.
/// </summary>
[Experimental("OPENAI002")]
[CodeGenModel("RealtimeServerEventError")]
public partial class ConversationErrorUpdate
{
    [CodeGenMember("Error")]
    private readonly InternalRealtimeServerEventErrorError _error;

    public string ErrorCode => _error?.Code;
    public string ErrorMessage => _error?.Message;
    public string ErrorParameterName => _error?.Param;
    public string ErrorEventId => _error?.EventId;
}