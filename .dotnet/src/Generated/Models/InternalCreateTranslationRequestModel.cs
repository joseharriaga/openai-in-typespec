// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;
using OpenAI;

namespace OpenAI.Audio
{
    internal readonly partial struct InternalCreateTranslationRequestModel : IEquatable<InternalCreateTranslationRequestModel>
    {
        private readonly string _value;
        private const string Whisper1Value = "whisper-1";

        public InternalCreateTranslationRequestModel(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        public static InternalCreateTranslationRequestModel Whisper1 { get; } = new InternalCreateTranslationRequestModel(Whisper1Value);

        public static bool operator ==(InternalCreateTranslationRequestModel left, InternalCreateTranslationRequestModel right) => left.Equals(right);

        public static bool operator !=(InternalCreateTranslationRequestModel left, InternalCreateTranslationRequestModel right) => !left.Equals(right);

        public static implicit operator InternalCreateTranslationRequestModel(string value) => new InternalCreateTranslationRequestModel(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalCreateTranslationRequestModel other && Equals(other);

        public bool Equals(InternalCreateTranslationRequestModel other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        public override string ToString() => _value;
    }
}
