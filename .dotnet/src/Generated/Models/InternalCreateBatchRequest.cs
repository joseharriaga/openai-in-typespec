// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.Batch
{
    internal partial class InternalCreateBatchRequest
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal InternalCreateBatchRequest(string inputFileId, InternalCreateBatchRequestEndpoint endpoint)
        {
            InputFileId = inputFileId;
            Endpoint = endpoint;
            Metadata = new ChangeTrackingDictionary<string, string>();
        }

        internal InternalCreateBatchRequest(string inputFileId, InternalCreateBatchRequestEndpoint endpoint, InternalBatchCompletionTimeframe completionWindow, IDictionary<string, string> metadata, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            InputFileId = inputFileId;
            Endpoint = endpoint;
            CompletionWindow = completionWindow;
            Metadata = metadata;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string InputFileId { get; }

        public InternalCreateBatchRequestEndpoint Endpoint { get; }

        public InternalBatchCompletionTimeframe CompletionWindow { get; } = "24h";

        public IDictionary<string, string> Metadata { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
