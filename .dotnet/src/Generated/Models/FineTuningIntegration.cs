// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    public abstract partial class FineTuningIntegration
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        private protected FineTuningIntegration(string @type)
        {
            Type = @type;
        }

        internal FineTuningIntegration(string @type, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Type = @type;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        internal string Type { get; set; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
