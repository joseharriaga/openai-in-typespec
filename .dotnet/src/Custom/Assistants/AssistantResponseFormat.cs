using OpenAI.Internal;
using System;
using System.ClientModel.Primitives;
using System.ComponentModel;

namespace OpenAI.Assistants;

[CodeGenModel("AssistantResponseFormat")]
public partial class AssistantResponseFormat
{
    public static AssistantResponseFormat Auto { get; } = CreateAutoFormat();
    public static AssistantResponseFormat Text { get; } = CreateTextFormat();
    public static AssistantResponseFormat JsonObject { get; } = CreateJsonObjectFormat();

    public static AssistantResponseFormat CreateAutoFormat()
        => new InternalAssistantResponseFormatPlainTextNoObject("auto");
    public static AssistantResponseFormat CreateTextFormat()
        => new InternalAssistantResponseFormatText();
    public static AssistantResponseFormat CreateJsonObjectFormat()
        => new InternalAssistantResponseFormatJsonObject();
    public static AssistantResponseFormat CreateJsonSchemaFormat(
        string name,
        string description = null,
        BinaryData jsonSchema = null,
        bool? requireStrictJsonSchemaMatch = null)
    {
        InternalResponseFormatJsonSchemaJsonSchema internalSchema = new(
            description,
            name,
            jsonSchema,
            requireStrictJsonSchemaMatch,
            null);
        return new InternalAssistantResponseFormatJsonSchema(internalSchema);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator ==(AssistantResponseFormat first, AssistantResponseFormat second)
        => first?.Equals(second) ?? false;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator !=(AssistantResponseFormat first, AssistantResponseFormat second)
        => !(first == second);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj)
    {
        if (this is InternalAssistantResponseFormatPlainTextNoObject thisPlainText
            && obj is InternalAssistantResponseFormatPlainTextNoObject otherPlainText)
        {
            return thisPlainText.Value.Equals(otherPlainText.Value);
        }
        else if (this is InternalAssistantResponseFormatText)
        {
            return obj is InternalAssistantResponseFormatText;
        }
        else if (this is InternalAssistantResponseFormatJsonObject)
        {
            return obj is InternalAssistantResponseFormatJsonObject;
        }
        else if (this is InternalAssistantResponseFormatJsonSchema thisJsonSchema
            && obj is InternalAssistantResponseFormatJsonSchema otherJsonSchema)
        {
            return thisJsonSchema.JsonSchema.Name.Equals(otherJsonSchema.JsonSchema.Name);
        }
        else
        {
            return ToString().Equals(obj?.ToString());
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => ToString().GetHashCode();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static implicit operator AssistantResponseFormat(string plainTextFormat)
        => new InternalAssistantResponseFormatPlainTextNoObject(plainTextFormat);

    public override string ToString()
    {
        if (this is InternalAssistantResponseFormatPlainTextNoObject plainTextInstance)
        {
            return plainTextInstance.Value;
        }
        else
        {
            return ModelReaderWriter.Write(this).ToString();
        }
    }
}