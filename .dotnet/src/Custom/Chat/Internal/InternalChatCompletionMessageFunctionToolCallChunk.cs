using System;
using System.Collections.Generic;

namespace OpenAI.Chat;

[CodeGenSuppress("InternalChatCompletionMessageFunctionToolCallChunk", typeof(int))]
internal partial class InternalChatCompletionMessageFunctionToolCallChunk : StreamingChatToolCallUpdate
{
    internal InternalChatCompletionMessageFunctionToolCallChunk(
        ChatToolCallKind kind,
        IDictionary<string, BinaryData> serializedAdditionalRawData,
        int index,
        string id,
        InternalChatCompletionMessageFunctionToolCallChunkFunction function)
            : base(kind, serializedAdditionalRawData)
    {
        Index = index;
        Id = id;
        Function = function;
        FunctionName = Function?.Name;
        FunctionArgumentsUpdate = Function?.Arguments;
    }
}

