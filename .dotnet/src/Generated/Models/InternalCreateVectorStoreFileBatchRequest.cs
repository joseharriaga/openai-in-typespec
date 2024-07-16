// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.VectorStores
{
    internal partial class InternalCreateVectorStoreFileBatchRequest
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        public InternalCreateVectorStoreFileBatchRequest(IEnumerable<string> fileIds)
        {
            Argument.AssertNotNull(fileIds, nameof(fileIds));

            FileIds = fileIds.ToList();
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        internal InternalCreateVectorStoreFileBatchRequest(IList<string> fileIds, BinaryData chunkingStrategy, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            FileIds = fileIds;
            ChunkingStrategy = chunkingStrategy;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal InternalCreateVectorStoreFileBatchRequest()
        {
        }

        public IList<string> FileIds { get; }
        public BinaryData ChunkingStrategy { get; set; }
    }
}
