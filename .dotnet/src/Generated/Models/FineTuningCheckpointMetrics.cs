// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    public partial class FineTuningCheckpointMetrics
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        internal FineTuningCheckpointMetrics(int stepNumber, float trainLoss, float trainMeanTokenAccuracy)
        {
            StepNumber = stepNumber;
            TrainLoss = trainLoss;
            TrainMeanTokenAccuracy = trainMeanTokenAccuracy;
        }

        internal FineTuningCheckpointMetrics(int stepNumber, float trainLoss, float trainMeanTokenAccuracy, float? validLoss, float? validMeanTokenAccuracy, float? fullValidLoss, float? fullValidMeanTokenAccuracy, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            StepNumber = stepNumber;
            TrainLoss = trainLoss;
            TrainMeanTokenAccuracy = trainMeanTokenAccuracy;
            ValidLoss = validLoss;
            ValidMeanTokenAccuracy = validMeanTokenAccuracy;
            FullValidLoss = fullValidLoss;
            FullValidMeanTokenAccuracy = fullValidMeanTokenAccuracy;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal FineTuningCheckpointMetrics()
        {
        }
        public float TrainLoss { get; }
        public float TrainMeanTokenAccuracy { get; }
        public float? ValidLoss { get; }
        public float? ValidMeanTokenAccuracy { get; }
        public float? FullValidLoss { get; }
        public float? FullValidMeanTokenAccuracy { get; }
    }
}
