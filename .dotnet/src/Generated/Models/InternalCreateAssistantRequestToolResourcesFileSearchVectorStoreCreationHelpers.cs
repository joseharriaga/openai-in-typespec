// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    internal partial class InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        public InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers()
        {
            VectorStores = new ChangeTrackingList<VectorStoreCreationHelper>();
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        internal InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers(IList<VectorStoreCreationHelper> vectorStores, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            VectorStores = vectorStores;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        public IList<VectorStoreCreationHelper> VectorStores { get; }
    }
}
