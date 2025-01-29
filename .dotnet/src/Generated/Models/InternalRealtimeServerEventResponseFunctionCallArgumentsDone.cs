// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeServerEventResponseFunctionCallArgumentsDone : ConversationUpdate
    {
        internal InternalRealtimeServerEventResponseFunctionCallArgumentsDone(string eventId, string responseId, string itemId, int outputIndex, string callId, string arguments) : base(eventId, RealtimeConversation.ConversationUpdateKind.ItemStreamingFunctionCallArgumentsFinished)
        {
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            CallId = callId;
            Arguments = arguments;
        }

        internal InternalRealtimeServerEventResponseFunctionCallArgumentsDone(string eventId, RealtimeConversation.ConversationUpdateKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties, string responseId, string itemId, int outputIndex, string callId, string arguments) : base(eventId, kind, additionalBinaryDataProperties)
        {
            ResponseId = responseId;
            ItemId = itemId;
            OutputIndex = outputIndex;
            CallId = callId;
            Arguments = arguments;
        }

        public string ResponseId { get; }

        public string ItemId { get; }

        public int OutputIndex { get; }

        public string CallId { get; }

        public string Arguments { get; }
    }
}
