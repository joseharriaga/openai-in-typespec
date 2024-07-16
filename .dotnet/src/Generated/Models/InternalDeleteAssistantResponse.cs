// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    internal partial class InternalDeleteAssistantResponse
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        internal InternalDeleteAssistantResponse(string id, bool deleted)
        {
            Argument.AssertNotNull(id, nameof(id));

            Id = id;
            Deleted = deleted;
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        internal InternalDeleteAssistantResponse(string id, bool deleted, InternalDeleteAssistantResponseObject @object, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Deleted = deleted;
            Object = @object;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal InternalDeleteAssistantResponse()
        {
        }

        public string Id { get; }
        public bool Deleted { get; }
        public InternalDeleteAssistantResponseObject Object { get; } = InternalDeleteAssistantResponseObject.AssistantDeleted;
    }
}
