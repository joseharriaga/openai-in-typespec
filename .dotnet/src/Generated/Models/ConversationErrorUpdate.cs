// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationErrorUpdate : ConversationUpdate
    {
        internal ConversationErrorUpdate(string eventId, InternalRealtimeServerEventErrorError error)
        {
            Argument.AssertNotNull(eventId, nameof(eventId));
            Argument.AssertNotNull(error, nameof(error));

            Kind = ConversationUpdateKind.Error;
            EventId = eventId;
            _error = error;
        }

        internal ConversationErrorUpdate(ConversationUpdateKind kind, IDictionary<string, BinaryData> serializedAdditionalRawData, string eventId, InternalRealtimeServerEventErrorError error) : base(kind, serializedAdditionalRawData)
        {
            EventId = eventId;
            _error = error;
        }

        internal ConversationErrorUpdate()
        {
        }

        public string EventId { get; }
    }
}
