// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Chat
{
    internal readonly partial struct InternalChatCompletionRequestMessageContentPartImageType : IEquatable<InternalChatCompletionRequestMessageContentPartImageType>
    {
        private readonly string _value;

        public InternalChatCompletionRequestMessageContentPartImageType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ImageUrlValue = "image_url";

        public static InternalChatCompletionRequestMessageContentPartImageType ImageUrl { get; } = new InternalChatCompletionRequestMessageContentPartImageType(ImageUrlValue);
        public static bool operator ==(InternalChatCompletionRequestMessageContentPartImageType left, InternalChatCompletionRequestMessageContentPartImageType right) => left.Equals(right);
        public static bool operator !=(InternalChatCompletionRequestMessageContentPartImageType left, InternalChatCompletionRequestMessageContentPartImageType right) => !left.Equals(right);
        public static implicit operator InternalChatCompletionRequestMessageContentPartImageType(string value) => new InternalChatCompletionRequestMessageContentPartImageType(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalChatCompletionRequestMessageContentPartImageType other && Equals(other);
        public bool Equals(InternalChatCompletionRequestMessageContentPartImageType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }
}
