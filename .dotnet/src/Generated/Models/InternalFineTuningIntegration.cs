// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    internal partial class InternalFineTuningIntegration
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        internal InternalFineTuningIntegration(InternalFineTuningIntegrationWandb wandb)
        {
            Argument.AssertNotNull(wandb, nameof(wandb));

            Wandb = wandb;
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
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
