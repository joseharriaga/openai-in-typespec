// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> The RunInProgressStreamEvent_event. </summary>
    internal readonly partial struct RunInProgressStreamEventEvent : IEquatable<RunInProgressStreamEventEvent>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RunInProgressStreamEventEvent"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RunInProgressStreamEventEvent(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ThreadRunInProgressValue = "thread.run.in_progress";

        /// <summary> thread.run.in_progress. </summary>
        public static RunInProgressStreamEventEvent ThreadRunInProgress { get; } = new RunInProgressStreamEventEvent(ThreadRunInProgressValue);
        /// <summary> Determines if two <see cref="RunInProgressStreamEventEvent"/> values are the same. </summary>
        public static bool operator ==(RunInProgressStreamEventEvent left, RunInProgressStreamEventEvent right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RunInProgressStreamEventEvent"/> values are not the same. </summary>
        public static bool operator !=(RunInProgressStreamEventEvent left, RunInProgressStreamEventEvent right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RunInProgressStreamEventEvent"/>. </summary>
        public static implicit operator RunInProgressStreamEventEvent(string value) => new RunInProgressStreamEventEvent(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RunInProgressStreamEventEvent other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RunInProgressStreamEventEvent other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
