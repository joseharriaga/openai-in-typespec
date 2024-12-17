// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal
{
    internal partial class OpenAIError
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal OpenAIError(string code, string message, string @param, string @type)
        {
            Code = code;
            Message = message;
            Param = @param;
            Type = @type;
        }

        internal OpenAIError(string code, string message, string @param, string @type, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Code = code;
            Message = message;
            Param = @param;
            Type = @type;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string Code { get; }

        public string Message { get; }

        public string Param { get; }

        public string Type { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
