// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> The RunCreatedStreamEvent_event. </summary>
    internal readonly partial struct RunCreatedStreamEventEvent : IEquatable<RunCreatedStreamEventEvent>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RunCreatedStreamEventEvent"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RunCreatedStreamEventEvent(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ThreadRunCreatedValue = "thread.run.created";

        /// <summary> thread.run.created. </summary>
        public static RunCreatedStreamEventEvent ThreadRunCreated { get; } = new RunCreatedStreamEventEvent(ThreadRunCreatedValue);
        /// <summary> Determines if two <see cref="RunCreatedStreamEventEvent"/> values are the same. </summary>
        public static bool operator ==(RunCreatedStreamEventEvent left, RunCreatedStreamEventEvent right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RunCreatedStreamEventEvent"/> values are not the same. </summary>
        public static bool operator !=(RunCreatedStreamEventEvent left, RunCreatedStreamEventEvent right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RunCreatedStreamEventEvent"/>. </summary>
        public static implicit operator RunCreatedStreamEventEvent(string value) => new RunCreatedStreamEventEvent(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RunCreatedStreamEventEvent other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RunCreatedStreamEventEvent other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
