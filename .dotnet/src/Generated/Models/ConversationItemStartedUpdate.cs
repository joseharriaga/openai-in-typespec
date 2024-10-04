// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationItemStartedUpdate : ConversationUpdate
    {
        internal ConversationItemStartedUpdate(string eventId, string responseId, int outputIndex, InternalRealtimeResponseItem internalItem)
        {
            Argument.AssertNotNull(eventId, nameof(eventId));
            Argument.AssertNotNull(responseId, nameof(responseId));
            Argument.AssertNotNull(internalItem, nameof(internalItem));

            Kind = ConversationUpdateKind.ItemStarted;
            EventId = eventId;
            ResponseId = responseId;
            OutputIndex = outputIndex;
            _internalItem = internalItem;
        }

        internal ConversationItemStartedUpdate(ConversationUpdateKind kind, IDictionary<string, BinaryData> serializedAdditionalRawData, string eventId, string responseId, int outputIndex, InternalRealtimeResponseItem internalItem) : base(kind, serializedAdditionalRawData)
        {
            EventId = eventId;
            ResponseId = responseId;
            OutputIndex = outputIndex;
            _internalItem = internalItem;
        }

        internal ConversationItemStartedUpdate()
        {
        }

        public string EventId { get; }
        public string ResponseId { get; }
        public int OutputIndex { get; }
    }
}