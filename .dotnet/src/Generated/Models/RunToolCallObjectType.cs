// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    internal readonly partial struct RunToolCallObjectType : IEquatable<RunToolCallObjectType>
    {
        private readonly string _value;

        public RunToolCallObjectType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string FunctionValue = "function";

        public static RunToolCallObjectType Function { get; } = new RunToolCallObjectType(FunctionValue);
        public static bool operator ==(RunToolCallObjectType left, RunToolCallObjectType right) => left.Equals(right);
        public static bool operator !=(RunToolCallObjectType left, RunToolCallObjectType right) => !left.Equals(right);
        public static implicit operator RunToolCallObjectType(string value) => new RunToolCallObjectType(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RunToolCallObjectType other && Equals(other);
        public bool Equals(RunToolCallObjectType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }
}
