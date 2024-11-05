// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeServerEventResponseAudioDelta : ConversationUpdate
    {
        internal InternalRealtimeServerEventResponseAudioDelta(string responseId, string itemId, int outputIndex, int contentIndex, BinaryData delta, string eventId) : base(eventId, RealtimeConversation.ConversationUpdateKind.ItemStreamingPartAudioDelta)
        {
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Delta = delta;
        }

        internal InternalRealtimeServerEventResponseAudioDelta(string responseId, string itemId, int outputIndex, int contentIndex, BinaryData delta, string eventId, RealtimeConversation.ConversationUpdateKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(eventId, kind, additionalBinaryDataProperties)
        {
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Delta = delta;
        }

        public string ResponseId { get; }

        public string ItemId { get; }

        public int OutputIndex { get; }

        public int ContentIndex { get; }

        public BinaryData Delta { get; }
    }
}
