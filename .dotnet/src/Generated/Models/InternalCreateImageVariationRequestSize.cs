// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Images
{
    internal readonly partial struct InternalCreateImageVariationRequestSize : IEquatable<InternalCreateImageVariationRequestSize>
    {
        private readonly string _value;

        public InternalCreateImageVariationRequestSize(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string _256x256Value = "256x256";
        private const string _512x512Value = "512x512";
        private const string _1024x1024Value = "1024x1024";

        public static InternalCreateImageVariationRequestSize _256x256 { get; } = new InternalCreateImageVariationRequestSize(_256x256Value);
        public static InternalCreateImageVariationRequestSize _512x512 { get; } = new InternalCreateImageVariationRequestSize(_512x512Value);
        public static InternalCreateImageVariationRequestSize _1024x1024 { get; } = new InternalCreateImageVariationRequestSize(_1024x1024Value);
        public static bool operator ==(InternalCreateImageVariationRequestSize left, InternalCreateImageVariationRequestSize right) => left.Equals(right);
        public static bool operator !=(InternalCreateImageVariationRequestSize left, InternalCreateImageVariationRequestSize right) => !left.Equals(right);
        public static implicit operator InternalCreateImageVariationRequestSize(string value) => new InternalCreateImageVariationRequestSize(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalCreateImageVariationRequestSize other && Equals(other);
        public bool Equals(InternalCreateImageVariationRequestSize other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }
}
