using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
[CodeGenModel("RealtimeContentPart")]
public partial class ConversationContentPart
{
    public string Text =>
        (this as InternalRealtimeRequestTextContentPart)?.InternalTextValue
        ?? (this as InternalRealtimeResponseTextContentPart)?.InternalTextValue;

    public string AudioTranscript =>
        (this as InternalRealtimeRequestAudioContentPart)?.InternalTranscriptValue
        ?? (this as InternalRealtimeResponseAudioContentPart)?.InternalTranscriptValue;

    public static ConversationContentPart FromInputText(string text)
        => new InternalRealtimeRequestTextContentPart(text, ConversationContentPartKind.Text);
    public static ConversationContentPart FromInputAudioTranscript(string transcript = null) => new InternalRealtimeRequestAudioContentPart()
    {
        Transcript = transcript,
    };
    public static ConversationContentPart FromOutputText(string text)
        => new InternalRealtimeResponseTextContentPart(text, ConversationContentPartKind.Text);
    public static ConversationContentPart FromOutputAudioTranscript(string transcript = null)
        => new InternalRealtimeResponseAudioContentPart(transcript, ConversationContentPartKind.Audio);

    public static implicit operator ConversationContentPart(string text) => FromInputText(text);
}