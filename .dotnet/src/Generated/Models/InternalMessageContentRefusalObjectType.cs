// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Assistants
{
    internal readonly partial struct InternalMessageContentRefusalObjectType : IEquatable<InternalMessageContentRefusalObjectType>
    {
        private readonly string _value;

        public InternalMessageContentRefusalObjectType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RefusalValue = "refusal";

        public static InternalMessageContentRefusalObjectType Refusal { get; } = new InternalMessageContentRefusalObjectType(RefusalValue);
        public static bool operator ==(InternalMessageContentRefusalObjectType left, InternalMessageContentRefusalObjectType right) => left.Equals(right);
        public static bool operator !=(InternalMessageContentRefusalObjectType left, InternalMessageContentRefusalObjectType right) => !left.Equals(right);
        public static implicit operator InternalMessageContentRefusalObjectType(string value) => new InternalMessageContentRefusalObjectType(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalMessageContentRefusalObjectType other && Equals(other);
        public bool Equals(InternalMessageContentRefusalObjectType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }
}
