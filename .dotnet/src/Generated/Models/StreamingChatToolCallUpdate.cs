// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat
{
    public abstract partial class StreamingChatToolCallUpdate
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        protected StreamingChatToolCallUpdate()
        {
        }

        internal StreamingChatToolCallUpdate(ChatToolCallKind kind, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Kind = kind;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }
    }
}
