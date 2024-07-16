// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    internal partial class InternalCreateThreadAndRunRequestToolResourcesCodeInterpreter
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        public InternalCreateThreadAndRunRequestToolResourcesCodeInterpreter()
        {
            FileIds = new ChangeTrackingList<string>();
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        internal InternalCreateThreadAndRunRequestToolResourcesCodeInterpreter(IList<string> fileIds, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            FileIds = fileIds;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        public IList<string> FileIds { get; }
    }
}
