// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> Enum for reason in MessageObjectIncompleteDetails. </summary>
    internal readonly partial struct MessageObjectIncompleteDetailsReason : IEquatable<MessageObjectIncompleteDetailsReason>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MessageObjectIncompleteDetailsReason"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MessageObjectIncompleteDetailsReason(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ContentFilterValue = "content_filter";
        private const string MaxTokensValue = "max_tokens";
        private const string RunCancelledValue = "run_cancelled";
        private const string RunExpiredValue = "run_expired";
        private const string RunFailedValue = "run_failed";

        /// <summary> content_filter. </summary>
        public static MessageObjectIncompleteDetailsReason ContentFilter { get; } = new MessageObjectIncompleteDetailsReason(ContentFilterValue);
        /// <summary> max_tokens. </summary>
        public static MessageObjectIncompleteDetailsReason MaxTokens { get; } = new MessageObjectIncompleteDetailsReason(MaxTokensValue);
        /// <summary> run_cancelled. </summary>
        public static MessageObjectIncompleteDetailsReason RunCancelled { get; } = new MessageObjectIncompleteDetailsReason(RunCancelledValue);
        /// <summary> run_expired. </summary>
        public static MessageObjectIncompleteDetailsReason RunExpired { get; } = new MessageObjectIncompleteDetailsReason(RunExpiredValue);
        /// <summary> run_failed. </summary>
        public static MessageObjectIncompleteDetailsReason RunFailed { get; } = new MessageObjectIncompleteDetailsReason(RunFailedValue);
        /// <summary> Determines if two <see cref="MessageObjectIncompleteDetailsReason"/> values are the same. </summary>
        public static bool operator ==(MessageObjectIncompleteDetailsReason left, MessageObjectIncompleteDetailsReason right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MessageObjectIncompleteDetailsReason"/> values are not the same. </summary>
        public static bool operator !=(MessageObjectIncompleteDetailsReason left, MessageObjectIncompleteDetailsReason right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MessageObjectIncompleteDetailsReason"/>. </summary>
        public static implicit operator MessageObjectIncompleteDetailsReason(string value) => new MessageObjectIncompleteDetailsReason(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MessageObjectIncompleteDetailsReason other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MessageObjectIncompleteDetailsReason other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
