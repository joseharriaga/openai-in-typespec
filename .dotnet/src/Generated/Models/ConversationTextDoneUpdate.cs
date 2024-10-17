// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationTextDoneUpdate : ConversationUpdate
    {
        internal ConversationTextDoneUpdate(string responseId, string itemId, int outputIndex, int contentIndex, string value, string eventId) : base(eventId, RealtimeConversation.ConversationUpdateKind.ResponseTextDone)
        {
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Value = value;
        }

        internal ConversationTextDoneUpdate(string responseId, string itemId, int outputIndex, int contentIndex, string value, string eventId, RealtimeConversation.ConversationUpdateKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(eventId, kind, additionalBinaryDataProperties)
        {
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Value = value;
        }

        public string ResponseId { get; set; }

        public string ItemId { get; set; }

        public int OutputIndex { get; set; }

        public int ContentIndex { get; set; }

        public string Value { get; set; }
    }
}
