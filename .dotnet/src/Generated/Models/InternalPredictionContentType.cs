// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;
using OpenAI;

namespace OpenAI.Chat
{
    internal readonly partial struct InternalPredictionContentType : IEquatable<InternalPredictionContentType>
    {
        private readonly string _value;
        private const string ContentValue = "content";

        public InternalPredictionContentType(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        public static InternalPredictionContentType Content { get; } = new InternalPredictionContentType(ContentValue);

        public static bool operator ==(InternalPredictionContentType left, InternalPredictionContentType right) => left.Equals(right);

        public static bool operator !=(InternalPredictionContentType left, InternalPredictionContentType right) => !left.Equals(right);

        public static implicit operator InternalPredictionContentType(string value) => new InternalPredictionContentType(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalPredictionContentType other && Equals(other);

        public bool Equals(InternalPredictionContentType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        public override string ToString() => _value;
    }
}
