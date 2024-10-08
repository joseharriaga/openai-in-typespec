// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeRequestResponseCancelCommand : InternalRealtimeRequestCommand
    {
        public InternalRealtimeRequestResponseCancelCommand() : base(InternalRealtimeRequestCommandType.ResponseCancel)
        {
        }

        internal InternalRealtimeRequestResponseCancelCommand(InternalRealtimeRequestCommandType kind, string eventId, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(kind, eventId, additionalBinaryDataProperties)
        {
        }
    }
}