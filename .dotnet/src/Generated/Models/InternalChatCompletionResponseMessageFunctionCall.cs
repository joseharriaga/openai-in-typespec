// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat
{
    internal partial class InternalChatCompletionResponseMessageFunctionCall
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        internal InternalChatCompletionResponseMessageFunctionCall(string name, string arguments)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(arguments, nameof(arguments));

            Name = name;
            Arguments = arguments;
        }

        internal InternalChatCompletionResponseMessageFunctionCall(string name, string arguments, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Arguments = arguments;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal InternalChatCompletionResponseMessageFunctionCall()
        {
        }

        public string Name { get; }
        public string Arguments { get; }
    }
}
