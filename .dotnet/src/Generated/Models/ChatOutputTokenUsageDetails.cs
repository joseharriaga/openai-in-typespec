// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat
{
    public partial class ChatOutputTokenUsageDetails
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal ChatOutputTokenUsageDetails(int reasoningTokenCount, int audioTokenCount)
        {
            ReasoningTokenCount = reasoningTokenCount;
            AudioTokenCount = audioTokenCount;
        }

        internal ChatOutputTokenUsageDetails(int reasoningTokenCount, int audioTokenCount, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            ReasoningTokenCount = reasoningTokenCount;
            AudioTokenCount = audioTokenCount;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
