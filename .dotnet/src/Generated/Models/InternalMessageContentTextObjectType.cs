// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Assistants
{
    /// <summary> The MessageContentTextObject_type. </summary>
    internal readonly partial struct InternalMessageContentTextObjectType : IEquatable<InternalMessageContentTextObjectType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InternalMessageContentTextObjectType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InternalMessageContentTextObjectType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TextValue = "text";

        /// <summary> text. </summary>
        public static InternalMessageContentTextObjectType Text { get; } = new InternalMessageContentTextObjectType(TextValue);
        /// <summary> Determines if two <see cref="InternalMessageContentTextObjectType"/> values are the same. </summary>
        public static bool operator ==(InternalMessageContentTextObjectType left, InternalMessageContentTextObjectType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InternalMessageContentTextObjectType"/> values are not the same. </summary>
        public static bool operator !=(InternalMessageContentTextObjectType left, InternalMessageContentTextObjectType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="InternalMessageContentTextObjectType"/>. </summary>
        public static implicit operator InternalMessageContentTextObjectType(string value) => new InternalMessageContentTextObjectType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalMessageContentTextObjectType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InternalMessageContentTextObjectType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}