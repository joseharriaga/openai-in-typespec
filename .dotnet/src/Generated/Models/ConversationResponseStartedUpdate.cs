// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationResponseStartedUpdate : ConversationUpdate
    {
        internal ConversationResponseStartedUpdate(InternalRealtimeResponse internalResponse, string eventId) : base(eventId, RealtimeConversation.ConversationUpdateKind.ResponseStarted)
        {
            _internalResponse = internalResponse;
        }

        internal ConversationResponseStartedUpdate(InternalRealtimeResponse internalResponse, string eventId, RealtimeConversation.ConversationUpdateKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(eventId, kind, additionalBinaryDataProperties)
        {
            _internalResponse = internalResponse;
        }
    }
}
