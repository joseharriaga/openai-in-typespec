// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> Enum for reason in RunObjectIncompleteDetails. </summary>
    internal readonly partial struct RunObjectIncompleteDetailsReason : IEquatable<RunObjectIncompleteDetailsReason>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RunObjectIncompleteDetailsReason"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RunObjectIncompleteDetailsReason(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MaxCompletionTokensValue = "max_completion_tokens";
        private const string MaxPromptTokensValue = "max_prompt_tokens";

        /// <summary> max_completion_tokens. </summary>
        public static RunObjectIncompleteDetailsReason MaxCompletionTokens { get; } = new RunObjectIncompleteDetailsReason(MaxCompletionTokensValue);
        /// <summary> max_prompt_tokens. </summary>
        public static RunObjectIncompleteDetailsReason MaxPromptTokens { get; } = new RunObjectIncompleteDetailsReason(MaxPromptTokensValue);
        /// <summary> Determines if two <see cref="RunObjectIncompleteDetailsReason"/> values are the same. </summary>
        public static bool operator ==(RunObjectIncompleteDetailsReason left, RunObjectIncompleteDetailsReason right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RunObjectIncompleteDetailsReason"/> values are not the same. </summary>
        public static bool operator !=(RunObjectIncompleteDetailsReason left, RunObjectIncompleteDetailsReason right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RunObjectIncompleteDetailsReason"/>. </summary>
        public static implicit operator RunObjectIncompleteDetailsReason(string value) => new RunObjectIncompleteDetailsReason(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RunObjectIncompleteDetailsReason other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RunObjectIncompleteDetailsReason other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}