// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    public partial class ToolConstraint
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal ToolConstraint(InternalAssistantsNamedToolChoiceFunction function, string objectType, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Function = function;
            _objectType = objectType;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
