// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.FineTuning
{
    /// <summary> The FineTuningJob_object. </summary>
    internal readonly partial struct FineTuningJobObject : IEquatable<FineTuningJobObject>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="FineTuningJobObject"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public FineTuningJobObject(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string FineTuningJobValue = "fine_tuning.job";

        /// <summary> fine_tuning.job. </summary>
        public static FineTuningJobObject FineTuningJob { get; } = new FineTuningJobObject(FineTuningJobValue);
        /// <summary> Determines if two <see cref="FineTuningJobObject"/> values are the same. </summary>
        public static bool operator ==(FineTuningJobObject left, FineTuningJobObject right) => left.Equals(right);
        /// <summary> Determines if two <see cref="FineTuningJobObject"/> values are not the same. </summary>
        public static bool operator !=(FineTuningJobObject left, FineTuningJobObject right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="FineTuningJobObject"/>. </summary>
        public static implicit operator FineTuningJobObject(string value) => new FineTuningJobObject(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FineTuningJobObject other && Equals(other);
        /// <inheritdoc />
        public bool Equals(FineTuningJobObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
