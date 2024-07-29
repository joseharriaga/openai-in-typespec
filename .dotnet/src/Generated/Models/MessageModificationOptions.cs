// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    public partial class MessageModificationOptions
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        public MessageModificationOptions()
        {
            Metadata = new ChangeTrackingDictionary<string, string>();
        }

        internal MessageModificationOptions(IDictionary<string, string> metadata, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Metadata = metadata;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        public IDictionary<string, string> Metadata { get; }
    }
}
