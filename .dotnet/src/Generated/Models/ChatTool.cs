// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.Chat
{
    public partial class ChatTool
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public ChatTool(InternalFunctionDefinition function, Chat.ChatToolKind kind)
        {
            Argument.AssertNotNull(function, nameof(function));

            Function = function;
            Kind = kind;
        }

        internal ChatTool(InternalFunctionDefinition function, Chat.ChatToolKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Function = function;
            Kind = kind;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }
    }
}
