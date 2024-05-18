// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;
using OpenAI;

namespace Azure.AI.OpenAI
{
    /// <summary> Enum for severity in AzureContentFilterSeverityResult. </summary>
    public readonly partial struct AzureContentFilterSeverityResultSeverity : IEquatable<AzureContentFilterSeverityResultSeverity>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AzureContentFilterSeverityResultSeverity"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AzureContentFilterSeverityResultSeverity(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SafeValue = "safe";
        private const string LowValue = "low";
        private const string MediumValue = "medium";
        private const string HighValue = "high";

        /// <summary> safe. </summary>
        public static AzureContentFilterSeverityResultSeverity Safe { get; } = new AzureContentFilterSeverityResultSeverity(SafeValue);
        /// <summary> low. </summary>
        public static AzureContentFilterSeverityResultSeverity Low { get; } = new AzureContentFilterSeverityResultSeverity(LowValue);
        /// <summary> medium. </summary>
        public static AzureContentFilterSeverityResultSeverity Medium { get; } = new AzureContentFilterSeverityResultSeverity(MediumValue);
        /// <summary> high. </summary>
        public static AzureContentFilterSeverityResultSeverity High { get; } = new AzureContentFilterSeverityResultSeverity(HighValue);
        /// <summary> Determines if two <see cref="AzureContentFilterSeverityResultSeverity"/> values are the same. </summary>
        public static bool operator ==(AzureContentFilterSeverityResultSeverity left, AzureContentFilterSeverityResultSeverity right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AzureContentFilterSeverityResultSeverity"/> values are not the same. </summary>
        public static bool operator !=(AzureContentFilterSeverityResultSeverity left, AzureContentFilterSeverityResultSeverity right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="AzureContentFilterSeverityResultSeverity"/>. </summary>
        public static implicit operator AzureContentFilterSeverityResultSeverity(string value) => new AzureContentFilterSeverityResultSeverity(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AzureContentFilterSeverityResultSeverity other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AzureContentFilterSeverityResultSeverity other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
