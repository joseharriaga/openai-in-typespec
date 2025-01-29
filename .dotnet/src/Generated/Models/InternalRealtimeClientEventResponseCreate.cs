// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeClientEventResponseCreate : InternalRealtimeClientEvent
    {
        public InternalRealtimeClientEventResponseCreate(InternalRealtimeResponseOptions response) : base(InternalRealtimeClientEventType.ResponseCreate)
        {
            Argument.AssertNotNull(response, nameof(response));

            Response = response;
        }

        internal InternalRealtimeClientEventResponseCreate(InternalRealtimeClientEventType kind, string eventId, IDictionary<string, BinaryData> additionalBinaryDataProperties, InternalRealtimeResponseOptions response) : base(kind, eventId, additionalBinaryDataProperties)
        {
            Response = response;
        }

        public InternalRealtimeResponseOptions Response { get; }
    }
}
