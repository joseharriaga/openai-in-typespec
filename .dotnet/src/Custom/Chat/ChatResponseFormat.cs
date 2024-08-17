using System;
using System.ComponentModel;
using OpenAI.Internal;

namespace OpenAI.Chat;

/// <summary>
/// Represents a requested <c>response_format</c> for the model to use, enabling "JSON mode" for guaranteed valid output.
/// </summary>
/// <remarks>
/// <b>Important</b>: when using JSON mode, the model <b><u>must</u></b> also be instructed to produce JSON via a
/// <c>system</c> or <c>user</c> message.
/// <para>
/// Without this paired, message-based accompaniment, the model may generate an unending stream of whitespace until the
/// generation reaches the token limit, resulting in a long-running and seemingly "stuck" request.
/// </para>
/// <para>
/// Also note that the message content may be partially cut off if <c>finish_reason</c> is <c>length</c>, which
/// indicates that the generation exceeded <c>max_tokens</c> or the conversation exceeded the max context length for
/// the model.
/// </para>
/// </remarks>
[CodeGenModel("ChatResponseFormat")]
public abstract partial class ChatResponseFormat
{
    /// <summary> text. </summary>
    public static ChatResponseFormat Text { get; } = new InternalChatResponseFormatText();
    /// <summary> json_object. </summary>
    public static ChatResponseFormat JsonObject { get; } = new InternalChatResponseFormatJsonObject();

    public static ChatResponseFormat FromJsonSchema(
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
        return new InternalChatResponseFormatJsonSchema(internalSchema);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj)
    {
        return
            (this is InternalChatResponseFormatText && obj is InternalChatResponseFormatText)
            || (this is InternalChatResponseFormatJsonObject && obj is InternalChatResponseFormatJsonObject)
            || (this is InternalChatResponseFormatJsonSchema thisSchema && obj is InternalChatResponseFormatJsonSchema otherSchema && thisSchema.JsonSchema.Name == otherSchema.JsonSchema.Name);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator==(ChatResponseFormat first, ChatResponseFormat second)
        => first.Equals(second);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator!=(ChatResponseFormat first, ChatResponseFormat second)
        => !first.Equals(second);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}