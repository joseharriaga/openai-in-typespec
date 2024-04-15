// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> The RunStepCompletedStreamEvent_event. </summary>
    internal readonly partial struct RunStepCompletedStreamEventEvent : IEquatable<RunStepCompletedStreamEventEvent>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RunStepCompletedStreamEventEvent"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RunStepCompletedStreamEventEvent(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ThreadRunStepCompletedValue = "thread.run.step.completed";

        /// <summary> thread.run.step.completed. </summary>
        public static RunStepCompletedStreamEventEvent ThreadRunStepCompleted { get; } = new RunStepCompletedStreamEventEvent(ThreadRunStepCompletedValue);
        /// <summary> Determines if two <see cref="RunStepCompletedStreamEventEvent"/> values are the same. </summary>
        public static bool operator ==(RunStepCompletedStreamEventEvent left, RunStepCompletedStreamEventEvent right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RunStepCompletedStreamEventEvent"/> values are not the same. </summary>
        public static bool operator !=(RunStepCompletedStreamEventEvent left, RunStepCompletedStreamEventEvent right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RunStepCompletedStreamEventEvent"/>. </summary>
        public static implicit operator RunStepCompletedStreamEventEvent(string value) => new RunStepCompletedStreamEventEvent(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RunStepCompletedStreamEventEvent other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RunStepCompletedStreamEventEvent other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
