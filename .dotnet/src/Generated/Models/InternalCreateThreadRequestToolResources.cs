// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    internal partial class InternalCreateThreadRequestToolResources
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        public InternalCreateThreadRequestToolResources()
        {
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        internal InternalCreateThreadRequestToolResources(InternalCreateThreadRequestToolResourcesCodeInterpreter codeInterpreter, BinaryData fileSearch, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            CodeInterpreter = codeInterpreter;
            FileSearch = fileSearch;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        public InternalCreateThreadRequestToolResourcesCodeInterpreter CodeInterpreter { get; set; }
        public BinaryData FileSearch { get; set; }
    }
}
