using System;

namespace OpenAI.Chat;

/// <summary>
///     A tool that the model may call.
///     <list>
///         <item>
///             Call <see cref="CreateFunctionTool(string, string, BinaryData, bool?)"/> to create a
///             <see cref="ChatTool"/> representing a function that the model may call.
///         </item>
///     </list>
/// </summary>
[CodeGenModel("ChatCompletionTool")]
public partial class ChatTool
{
    // CUSTOM: Made internal.
    [CodeGenMember("Type")]
    internal InternalChatCompletionToolType Type { get; } = InternalChatCompletionToolType.Function;

    // CUSTOM: Made internal.
    [CodeGenMember("Function")]
    internal InternalFunctionDefinition Function { get; }

    // CUSTOM: Made internal.
    internal ChatTool(InternalFunctionDefinition function)
    {
        Argument.AssertNotNull(function, nameof(function));

        Function = function;
    }

    /// <summary> Creates a new <see cref="ChatTool"/> representing a function that the model may call. </summary>
    /// <param name="functionName"> The name of the function. </param>
    /// <param name="functionDescription">
    ///     The description of what the function does, which is used by the model to choose when and how to call the
    ///     function.
    /// </param>
    /// <param name="functionParameters">
    ///     The parameters that the function accepts, which are described as a JSON schema. If omitted, this defines
    ///     a function with an empty parameter list. Learn more in the
    ///     <see href="https://platform.openai.com/docs/api-reference/chat/docs/guides/function-calling">function calling guide</see>
    ///     and the <see href="https://json-schema.org/understanding-json-schema">JSON schema reference documentation</see>.
    /// </param>
    /// <param name="strictParameterSchemaEnabled">
    ///     Whether to enable strict schema adherence when generating the function call. If set to <c>true</c>, the
    ///     model will follow the exact schema defined in <paramref name="functionParameters"/>.
    ///     <remarks>
    ///         Only a subset of the JSON schema specification is supported when this is set to <c>true</c>. Learn more
    ///         about structured outputs in the
    ///         <see href="https://platform.openai.com/docs/api-reference/chat/docs/guides/function-calling">function calling guide</see>.
    ///     </remarks>
    /// </param> 
    public static ChatTool CreateFunctionTool(string functionName, string functionDescription = null, BinaryData functionParameters = null, bool? strictParameterSchemaEnabled = null)
    {
        Argument.AssertNotNull(functionName, nameof(functionName));

        InternalFunctionDefinition function = new(functionName)
        {
            Description = functionDescription,
            Parameters = functionParameters,
            Strict = strictParameterSchemaEnabled,
        };

        return new(
            type: InternalChatCompletionToolType.Function,
            function: function,
            serializedAdditionalRawData: null);
    }
}
