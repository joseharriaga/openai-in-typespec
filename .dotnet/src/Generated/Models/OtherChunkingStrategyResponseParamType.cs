// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    internal readonly partial struct OtherChunkingStrategyResponseParamType : IEquatable<OtherChunkingStrategyResponseParamType>
    {
        private readonly string _value;

        public OtherChunkingStrategyResponseParamType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string OtherValue = "other";

        public static OtherChunkingStrategyResponseParamType Other { get; } = new OtherChunkingStrategyResponseParamType(OtherValue);
        public static bool operator ==(OtherChunkingStrategyResponseParamType left, OtherChunkingStrategyResponseParamType right) => left.Equals(right);
        public static bool operator !=(OtherChunkingStrategyResponseParamType left, OtherChunkingStrategyResponseParamType right) => !left.Equals(right);
        public static implicit operator OtherChunkingStrategyResponseParamType(string value) => new OtherChunkingStrategyResponseParamType(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is OtherChunkingStrategyResponseParamType other && Equals(other);
        public bool Equals(OtherChunkingStrategyResponseParamType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }
}