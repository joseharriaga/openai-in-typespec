// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat
{
    public partial class ToolChatMessage : ChatMessage
    {
        internal ToolChatMessage(ChatMessageRole role, ChatMessageContent content, IDictionary<string, BinaryData> serializedAdditionalRawData, string toolCallId) : base(role, content, serializedAdditionalRawData)
        {
            ToolCallId = toolCallId;
        }

        internal ToolChatMessage()
        {
        }

        public string ToolCallId { get; }
    }
}
