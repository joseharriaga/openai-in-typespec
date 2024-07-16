// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    internal partial class InternalRunStepDelta
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        internal InternalRunStepDelta(string id, InternalRunStepDeltaObjectDelta delta)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(delta, nameof(delta));

            Id = id;
            Delta = delta;
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        internal InternalRunStepDelta(string id, object @object, InternalRunStepDeltaObjectDelta delta, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Object = @object;
            Delta = delta;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal InternalRunStepDelta()
        {
        }

        public string Id { get; }

        public InternalRunStepDeltaObjectDelta Delta { get; }
    }
}
