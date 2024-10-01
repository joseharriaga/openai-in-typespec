// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationAudioDoneUpdate : ConversationUpdate
    {
        internal ConversationAudioDoneUpdate(string eventId, string responseId, string itemId, int outputIndex, int contentIndex) : base(eventId)
        {
            Argument.AssertNotNull(responseId, nameof(responseId));
            Argument.AssertNotNull(itemId, nameof(itemId));

            Kind = ConversationUpdateKind.ResponseAudioDone;
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
        }

        internal ConversationAudioDoneUpdate(ConversationUpdateKind kind, string eventId, IDictionary<string, BinaryData> serializedAdditionalRawData, string responseId, string itemId, int outputIndex, int contentIndex) : base(kind, eventId, serializedAdditionalRawData)
        {
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            ContentIndex = contentIndex;
        }

        internal ConversationAudioDoneUpdate()
        {
        }

        public string ResponseId { get; }
        public string ItemId { get; }
        public int OutputIndex { get; }
        public int ContentIndex { get; }
    }
}
