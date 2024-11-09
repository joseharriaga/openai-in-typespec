using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

/// <summary>
/// The update (response command) of type <c>response.done</c>, which is received when a model response turn has
/// completed and no further content part or item information will be transmitted.
/// </summary>
[Experimental("OPENAI002")]
[CodeGenModel("RealtimeServerEventResponseDone")]
public partial class ConversationResponseFinishedUpdate
{
    [CodeGenMember("Response")]
    internal readonly InternalRealtimeResponse _internalResponse;

    public string ResponseId => _internalResponse?.Id;

    public ConversationResponseStatus Status => _status ??= new(_internalResponse.Status, _internalResponse.StatusDetails);
    private ConversationResponseStatus _status;

    [CodeGenMember("Output")]
    public IReadOnlyList<ConversationItem> CreatedItems => _internalResponse?.Output ?? [];

    public ConversationTokenUsage Usage => _internalResponse.Usage;
}
