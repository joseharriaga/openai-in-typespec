// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    public partial class MessageDeletionResult
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        internal MessageDeletionResult(string messageId, bool deleted)
        {
            Argument.AssertNotNull(messageId, nameof(messageId));

            MessageId = messageId;
            Deleted = deleted;
        }

        internal MessageDeletionResult(string messageId, bool deleted, InternalDeleteMessageResponseObject @object, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            MessageId = messageId;
            Deleted = deleted;
            Object = @object;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal MessageDeletionResult()
        {
        }
        public bool Deleted { get; }
    }
}
