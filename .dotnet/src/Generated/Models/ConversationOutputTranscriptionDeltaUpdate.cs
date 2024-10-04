// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationOutputTranscriptionDeltaUpdate : ConversationUpdate
    {
        internal ConversationOutputTranscriptionDeltaUpdate(string eventId, string responseId, string itemId, int outputIndex, int contentIndex, string delta)
        {
            Argument.AssertNotNull(eventId, nameof(eventId));
            Argument.AssertNotNull(responseId, nameof(responseId));
            Argument.AssertNotNull(itemId, nameof(itemId));
            Argument.AssertNotNull(delta, nameof(delta));

            Kind = ConversationUpdateKind.ResponseAudioTranscriptDelta;
            EventId = eventId;
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Delta = delta;
        }

        internal ConversationOutputTranscriptionDeltaUpdate(ConversationUpdateKind kind, IDictionary<string, BinaryData> serializedAdditionalRawData, string eventId, string responseId, string itemId, int outputIndex, int contentIndex, string delta) : base(kind, serializedAdditionalRawData)
        {
            EventId = eventId;
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Delta = delta;
        }

        internal ConversationOutputTranscriptionDeltaUpdate()
        {
        }

        public string EventId { get; }
        public string ResponseId { get; }
        public string ItemId { get; }
        public int OutputIndex { get; }
        public int ContentIndex { get; }
        public string Delta { get; }
    }
}