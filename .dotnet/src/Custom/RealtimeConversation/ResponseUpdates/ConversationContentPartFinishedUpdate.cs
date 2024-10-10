using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

/// <summary>
/// The update (response command) of type <c>response.content_part.done</c>, which is received when a response turn
/// has completed emission of a content part within a conversation item. This will be preceded by a
/// <see cref="ConversationContentPartStartedUpdate"/> command (<c>response.content_part.added</c>) and some number of
/// <c>*delta</c> commands (e.g. <see cref="ConversationTextContentDeltaUpdate"/> or
/// <see cref="ConversationOutputTranscriptionDeltaUpdate"/>).
/// </summary>
[Experimental("OPENAI002")]
[CodeGenModel("RealtimeServerEventResponseContentPartDone")]
public partial class ConversationContentPartFinishedUpdate
{
    [CodeGenMember("Part")]
    private readonly ConversationContentPart _internalContentPart;

    public ConversationContentPartKind ContentPartKind => _internalContentPart switch
    {
        InternalRealtimeResponseTextContentPart => ConversationContentPartKind.InputText,
        InternalRealtimeResponseAudioContentPart => ConversationContentPartKind.InputAudio,
        _ => null,
    };

    public string Text => (_internalContentPart as InternalRealtimeResponseTextContentPart)?.Text;
    public string AudioTranscript => (_internalContentPart as InternalRealtimeResponseAudioContentPart)?.Transcript;
}
