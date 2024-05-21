// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.OpenAI
{
    /// <summary> Enum for severity in ContentFilterSeverityResult. </summary>
    public readonly partial struct ContentFilterSeverityResultSeverity : IEquatable<ContentFilterSeverityResultSeverity>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ContentFilterSeverityResultSeverity"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ContentFilterSeverityResultSeverity(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SafeValue = "safe";
        private const string LowValue = "low";
        private const string MediumValue = "medium";
        private const string HighValue = "high";

        /// <summary> safe. </summary>
        public static ContentFilterSeverityResultSeverity Safe { get; } = new ContentFilterSeverityResultSeverity(SafeValue);
        /// <summary> low. </summary>
        public static ContentFilterSeverityResultSeverity Low { get; } = new ContentFilterSeverityResultSeverity(LowValue);
        /// <summary> medium. </summary>
        public static ContentFilterSeverityResultSeverity Medium { get; } = new ContentFilterSeverityResultSeverity(MediumValue);
        /// <summary> high. </summary>
        public static ContentFilterSeverityResultSeverity High { get; } = new ContentFilterSeverityResultSeverity(HighValue);
        /// <summary> Determines if two <see cref="ContentFilterSeverityResultSeverity"/> values are the same. </summary>
        public static bool operator ==(ContentFilterSeverityResultSeverity left, ContentFilterSeverityResultSeverity right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ContentFilterSeverityResultSeverity"/> values are not the same. </summary>
        public static bool operator !=(ContentFilterSeverityResultSeverity left, ContentFilterSeverityResultSeverity right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ContentFilterSeverityResultSeverity"/>. </summary>
        public static implicit operator ContentFilterSeverityResultSeverity(string value) => new ContentFilterSeverityResultSeverity(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ContentFilterSeverityResultSeverity other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ContentFilterSeverityResultSeverity other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}