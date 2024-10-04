// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeServerEventConversationCreated : ConversationUpdate
    {
        internal InternalRealtimeServerEventConversationCreated(string eventId, InternalRealtimeServerEventConversationCreatedConversation conversation)
        {
            Argument.AssertNotNull(eventId, nameof(eventId));
            Argument.AssertNotNull(conversation, nameof(conversation));

            Kind = ConversationUpdateKind.ConversationCreated;
            EventId = eventId;
            Conversation = conversation;
        }

        internal InternalRealtimeServerEventConversationCreated(ConversationUpdateKind kind, IDictionary<string, BinaryData> serializedAdditionalRawData, string eventId, InternalRealtimeServerEventConversationCreatedConversation conversation) : base(kind, serializedAdditionalRawData)
        {
            EventId = eventId;
            Conversation = conversation;
        }

        internal InternalRealtimeServerEventConversationCreated()
        {
        }

        public string EventId { get; }
        public InternalRealtimeServerEventConversationCreatedConversation Conversation { get; }
    }
}