// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> The ListAssistantsResponse_object. </summary>
    internal readonly partial struct ListAssistantsResponseObject : IEquatable<ListAssistantsResponseObject>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ListAssistantsResponseObject"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ListAssistantsResponseObject(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ListValue = "list";

        /// <summary> list. </summary>
        public static ListAssistantsResponseObject List { get; } = new ListAssistantsResponseObject(ListValue);
        /// <summary> Determines if two <see cref="ListAssistantsResponseObject"/> values are the same. </summary>
        public static bool operator ==(ListAssistantsResponseObject left, ListAssistantsResponseObject right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ListAssistantsResponseObject"/> values are not the same. </summary>
        public static bool operator !=(ListAssistantsResponseObject left, ListAssistantsResponseObject right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ListAssistantsResponseObject"/>. </summary>
        public static implicit operator ListAssistantsResponseObject(string value) => new ListAssistantsResponseObject(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ListAssistantsResponseObject other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ListAssistantsResponseObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
