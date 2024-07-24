// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    public partial class RunIncompleteDetails
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        internal RunIncompleteDetails()
        {
        }

        internal RunIncompleteDetails(RunIncompleteReason? reason, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Reason = reason;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        public RunIncompleteReason? Reason { get; }
    }
}
