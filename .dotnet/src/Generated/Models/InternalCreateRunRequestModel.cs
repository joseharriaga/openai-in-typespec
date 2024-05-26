// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Assistants
{
    /// <summary> The CreateRunRequestModel. </summary>
    internal readonly partial struct InternalCreateRunRequestModel : IEquatable<InternalCreateRunRequestModel>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InternalCreateRunRequestModel"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InternalCreateRunRequestModel(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Gpt4oValue = "gpt-4o";
        private const string Gpt4o20240513Value = "gpt-4o-2024-05-13";
        private const string Gpt4TurboValue = "gpt-4-turbo";
        private const string Gpt4Turbo20240409Value = "gpt-4-turbo-2024-04-09";
        private const string Gpt40125PreviewValue = "gpt-4-0125-preview";
        private const string Gpt4TurboPreviewValue = "gpt-4-turbo-preview";
        private const string Gpt41106PreviewValue = "gpt-4-1106-preview";
        private const string Gpt4VisionPreviewValue = "gpt-4-vision-preview";
        private const string Gpt4Value = "gpt-4";
        private const string Gpt40314Value = "gpt-4-0314";
        private const string Gpt40613Value = "gpt-4-0613";
        private const string Gpt432kValue = "gpt-4-32k";
        private const string Gpt432k0314Value = "gpt-4-32k-0314";
        private const string Gpt432k0613Value = "gpt-4-32k-0613";
        private const string Gpt35TurboValue = "gpt-3.5-turbo";
        private const string Gpt35Turbo16kValue = "gpt-3.5-turbo-16k";
        private const string Gpt35Turbo0613Value = "gpt-3.5-turbo-0613";
        private const string Gpt35Turbo1106Value = "gpt-3.5-turbo-1106";
        private const string Gpt35Turbo0125Value = "gpt-3.5-turbo-0125";
        private const string Gpt35Turbo16k0613Value = "gpt-3.5-turbo-16k-0613";

        /// <summary> gpt-4o. </summary>
        public static InternalCreateRunRequestModel Gpt4o { get; } = new InternalCreateRunRequestModel(Gpt4oValue);
        /// <summary> gpt-4o-2024-05-13. </summary>
        public static InternalCreateRunRequestModel Gpt4o20240513 { get; } = new InternalCreateRunRequestModel(Gpt4o20240513Value);
        /// <summary> gpt-4-turbo. </summary>
        public static InternalCreateRunRequestModel Gpt4Turbo { get; } = new InternalCreateRunRequestModel(Gpt4TurboValue);
        /// <summary> gpt-4-turbo-2024-04-09. </summary>
        public static InternalCreateRunRequestModel Gpt4Turbo20240409 { get; } = new InternalCreateRunRequestModel(Gpt4Turbo20240409Value);
        /// <summary> gpt-4-0125-preview. </summary>
        public static InternalCreateRunRequestModel Gpt40125Preview { get; } = new InternalCreateRunRequestModel(Gpt40125PreviewValue);
        /// <summary> gpt-4-turbo-preview. </summary>
        public static InternalCreateRunRequestModel Gpt4TurboPreview { get; } = new InternalCreateRunRequestModel(Gpt4TurboPreviewValue);
        /// <summary> gpt-4-1106-preview. </summary>
        public static InternalCreateRunRequestModel Gpt41106Preview { get; } = new InternalCreateRunRequestModel(Gpt41106PreviewValue);
        /// <summary> gpt-4-vision-preview. </summary>
        public static InternalCreateRunRequestModel Gpt4VisionPreview { get; } = new InternalCreateRunRequestModel(Gpt4VisionPreviewValue);
        /// <summary> gpt-4. </summary>
        public static InternalCreateRunRequestModel Gpt4 { get; } = new InternalCreateRunRequestModel(Gpt4Value);
        /// <summary> gpt-4-0314. </summary>
        public static InternalCreateRunRequestModel Gpt40314 { get; } = new InternalCreateRunRequestModel(Gpt40314Value);
        /// <summary> gpt-4-0613. </summary>
        public static InternalCreateRunRequestModel Gpt40613 { get; } = new InternalCreateRunRequestModel(Gpt40613Value);
        /// <summary> gpt-4-32k. </summary>
        public static InternalCreateRunRequestModel Gpt432k { get; } = new InternalCreateRunRequestModel(Gpt432kValue);
        /// <summary> gpt-4-32k-0314. </summary>
        public static InternalCreateRunRequestModel Gpt432k0314 { get; } = new InternalCreateRunRequestModel(Gpt432k0314Value);
        /// <summary> gpt-4-32k-0613. </summary>
        public static InternalCreateRunRequestModel Gpt432k0613 { get; } = new InternalCreateRunRequestModel(Gpt432k0613Value);
        /// <summary> gpt-3.5-turbo. </summary>
        public static InternalCreateRunRequestModel Gpt35Turbo { get; } = new InternalCreateRunRequestModel(Gpt35TurboValue);
        /// <summary> gpt-3.5-turbo-16k. </summary>
        public static InternalCreateRunRequestModel Gpt35Turbo16k { get; } = new InternalCreateRunRequestModel(Gpt35Turbo16kValue);
        /// <summary> gpt-3.5-turbo-0613. </summary>
        public static InternalCreateRunRequestModel Gpt35Turbo0613 { get; } = new InternalCreateRunRequestModel(Gpt35Turbo0613Value);
        /// <summary> gpt-3.5-turbo-1106. </summary>
        public static InternalCreateRunRequestModel Gpt35Turbo1106 { get; } = new InternalCreateRunRequestModel(Gpt35Turbo1106Value);
        /// <summary> gpt-3.5-turbo-0125. </summary>
        public static InternalCreateRunRequestModel Gpt35Turbo0125 { get; } = new InternalCreateRunRequestModel(Gpt35Turbo0125Value);
        /// <summary> gpt-3.5-turbo-16k-0613. </summary>
        public static InternalCreateRunRequestModel Gpt35Turbo16k0613 { get; } = new InternalCreateRunRequestModel(Gpt35Turbo16k0613Value);
        /// <summary> Determines if two <see cref="InternalCreateRunRequestModel"/> values are the same. </summary>
        public static bool operator ==(InternalCreateRunRequestModel left, InternalCreateRunRequestModel right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InternalCreateRunRequestModel"/> values are not the same. </summary>
        public static bool operator !=(InternalCreateRunRequestModel left, InternalCreateRunRequestModel right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="InternalCreateRunRequestModel"/>. </summary>
        public static implicit operator InternalCreateRunRequestModel(string value) => new InternalCreateRunRequestModel(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InternalCreateRunRequestModel other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InternalCreateRunRequestModel other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
