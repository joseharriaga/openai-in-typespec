// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    internal readonly partial struct ChatCompletionServiceTier : IEquatable<ChatCompletionServiceTier>
    {
        private readonly string _value;

        public ChatCompletionServiceTier(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ScaleValue = "scale";
        private const string DefaultValue = "default";

        public static ChatCompletionServiceTier Scale { get; } = new ChatCompletionServiceTier(ScaleValue);
        public static ChatCompletionServiceTier Default { get; } = new ChatCompletionServiceTier(DefaultValue);
        public static bool operator ==(ChatCompletionServiceTier left, ChatCompletionServiceTier right) => left.Equals(right);
        public static bool operator !=(ChatCompletionServiceTier left, ChatCompletionServiceTier right) => !left.Equals(right);
        public static implicit operator ChatCompletionServiceTier(string value) => new ChatCompletionServiceTier(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ChatCompletionServiceTier other && Equals(other);
        public bool Equals(ChatCompletionServiceTier other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }
}
