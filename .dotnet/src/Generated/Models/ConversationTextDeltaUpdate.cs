// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationTextDeltaUpdate : ConversationUpdate
    {
        internal ConversationTextDeltaUpdate(string responseId, string itemId, int outputIndex, int contentIndex, string delta, string eventId) : base(eventId, RealtimeConversation.ConversationUpdateKind.ResponseTextDelta)
        {
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Delta = delta;
        }

        internal ConversationTextDeltaUpdate(string responseId, string itemId, int outputIndex, int contentIndex, string delta, string eventId, RealtimeConversation.ConversationUpdateKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(eventId, kind, additionalBinaryDataProperties)
        {
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Delta = delta;
        }

        public string ResponseId { get; set; }

        public string ItemId { get; set; }

        public int OutputIndex { get; set; }

        public int ContentIndex { get; set; }

        public string Delta { get; set; }
    }
}
