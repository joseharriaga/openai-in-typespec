// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI.Chat;

namespace OpenAI.FineTuning
{
    [Obsolete("This field is marked as deprecated.")]
    internal partial class InternalFineTuneChatCompletionRequestFunctionMessage : FunctionChatMessage
    {
        internal InternalFineTuneChatCompletionRequestFunctionMessage(string role, IList<ChatMessageContentPart> content, IDictionary<string, BinaryData> serializedAdditionalRawData, string functionName) : base(role, content, serializedAdditionalRawData, functionName)
        {
        }

        internal InternalFineTuneChatCompletionRequestFunctionMessage()
        {
        }
    }
}