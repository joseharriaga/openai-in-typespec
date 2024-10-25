// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationRateLimitDetailsItem
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal ConversationRateLimitDetailsItem(string name, int limit, int remaining, float resetSeconds)
        {
            Name = name;
            Limit = limit;
            Remaining = remaining;
            ResetSeconds = resetSeconds;
        }

        internal ConversationRateLimitDetailsItem(string name, int limit, int remaining, float resetSeconds, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Name = name;
            Limit = limit;
            Remaining = remaining;
            ResetSeconds = resetSeconds;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string Name { get; }

        public int Limit { get; }

        public int Remaining { get; }

        public float ResetSeconds { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
