// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;
using OpenAI;

namespace OpenAI.VectorStores
{
    internal readonly partial struct InternalListVectorStoresResponseObject : IEquatable<InternalListVectorStoresResponseObject>
    {
        private readonly string _value;
        private const string ListValue = "list";

        public InternalListVectorStoresResponseObject(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        public static InternalListVectorStoresResponseObject List { get; } = new InternalListVectorStoresResponseObject(ListValue);

        public static bool operator ==(InternalListVectorStoresResponseObject left, InternalListVectorStoresResponseObject right) => left.Equals(right);

        public static bool operator !=(InternalListVectorStoresResponseObject left, InternalListVectorStoresResponseObject right) => !left.Equals(right);

        public static implicit operator InternalListVectorStoresResponseObject(string value) => new InternalListVectorStoresResponseObject(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalListVectorStoresResponseObject other && Equals(other);

        public bool Equals(InternalListVectorStoresResponseObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        public override string ToString() => _value;
    }
}
