// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    internal partial class InternalRealtimeResponseApiError
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal InternalRealtimeResponseApiError(string @type, string message)
        {
            Type = @type;
            Message = message;
        }

        internal InternalRealtimeResponseApiError(string @type, string code, string message, string @param, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Type = @type;
            Code = code;
            Message = message;
            Param = @param;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string Type { get; set; }

        public string Code { get; set; }

        public string Message { get; set; }

        public string Param { get; set; }
    }
}