// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationItemStreamingAudioTranscriptionFinishedUpdate : ConversationUpdate
    {
        internal ConversationItemStreamingAudioTranscriptionFinishedUpdate(string eventId, string responseId, string itemId, int outputIndex, int contentIndex, string transcript) : base(eventId, RealtimeConversation.ConversationUpdateKind.ItemStreamingPartAudioTranscriptionFinished)
        {
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Transcript = transcript;
        }

        internal ConversationItemStreamingAudioTranscriptionFinishedUpdate(string eventId, string responseId, string itemId, int outputIndex, int contentIndex, string transcript, RealtimeConversation.ConversationUpdateKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(eventId, kind, additionalBinaryDataProperties)
        {
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
            Transcript = transcript;
        }

        public new string EventId => _eventId ?? default;

        public string ResponseId { get; }

        public string ItemId { get; }

        public int OutputIndex { get; }

        public int ContentIndex { get; }

        public string Transcript { get; }
    }
}
