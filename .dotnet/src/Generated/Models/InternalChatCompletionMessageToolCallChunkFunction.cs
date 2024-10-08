// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat
{
    internal partial class InternalChatCompletionMessageToolCallChunkFunction
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal InternalChatCompletionMessageToolCallChunkFunction()
        {
        }

        internal InternalChatCompletionMessageToolCallChunkFunction(string name, BinaryData arguments, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Name = name;
            Arguments = arguments;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string Name { get; set; }
    }
}
