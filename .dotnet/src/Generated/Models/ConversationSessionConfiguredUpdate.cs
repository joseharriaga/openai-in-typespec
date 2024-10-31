// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationSessionConfiguredUpdate : ConversationUpdate
    {
        internal ConversationSessionConfiguredUpdate(string eventId, InternalRealtimeResponseSession internalSession) : base(eventId, RealtimeConversation.ConversationUpdateKind.SessionConfigured)
        {
            _internalSession = internalSession;
        }

        internal ConversationSessionConfiguredUpdate(string eventId, InternalRealtimeResponseSession internalSession, RealtimeConversation.ConversationUpdateKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(eventId, kind, additionalBinaryDataProperties)
        {
            _internalSession = internalSession;
        }

        public new string EventId => _eventId ?? default;
    }
}
