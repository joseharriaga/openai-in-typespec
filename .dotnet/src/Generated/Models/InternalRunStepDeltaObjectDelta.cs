// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    internal partial class InternalRunStepDeltaObjectDelta
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        internal InternalRunStepDeltaObjectDelta()
        {
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        internal InternalRunStepDeltaObjectDelta(InternalRunStepDeltaStepDetails stepDetails, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            StepDetails = stepDetails;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        public InternalRunStepDeltaStepDetails StepDetails { get; }
    }
}
