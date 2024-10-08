// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationFunctionCallArgumentsDeltaUpdate : ConversationUpdate
    {
        internal ConversationFunctionCallArgumentsDeltaUpdate(string responseId, string itemId, int outputIndex, string callId, string delta, string eventId) : base(eventId)
        {
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            CallId = callId;
            Delta = delta;
        }

        internal ConversationFunctionCallArgumentsDeltaUpdate(string responseId, string itemId, int outputIndex, string callId, string delta, string eventId, RealtimeConversation.ConversationUpdateKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(eventId, kind, additionalBinaryDataProperties)
        {
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            CallId = callId;
            Delta = delta;
        }

        public string ResponseId { get; set; }

        public string ItemId { get; set; }

        public int OutputIndex { get; set; }

        public string CallId { get; set; }

        public string Delta { get; set; }
    }
}
