// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    internal readonly partial struct InternalRealtimeResponseSessionObject : IEquatable<InternalRealtimeResponseSessionObject>
    {
        private readonly string _value;
        private const string RealtimeSessionValue = "realtime.session";

        public InternalRealtimeResponseSessionObject(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        public static InternalRealtimeResponseSessionObject RealtimeSession { get; } = new InternalRealtimeResponseSessionObject(RealtimeSessionValue);

        public static bool operator ==(InternalRealtimeResponseSessionObject left, InternalRealtimeResponseSessionObject right) => left.Equals(right);

        public static bool operator !=(InternalRealtimeResponseSessionObject left, InternalRealtimeResponseSessionObject right) => !left.Equals(right);

        public static implicit operator InternalRealtimeResponseSessionObject(string value) => new InternalRealtimeResponseSessionObject(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalRealtimeResponseSessionObject other && Equals(other);

        public bool Equals(InternalRealtimeResponseSessionObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        public override string ToString() => _value;
    }
}
