// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> The MessageDeltaContentTextAnnotationsFileCitationObject_type. </summary>
    internal readonly partial struct MessageDeltaContentTextAnnotationsFileCitationObjectType : IEquatable<MessageDeltaContentTextAnnotationsFileCitationObjectType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MessageDeltaContentTextAnnotationsFileCitationObjectType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MessageDeltaContentTextAnnotationsFileCitationObjectType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string FileCitationValue = "file_citation";

        /// <summary> file_citation. </summary>
        public static MessageDeltaContentTextAnnotationsFileCitationObjectType FileCitation { get; } = new MessageDeltaContentTextAnnotationsFileCitationObjectType(FileCitationValue);
        /// <summary> Determines if two <see cref="MessageDeltaContentTextAnnotationsFileCitationObjectType"/> values are the same. </summary>
        public static bool operator ==(MessageDeltaContentTextAnnotationsFileCitationObjectType left, MessageDeltaContentTextAnnotationsFileCitationObjectType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MessageDeltaContentTextAnnotationsFileCitationObjectType"/> values are not the same. </summary>
        public static bool operator !=(MessageDeltaContentTextAnnotationsFileCitationObjectType left, MessageDeltaContentTextAnnotationsFileCitationObjectType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MessageDeltaContentTextAnnotationsFileCitationObjectType"/>. </summary>
        public static implicit operator MessageDeltaContentTextAnnotationsFileCitationObjectType(string value) => new MessageDeltaContentTextAnnotationsFileCitationObjectType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MessageDeltaContentTextAnnotationsFileCitationObjectType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MessageDeltaContentTextAnnotationsFileCitationObjectType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
