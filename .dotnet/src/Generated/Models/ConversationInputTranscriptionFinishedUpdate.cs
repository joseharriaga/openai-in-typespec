// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationInputTranscriptionFinishedUpdate : ConversationUpdate
    {
        internal ConversationInputTranscriptionFinishedUpdate(string eventId, string itemId, int contentIndex, string transcript) : base(eventId)
        {
            Argument.AssertNotNull(itemId, nameof(itemId));
            Argument.AssertNotNull(transcript, nameof(transcript));

            Kind = ConversationUpdateKind.ItemInputAudioTranscriptionCompleted;
            ItemId = itemId;
            ContentIndex = contentIndex;
            Transcript = transcript;
        }

        internal ConversationInputTranscriptionFinishedUpdate(ConversationUpdateKind kind, string eventId, IDictionary<string, BinaryData> serializedAdditionalRawData, string itemId, int contentIndex, string transcript) : base(kind, eventId, serializedAdditionalRawData)
        {
            ItemId = itemId;
            ContentIndex = contentIndex;
            Transcript = transcript;
        }

        internal ConversationInputTranscriptionFinishedUpdate()
        {
        }

        public string ItemId { get; }
        public int ContentIndex { get; }
        public string Transcript { get; }
    }
}
