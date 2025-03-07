// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    public partial class HyperparametersForDPO
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public HyperparametersForDPO()
        {
        }

        internal HyperparametersForDPO(BinaryData batchSize, BinaryData nEpochs, BinaryData learningRateMultiplier, BinaryData beta, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            _BatchSize = batchSize;
            _NEpochs = nEpochs;
            _LearningRateMultiplier = learningRateMultiplier;
            _Beta = beta;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
