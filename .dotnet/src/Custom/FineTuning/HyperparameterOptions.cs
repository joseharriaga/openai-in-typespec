using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning;

[CodeGenModel("CreateFineTuningJobRequestHyperparameters")]
public partial class HyperparameterOptions
{
    [CodeGenMember("NEpochs")]
    public HyperparameterCycleCount CycleCount { get; }

    [CodeGenMember("BatchSize")]
    public HyperparameterBatchSize BatchSize { get; } 

    [CodeGenMember("LearningRateMultiplier")]
    public HyperparameterLearningRate LearningRate { get; }

    public HyperparameterOptions(HyperparameterCycleCount cycleCount = default, HyperparameterBatchSize batchSize = default, HyperparameterLearningRate learningRate = default, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
    {
        CycleCount = cycleCount;
        BatchSize = batchSize;
        LearningRate = learningRate;
        SerializedAdditionalRawData = serializedAdditionalRawData;
    }

}