// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    public partial class VectorStoreCreationHelper
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        public VectorStoreCreationHelper()
        {
            FileIds = new ChangeTrackingList<string>();
            Metadata = new ChangeTrackingDictionary<string, string>();
        }

        internal VectorStoreCreationHelper(IList<string> fileIds, IDictionary<string, string> metadata, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            FileIds = fileIds;
            Metadata = metadata;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        public IList<string> FileIds { get; }
        public IDictionary<string, string> Metadata { get; }
    }
}
