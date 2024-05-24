// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Embeddings
{
    internal readonly partial struct InternalCreateEmbeddingRequestModel : IEquatable<InternalCreateEmbeddingRequestModel>
    {
        private readonly string _value;

        public InternalCreateEmbeddingRequestModel(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TextEmbeddingAda002Value = "text-embedding-ada-002";
        private const string TextEmbedding3SmallValue = "text-embedding-3-small";
        private const string TextEmbedding3LargeValue = "text-embedding-3-large";

        public static InternalCreateEmbeddingRequestModel TextEmbeddingAda002 { get; } = new InternalCreateEmbeddingRequestModel(TextEmbeddingAda002Value);
        public static InternalCreateEmbeddingRequestModel TextEmbedding3Small { get; } = new InternalCreateEmbeddingRequestModel(TextEmbedding3SmallValue);
        public static InternalCreateEmbeddingRequestModel TextEmbedding3Large { get; } = new InternalCreateEmbeddingRequestModel(TextEmbedding3LargeValue);
        public static bool operator ==(InternalCreateEmbeddingRequestModel left, InternalCreateEmbeddingRequestModel right) => left.Equals(right);
        public static bool operator !=(InternalCreateEmbeddingRequestModel left, InternalCreateEmbeddingRequestModel right) => !left.Equals(right);
        public static implicit operator InternalCreateEmbeddingRequestModel(string value) => new InternalCreateEmbeddingRequestModel(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalCreateEmbeddingRequestModel other && Equals(other);
        public bool Equals(InternalCreateEmbeddingRequestModel other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }
}
