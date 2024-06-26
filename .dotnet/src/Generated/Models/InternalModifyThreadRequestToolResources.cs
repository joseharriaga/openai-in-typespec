// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    internal partial class InternalModifyThreadRequestToolResources
    {
        internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        public InternalModifyThreadRequestToolResources()
        {
        }

        internal InternalModifyThreadRequestToolResources(InternalModifyThreadRequestToolResourcesCodeInterpreter codeInterpreter, InternalModifyThreadRequestToolResourcesFileSearch fileSearch, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            CodeInterpreter = codeInterpreter;
            FileSearch = fileSearch;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        public InternalModifyThreadRequestToolResourcesCodeInterpreter CodeInterpreter { get; set; }
        public InternalModifyThreadRequestToolResourcesFileSearch FileSearch { get; set; }
    }
}
