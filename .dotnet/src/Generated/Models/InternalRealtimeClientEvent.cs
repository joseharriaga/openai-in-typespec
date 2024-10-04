// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    internal abstract partial class InternalRealtimeClientEvent
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        protected InternalRealtimeClientEvent()
        {
        }

        internal InternalRealtimeClientEvent(InternalRealtimeClientEventType kind, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Kind = kind;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal InternalRealtimeClientEventType Kind { get; set; }
    }
}