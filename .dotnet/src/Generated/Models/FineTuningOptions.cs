// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI.Models;

namespace OpenAI.FineTuning
{
    public partial class FineTuningOptions
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }

        internal FineTuningOptions(CreateFineTuningJobRequestModel model, string trainingFile, HyperparameterOptions hyperparameters, string suffix, string validationFile, IList<Integration> integrations, int? seed, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Model = model;
            TrainingFile = trainingFile;
            Hyperparameters = hyperparameters;
            Suffix = suffix;
            ValidationFile = validationFile;
            Integrations = integrations;
            Seed = seed;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }
    }
}
