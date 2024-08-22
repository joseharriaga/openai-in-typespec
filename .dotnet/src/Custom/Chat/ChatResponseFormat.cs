using OpenAI.Internal;
using System;
using System.ClientModel.Primitives;
using System.ComponentModel;

namespace OpenAI.Chat;

[CodeGenModel("ChatResponseFormat")]
public abstract partial class ChatResponseFormat
{
    public static ChatResponseFormat Text { get; } = new InternalChatResponseFormatText();
    public static ChatResponseFormat JsonObject { get; } = new InternalChatResponseFormatJsonObject();

    public static ChatResponseFormat CreateTextFormat() => new InternalChatResponseFormatText();
    public static ChatResponseFormat CreateJsonObjectFormat() => new InternalChatResponseFormatJsonObject();
    public static ChatResponseFormat CreateJsonSchemaFormat(
        string name,
        BinaryData jsonSchema,
        string description = null,
        bool? requireStrictJsonSchemaMatch = null)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(jsonSchema, nameof(jsonSchema));

        InternalResponseFormatJsonSchemaJsonSchema internalSchema = new(
            description,
            name,
            jsonSchema,
            requireStrictJsonSchemaMatch,
            null);
        return new InternalChatResponseFormatJsonSchema(internalSchema);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator ==(ChatResponseFormat first, ChatResponseFormat second)
        => first?.Equals(second) ?? false;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator !=(ChatResponseFormat first, ChatResponseFormat second)
        => !(first == second);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj)
    {
        if (this is InternalChatResponseFormatText)
        {
            return obj is InternalChatResponseFormatText;
        }
        else if (this is InternalChatResponseFormatJsonObject)
        {
            return obj is InternalChatResponseFormatJsonObject;
        }
        else if (this is InternalChatResponseFormatJsonSchema thisJsonSchema
            && obj is InternalChatResponseFormatJsonSchema otherJsonSchema)
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

    public override string ToString()
    {
        return ModelReaderWriter.Write(this).ToString();
    }
}