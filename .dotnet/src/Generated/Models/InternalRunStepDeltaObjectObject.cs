// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Assistants
{
    /// <summary> The RunStepDeltaObject_object. </summary>
    internal readonly partial struct InternalRunStepDeltaObjectObject : IEquatable<InternalRunStepDeltaObjectObject>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InternalRunStepDeltaObjectObject"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InternalRunStepDeltaObjectObject(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ThreadRunStepDeltaValue = "thread.run.step.delta";

        /// <summary> thread.run.step.delta. </summary>
        public static InternalRunStepDeltaObjectObject ThreadRunStepDelta { get; } = new InternalRunStepDeltaObjectObject(ThreadRunStepDeltaValue);
        /// <summary> Determines if two <see cref="InternalRunStepDeltaObjectObject"/> values are the same. </summary>
        public static bool operator ==(InternalRunStepDeltaObjectObject left, InternalRunStepDeltaObjectObject right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InternalRunStepDeltaObjectObject"/> values are not the same. </summary>
        public static bool operator !=(InternalRunStepDeltaObjectObject left, InternalRunStepDeltaObjectObject right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="InternalRunStepDeltaObjectObject"/>. </summary>
        public static implicit operator InternalRunStepDeltaObjectObject(string value) => new InternalRunStepDeltaObjectObject(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalRunStepDeltaObjectObject other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InternalRunStepDeltaObjectObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}