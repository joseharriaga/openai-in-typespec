// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationRateLimitsUpdatedUpdate : ConversationUpdate
    {
        internal ConversationRateLimitsUpdatedUpdate(string eventId, IEnumerable<ConversationRateLimitDetailsItem> rateLimits) : base(eventId)
        {
            Argument.AssertNotNull(rateLimits, nameof(rateLimits));

            Kind = ConversationUpdateKind.RateLimitsUpdated;
            RateLimits = rateLimits.ToList();
        }

        internal ConversationRateLimitsUpdatedUpdate(ConversationUpdateKind kind, string eventId, IDictionary<string, BinaryData> serializedAdditionalRawData, IReadOnlyList<ConversationRateLimitDetailsItem> rateLimits) : base(kind, eventId, serializedAdditionalRawData)
        {
            RateLimits = rateLimits;
        }

        internal ConversationRateLimitsUpdatedUpdate()
        {
        }

        public IReadOnlyList<ConversationRateLimitDetailsItem> RateLimits { get; }
    }
}
