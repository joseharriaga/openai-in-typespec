// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeRequestSessionUpdateCommand : InternalRealtimeRequestCommand
    {
        public InternalRealtimeRequestSessionUpdateCommand(ConversationSessionOptions session) : base(InternalRealtimeRequestCommandType.SessionUpdate)
        {
            Argument.AssertNotNull(session, nameof(session));

            Session = session;
        }

        internal InternalRealtimeRequestSessionUpdateCommand(ConversationSessionOptions session, InternalRealtimeRequestCommandType kind, string eventId, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(kind, eventId, additionalBinaryDataProperties)
        {
            Session = session;
        }

        public ConversationSessionOptions Session { get; set; }
    }
}
