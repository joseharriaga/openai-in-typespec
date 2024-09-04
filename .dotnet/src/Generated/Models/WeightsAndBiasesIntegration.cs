// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    internal partial class WeightsAndBiasesIntegration : FineTuningIntegration
    {
        public WeightsAndBiasesIntegration(InternalCreateFineTuningJobRequestWandbIntegrationWandb wandb)
        {
            Argument.AssertNotNull(wandb, nameof(wandb));

            Type = "wandb";
            Wandb = wandb;
        }

        internal WeightsAndBiasesIntegration(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, InternalCreateFineTuningJobRequestWandbIntegrationWandb wandb) : base(type, serializedAdditionalRawData)
        {
            Wandb = wandb;
        }

        internal WeightsAndBiasesIntegration()
        {
        }

        public InternalCreateFineTuningJobRequestWandbIntegrationWandb Wandb { get; }
    }
}
