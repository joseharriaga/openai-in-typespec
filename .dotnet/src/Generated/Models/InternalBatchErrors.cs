// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Batch
{
    internal partial class InternalBatchErrors
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        internal InternalBatchErrors()
        {
            Data = new ChangeTrackingList<InternalBatchError>();
        }

        internal InternalBatchErrors(InternalBatchErrorsObject? @object, IReadOnlyList<InternalBatchError> data, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Object = @object;
            Data = data;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        public InternalBatchErrorsObject? Object { get; }
        public IReadOnlyList<InternalBatchError> Data { get; }
    }
}
