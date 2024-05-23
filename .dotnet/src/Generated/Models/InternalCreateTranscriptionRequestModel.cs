// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Audio
{
    /// <summary> The CreateTranscriptionRequestModel. </summary>
    internal readonly partial struct InternalCreateTranscriptionRequestModel : IEquatable<InternalCreateTranscriptionRequestModel>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InternalCreateTranscriptionRequestModel"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InternalCreateTranscriptionRequestModel(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Whisper1Value = "whisper-1";

        /// <summary> whisper-1. </summary>
        public static InternalCreateTranscriptionRequestModel Whisper1 { get; } = new InternalCreateTranscriptionRequestModel(Whisper1Value);
        /// <summary> Determines if two <see cref="InternalCreateTranscriptionRequestModel"/> values are the same. </summary>
        public static bool operator ==(InternalCreateTranscriptionRequestModel left, InternalCreateTranscriptionRequestModel right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InternalCreateTranscriptionRequestModel"/> values are not the same. </summary>
        public static bool operator !=(InternalCreateTranscriptionRequestModel left, InternalCreateTranscriptionRequestModel right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="InternalCreateTranscriptionRequestModel"/>. </summary>
        public static implicit operator InternalCreateTranscriptionRequestModel(string value) => new InternalCreateTranscriptionRequestModel(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalCreateTranscriptionRequestModel other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InternalCreateTranscriptionRequestModel other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}