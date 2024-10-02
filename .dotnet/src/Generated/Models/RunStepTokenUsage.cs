// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    public partial class RunStepTokenUsage
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal RunStepTokenUsage(int outputTokenCount, int inputTokenCount, int totalTokenCount)
        {
            OutputTokenCount = outputTokenCount;
            InputTokenCount = inputTokenCount;
            TotalTokenCount = totalTokenCount;
        }

        internal RunStepTokenUsage(int outputTokenCount, int inputTokenCount, int totalTokenCount, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            OutputTokenCount = outputTokenCount;
            InputTokenCount = inputTokenCount;
            TotalTokenCount = totalTokenCount;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }
    }
}
