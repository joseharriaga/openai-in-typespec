using System;
using System.ComponentModel;

namespace OpenAI.FineTuning;

[CodeGenModel("CreateFineTuningJobRequestHyperparametersBatchSizeChoiceEnum")]
public readonly partial struct HyperparameterBatchSize : IEquatable<int>, IEquatable<string>
{
    internal HyperparameterBatchSize(string predefinedLabel)
    {
        _value = $@"""{predefinedLabel}""";
    }

    public HyperparameterBatchSize(int batchSize)
    {
        _value = $"{batchSize}";
    }

    public static implicit operator HyperparameterBatchSize(int batchSize) => new(batchSize);

    public bool Equals(int other) => this == new HyperparameterBatchSize(other);
    public bool Equals(string other) => this == new HyperparameterBatchSize(other);
    public override bool Equals(object other) => other is HyperparameterBatchSize bs && bs == this;

}
