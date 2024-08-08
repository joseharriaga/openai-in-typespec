using System;

namespace OpenAI.FineTuning;

[CodeGenModel("CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum")]
public readonly partial struct HyperparameterCycleCount
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
}
