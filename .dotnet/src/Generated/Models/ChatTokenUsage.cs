// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat
{
    public partial class ChatTokenUsage
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        internal ChatTokenUsage(int outputTokens, int inputTokens, int totalTokens)
        {
            OutputTokens = outputTokens;
            InputTokens = inputTokens;
            TotalTokens = totalTokens;
        }

        internal ChatTokenUsage(int outputTokens, int inputTokens, int totalTokens, InternalCompletionUsageCompletionTokensDetails internalCompletionTokenDetails, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            OutputTokens = outputTokens;
            InputTokens = inputTokens;
            TotalTokens = totalTokens;
            _internalCompletionTokenDetails = internalCompletionTokenDetails;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal ChatTokenUsage()
        {
        }
        public int TotalTokens { get; }
    }
}
