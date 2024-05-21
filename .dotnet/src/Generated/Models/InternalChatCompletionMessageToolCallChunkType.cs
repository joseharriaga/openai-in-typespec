// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Chat
{
    /// <summary> The ChatCompletionMessageToolCallChunk_type. </summary>
    internal readonly partial struct InternalChatCompletionMessageToolCallChunkType : IEquatable<InternalChatCompletionMessageToolCallChunkType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InternalChatCompletionMessageToolCallChunkType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InternalChatCompletionMessageToolCallChunkType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string FunctionValue = "function";

        /// <summary> function. </summary>
        public static InternalChatCompletionMessageToolCallChunkType Function { get; } = new InternalChatCompletionMessageToolCallChunkType(FunctionValue);
        /// <summary> Determines if two <see cref="InternalChatCompletionMessageToolCallChunkType"/> values are the same. </summary>
        public static bool operator ==(InternalChatCompletionMessageToolCallChunkType left, InternalChatCompletionMessageToolCallChunkType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InternalChatCompletionMessageToolCallChunkType"/> values are not the same. </summary>
        public static bool operator !=(InternalChatCompletionMessageToolCallChunkType left, InternalChatCompletionMessageToolCallChunkType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="InternalChatCompletionMessageToolCallChunkType"/>. </summary>
        public static implicit operator InternalChatCompletionMessageToolCallChunkType(string value) => new InternalChatCompletionMessageToolCallChunkType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalChatCompletionMessageToolCallChunkType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InternalChatCompletionMessageToolCallChunkType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}