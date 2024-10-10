using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

/// <summary>
/// The update (response command) of type <c>response.content_part.added</c>, which is received when a response turn
/// has begun emission of a content part within a conversation item. This will be followed by some number of
/// <c>*delta</c> commands (e.g. <see cref="ConversationTextDeltaUpdate"/> or
/// <see cref="ConversationOutputTranscriptionDeltaUpdate"/>) before finalization via a
/// <see cref="ConversationContentPartFinishedUpdate"/> command (<c>response.content_part.done</c>).
/// </summary>
[Experimental("OPENAI002")]
[CodeGenModel("RealtimeServerEventResponseContentPartAdded")]
public partial class ConversationContentPartStartedUpdate
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
