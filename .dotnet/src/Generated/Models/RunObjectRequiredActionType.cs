// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Internal.Models
{
    internal readonly partial struct RunObjectRequiredActionType : IEquatable<RunObjectRequiredActionType>
    {
        private readonly string _value;

        public RunObjectRequiredActionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SubmitToolOutputsValue = "submit_tool_outputs";

        public static RunObjectRequiredActionType SubmitToolOutputs { get; } = new RunObjectRequiredActionType(SubmitToolOutputsValue);
        public static bool operator ==(RunObjectRequiredActionType left, RunObjectRequiredActionType right) => left.Equals(right);
        public static bool operator !=(RunObjectRequiredActionType left, RunObjectRequiredActionType right) => !left.Equals(right);
        public static implicit operator RunObjectRequiredActionType(string value) => new RunObjectRequiredActionType(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RunObjectRequiredActionType other && Equals(other);
        public bool Equals(RunObjectRequiredActionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }
}
