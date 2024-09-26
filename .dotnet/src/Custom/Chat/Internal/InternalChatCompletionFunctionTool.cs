using System;
using System.Collections.Generic;

namespace OpenAI.Chat;

internal partial class InternalChatCompletionFunctionTool : ChatTool
{
    public InternalChatCompletionFunctionTool(InternalFunctionDefinition function)
        : this(ChatToolKind.Function, serializedAdditionalRawData: null, function)
    { }

    internal InternalChatCompletionFunctionTool(ChatToolKind kind, IDictionary<string, BinaryData> serializedAdditionalRawData, InternalFunctionDefinition function)
        : base(kind, serializedAdditionalRawData)
    {
        Function = function;
        FunctionName = Function?.Name;
        FunctionDescription = Function?.Description;
        FunctionParameters = Function?.Parameters;
        FunctionSchemaIsStrict = Function?.Strict;
    }

    internal InternalChatCompletionFunctionTool() : this(null)
    { }
}

