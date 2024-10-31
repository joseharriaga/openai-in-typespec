// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeRequestAudioContentPart : ConversationContentPart
    {
        public InternalRealtimeRequestAudioContentPart() : base(ConversationContentPartKind.InputAudio)
        {
        }

        internal InternalRealtimeRequestAudioContentPart(string @type, string internalTranscriptValue, ConversationContentPartKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(kind, additionalBinaryDataProperties)
        {
            Type = @type;
            InternalTranscriptValue = internalTranscriptValue;
        }

        internal string Type { get; set; } = "input_audio";
    }
}
