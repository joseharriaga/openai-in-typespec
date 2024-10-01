// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationInputAudioBufferClearedUpdate : ConversationUpdate
    {
        internal ConversationInputAudioBufferClearedUpdate(string eventId) : base(eventId)
        {
            Type = ConversationUpdateKind.InputAudioBufferCleared;
        }

        internal ConversationInputAudioBufferClearedUpdate(ConversationUpdateKind type, string eventId, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(type, eventId, serializedAdditionalRawData)
        {
        }

        internal ConversationInputAudioBufferClearedUpdate()
        {
        }
    }
}
