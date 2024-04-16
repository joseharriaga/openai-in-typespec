 using System;
using System.ComponentModel;

namespace OpenAI.Files;

public readonly partial struct OpenAIFilePurpose
{
    private readonly string _value;

    /// <summary> Initializes a new instance of <see cref="OpenAIFilePurpose"/>. </summary>
    /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
    public OpenAIFilePurpose(string value)
    {
        _value = value ?? throw new ArgumentNullException(nameof(value));
    }

    internal OpenAIFilePurpose(Internal.Models.OpenAIFilePurpose internalPurpose)
        : this(internalPurpose.ToString())
    { }

    /// <summary> fine-tune. </summary>
    public static OpenAIFilePurpose FineTune { get; } = new OpenAIFilePurpose(Internal.Models.OpenAIFilePurpose.FineTune);
    /// <summary> fine-tune-results. </summary>
    public static OpenAIFilePurpose FineTuneResults { get; } = new OpenAIFilePurpose(Internal.Models.OpenAIFilePurpose.FineTuneResults);
    /// <summary> assistants. </summary>
    public static OpenAIFilePurpose Assistants { get; } = new OpenAIFilePurpose(Internal.Models.OpenAIFilePurpose.Assistants);
    /// <summary> assistants_output. </summary>
    public static OpenAIFilePurpose AssistantsOutput { get; } = new OpenAIFilePurpose(Internal.Models.OpenAIFilePurpose.AssistantsOutput);
    /// <summary> batch. </summary>
    public static OpenAIFilePurpose BatchInput { get; } = new OpenAIFilePurpose(Internal.Models.OpenAIFilePurpose.Batch);
    /// <summary> batch_output. </summary>
    public static OpenAIFilePurpose BatchOutput { get; } = new OpenAIFilePurpose(Internal.Models.OpenAIFilePurpose.BatchOutput);

    /// <summary> Determines if two <see cref="OpenAIFilePurpose"/> values are the same. </summary>
    public static bool operator ==(OpenAIFilePurpose left, OpenAIFilePurpose right) => left.Equals(right);
    /// <summary> Determines if two <see cref="OpenAIFilePurpose"/> values are not the same. </summary>
    public static bool operator !=(OpenAIFilePurpose left, OpenAIFilePurpose right) => !left.Equals(right);
    /// <summary> Converts a string to a <see cref="OpenAIFilePurpose"/>. </summary>
    public static implicit operator OpenAIFilePurpose(string value) => new OpenAIFilePurpose(value);

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => obj is OpenAIFilePurpose other && Equals(other);
    /// <inheritdoc />
    public bool Equals(OpenAIFilePurpose other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;
    /// <inheritdoc />
    public override string ToString() => _value;
}