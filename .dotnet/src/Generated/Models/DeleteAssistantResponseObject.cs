// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> The DeleteAssistantResponse_object. </summary>
    internal readonly partial struct DeleteAssistantResponseObject : IEquatable<DeleteAssistantResponseObject>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DeleteAssistantResponseObject"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DeleteAssistantResponseObject(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AssistantDeletedValue = "assistant.deleted";

        /// <summary> assistant.deleted. </summary>
        public static DeleteAssistantResponseObject AssistantDeleted { get; } = new DeleteAssistantResponseObject(AssistantDeletedValue);
        /// <summary> Determines if two <see cref="DeleteAssistantResponseObject"/> values are the same. </summary>
        public static bool operator ==(DeleteAssistantResponseObject left, DeleteAssistantResponseObject right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DeleteAssistantResponseObject"/> values are not the same. </summary>
        public static bool operator !=(DeleteAssistantResponseObject left, DeleteAssistantResponseObject right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DeleteAssistantResponseObject"/>. </summary>
        public static implicit operator DeleteAssistantResponseObject(string value) => new DeleteAssistantResponseObject(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DeleteAssistantResponseObject other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DeleteAssistantResponseObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
