// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    public partial class RunError
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal RunError(RunErrorCode code, string message)
        {
            Code = code;
            Message = message;
        }

        internal RunError(RunErrorCode code, string message, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Code = code;
            Message = message;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public RunErrorCode Code { get; }

        public string Message { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
