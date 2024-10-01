// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationItemStartedUpdate : ConversationUpdate
    {
        internal ConversationItemStartedUpdate(string eventId, string responseId, int outputIndex, InternalRealtimeResponseItem internalItem) : base(eventId)
        {
            Argument.AssertNotNull(responseId, nameof(responseId));
            Argument.AssertNotNull(internalItem, nameof(internalItem));

            Type = ConversationUpdateKind.ItemStarted;
            ResponseId = responseId;
            OutputIndex = outputIndex;
            _internalItem = internalItem;
        }

        internal ConversationItemStartedUpdate(ConversationUpdateKind type, string eventId, IDictionary<string, BinaryData> serializedAdditionalRawData, string responseId, int outputIndex, InternalRealtimeResponseItem internalItem) : base(type, eventId, serializedAdditionalRawData)
        {
            ResponseId = responseId;
            OutputIndex = outputIndex;
            _internalItem = internalItem;
        }

        internal ConversationItemStartedUpdate()
        {
        }

        public string ResponseId { get; }
        public int OutputIndex { get; }
    }
}
