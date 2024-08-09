using System;
using OpenAI.Internal;
using OpenAI.Models;

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
public readonly partial struct ChatResponseFormat
{
    internal static ChatResponseFormat Auto { get; }

    public static ChatResponseFormat Text { get; } = new($@"{{""type"":""text""}}");
    public static ChatResponseFormat JsonObject { get; } = new($@"{{""type"":""json_object""}}");
    public static ChatResponseFormat FromJsonSchema(BinaryData jsonSchema)
        => new($@"{{""type"":""json_schema"",""json_schema"":""{jsonSchema.ToString()}""}}");
}