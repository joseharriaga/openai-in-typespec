// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;
using OpenAI;

namespace OpenAI.Assistants
{
    internal readonly partial struct InternalDeleteAssistantResponseObject : IEquatable<InternalDeleteAssistantResponseObject>
    {
        private readonly string _value;
        private const string AssistantDeletedValue = "assistant.deleted";

        public InternalDeleteAssistantResponseObject(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        public static InternalDeleteAssistantResponseObject AssistantDeleted { get; } = new InternalDeleteAssistantResponseObject(AssistantDeletedValue);

        public static bool operator ==(InternalDeleteAssistantResponseObject left, InternalDeleteAssistantResponseObject right) => left.Equals(right);

        public static bool operator !=(InternalDeleteAssistantResponseObject left, InternalDeleteAssistantResponseObject right) => !left.Equals(right);

        public static implicit operator InternalDeleteAssistantResponseObject(string value) => new InternalDeleteAssistantResponseObject(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalDeleteAssistantResponseObject other && Equals(other);

        public bool Equals(InternalDeleteAssistantResponseObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        public override string ToString() => _value;
    }
}
