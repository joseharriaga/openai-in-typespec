// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> The RunStepDetailsToolCallsRetrievalObject_type. </summary>
    internal readonly partial struct RunStepDetailsToolCallsRetrievalObjectType : IEquatable<RunStepDetailsToolCallsRetrievalObjectType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RunStepDetailsToolCallsRetrievalObjectType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RunStepDetailsToolCallsRetrievalObjectType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RetrievalValue = "retrieval";

        /// <summary> retrieval. </summary>
        public static RunStepDetailsToolCallsRetrievalObjectType Retrieval { get; } = new RunStepDetailsToolCallsRetrievalObjectType(RetrievalValue);
        /// <summary> Determines if two <see cref="RunStepDetailsToolCallsRetrievalObjectType"/> values are the same. </summary>
        public static bool operator ==(RunStepDetailsToolCallsRetrievalObjectType left, RunStepDetailsToolCallsRetrievalObjectType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RunStepDetailsToolCallsRetrievalObjectType"/> values are not the same. </summary>
        public static bool operator !=(RunStepDetailsToolCallsRetrievalObjectType left, RunStepDetailsToolCallsRetrievalObjectType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RunStepDetailsToolCallsRetrievalObjectType"/>. </summary>
        public static implicit operator RunStepDetailsToolCallsRetrievalObjectType(string value) => new RunStepDetailsToolCallsRetrievalObjectType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RunStepDetailsToolCallsRetrievalObjectType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RunStepDetailsToolCallsRetrievalObjectType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
