// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeClientEventConversationItemDelete : InternalRealtimeClientEvent
    {
        public InternalRealtimeClientEventConversationItemDelete(string itemId)
        {
            Argument.AssertNotNull(itemId, nameof(itemId));

            Kind = InternalRealtimeClientEventType.ConversationItemDelete;
            ItemId = itemId;
        }

        internal InternalRealtimeClientEventConversationItemDelete(InternalRealtimeClientEventType kind, IDictionary<string, BinaryData> serializedAdditionalRawData, string eventId, string itemId) : base(kind, serializedAdditionalRawData)
        {
            EventId = eventId;
            ItemId = itemId;
        }

        internal InternalRealtimeClientEventConversationItemDelete()
        {
        }

        public string EventId { get; set; }
        public string ItemId { get; }
    }
}