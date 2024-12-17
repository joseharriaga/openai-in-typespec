// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    public readonly partial struct ConversationToolKind : IEquatable<ConversationToolKind>
    {
        private readonly string _value;
        private const string FunctionValue = "function";

        public ConversationToolKind(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        public static ConversationToolKind Function { get; } = new ConversationToolKind(FunctionValue);

        public static bool operator ==(ConversationToolKind left, ConversationToolKind right) => left.Equals(right);

        public static bool operator !=(ConversationToolKind left, ConversationToolKind right) => !left.Equals(right);

        public static implicit operator ConversationToolKind(string value) => new ConversationToolKind(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ConversationToolKind other && Equals(other);

        public bool Equals(ConversationToolKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        public override string ToString() => _value;
    }
}
