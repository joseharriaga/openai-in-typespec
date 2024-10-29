// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationRateLimitsUpdatedUpdate : ConversationUpdate
    {
        internal ConversationRateLimitsUpdatedUpdate(IEnumerable<ConversationRateLimitDetailsItem> rateLimits, string eventId) : base(eventId, RealtimeConversation.ConversationUpdateKind.RateLimitsUpdated)
        {
            RateLimits = rateLimits.ToList();
        }

        internal ConversationRateLimitsUpdatedUpdate(IList<ConversationRateLimitDetailsItem> rateLimits, string eventId, RealtimeConversation.ConversationUpdateKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(eventId, kind, additionalBinaryDataProperties)
        {
            RateLimits = rateLimits;
        }

        public IList<ConversationRateLimitDetailsItem> RateLimits { get; }
    }
}