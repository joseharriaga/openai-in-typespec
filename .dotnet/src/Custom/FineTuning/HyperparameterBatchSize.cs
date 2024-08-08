using System;

namespace OpenAI.FineTuning;

[CodeGenModel("CreateFineTuningJobRequestHyperparametersBatchSizeChoiceEnum")]
public readonly partial struct HyperparameterBatchSize
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
}
