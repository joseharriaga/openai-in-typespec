// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    /// <summary> Enum for status in ThreadRun. </summary>
    public readonly partial struct RunStatus : IEquatable<RunStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RunStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RunStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string QueuedValue = "queued";
        private const string InProgressValue = "in_progress";
        private const string RequiresActionValue = "requires_action";
        private const string CancellingValue = "cancelling";
        private const string CancelledValue = "cancelled";
        private const string FailedValue = "failed";
        private const string CompletedValue = "completed";
        private const string ExpiredValue = "expired";
        private const string IncompleteValue = "incomplete";

        /// <summary> queued. </summary>
        public static RunStatus Queued { get; } = new RunStatus(QueuedValue);
        /// <summary> in_progress. </summary>
        public static RunStatus InProgress { get; } = new RunStatus(InProgressValue);
        /// <summary> requires_action. </summary>
        public static RunStatus RequiresAction { get; } = new RunStatus(RequiresActionValue);
        /// <summary> cancelling. </summary>
        public static RunStatus Cancelling { get; } = new RunStatus(CancellingValue);
        /// <summary> cancelled. </summary>
        public static RunStatus Cancelled { get; } = new RunStatus(CancelledValue);
        /// <summary> failed. </summary>
        public static RunStatus Failed { get; } = new RunStatus(FailedValue);
        /// <summary> completed. </summary>
        public static RunStatus Completed { get; } = new RunStatus(CompletedValue);
        /// <summary> expired. </summary>
        public static RunStatus Expired { get; } = new RunStatus(ExpiredValue);
        /// <summary> incomplete. </summary>
        public static RunStatus Incomplete { get; } = new RunStatus(IncompleteValue);
        /// <summary> Determines if two <see cref="RunStatus"/> values are the same. </summary>
        public static bool operator ==(RunStatus left, RunStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RunStatus"/> values are not the same. </summary>
        public static bool operator !=(RunStatus left, RunStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RunStatus"/>. </summary>
        public static implicit operator RunStatus(string value) => new RunStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RunStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RunStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
