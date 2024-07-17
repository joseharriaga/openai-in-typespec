// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.VectorStores
{
    internal partial class InternalDeleteVectorStoreResponse
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        internal InternalDeleteVectorStoreResponse(string id, bool deleted)
        {
            Argument.AssertNotNull(id, nameof(id));

            Id = id;
            Deleted = deleted;
        }

        internal InternalDeleteVectorStoreResponse(string id, bool deleted, InternalDeleteVectorStoreResponseObject @object, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Deleted = deleted;
            Object = @object;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal InternalDeleteVectorStoreResponse()
        {
        }

        public string Id { get; }
        public bool Deleted { get; }
        public InternalDeleteVectorStoreResponseObject Object { get; } = InternalDeleteVectorStoreResponseObject.VectorStoreDeleted;
    }
}
