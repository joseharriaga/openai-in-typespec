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
public abstract partial class ChatTool
{
    // CUSTOM: Made public after rename from 'type'.
    [CodeGenMember("Kind")]
    public ChatToolKind Kind { get; }

    // CUSTOM: Spread.
    /// <summary> The name of the function. </summary>
    /// <remarks> Present when <see cref="Kind"/> is <see cref="ChatToolKind.Function"/>. </remarks>
    public string FunctionName { get; private protected set; }

    // CUSTOM: Spread.
    /// <summary>
    ///     The description of what the function does, which is used by the model to choose when and how to call the
    ///     function.
    /// </summary>
    /// <remarks> Present when <see cref="Kind"/> is <see cref="ChatToolKind.Function"/>. </remarks>
    public string FunctionDescription { get; private protected set; }

    // CUSTOM: Spread.
    /// <summary>
    ///     The parameters that the function accepts, which are described as a JSON schema. If omitted, this
    ///     defines a function with an empty parameter list. Learn more in the
    ///     <see href="https://platform.openai.com/docs/api-reference/chat/docs/guides/function-calling">function calling guide</see>
    ///     and the
    ///     <see href="https://json-schema.org/understanding-json-schema">JSON schema reference documentation</see>.
    /// </summary>
    /// <remarks> Present when <see cref="Kind"/> is <see cref="ChatToolKind.Function"/>. </remarks>
    public BinaryData FunctionParameters { get; private protected set; }

    // CUSTOM: Spread.
    /// <summary>
    ///     <para>
    ///         Whether to enable strict schema adherence when generating the function call. If set to <c>true</c>, the
    ///         model will follow the exact schema defined in <see cref="FunctionParameters">
    ///     </para>
    ///     <para>
    ///         Only a subset of the JSON schema specification is supported when this is set to <c>true</c>. Learn more
    ///         about structured outputs in the
    ///         <see href="https://platform.openai.com/docs/api-reference/chat/docs/guides/function-calling">function calling guide</see>.
    ///     </para>
    /// </summary>
    /// <remarks> Present when <see cref="Kind"/> is <see cref="ChatToolKind.Function"/>. </remarks>
    public bool? FunctionSchemaIsStrict { get; private protected set; }

    /// <summary> Creates a new <see cref="ChatTool"/> representing a function that the model may call. </summary>
    /// <param name="functionName"> The name of the function. </param>
    /// <param name="functionDescription">
    ///     The description of what the function does, which is used by the model to choose when and how to call the
    ///     function.
    /// </param>
    /// <param name="functionParameters">
    ///     <para>
    ///         The parameters that the function accepts, which are described as a JSON schema. If omitted, this
    ///         defines a function with an empty parameter list. Learn more in the
    ///         <see href="https://platform.openai.com/docs/api-reference/chat/docs/guides/function-calling">function calling guide</see>
    ///         and the
    ///         <see href="https://json-schema.org/understanding-json-schema">JSON schema reference documentation</see>.
    ///     </para>
    ///     <para>
    ///         You can easily create a JSON schema via the factory methods of the <see cref="BinaryData"/> class, such
    ///         as <see cref="BinaryData.FromBytes(byte[])"/> or <see cref="BinaryData.FromString(string)"/>. For
    ///         example, the following code defines a simple schema for a function that takes a customer's order ID as
    ///         a <c>string</c> parameter:
    ///         <code>
    ///             BinaryData functionParameters = BinaryData.FromBytes("""
    ///                 {
    ///                     "type": "object",
    ///                     "properties": {
    ///                         "order_id": {
    ///                             "type": "string",
    ///                             "description": "The customer's order ID."
    ///                         }
    ///                     },
    ///                     "required": ["order_id"],
    ///                     "additionalProperties": false
    ///                 }
    ///                 """u8.ToArray());
    ///         </code>
    ///     </para>
    /// </param>
    /// <param name="functionSchemaIsStrict">
    ///     <para>
    ///         Whether to enable strict schema adherence when generating the function call. If set to <c>true</c>, the
    ///         model will follow the exact schema defined in <paramref name="functionParameters"/>.
    ///     </para>
    ///     <para>
    ///         Only a subset of the JSON schema specification is supported when this is set to <c>true</c>. Learn more
    ///         about structured outputs in the
    ///         <see href="https://platform.openai.com/docs/api-reference/chat/docs/guides/function-calling">function calling guide</see>.
    ///     </para>
    /// </param> 
    public static ChatTool CreateFunctionTool(string functionName, string functionDescription = null, BinaryData functionParameters = null, bool? functionSchemaIsStrict = null)
    {
        Argument.AssertNotNull(functionName, nameof(functionName));

        InternalFunctionDefinition function = new(functionName)
        {
            Description = functionDescription,
            Parameters = functionParameters,
            Strict = functionSchemaIsStrict,
        };

        return new InternalChatCompletionFunctionTool(function);
    }
}
