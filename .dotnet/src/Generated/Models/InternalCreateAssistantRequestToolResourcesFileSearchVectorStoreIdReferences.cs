// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    internal partial class InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreIdReferences
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        public InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreIdReferences()
        {
            VectorStoreIds = new ChangeTrackingList<string>();
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        internal InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreIdReferences(IList<string> vectorStoreIds, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            VectorStoreIds = vectorStoreIds;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        public IList<string> VectorStoreIds { get; }
    }
}
