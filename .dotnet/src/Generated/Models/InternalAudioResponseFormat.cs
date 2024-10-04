// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Audio
{
    internal readonly partial struct InternalAudioResponseFormat : IEquatable<InternalAudioResponseFormat>
    {
        private readonly string _value;

        public InternalAudioResponseFormat(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string JsonValue = "json";
        private const string TextValue = "text";
        private const string SrtValue = "srt";
        private const string VerboseJsonValue = "verbose_json";
        private const string VttValue = "vtt";

        public static InternalAudioResponseFormat Json { get; } = new InternalAudioResponseFormat(JsonValue);
        public static InternalAudioResponseFormat Text { get; } = new InternalAudioResponseFormat(TextValue);
        public static InternalAudioResponseFormat Srt { get; } = new InternalAudioResponseFormat(SrtValue);
        public static InternalAudioResponseFormat VerboseJson { get; } = new InternalAudioResponseFormat(VerboseJsonValue);
        public static InternalAudioResponseFormat Vtt { get; } = new InternalAudioResponseFormat(VttValue);
        public static bool operator ==(InternalAudioResponseFormat left, InternalAudioResponseFormat right) => left.Equals(right);
        public static bool operator !=(InternalAudioResponseFormat left, InternalAudioResponseFormat right) => !left.Equals(right);
        public static implicit operator InternalAudioResponseFormat(string value) => new InternalAudioResponseFormat(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalAudioResponseFormat other && Equals(other);
        public bool Equals(InternalAudioResponseFormat other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }
}