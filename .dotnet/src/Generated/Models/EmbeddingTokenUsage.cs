// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Embeddings
{
    public partial class EmbeddingTokenUsage
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal EmbeddingTokenUsage(int inputTokenCount, int totalTokenCount)
        {
            InputTokenCount = inputTokenCount;
            TotalTokenCount = totalTokenCount;
        }

        internal EmbeddingTokenUsage(int inputTokenCount, int totalTokenCount, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            InputTokenCount = inputTokenCount;
            TotalTokenCount = totalTokenCount;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }
    }
}
