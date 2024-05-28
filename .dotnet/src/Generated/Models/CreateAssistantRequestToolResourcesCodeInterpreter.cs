// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    internal partial class CreateAssistantRequestToolResourcesCodeInterpreter
    {
        internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        public CreateAssistantRequestToolResourcesCodeInterpreter()
        {
            FileIds = new ChangeTrackingList<string>();
        }

        internal CreateAssistantRequestToolResourcesCodeInterpreter(IList<string> fileIds, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            FileIds = fileIds;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        public IList<string> FileIds { get; }
    }
}