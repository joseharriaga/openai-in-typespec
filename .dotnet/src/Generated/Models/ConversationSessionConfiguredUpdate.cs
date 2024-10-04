// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationSessionConfiguredUpdate : ConversationUpdate
    {
        internal ConversationSessionConfiguredUpdate(string eventId, InternalRealtimeResponseSession internalSession)
        {
            Argument.AssertNotNull(eventId, nameof(eventId));
            Argument.AssertNotNull(internalSession, nameof(internalSession));

            Kind = ConversationUpdateKind.SessionConfigured;
            EventId = eventId;
            _internalSession = internalSession;
        }

        internal ConversationSessionConfiguredUpdate(ConversationUpdateKind kind, IDictionary<string, BinaryData> serializedAdditionalRawData, string eventId, InternalRealtimeResponseSession internalSession) : base(kind, serializedAdditionalRawData)
        {
            EventId = eventId;
            _internalSession = internalSession;
        }

        internal ConversationSessionConfiguredUpdate()
        {
        }

        public string EventId { get; }
    }
}
