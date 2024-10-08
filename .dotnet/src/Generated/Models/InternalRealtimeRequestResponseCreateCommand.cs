// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeRequestResponseCreateCommand : InternalRealtimeRequestCommand
    {
        public InternalRealtimeRequestResponseCreateCommand() : base(InternalRealtimeRequestCommandType.ResponseCreate)
        {
        }

        internal InternalRealtimeRequestResponseCreateCommand(InternalRealtimeRequestResponseCreateCommandResponse response, InternalRealtimeRequestCommandType kind, string eventId, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(kind, eventId, additionalBinaryDataProperties)
        {
            Response = response;
        }

        public InternalRealtimeRequestResponseCreateCommandResponse Response { get; set; }
    }
}
