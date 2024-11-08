// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationItemTruncatedUpdate : ConversationResponse
    {
        internal ConversationItemTruncatedUpdate(string eventId, string itemId, int audioEndMs, int index) : base(eventId)
        {
            Argument.AssertNotNull(itemId, nameof(itemId));

            Kind = ConversationResponseKind.ItemTruncated;
            ItemId = itemId;
            AudioEndMs = audioEndMs;
            Index = index;
        }

        internal ConversationItemTruncatedUpdate(ConversationResponseKind kind, string eventId, IDictionary<string, BinaryData> serializedAdditionalRawData, string itemId, int audioEndMs, int index) : base(kind, eventId, serializedAdditionalRawData)
        {
            ItemId = itemId;
            AudioEndMs = audioEndMs;
            Index = index;
        }

        internal ConversationItemTruncatedUpdate()
        {
        }

        public string ItemId { get; }
        public int AudioEndMs { get; }
        public int Index { get; }
    }
}
