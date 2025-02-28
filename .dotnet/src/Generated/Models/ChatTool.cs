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

        internal ChatTool(InternalFunctionDefinition function, ChatToolKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Function = function;
            Kind = kind;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
