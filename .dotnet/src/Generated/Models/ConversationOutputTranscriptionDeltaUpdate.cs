// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationOutputTranscriptionDeltaUpdate : ConversationResponse
    {
        internal ConversationOutputTranscriptionDeltaUpdate(string eventId, string responseId, string itemId, int outputIndex, int contentIndex, string delta) : base(eventId)
        {
            Argument.AssertNotNull(responseId, nameof(responseId));
            Argument.AssertNotNull(itemId, nameof(itemId));
            Argument.AssertNotNull(delta, nameof(delta));

            Kind = ConversationResponseKind.ResponseAudioTranscriptDelta;
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Delta = delta;
        }

        internal ConversationOutputTranscriptionDeltaUpdate(ConversationResponseKind kind, string eventId, IDictionary<string, BinaryData> serializedAdditionalRawData, string responseId, string itemId, int outputIndex, int contentIndex, string delta) : base(kind, eventId, serializedAdditionalRawData)
        {
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Delta = delta;
        }

        internal ConversationOutputTranscriptionDeltaUpdate()
        {
        }

        public string ResponseId { get; }
        public string ItemId { get; }
        public int OutputIndex { get; }
        public int ContentIndex { get; }
        public string Delta { get; }
    }
}
