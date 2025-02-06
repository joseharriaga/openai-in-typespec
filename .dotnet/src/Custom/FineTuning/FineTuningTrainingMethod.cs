using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.FineTuning;

[Experimental("OPENAI001")]
[CodeGenModel("FineTuneMethod")]
public partial class FineTuningTrainingMethod
{
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
                    BatchSize = batchSize is not null ? ModelReaderWriter.Write(batchSize) : null,
                    NEpochs = cycleCount is not null ? ModelReaderWriter.Write(cycleCount) : null,
                    LearningRateMultiplier = learningRate is not null ? ModelReaderWriter.Write(learningRate) : null,
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
                    Beta = betaFactor is not null ? ModelReaderWriter.Write(betaFactor) : null,
                    BatchSize = batchSize is not null ? ModelReaderWriter.Write(batchSize) : null,
                    NEpochs = cycleCount is not null ? ModelReaderWriter.Write(cycleCount) : null,
                    LearningRateMultiplier = learningRate is not null ? ModelReaderWriter.Write(learningRate) : null,
                },
            },
        };
    }
}