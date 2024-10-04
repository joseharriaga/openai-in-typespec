// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationOutputTranscriptionFinishedUpdate : ConversationUpdate
    {
        internal ConversationOutputTranscriptionFinishedUpdate(string eventId, string responseId, string itemId, int outputIndex, int contentIndex, string transcript)
        {
            Argument.AssertNotNull(eventId, nameof(eventId));
            Argument.AssertNotNull(responseId, nameof(responseId));
            Argument.AssertNotNull(itemId, nameof(itemId));
            Argument.AssertNotNull(transcript, nameof(transcript));

            Kind = ConversationUpdateKind.ResponseAudioTranscriptDone;
            EventId = eventId;
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Transcript = transcript;
        }

        internal ConversationOutputTranscriptionFinishedUpdate(ConversationUpdateKind kind, IDictionary<string, BinaryData> serializedAdditionalRawData, string eventId, string responseId, string itemId, int outputIndex, int contentIndex, string transcript) : base(kind, serializedAdditionalRawData)
        {
            EventId = eventId;
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Transcript = transcript;
        }

        internal ConversationOutputTranscriptionFinishedUpdate()
        {
        }

        public string EventId { get; }
        public string ResponseId { get; }
        public string ItemId { get; }
        public int OutputIndex { get; }
        public int ContentIndex { get; }
        public string Transcript { get; }
    }
}
