// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationSessionStartedUpdate : ConversationUpdate
    {
        internal ConversationSessionStartedUpdate(InternalRealtimeResponseSession session, string eventId) : base(eventId)
        {
            Session = session;
        }

        internal ConversationSessionStartedUpdate(InternalRealtimeResponseSession session, string eventId, RealtimeConversation.ConversationUpdateKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(eventId, kind, additionalBinaryDataProperties)
        {
            Session = session;
        }

        public InternalRealtimeResponseSession Session { get; set; }
    }
}
