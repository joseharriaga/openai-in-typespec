// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationFunctionCallArgumentsDoneUpdate : ConversationUpdate
    {
        internal ConversationFunctionCallArgumentsDoneUpdate(string eventId, string responseId, string itemId, int outputIndex, string callId, string arguments)
        {
            Argument.AssertNotNull(eventId, nameof(eventId));
            Argument.AssertNotNull(responseId, nameof(responseId));
            Argument.AssertNotNull(itemId, nameof(itemId));
            Argument.AssertNotNull(callId, nameof(callId));
            Argument.AssertNotNull(arguments, nameof(arguments));

            Kind = ConversationUpdateKind.ResponseFunctionCallArgumentsDone;
            EventId = eventId;
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            CallId = callId;
            Arguments = arguments;
        }

        internal ConversationFunctionCallArgumentsDoneUpdate(ConversationUpdateKind kind, IDictionary<string, BinaryData> serializedAdditionalRawData, string eventId, string responseId, string itemId, int outputIndex, string callId, string arguments) : base(kind, serializedAdditionalRawData)
        {
            EventId = eventId;
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            CallId = callId;
            Arguments = arguments;
        }

        internal ConversationFunctionCallArgumentsDoneUpdate()
        {
        }

        public string EventId { get; }
        public string ResponseId { get; }
        public string ItemId { get; }
        public int OutputIndex { get; }
        public string CallId { get; }
        public string Arguments { get; }
    }
}