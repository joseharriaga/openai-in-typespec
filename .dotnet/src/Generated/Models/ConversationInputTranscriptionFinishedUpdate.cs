// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationInputTranscriptionFinishedUpdate : ConversationUpdate
    {
        internal ConversationInputTranscriptionFinishedUpdate(string itemId, int contentIndex, string transcript, string eventId) : base(eventId, RealtimeConversation.ConversationUpdateKind.ItemInputAudioTranscriptionCompleted)
        {
            ItemId = itemId;
            ContentIndex = contentIndex;
            Transcript = transcript;
        }

        internal ConversationInputTranscriptionFinishedUpdate(string itemId, int contentIndex, string transcript, string eventId, RealtimeConversation.ConversationUpdateKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(eventId, kind, additionalBinaryDataProperties)
        {
            ItemId = itemId;
            ContentIndex = contentIndex;
            Transcript = transcript;
        }

        public string ItemId { get; set; }

        public int ContentIndex { get; set; }

        public string Transcript { get; set; }
    }
}
