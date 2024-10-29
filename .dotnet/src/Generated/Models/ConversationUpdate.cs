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
            Argument.AssertNotNull(eventId, nameof(eventId));

            EventId = eventId;
        }

        internal ConversationUpdate(ConversationUpdateKind kind, string eventId, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Kind = kind;
            EventId = eventId;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal ConversationUpdate()
        {
        }
        public string EventId { get; }
    }
}
