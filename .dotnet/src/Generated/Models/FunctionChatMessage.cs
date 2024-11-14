// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.Chat
{
    public partial class FunctionChatMessage : ChatMessage
    {
        public FunctionChatMessage(string functionName) : base(Chat.ChatMessageRole.Function)
        {
            Argument.AssertNotNull(functionName, nameof(functionName));

            FunctionName = functionName;
        }

        internal FunctionChatMessage(Chat.ChatMessageRole role, ChatMessageContent content, IDictionary<string, BinaryData> additionalBinaryDataProperties, string functionName) : base(role, content, additionalBinaryDataProperties)
        {
            FunctionName = functionName;
        }
    }
}
