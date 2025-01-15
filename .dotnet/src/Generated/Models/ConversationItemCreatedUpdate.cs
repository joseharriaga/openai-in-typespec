// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationItemCreatedUpdate : ConversationUpdate
    {
        internal ConversationItemCreatedUpdate(string eventId, string previousItemId, InternalRealtimeResponseItem internalItem) : base(eventId, ConversationUpdateKind.ItemCreated)
        {
            PreviousItemId = previousItemId;
            _internalItem = internalItem;
        }

        internal ConversationItemCreatedUpdate(string eventId, ConversationUpdateKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties, string previousItemId, InternalRealtimeResponseItem internalItem) : base(eventId, kind, additionalBinaryDataProperties)
        {
            PreviousItemId = previousItemId;
            _internalItem = internalItem;
        }

        public string PreviousItemId { get; }
    }
}
