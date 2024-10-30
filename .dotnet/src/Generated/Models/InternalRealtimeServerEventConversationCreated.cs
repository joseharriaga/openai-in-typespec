// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeServerEventConversationCreated : ConversationUpdate
    {
        internal InternalRealtimeServerEventConversationCreated(string eventId, InternalRealtimeServerEventConversationCreatedConversation conversation) : base(eventId)
        {
            Argument.AssertNotNull(eventId, nameof(eventId));
            Argument.AssertNotNull(conversation, nameof(conversation));

            Kind = ConversationUpdateKind.ConversationCreated;
            Conversation = conversation;
        }

        internal InternalRealtimeServerEventConversationCreated(ConversationUpdateKind kind, string eventId, IDictionary<string, BinaryData> serializedAdditionalRawData, InternalRealtimeServerEventConversationCreatedConversation conversation) : base(kind, eventId, serializedAdditionalRawData)
        {
            Conversation = conversation;
        }

        internal InternalRealtimeServerEventConversationCreated()
        {
        }

        public InternalRealtimeServerEventConversationCreatedConversation Conversation { get; }
    }
}