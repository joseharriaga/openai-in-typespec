// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Moderations
{
    internal readonly partial struct InternalCreateModerationResponseResultCategoryAppliedInputTypesViolenceGraphic : IEquatable<InternalCreateModerationResponseResultCategoryAppliedInputTypesViolenceGraphic>
    {
        private readonly string _value;

        public InternalCreateModerationResponseResultCategoryAppliedInputTypesViolenceGraphic(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TextValue = "text";
        private const string ImageValue = "image";

        public static InternalCreateModerationResponseResultCategoryAppliedInputTypesViolenceGraphic Text { get; } = new InternalCreateModerationResponseResultCategoryAppliedInputTypesViolenceGraphic(TextValue);
        public static InternalCreateModerationResponseResultCategoryAppliedInputTypesViolenceGraphic Image { get; } = new InternalCreateModerationResponseResultCategoryAppliedInputTypesViolenceGraphic(ImageValue);
        public static bool operator ==(InternalCreateModerationResponseResultCategoryAppliedInputTypesViolenceGraphic left, InternalCreateModerationResponseResultCategoryAppliedInputTypesViolenceGraphic right) => left.Equals(right);
        public static bool operator !=(InternalCreateModerationResponseResultCategoryAppliedInputTypesViolenceGraphic left, InternalCreateModerationResponseResultCategoryAppliedInputTypesViolenceGraphic right) => !left.Equals(right);
        public static implicit operator InternalCreateModerationResponseResultCategoryAppliedInputTypesViolenceGraphic(string value) => new InternalCreateModerationResponseResultCategoryAppliedInputTypesViolenceGraphic(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalCreateModerationResponseResultCategoryAppliedInputTypesViolenceGraphic other && Equals(other);
        public bool Equals(InternalCreateModerationResponseResultCategoryAppliedInputTypesViolenceGraphic other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }
}
