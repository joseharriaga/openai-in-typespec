// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> Enum for voice in CreateSpeechRequest. </summary>
    internal readonly partial struct CreateSpeechRequestVoice : IEquatable<CreateSpeechRequestVoice>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CreateSpeechRequestVoice"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CreateSpeechRequestVoice(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AlloyValue = "alloy";
        private const string EchoValue = "echo";
        private const string FableValue = "fable";
        private const string OnyxValue = "onyx";
        private const string NovaValue = "nova";
        private const string ShimmerValue = "shimmer";

        /// <summary> alloy. </summary>
        public static CreateSpeechRequestVoice Alloy { get; } = new CreateSpeechRequestVoice(AlloyValue);
        /// <summary> echo. </summary>
        public static CreateSpeechRequestVoice Echo { get; } = new CreateSpeechRequestVoice(EchoValue);
        /// <summary> fable. </summary>
        public static CreateSpeechRequestVoice Fable { get; } = new CreateSpeechRequestVoice(FableValue);
        /// <summary> onyx. </summary>
        public static CreateSpeechRequestVoice Onyx { get; } = new CreateSpeechRequestVoice(OnyxValue);
        /// <summary> nova. </summary>
        public static CreateSpeechRequestVoice Nova { get; } = new CreateSpeechRequestVoice(NovaValue);
        /// <summary> shimmer. </summary>
        public static CreateSpeechRequestVoice Shimmer { get; } = new CreateSpeechRequestVoice(ShimmerValue);
        /// <summary> Determines if two <see cref="CreateSpeechRequestVoice"/> values are the same. </summary>
        public static bool operator ==(CreateSpeechRequestVoice left, CreateSpeechRequestVoice right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CreateSpeechRequestVoice"/> values are not the same. </summary>
        public static bool operator !=(CreateSpeechRequestVoice left, CreateSpeechRequestVoice right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CreateSpeechRequestVoice"/>. </summary>
        public static implicit operator CreateSpeechRequestVoice(string value) => new CreateSpeechRequestVoice(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CreateSpeechRequestVoice other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CreateSpeechRequestVoice other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
