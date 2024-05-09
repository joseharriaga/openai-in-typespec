// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Models
{
    /// <summary> Enum for status in InternalBatchJob. </summary>
    public readonly partial struct InternalBatchJobStatus : IEquatable<InternalBatchJobStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InternalBatchJobStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InternalBatchJobStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ValidatingValue = "validating";
        private const string FailedValue = "failed";
        private const string InProgressValue = "in_progress";
        private const string FinalizingValue = "finalizing";
        private const string CompletedValue = "completed";
        private const string ExpiredValue = "expired";
        private const string CancellingValue = "cancelling";
        private const string CancelledValue = "cancelled";

        /// <summary> validating. </summary>
        public static InternalBatchJobStatus Validating { get; } = new InternalBatchJobStatus(ValidatingValue);
        /// <summary> failed. </summary>
        public static InternalBatchJobStatus Failed { get; } = new InternalBatchJobStatus(FailedValue);
        /// <summary> in_progress. </summary>
        public static InternalBatchJobStatus InProgress { get; } = new InternalBatchJobStatus(InProgressValue);
        /// <summary> finalizing. </summary>
        public static InternalBatchJobStatus Finalizing { get; } = new InternalBatchJobStatus(FinalizingValue);
        /// <summary> completed. </summary>
        public static InternalBatchJobStatus Completed { get; } = new InternalBatchJobStatus(CompletedValue);
        /// <summary> expired. </summary>
        public static InternalBatchJobStatus Expired { get; } = new InternalBatchJobStatus(ExpiredValue);
        /// <summary> cancelling. </summary>
        public static InternalBatchJobStatus Cancelling { get; } = new InternalBatchJobStatus(CancellingValue);
        /// <summary> cancelled. </summary>
        public static InternalBatchJobStatus Cancelled { get; } = new InternalBatchJobStatus(CancelledValue);
        /// <summary> Determines if two <see cref="InternalBatchJobStatus"/> values are the same. </summary>
        public static bool operator ==(InternalBatchJobStatus left, InternalBatchJobStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InternalBatchJobStatus"/> values are not the same. </summary>
        public static bool operator !=(InternalBatchJobStatus left, InternalBatchJobStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="InternalBatchJobStatus"/>. </summary>
        public static implicit operator InternalBatchJobStatus(string value) => new InternalBatchJobStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalBatchJobStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InternalBatchJobStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
