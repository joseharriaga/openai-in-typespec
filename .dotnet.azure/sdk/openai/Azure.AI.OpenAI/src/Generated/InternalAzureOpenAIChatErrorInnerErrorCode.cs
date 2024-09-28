// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.OpenAI
{
    /// <summary> The AzureOpenAIChatErrorInnerError_code. </summary>
    internal readonly partial struct InternalAzureOpenAIChatErrorInnerErrorCode : IEquatable<InternalAzureOpenAIChatErrorInnerErrorCode>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InternalAzureOpenAIChatErrorInnerErrorCode"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InternalAzureOpenAIChatErrorInnerErrorCode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ResponsibleAIPolicyViolationValue = "ResponsibleAIPolicyViolation";

        /// <summary> ResponsibleAIPolicyViolation. </summary>
        internal static InternalAzureOpenAIChatErrorInnerErrorCode ResponsibleAIPolicyViolation { get; set; } = new InternalAzureOpenAIChatErrorInnerErrorCode(ResponsibleAIPolicyViolationValue);
        /// <summary> Determines if two <see cref="InternalAzureOpenAIChatErrorInnerErrorCode"/> values are the same. </summary>
        public static bool operator ==(InternalAzureOpenAIChatErrorInnerErrorCode left, InternalAzureOpenAIChatErrorInnerErrorCode right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InternalAzureOpenAIChatErrorInnerErrorCode"/> values are not the same. </summary>
        public static bool operator !=(InternalAzureOpenAIChatErrorInnerErrorCode left, InternalAzureOpenAIChatErrorInnerErrorCode right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="InternalAzureOpenAIChatErrorInnerErrorCode"/>. </summary>
        public static implicit operator InternalAzureOpenAIChatErrorInnerErrorCode(string value) => new InternalAzureOpenAIChatErrorInnerErrorCode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalAzureOpenAIChatErrorInnerErrorCode other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InternalAzureOpenAIChatErrorInnerErrorCode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}



