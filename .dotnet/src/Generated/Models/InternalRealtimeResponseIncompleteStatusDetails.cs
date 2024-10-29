// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeResponseIncompleteStatusDetails : InternalRealtimeResponseStatusDetails
    {
        internal InternalRealtimeResponseIncompleteStatusDetails(InternalRealtimeResponseIncompleteStatusDetailsReason reason) : base(ConversationStatus.Incomplete)
        {
            Reason = reason;
        }

        internal InternalRealtimeResponseIncompleteStatusDetails(InternalRealtimeResponseIncompleteStatusDetailsReason reason, ConversationStatus @type, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(@type, additionalBinaryDataProperties)
        {
            Reason = reason;
        }

        public InternalRealtimeResponseIncompleteStatusDetailsReason Reason { get; }
    }
}