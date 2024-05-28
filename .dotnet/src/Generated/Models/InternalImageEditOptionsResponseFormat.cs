// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Images
{
    /// <summary> Enum for response_format in ImageEditOptions. </summary>
    internal readonly partial struct InternalImageEditOptionsResponseFormat : IEquatable<InternalImageEditOptionsResponseFormat>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InternalImageEditOptionsResponseFormat"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InternalImageEditOptionsResponseFormat(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UrlValue = "url";
        private const string B64JsonValue = "b64_json";

        /// <summary> url. </summary>
        public static InternalImageEditOptionsResponseFormat Url { get; } = new InternalImageEditOptionsResponseFormat(UrlValue);
        /// <summary> b64_json. </summary>
        public static InternalImageEditOptionsResponseFormat B64Json { get; } = new InternalImageEditOptionsResponseFormat(B64JsonValue);
        /// <summary> Determines if two <see cref="InternalImageEditOptionsResponseFormat"/> values are the same. </summary>
        public static bool operator ==(InternalImageEditOptionsResponseFormat left, InternalImageEditOptionsResponseFormat right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InternalImageEditOptionsResponseFormat"/> values are not the same. </summary>
        public static bool operator !=(InternalImageEditOptionsResponseFormat left, InternalImageEditOptionsResponseFormat right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="InternalImageEditOptionsResponseFormat"/>. </summary>
        public static implicit operator InternalImageEditOptionsResponseFormat(string value) => new InternalImageEditOptionsResponseFormat(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalImageEditOptionsResponseFormat other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InternalImageEditOptionsResponseFormat other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}