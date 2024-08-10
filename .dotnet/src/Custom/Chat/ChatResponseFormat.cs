using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
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
public partial class ChatResponseFormat : IEquatable<ChatResponseFormat>
{
    private readonly BinaryData _binaryValue;

    public static ChatResponseFormat Text { get; }
        = new(ModelReaderWriter.Write(new InternalResponseFormatText()));
    public static ChatResponseFormat JsonObject { get; }
        = new(ModelReaderWriter.Write(new InternalResponseFormatJsonObject()));
    public static ChatResponseFormat FromDefinition(ChatResponseFormatDefinition formatDefinition)
        => new(ModelReaderWriter.Write(formatDefinition));

    internal ChatResponseFormat(BinaryData binaryValue)
    {
        _binaryValue = binaryValue;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    bool IEquatable<ChatResponseFormat>.Equals(ChatResponseFormat other)
        => (this._binaryValue is not null && other?._binaryValue is not null && this._binaryValue.ToString() == other._binaryValue.ToString());

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj)
        => obj is ChatResponseFormat format && this.Equals(format);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _binaryValue.GetHashCode();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator ==(ChatResponseFormat first, ChatResponseFormat second)
        => first?.Equals(second) == true;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator !=(ChatResponseFormat first, ChatResponseFormat second)
        => first?.Equals(second) != true;

    public static implicit operator ChatResponseFormat(BinaryData binaryData) => new(binaryData);
}