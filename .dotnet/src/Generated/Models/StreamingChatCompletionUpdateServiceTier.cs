// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    internal readonly partial struct StreamingChatCompletionUpdateServiceTier : IEquatable<StreamingChatCompletionUpdateServiceTier>
    {
        private readonly string _value;

        public StreamingChatCompletionUpdateServiceTier(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ScaleValue = "scale";
        private const string DefaultValue = "default";

        public static StreamingChatCompletionUpdateServiceTier Scale { get; } = new StreamingChatCompletionUpdateServiceTier(ScaleValue);
        public static StreamingChatCompletionUpdateServiceTier Default { get; } = new StreamingChatCompletionUpdateServiceTier(DefaultValue);
        public static bool operator ==(StreamingChatCompletionUpdateServiceTier left, StreamingChatCompletionUpdateServiceTier right) => left.Equals(right);
        public static bool operator !=(StreamingChatCompletionUpdateServiceTier left, StreamingChatCompletionUpdateServiceTier right) => !left.Equals(right);
        public static implicit operator StreamingChatCompletionUpdateServiceTier(string value) => new StreamingChatCompletionUpdateServiceTier(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StreamingChatCompletionUpdateServiceTier other && Equals(other);
        public bool Equals(StreamingChatCompletionUpdateServiceTier other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }
}