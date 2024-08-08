using System;

namespace OpenAI.FineTuning;

[CodeGenModel("CreateFineTuningJobRequestHyperparameters")]
public partial class HyperparameterOptions
{
    [CodeGenMember("BatchSize")]
    public HyperparameterBatchSize BatchSize { get; set; } 

    [CodeGenMember("LearningRateMultiplier")]
    public HyperparameterLearningRate LearningRate { get; set; }

    [CodeGenMember("NEpochs")]
    public HyperparameterCycleCount CycleCount { get; set; }
}