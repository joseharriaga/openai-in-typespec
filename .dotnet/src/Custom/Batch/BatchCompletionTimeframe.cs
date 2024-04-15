using System;
using System.ComponentModel;

namespace OpenAI.Batch;

/// <summary> The service client for OpenAI image operations. </summary>
public readonly partial struct BatchCompletionTimeframe : IEquatable<BatchCompletionTimeframe>
{
    private readonly string _value;

    /// <summary>
    /// Creates a new instance of <see cref="BatchCompletionTimeframe"/>.
    /// </summary>
    /// <param name="value"> The underlying string value for the timeframe. </param>
    public BatchCompletionTimeframe(string value)
    {
        _value = value;
    }

    /// <summary>
    /// Specifies that the batch should be completed within 24 hours of creation.
    /// </summary>
    public static BatchCompletionTimeframe Within_24H = new("24h");

    /// <summary> Determines if two <see cref="BatchCompletionTimeframe"/> values are the same. </summary>
    public static bool operator ==(BatchCompletionTimeframe left, BatchCompletionTimeframe right) => left.Equals(right);

    /// <summary> Determines if two <see cref="BatchCompletionTimeframe"/> values are not the same. </summary>
    public static bool operator !=(BatchCompletionTimeframe left, BatchCompletionTimeframe right) => !left.Equals(right);

    /// <summary> Converts a string to a <see cref="BatchCompletionTimeframe"/>. </summary>
    public static implicit operator BatchCompletionTimeframe(string value) => new BatchCompletionTimeframe(value);

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => obj is BatchCompletionTimeframe other && Equals(other);

    /// <inheritdoc />
    public bool Equals(BatchCompletionTimeframe other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;

    /// <inheritdoc/>
    public override string ToString() => _value;
}