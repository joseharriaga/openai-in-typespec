// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    internal abstract partial class MessageDeltaTextContentAnnotation
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        protected MessageDeltaTextContentAnnotation()
        {
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        internal MessageDeltaTextContentAnnotation(string type, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Type = type;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal string Type { get; init; }
    }
}
