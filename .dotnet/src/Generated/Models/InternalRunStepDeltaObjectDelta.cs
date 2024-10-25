// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    internal partial class InternalRunStepDeltaObjectDelta
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal InternalRunStepDeltaObjectDelta()
        {
        }

        internal InternalRunStepDeltaObjectDelta(InternalRunStepDeltaStepDetails stepDetails, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            StepDetails = stepDetails;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public InternalRunStepDeltaStepDetails StepDetails { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
