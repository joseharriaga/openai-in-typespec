// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Moderations
{
    internal readonly partial struct InternalCreateModerationResponseResultCategoryAppliedInputTypesSexual : IEquatable<InternalCreateModerationResponseResultCategoryAppliedInputTypesSexual>
    {
        private readonly string _value;

        public InternalCreateModerationResponseResultCategoryAppliedInputTypesSexual(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TextValue = "text";
        private const string ImageValue = "image";

        public static InternalCreateModerationResponseResultCategoryAppliedInputTypesSexual Text { get; } = new InternalCreateModerationResponseResultCategoryAppliedInputTypesSexual(TextValue);
        public static InternalCreateModerationResponseResultCategoryAppliedInputTypesSexual Image { get; } = new InternalCreateModerationResponseResultCategoryAppliedInputTypesSexual(ImageValue);
        public static bool operator ==(InternalCreateModerationResponseResultCategoryAppliedInputTypesSexual left, InternalCreateModerationResponseResultCategoryAppliedInputTypesSexual right) => left.Equals(right);
        public static bool operator !=(InternalCreateModerationResponseResultCategoryAppliedInputTypesSexual left, InternalCreateModerationResponseResultCategoryAppliedInputTypesSexual right) => !left.Equals(right);
        public static implicit operator InternalCreateModerationResponseResultCategoryAppliedInputTypesSexual(string value) => new InternalCreateModerationResponseResultCategoryAppliedInputTypesSexual(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalCreateModerationResponseResultCategoryAppliedInputTypesSexual other && Equals(other);
        public bool Equals(InternalCreateModerationResponseResultCategoryAppliedInputTypesSexual other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }
}