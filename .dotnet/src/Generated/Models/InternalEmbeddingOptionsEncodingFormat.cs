// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Embeddings
{
    /// <summary> Enum for encoding_format in EmbeddingOptions. </summary>
    internal readonly partial struct InternalEmbeddingOptionsEncodingFormat : IEquatable<InternalEmbeddingOptionsEncodingFormat>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InternalEmbeddingOptionsEncodingFormat"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InternalEmbeddingOptionsEncodingFormat(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string FloatValue = "float";
        private const string Base64Value = "base64";

        /// <summary> float. </summary>
        public static InternalEmbeddingOptionsEncodingFormat Float { get; } = new InternalEmbeddingOptionsEncodingFormat(FloatValue);
        /// <summary> base64. </summary>
        public static InternalEmbeddingOptionsEncodingFormat Base64 { get; } = new InternalEmbeddingOptionsEncodingFormat(Base64Value);
        /// <summary> Determines if two <see cref="InternalEmbeddingOptionsEncodingFormat"/> values are the same. </summary>
        public static bool operator ==(InternalEmbeddingOptionsEncodingFormat left, InternalEmbeddingOptionsEncodingFormat right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InternalEmbeddingOptionsEncodingFormat"/> values are not the same. </summary>
        public static bool operator !=(InternalEmbeddingOptionsEncodingFormat left, InternalEmbeddingOptionsEncodingFormat right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="InternalEmbeddingOptionsEncodingFormat"/>. </summary>
        public static implicit operator InternalEmbeddingOptionsEncodingFormat(string value) => new InternalEmbeddingOptionsEncodingFormat(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalEmbeddingOptionsEncodingFormat other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InternalEmbeddingOptionsEncodingFormat other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
