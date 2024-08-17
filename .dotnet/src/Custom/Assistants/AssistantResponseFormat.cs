using System;
using System.Collections.Generic;
using System.ComponentModel;
using OpenAI.Internal;

namespace OpenAI.Assistants;

/// <summary>
/// Specifies the format that the model must output. Compatible with GPT-4o, GPT-4 Turbo, and all GPT-3.5 Turbo models since gpt-3.5-turbo-1106.
/// </summary>
/// <remarks>
/// <para>
/// Setting to { "type": "json_object" } enables JSON mode, which guarantees the message the model generates is valid JSON.
/// </para>
/// <para>
/// Important: when using JSON mode, you must also instruct the model to produce JSON yourself via a system or user message.Without this, the model may generate an unending stream of whitespace until the generation reaches the token limit, resulting in a long-running and seemingly "stuck" request.Also note that the message content may be partially cut off if finish_reason= "length", which indicates the generation exceeded max_tokens or the conversation exceeded the max context length.
/// </para>
/// </remarks>
[CodeGenModel("AssistantResponseFormat")]
public partial class AssistantResponseFormat
{
    public static AssistantResponseFormat Auto { get; } = new InternalAssistantResponseFormatPlainTextNoObject("auto");
    public static AssistantResponseFormat Text { get; } = new InternalAssistantResponseFormatText();
    public static AssistantResponseFormat JsonObject { get; } = new InternalAssistantResponseFormatJsonObject();
    public static AssistantResponseFormat FromJsonSchema(
        string name,
        string description = null,
        BinaryData jsonSchema = null,
        bool? useStrictSchema = null)
    {
        InternalResponseFormatJsonSchemaJsonSchema internalSchema = new(
            description,
            name,
            jsonSchema,
            useStrictSchema,
            null);
        return new InternalAssistantResponseFormatJsonSchema(internalSchema);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj)
    {
        return
            (this is InternalAssistantResponseFormatText && obj is InternalAssistantResponseFormatText)
            || (this is InternalAssistantResponseFormatJsonObject && obj is InternalAssistantResponseFormatJsonObject)
            || (this is InternalAssistantResponseFormatJsonSchema thisSchema && obj is InternalAssistantResponseFormatJsonSchema otherSchema && thisSchema.JsonSchema.Name == otherSchema.JsonSchema.Name)
            || (this is InternalAssistantResponseFormatPlainTextNoObject plainThis
                    && obj is InternalAssistantResponseFormatPlainTextNoObject otherFormat
                    && plainThis.Value == otherFormat.Value)
            || (this is InternalAssistantResponseFormatPlainTextNoObject plainThis2 && obj is string otherPlainText
                    && plainThis2.Value == otherPlainText);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator==(AssistantResponseFormat first, AssistantResponseFormat second)
        => first.Equals(second);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator!=(AssistantResponseFormat first, AssistantResponseFormat second)
        => !first.Equals(second);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static implicit operator AssistantResponseFormat(string plainTextValue)
        => new InternalAssistantResponseFormatPlainTextNoObject(plainTextValue);
}