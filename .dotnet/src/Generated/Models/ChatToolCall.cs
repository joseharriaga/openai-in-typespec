// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.Chat
{
    public partial class ChatToolCall
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public ChatToolCall(string id, InternalChatCompletionMessageToolCallFunction function, Chat.ChatToolCallKind kind)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(function, nameof(function));

            Id = id;
            Function = function;
            Kind = kind;
        }

        internal ChatToolCall(string id, InternalChatCompletionMessageToolCallFunction function, Chat.ChatToolCallKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Id = id;
            Function = function;
            Kind = kind;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string Id { get; set; }
    }
}
