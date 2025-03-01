using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.FineTuning;

[Experimental("OPENAI001")]
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