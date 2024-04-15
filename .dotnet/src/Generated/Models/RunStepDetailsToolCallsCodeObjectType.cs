// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> The RunStepDetailsToolCallsCodeObject_type. </summary>
    internal readonly partial struct RunStepDetailsToolCallsCodeObjectType : IEquatable<RunStepDetailsToolCallsCodeObjectType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RunStepDetailsToolCallsCodeObjectType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RunStepDetailsToolCallsCodeObjectType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CodeInterpreterValue = "code_interpreter";

        /// <summary> code_interpreter. </summary>
        public static RunStepDetailsToolCallsCodeObjectType CodeInterpreter { get; } = new RunStepDetailsToolCallsCodeObjectType(CodeInterpreterValue);
        /// <summary> Determines if two <see cref="RunStepDetailsToolCallsCodeObjectType"/> values are the same. </summary>
        public static bool operator ==(RunStepDetailsToolCallsCodeObjectType left, RunStepDetailsToolCallsCodeObjectType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RunStepDetailsToolCallsCodeObjectType"/> values are not the same. </summary>
        public static bool operator !=(RunStepDetailsToolCallsCodeObjectType left, RunStepDetailsToolCallsCodeObjectType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RunStepDetailsToolCallsCodeObjectType"/>. </summary>
        public static implicit operator RunStepDetailsToolCallsCodeObjectType(string value) => new RunStepDetailsToolCallsCodeObjectType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RunStepDetailsToolCallsCodeObjectType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RunStepDetailsToolCallsCodeObjectType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
