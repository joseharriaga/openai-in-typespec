// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationInputTranscriptionFinishedUpdate : ConversationUpdate
    {
        internal ConversationInputTranscriptionFinishedUpdate(string eventId, string itemId, int contentIndex, string transcript)
        {
            Argument.AssertNotNull(eventId, nameof(eventId));
            Argument.AssertNotNull(itemId, nameof(itemId));
            Argument.AssertNotNull(transcript, nameof(transcript));

            Kind = ConversationUpdateKind.ItemInputAudioTranscriptionCompleted;
            EventId = eventId;
            ItemId = itemId;
            ContentIndex = contentIndex;
            Transcript = transcript;
        }

        internal ConversationInputTranscriptionFinishedUpdate(ConversationUpdateKind kind, IDictionary<string, BinaryData> serializedAdditionalRawData, string eventId, string itemId, int contentIndex, string transcript) : base(kind, serializedAdditionalRawData)
        {
            EventId = eventId;
            ItemId = itemId;
            ContentIndex = contentIndex;
            Transcript = transcript;
        }

        internal ConversationInputTranscriptionFinishedUpdate()
        {
        }

        public string EventId { get; }
        public string ItemId { get; }
        public int ContentIndex { get; }
        public string Transcript { get; }
    }
}
