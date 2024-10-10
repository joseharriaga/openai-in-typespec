// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationInputSpeechFinishedUpdate : ConversationUpdate
    {
        internal ConversationInputSpeechFinishedUpdate(string eventId, int audioEndMs, string itemId) : base(eventId)
        {
            Argument.AssertNotNull(eventId, nameof(eventId));
            Argument.AssertNotNull(itemId, nameof(itemId));

            Kind = ConversationUpdateKind.InputSpeechStopped;
            AudioEndMs = audioEndMs;
            ItemId = itemId;
        }

        internal ConversationInputSpeechFinishedUpdate(ConversationUpdateKind kind, string eventId, IDictionary<string, BinaryData> serializedAdditionalRawData, int audioEndMs, string itemId) : base(kind, eventId, serializedAdditionalRawData)
        {
            AudioEndMs = audioEndMs;
            ItemId = itemId;
        }

        internal ConversationInputSpeechFinishedUpdate()
        {
        }

        public int AudioEndMs { get; }
        public string ItemId { get; }
    }
}
