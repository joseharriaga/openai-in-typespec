// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Assistants
{
    /// <summary> The MessageRequestContentTextObject_type. </summary>
    internal readonly partial struct InternalMessageRequestContentTextObjectType : IEquatable<InternalMessageRequestContentTextObjectType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InternalMessageRequestContentTextObjectType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InternalMessageRequestContentTextObjectType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TextValue = "text";

        /// <summary> text. </summary>
        public static InternalMessageRequestContentTextObjectType Text { get; } = new InternalMessageRequestContentTextObjectType(TextValue);
        /// <summary> Determines if two <see cref="InternalMessageRequestContentTextObjectType"/> values are the same. </summary>
        public static bool operator ==(InternalMessageRequestContentTextObjectType left, InternalMessageRequestContentTextObjectType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InternalMessageRequestContentTextObjectType"/> values are not the same. </summary>
        public static bool operator !=(InternalMessageRequestContentTextObjectType left, InternalMessageRequestContentTextObjectType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="InternalMessageRequestContentTextObjectType"/>. </summary>
        public static implicit operator InternalMessageRequestContentTextObjectType(string value) => new InternalMessageRequestContentTextObjectType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalMessageRequestContentTextObjectType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InternalMessageRequestContentTextObjectType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
