// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    internal partial class InternalRunRequiredAction
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal InternalRunRequiredAction(InternalRunObjectRequiredActionSubmitToolOutputs submitToolOutputs)
        {
            SubmitToolOutputs = submitToolOutputs;
        }

        internal InternalRunRequiredAction(InternalRunObjectRequiredActionSubmitToolOutputs submitToolOutputs, object @type, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            SubmitToolOutputs = submitToolOutputs;
            Type = @type;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public InternalRunObjectRequiredActionSubmitToolOutputs SubmitToolOutputs { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
