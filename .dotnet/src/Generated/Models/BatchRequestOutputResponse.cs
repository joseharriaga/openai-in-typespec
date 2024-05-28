// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    internal partial class BatchRequestOutputResponse
    {
        internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        internal BatchRequestOutputResponse()
        {
            Body = new ChangeTrackingDictionary<string, string>();
        }

        internal BatchRequestOutputResponse(int? statusCode, string requestId, IReadOnlyDictionary<string, string> body, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            StatusCode = statusCode;
            RequestId = requestId;
            Body = body;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        public int? StatusCode { get; }
        public string RequestId { get; }
        public IReadOnlyDictionary<string, string> Body { get; }
    }
}