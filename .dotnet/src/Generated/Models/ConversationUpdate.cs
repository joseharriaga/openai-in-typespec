// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public abstract partial class ConversationUpdate
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        protected ConversationUpdate(string eventId)
        {
            EventId = eventId;
        }

        internal ConversationUpdate(ConversationUpdateKind type, string eventId, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Type = type;
            EventId = eventId;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal ConversationUpdate()
        {
        }
        public string EventId { get; }
    }
}
