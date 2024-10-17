// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationItemStartedUpdate : ConversationUpdate
    {
        internal ConversationItemStartedUpdate(string responseId, int outputIndex, InternalRealtimeResponseItem internalItem, string eventId) : base(eventId, RealtimeConversation.ConversationUpdateKind.ItemStarted)
        {
            ResponseId = responseId;
            OutputIndex = outputIndex;
            _internalItem = internalItem;
        }

        internal ConversationItemStartedUpdate(string responseId, int outputIndex, InternalRealtimeResponseItem internalItem, string eventId, RealtimeConversation.ConversationUpdateKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(eventId, kind, additionalBinaryDataProperties)
        {
            ResponseId = responseId;
            OutputIndex = outputIndex;
            _internalItem = internalItem;
        }

        public string ResponseId { get; set; }

        public int OutputIndex { get; set; }
    }
}
