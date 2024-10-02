// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.RealtimeConversation
{
    internal readonly partial struct InternalRealtimeResponseIncompleteStatusDetailsReason : IEquatable<InternalRealtimeResponseIncompleteStatusDetailsReason>
    {
        private readonly string _value;

        public InternalRealtimeResponseIncompleteStatusDetailsReason(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MaxOutputTokensValue = "max_output_tokens";
        private const string ContentFilterValue = "content_filter";

        public static InternalRealtimeResponseIncompleteStatusDetailsReason MaxOutputTokens { get; } = new InternalRealtimeResponseIncompleteStatusDetailsReason(MaxOutputTokensValue);
        public static InternalRealtimeResponseIncompleteStatusDetailsReason ContentFilter { get; } = new InternalRealtimeResponseIncompleteStatusDetailsReason(ContentFilterValue);
        public static bool operator ==(InternalRealtimeResponseIncompleteStatusDetailsReason left, InternalRealtimeResponseIncompleteStatusDetailsReason right) => left.Equals(right);
        public static bool operator !=(InternalRealtimeResponseIncompleteStatusDetailsReason left, InternalRealtimeResponseIncompleteStatusDetailsReason right) => !left.Equals(right);
        public static implicit operator InternalRealtimeResponseIncompleteStatusDetailsReason(string value) => new InternalRealtimeResponseIncompleteStatusDetailsReason(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalRealtimeResponseIncompleteStatusDetailsReason other && Equals(other);
        public bool Equals(InternalRealtimeResponseIncompleteStatusDetailsReason other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }
}
