using System;
using System.ComponentModel;

namespace OpenAI.FineTuning;

[CodeGenModel("CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum")]
public readonly partial struct HyperparameterCycleCount : IEquatable<int>, IEquatable<string>
{
    internal HyperparameterCycleCount(string predefinedLabel)
    {
        _value = $@"""{predefinedLabel}""";
    }

    public HyperparameterCycleCount(int epochCount)
    {
        _value = $"{epochCount}";
    }

    public static implicit operator HyperparameterCycleCount(int epochCount) => new(epochCount);

    public bool Equals(int other) => this == new HyperparameterCycleCount(other);
    public bool Equals(string other) => this == new HyperparameterCycleCount(other);

    public override bool Equals(object other) => other is HyperparameterCycleCount cc && cc == this;
}
