using System;

namespace OpenAI.FineTuning;

[CodeGenModel("CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum")]
public readonly partial struct HyperparameterLearningRate
{
    internal HyperparameterLearningRate(string predefinedLabel)
    {
        _value = $@"""{predefinedLabel}""";
    }

    public HyperparameterLearningRate(float multiplier)
    {
        _value = $"{multiplier}";
    }

    public static implicit operator HyperparameterLearningRate(float multiplier) => new(multiplier);
}