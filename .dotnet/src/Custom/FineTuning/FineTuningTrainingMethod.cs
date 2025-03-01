using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.FineTuning;

[Experimental("OPENAI001")]
[CodeGenModel("FineTuneMethod")]
public partial class FineTuningTrainingMethod
{
    private static readonly BinaryData Auto = new("\"auto\"");

    internal InternalFineTuneMethodType? Type { get; set; }

    internal InternalFineTuningJobRequestMethodSupervised Supervised { get; set; }

    internal InternalFineTuningJobRequestMethodDpo Dpo { get; set; }

    public static FineTuningTrainingMethod CreateSupervised(
        HyperparameterBatchSize batchSize = null,
        HyperparameterCycleCount cycleCount = null,
        HyperparameterLearningRate learningRate = null)
    {
        return new FineTuningTrainingMethod()
        {
            Type = InternalFineTuneMethodType.Supervised,
            Supervised = new() {
                Hyperparameters = new() {
                    _BatchSize = batchSize is not null ? ModelReaderWriter.Write(batchSize) : null,
                    _NEpochs = cycleCount is not null ? ModelReaderWriter.Write(cycleCount) : null,
                    _LearningRateMultiplier = learningRate is not null ? ModelReaderWriter.Write(learningRate) : null,
                },
            },
        };
    }

    public static FineTuningTrainingMethod CreateDirectPreferenceOptimization(
        HyperparameterBatchSize batchSize = null,
        HyperparameterCycleCount cycleCount = null,
        HyperparameterLearningRate learningRate = null,
        HyperparameterBetaFactor betaFactor = null)
    {
        return new FineTuningTrainingMethod()
        {
            Type = InternalFineTuneMethodType.Dpo,
            Dpo = new() {
                Hyperparameters = new() {
                    _Beta = betaFactor is not null ? ModelReaderWriter.Write(betaFactor) : null,
                    _BatchSize = batchSize is not null ? ModelReaderWriter.Write(batchSize) : null,
                    _NEpochs = cycleCount is not null ? ModelReaderWriter.Write(cycleCount) : null,
                    _LearningRateMultiplier = learningRate is not null ? ModelReaderWriter.Write(learningRate) : null,
                },
            },
        };
    }
}