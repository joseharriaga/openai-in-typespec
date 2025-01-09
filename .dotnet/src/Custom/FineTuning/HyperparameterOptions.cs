using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning;

[CodeGenModel("CreateFineTuningJobRequestHyperparameters")]
internal partial class HyperparameterOptions
{
    [CodeGenMember("NEpochs")]
    public HyperparameterCycleCount CycleCount { get; set; }

    [CodeGenMember("BatchSize")]
    public HyperparameterBatchSize BatchSize { get; set; }

    [CodeGenMember("LearningRateMultiplier")]
    public HyperparameterLearningRate LearningRate { get; set; }
}