// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeClientEventConversationItemDelete : InternalRealtimeClientEvent
    {
        public InternalRealtimeClientEventConversationItemDelete(string itemId) : base(InternalRealtimeClientEventType.ConversationItemDelete)
        {
            Argument.AssertNotNull(itemId, nameof(itemId));

            ItemId = itemId;
        }

        internal InternalRealtimeClientEventConversationItemDelete(string itemId, InternalRealtimeClientEventType kind, string eventId, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(kind, eventId, additionalBinaryDataProperties)
        {
            ItemId = itemId;
        }

        public string ItemId { get; }
    }
}
