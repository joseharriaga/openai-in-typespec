// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Images
{
    internal readonly partial struct InternalImageVariationOptionsSize : IEquatable<InternalImageVariationOptionsSize>
    {
        private readonly string _value;

        public InternalImageVariationOptionsSize(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string _256x256Value = "256x256";
        private const string _512x512Value = "512x512";
        private const string _1024x1024Value = "1024x1024";

        public static InternalImageVariationOptionsSize _256x256 { get; } = new InternalImageVariationOptionsSize(_256x256Value);
        public static InternalImageVariationOptionsSize _512x512 { get; } = new InternalImageVariationOptionsSize(_512x512Value);
        public static InternalImageVariationOptionsSize _1024x1024 { get; } = new InternalImageVariationOptionsSize(_1024x1024Value);
        public static bool operator ==(InternalImageVariationOptionsSize left, InternalImageVariationOptionsSize right) => left.Equals(right);
        public static bool operator !=(InternalImageVariationOptionsSize left, InternalImageVariationOptionsSize right) => !left.Equals(right);
        public static implicit operator InternalImageVariationOptionsSize(string value) => new InternalImageVariationOptionsSize(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalImageVariationOptionsSize other && Equals(other);
        public bool Equals(InternalImageVariationOptionsSize other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }
}
