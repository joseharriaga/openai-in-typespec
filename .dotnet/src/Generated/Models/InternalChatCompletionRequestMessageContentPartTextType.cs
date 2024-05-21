// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Chat
{
    /// <summary> The ChatCompletionRequestMessageContentPartText_type. </summary>
    internal readonly partial struct InternalChatCompletionRequestMessageContentPartTextType : IEquatable<InternalChatCompletionRequestMessageContentPartTextType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InternalChatCompletionRequestMessageContentPartTextType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InternalChatCompletionRequestMessageContentPartTextType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TextValue = "text";

        /// <summary> text. </summary>
        public static InternalChatCompletionRequestMessageContentPartTextType Text { get; } = new InternalChatCompletionRequestMessageContentPartTextType(TextValue);
        /// <summary> Determines if two <see cref="InternalChatCompletionRequestMessageContentPartTextType"/> values are the same. </summary>
        public static bool operator ==(InternalChatCompletionRequestMessageContentPartTextType left, InternalChatCompletionRequestMessageContentPartTextType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InternalChatCompletionRequestMessageContentPartTextType"/> values are not the same. </summary>
        public static bool operator !=(InternalChatCompletionRequestMessageContentPartTextType left, InternalChatCompletionRequestMessageContentPartTextType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="InternalChatCompletionRequestMessageContentPartTextType"/>. </summary>
        public static implicit operator InternalChatCompletionRequestMessageContentPartTextType(string value) => new InternalChatCompletionRequestMessageContentPartTextType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalChatCompletionRequestMessageContentPartTextType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InternalChatCompletionRequestMessageContentPartTextType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
