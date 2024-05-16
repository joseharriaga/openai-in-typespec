using System;
using System.ComponentModel;

namespace OpenAI.Assistants;

[CodeGenModel("AssistantResponseFormat")]
public partial class AssistantResponseFormat
{
    private readonly string _value;
    private readonly bool _isPlainString;

    private const string NoneValue = "none";
    private const string AutoValue = "auto";
    private const string TextValue = "text";
    private const string JsonObjectValue = "json_object";

    /// <summary>
    /// 
    /// </summary>
    public static AssistantResponseFormat None { get; } = new(NoneValue, isStringLiteral: true);

    /// <summary>
    /// Default option. Specifies that the model should automatically determine whether it should respond with
    /// plain text or another format.
    /// </summary>
    public static AssistantResponseFormat Auto { get; } = new(AutoValue, isStringLiteral: true);

    /// <summary>
    /// Specifies that the model should respond with plain text.
    /// </summary>
    public static AssistantResponseFormat Text { get; } = new(TextValue, isStringLiteral: false);

    /// <summary>
    /// Specifies that the model should reply with a structured JSON object, enabling JSON mode.
    /// </summary>
    /// <remarks>
    /// **Important:** when using JSON mode, you **must** also instruct the model to produce JSON yourself via a
    /// system or user message. Without this, the model may generate an unending stream of whitespace until the
    /// generation reaches the token limit, resulting in a long-running and seemingly "stuck" request. Also note that
    /// the message content may be partially cut off if `finish_reason="length"`, which indicates the generation
    /// exceeded `max_tokens` or the conversation exceeded the max context length.
    /// </remarks>
    public static AssistantResponseFormat JsonObject { get; } = new(JsonObjectValue, isStringLiteral: false);

    /// <summary>
    /// Creates a new instance of <see cref="AssistantResponseFormat"/>.
    /// </summary>
    /// <remarks>
    /// Consider using one of the static properties available on <see cref="AssistantResponseFormat"/>, instead.
    /// </remarks>
    /// <param name="value"></param>
    public AssistantResponseFormat(string value)
        : this(value, isStringLiteral: true)
    {}

    internal AssistantResponseFormat(string value, bool isStringLiteral)
    {
        _value = value;
        _isPlainString = isStringLiteral;
    }

    /// <inheritdoc />
    public static bool operator ==(AssistantResponseFormat left, AssistantResponseFormat right) => left.Equals(right);
    /// <inheritdoc />
    public static bool operator !=(AssistantResponseFormat left, AssistantResponseFormat right) => !left.Equals(right);
    /// <inheritdoc />
    public static implicit operator AssistantResponseFormat(string value) => new AssistantResponseFormat(value);
    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => obj is AssistantResponseFormat other && Equals(other);
    /// <inheritdoc />
    public bool Equals(AssistantResponseFormat other) => _isPlainString == other?._isPlainString && string.Equals(_value, other?._value, StringComparison.InvariantCultureIgnoreCase);
    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => $"{_value}:{_isPlainString}".GetHashCode();
    /// <inheritdoc />
    public override string ToString() => _value;
}
