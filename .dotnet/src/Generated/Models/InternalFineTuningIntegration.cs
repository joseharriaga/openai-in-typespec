// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    internal partial class InternalFineTuningIntegration
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        internal InternalFineTuningIntegration(InternalFineTuningIntegrationWandb wandb)
        {
            Argument.AssertNotNull(wandb, nameof(wandb));

            Wandb = wandb;
        }

        internal InternalFineTuningIntegration(InternalFineTuningIntegrationType type, InternalFineTuningIntegrationWandb wandb, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Type = type;
            Wandb = wandb;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal InternalFineTuningIntegration()
        {
        }

        public InternalFineTuningIntegrationType Type { get; } = InternalFineTuningIntegrationType.Wandb;

        public InternalFineTuningIntegrationWandb Wandb { get; }
    }
}
