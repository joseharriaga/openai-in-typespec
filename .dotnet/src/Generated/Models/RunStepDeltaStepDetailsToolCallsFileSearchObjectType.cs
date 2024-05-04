// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> The RunStepDeltaStepDetailsToolCallsFileSearchObject_type. </summary>
    internal readonly partial struct RunStepDeltaStepDetailsToolCallsFileSearchObjectType : IEquatable<RunStepDeltaStepDetailsToolCallsFileSearchObjectType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RunStepDeltaStepDetailsToolCallsFileSearchObjectType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RunStepDeltaStepDetailsToolCallsFileSearchObjectType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string FileSearchValue = "file_search";

        /// <summary> file_search. </summary>
        public static RunStepDeltaStepDetailsToolCallsFileSearchObjectType FileSearch { get; } = new RunStepDeltaStepDetailsToolCallsFileSearchObjectType(FileSearchValue);
        /// <summary> Determines if two <see cref="RunStepDeltaStepDetailsToolCallsFileSearchObjectType"/> values are the same. </summary>
        public static bool operator ==(RunStepDeltaStepDetailsToolCallsFileSearchObjectType left, RunStepDeltaStepDetailsToolCallsFileSearchObjectType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RunStepDeltaStepDetailsToolCallsFileSearchObjectType"/> values are not the same. </summary>
        public static bool operator !=(RunStepDeltaStepDetailsToolCallsFileSearchObjectType left, RunStepDeltaStepDetailsToolCallsFileSearchObjectType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RunStepDeltaStepDetailsToolCallsFileSearchObjectType"/>. </summary>
        public static implicit operator RunStepDeltaStepDetailsToolCallsFileSearchObjectType(string value) => new RunStepDeltaStepDetailsToolCallsFileSearchObjectType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RunStepDeltaStepDetailsToolCallsFileSearchObjectType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RunStepDeltaStepDetailsToolCallsFileSearchObjectType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
