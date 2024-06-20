// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI
{
    public readonly partial struct ServiceLatencyTierChoice : IEquatable<ServiceLatencyTierChoice>
    {
        private readonly string _value;

        public ServiceLatencyTierChoice(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ApplyScaleCreditsValue = "auto";
        private const string DefaultValue = "default";
        public static ServiceLatencyTierChoice Default { get; } = new ServiceLatencyTierChoice(DefaultValue);
        public static bool operator ==(ServiceLatencyTierChoice left, ServiceLatencyTierChoice right) => left.Equals(right);
        public static bool operator !=(ServiceLatencyTierChoice left, ServiceLatencyTierChoice right) => !left.Equals(right);
        public static implicit operator ServiceLatencyTierChoice(string value) => new ServiceLatencyTierChoice(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ServiceLatencyTierChoice other && Equals(other);
        public bool Equals(ServiceLatencyTierChoice other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }
}
