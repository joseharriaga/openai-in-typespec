// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Batch
{
    internal partial class InternalBatchError
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        internal InternalBatchError()
        {
        }

        internal InternalBatchError(string code, string message, string param, int? line, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Code = code;
            Message = message;
            Param = param;
            Line = line;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        public string Code { get; }
        public string Message { get; }
        public string Param { get; }
        public int? Line { get; }
    }
}
