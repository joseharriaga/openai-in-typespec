// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Batch
{
    internal partial class InternalCreateBatchRequest
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        public InternalCreateBatchRequest(string inputFileId, InternalCreateBatchRequestEndpoint endpoint)
        {
            Argument.AssertNotNull(inputFileId, nameof(inputFileId));

            InputFileId = inputFileId;
            Endpoint = endpoint;
            Metadata = new ChangeTrackingDictionary<string, string>();
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        internal InternalCreateBatchRequest(string inputFileId, InternalCreateBatchRequestEndpoint endpoint, InternalBatchCompletionTimeframe completionWindow, IDictionary<string, string> metadata, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            InputFileId = inputFileId;
            Endpoint = endpoint;
            CompletionWindow = completionWindow;
            Metadata = metadata;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal InternalCreateBatchRequest()
        {
        }

        public string InputFileId { get; }
        public InternalCreateBatchRequestEndpoint Endpoint { get; }
        public InternalBatchCompletionTimeframe CompletionWindow { get; } = InternalBatchCompletionTimeframe._24h;

        public IDictionary<string, string> Metadata { get; set; }
    }
}
