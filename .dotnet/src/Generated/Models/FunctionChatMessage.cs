// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat
{
    public partial class FunctionChatMessage : ChatMessage
    {
        internal FunctionChatMessage(ChatMessageRole role, IList<ChatMessageContentPart> content, IDictionary<string, BinaryData> serializedAdditionalRawData, string functionName) : base(role, content, serializedAdditionalRawData)
        {
            FunctionName = functionName;
        }

        internal FunctionChatMessage()
        {
        }
    }
}
