// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> The AssistantToolsFunction_type. </summary>
    internal readonly partial struct AssistantToolsFunctionType : IEquatable<AssistantToolsFunctionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AssistantToolsFunctionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AssistantToolsFunctionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string FunctionValue = "function";

        /// <summary> function. </summary>
        public static AssistantToolsFunctionType Function { get; } = new AssistantToolsFunctionType(FunctionValue);
        /// <summary> Determines if two <see cref="AssistantToolsFunctionType"/> values are the same. </summary>
        public static bool operator ==(AssistantToolsFunctionType left, AssistantToolsFunctionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AssistantToolsFunctionType"/> values are not the same. </summary>
        public static bool operator !=(AssistantToolsFunctionType left, AssistantToolsFunctionType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="AssistantToolsFunctionType"/>. </summary>
        public static implicit operator AssistantToolsFunctionType(string value) => new AssistantToolsFunctionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AssistantToolsFunctionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AssistantToolsFunctionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
