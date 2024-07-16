// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    public partial class MessageFailureDetails
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        internal MessageFailureDetails(MessageFailureReason reason)
        {
            Reason = reason;
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        internal MessageFailureDetails(MessageFailureReason reason, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Reason = reason;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal MessageFailureDetails()
        {
        }

        public MessageFailureReason Reason { get; }
    }
}
