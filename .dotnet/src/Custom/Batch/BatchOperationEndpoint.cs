using System;
using System.ComponentModel;

namespace OpenAI.Batch;

/// <summary>
/// Represents an API endpoint usable for batch operations.
/// </summary>
public readonly partial struct BatchOperationEndpoint : IEquatable<BatchOperationEndpoint>
{
    private readonly string _value;

    /// <summary>
    /// Creates a new instance of <see cref="BatchOperationEndpoint"/>.
    /// </summary>
    /// <param name="value"></param>
    public BatchOperationEndpoint(string value)
    {
        _value = value;
    }

    /// <summary>
    /// Specifies the /v1/chat/completions endpoint.
    /// </summary>
    public static BatchOperationEndpoint V1_Chat_Completions = new("/v1/chat/completions");

    /// <summary> Determines if two <see cref="BatchOperationEndpoint"/> values are the same. </summary>
    public static bool operator ==(BatchOperationEndpoint left, BatchOperationEndpoint right) => left.Equals(right);

    /// <summary> Determines if two <see cref="BatchOperationEndpoint"/> values are not the same. </summary>
    public static bool operator !=(BatchOperationEndpoint left, BatchOperationEndpoint right) => !left.Equals(right);

    /// <summary> Converts a string to a <see cref="BatchOperationEndpoint"/>. </summary>
    public static implicit operator BatchOperationEndpoint(string value) => new BatchOperationEndpoint(value);

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => obj is BatchOperationEndpoint other && Equals(other);

    /// <inheritdoc />
    public bool Equals(BatchOperationEndpoint other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;

    /// <inheritdoc/>
    public override string ToString() => _value;
}