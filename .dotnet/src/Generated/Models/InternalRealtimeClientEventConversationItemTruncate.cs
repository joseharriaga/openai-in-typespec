// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeClientEventConversationItemTruncate : InternalRealtimeClientEvent
    {
        public InternalRealtimeClientEventConversationItemTruncate(string itemId, int contentIndex, int audioEndMs) : base(InternalRealtimeClientEventType.ConversationItemTruncate)
        {
            Argument.AssertNotNull(itemId, nameof(itemId));

            ItemId = itemId;
            ContentIndex = contentIndex;
            AudioEndMs = audioEndMs;
        }

        internal InternalRealtimeClientEventConversationItemTruncate(string eventId, string itemId, int contentIndex, int audioEndMs, InternalRealtimeClientEventType kind, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(kind, eventId, additionalBinaryDataProperties)
        {
            ItemId = itemId;
            ContentIndex = contentIndex;
            AudioEndMs = audioEndMs;
        }

        public new string EventId
        {
            get => _eventId ?? default;
            set => _eventId = value;
        }

        public string ItemId { get; set; }

        public int ContentIndex { get; set; }

        public int AudioEndMs { get; set; }
    }
}
