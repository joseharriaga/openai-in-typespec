// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Assistants
{
    /// <summary> Enum for reason in MessageFailureDetails. </summary>
    public readonly partial struct MessageFailureReason : IEquatable<MessageFailureReason>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MessageFailureReason"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MessageFailureReason(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ContentFilterValue = "content_filter";
        private const string MaxTokensValue = "max_tokens";
        private const string RunCancelledValue = "run_cancelled";
        private const string RunExpiredValue = "run_expired";
        private const string RunFailedValue = "run_failed";

        /// <summary> content_filter. </summary>
        public static MessageFailureReason ContentFilter { get; } = new MessageFailureReason(ContentFilterValue);
        /// <summary> max_tokens. </summary>
        public static MessageFailureReason MaxTokens { get; } = new MessageFailureReason(MaxTokensValue);
        /// <summary> run_cancelled. </summary>
        public static MessageFailureReason RunCancelled { get; } = new MessageFailureReason(RunCancelledValue);
        /// <summary> run_expired. </summary>
        public static MessageFailureReason RunExpired { get; } = new MessageFailureReason(RunExpiredValue);
        /// <summary> run_failed. </summary>
        public static MessageFailureReason RunFailed { get; } = new MessageFailureReason(RunFailedValue);
        /// <summary> Determines if two <see cref="MessageFailureReason"/> values are the same. </summary>
        public static bool operator ==(MessageFailureReason left, MessageFailureReason right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MessageFailureReason"/> values are not the same. </summary>
        public static bool operator !=(MessageFailureReason left, MessageFailureReason right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MessageFailureReason"/>. </summary>
        public static implicit operator MessageFailureReason(string value) => new MessageFailureReason(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MessageFailureReason other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MessageFailureReason other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}