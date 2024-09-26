// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat;

internal partial class InternalChatCompletionMessageFunctionToolCall : ChatToolCall
{
    public InternalChatCompletionMessageFunctionToolCall(string id, InternalChatCompletionMessageFunctionToolCallFunction function)
        : this(ChatToolCallKind.Function, serializedAdditionalRawData: null, id, function)
    { }

    internal InternalChatCompletionMessageFunctionToolCall(
        ChatToolCallKind kind,
        IDictionary<string, BinaryData> serializedAdditionalRawData,
        string id,
        InternalChatCompletionMessageFunctionToolCallFunction function)
            : base(kind, serializedAdditionalRawData)
    {
        Id = id;
        Function = function;
        FunctionName = Function?.Name;
        FunctionArguments = Function?.Arguments;
    }

    internal InternalChatCompletionMessageFunctionToolCall() : this(null, null)
    { }
}
