// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationContentPartFinishedUpdate : ConversationUpdate
    {
        internal ConversationContentPartFinishedUpdate(string responseId, string itemId, int outputIndex, int contentIndex, ConversationContentPart part, string eventId) : base(eventId)
        {
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Part = part;
        }

        internal ConversationContentPartFinishedUpdate(string responseId, string itemId, int outputIndex, int contentIndex, ConversationContentPart part, string eventId, RealtimeConversation.ConversationUpdateKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(eventId, kind, additionalBinaryDataProperties)
        {
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Part = part;
        }

        public string ResponseId { get; set; }

        public string ItemId { get; set; }

        public int OutputIndex { get; set; }

        public int ContentIndex { get; set; }

        public ConversationContentPart Part { get; set; }
    }
}
