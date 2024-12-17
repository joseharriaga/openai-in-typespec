// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    public readonly partial struct FineTuningHyperparameters
    {
        internal FineTuningHyperparameters(BinaryData cycleCount, BinaryData batchSize, BinaryData learningRateMultiplier)
        {
            Argument.AssertNotNull(cycleCount, nameof(cycleCount));
            Argument.AssertNotNull(batchSize, nameof(batchSize));
            Argument.AssertNotNull(learningRateMultiplier, nameof(learningRateMultiplier));

            _CycleCount = cycleCount;
            _BatchSize = batchSize;
            _LearningRateMultiplier = learningRateMultiplier;
        }

        internal FineTuningHyperparameters(BinaryData cycleCount, BinaryData batchSize, BinaryData learningRateMultiplier, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            _CycleCount = cycleCount;
            _BatchSize = batchSize;
            _LearningRateMultiplier = learningRateMultiplier;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        public FineTuningHyperparameters()
        {
        }
    }
}