// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    internal readonly partial struct VectorStoreFileBatchObjectObject : IEquatable<VectorStoreFileBatchObjectObject>
    {
        private readonly string _value;

        public VectorStoreFileBatchObjectObject(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string VectorStoreFilesBatchValue = "vector_store.files_batch";

        public static VectorStoreFileBatchObjectObject VectorStoreFilesBatch { get; } = new VectorStoreFileBatchObjectObject(VectorStoreFilesBatchValue);
        public static bool operator ==(VectorStoreFileBatchObjectObject left, VectorStoreFileBatchObjectObject right) => left.Equals(right);
        public static bool operator !=(VectorStoreFileBatchObjectObject left, VectorStoreFileBatchObjectObject right) => !left.Equals(right);
        public static implicit operator VectorStoreFileBatchObjectObject(string value) => new VectorStoreFileBatchObjectObject(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is VectorStoreFileBatchObjectObject other && Equals(other);
        public bool Equals(VectorStoreFileBatchObjectObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }
}
