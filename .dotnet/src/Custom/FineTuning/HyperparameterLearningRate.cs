using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OpenAI.FineTuning;

[CodeGenModel("CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum")]
public readonly partial struct HyperparameterLearningRate : IEquatable<float>, IEquatable<double>, IEquatable<string>
{
    internal HyperparameterLearningRate(string predefinedLabel)
    {
        _value = $@"""{predefinedLabel}""";
    }

    public HyperparameterLearningRate(float multiplier)
    {
        _value = $"{multiplier}";
    }
    public HyperparameterLearningRate(double multiplier)
    {
        _value = $"{multiplier}";
    }

    public static implicit operator HyperparameterLearningRate(float multiplier) => new(multiplier);
    public static implicit operator HyperparameterLearningRate(double multiplier) => new(multiplier);
    public bool Equals(float other) => this == new HyperparameterLearningRate(other);
    public bool Equals(double other) => this == new HyperparameterLearningRate(other);
    public bool Equals(string other) => this == new HyperparameterLearningRate(other);
    public override bool Equals(object other)
        => other is HyperparameterLearningRate lr && lr == this
        || other is int i && this == new HyperparameterLearningRate(i);

}