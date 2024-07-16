// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.VectorStores
{
    internal partial class InternalDeleteVectorStoreFileResponse
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        internal InternalDeleteVectorStoreFileResponse(string id, bool deleted)
        {
            Argument.AssertNotNull(id, nameof(id));

            Id = id;
            Deleted = deleted;
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        internal InternalDeleteVectorStoreFileResponse(string id, bool deleted, InternalDeleteVectorStoreFileResponseObject @object, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Deleted = deleted;
            Object = @object;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal InternalDeleteVectorStoreFileResponse()
        {
        }

        public string Id { get; }
        public bool Deleted { get; }
        public InternalDeleteVectorStoreFileResponseObject Object { get; } = InternalDeleteVectorStoreFileResponseObject.VectorStoreFileDeleted;
    }
}
