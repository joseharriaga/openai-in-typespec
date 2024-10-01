// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationInputTranscriptionFailedUpdate : ConversationUpdate
    {
        internal ConversationInputTranscriptionFailedUpdate(string eventId, string itemId, int contentIndex, InternalRealtimeResponseApiError error) : base(eventId)
        {
            Argument.AssertNotNull(itemId, nameof(itemId));
            Argument.AssertNotNull(error, nameof(error));

            Type = ConversationUpdateKind.ItemInputAudioTranscriptionFailed;
            ItemId = itemId;
            ContentIndex = contentIndex;
            _error = error;
        }

        internal ConversationInputTranscriptionFailedUpdate(ConversationUpdateKind type, string eventId, IDictionary<string, BinaryData> serializedAdditionalRawData, string itemId, int contentIndex, InternalRealtimeResponseApiError error) : base(type, eventId, serializedAdditionalRawData)
        {
            ItemId = itemId;
            ContentIndex = contentIndex;
            _error = error;
        }

        internal ConversationInputTranscriptionFailedUpdate()
        {
        }

        public string ItemId { get; }
        public int ContentIndex { get; }
    }
}
