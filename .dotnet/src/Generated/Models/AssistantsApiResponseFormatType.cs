// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> Enum for type in AssistantsApiResponseFormat. </summary>
    internal readonly partial struct AssistantsApiResponseFormatType : IEquatable<AssistantsApiResponseFormatType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AssistantsApiResponseFormatType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AssistantsApiResponseFormatType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TextValue = "text";
        private const string JsonObjectValue = "json_object";

        /// <summary> text. </summary>
        public static AssistantsApiResponseFormatType Text { get; } = new AssistantsApiResponseFormatType(TextValue);
        /// <summary> json_object. </summary>
        public static AssistantsApiResponseFormatType JsonObject { get; } = new AssistantsApiResponseFormatType(JsonObjectValue);
        /// <summary> Determines if two <see cref="AssistantsApiResponseFormatType"/> values are the same. </summary>
        public static bool operator ==(AssistantsApiResponseFormatType left, AssistantsApiResponseFormatType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AssistantsApiResponseFormatType"/> values are not the same. </summary>
        public static bool operator !=(AssistantsApiResponseFormatType left, AssistantsApiResponseFormatType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="AssistantsApiResponseFormatType"/>. </summary>
        public static implicit operator AssistantsApiResponseFormatType(string value) => new AssistantsApiResponseFormatType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AssistantsApiResponseFormatType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AssistantsApiResponseFormatType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
