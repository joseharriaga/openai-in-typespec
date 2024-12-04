using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning;

[CodeGenModel("FineTuningJobHyperparameters")]
public readonly partial struct FineTuningHyperparameters
{
    private static readonly BinaryData Auto = new("\"auto\"");

    [CodeGenMember("NEpochs")]
    internal BinaryData _CycleCount { get; }
    [CodeGenMember("BatchSize")]
    internal BinaryData _BatchSize { get; }
    [CodeGenMember("LearningRateMultiplier")]
    internal BinaryData _LearningRateMultiplier { get; }

    public IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }

    private float HandleDefaults(BinaryData data)
    {
        if (data is null)
        {
            throw new ArgumentNullException("This hyperparameter is not set. Values for BatchSize and LearningRateMultiplier are not available in responses.");
        }

        if (data.ToString() == Auto.ToString())
        {
            return 0;
        }

        try
        {
            return float.Parse(data.ToString());
        }
        catch (FormatException)
        {
            throw new FormatException($"Hyperparameter expected a number or \"auto\" string. Got {data}");
        }
    }

    public int CycleCount => (int)HandleDefaults(_CycleCount);
    public int BatchSize => (int)HandleDefaults(_BatchSize);
    public float LearningRateMultiplier => HandleDefaults(_LearningRateMultiplier);
}
