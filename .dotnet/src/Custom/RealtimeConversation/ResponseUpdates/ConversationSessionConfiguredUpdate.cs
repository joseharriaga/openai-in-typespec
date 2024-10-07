using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
[CodeGenModel("RealtimeServerEventRateLimitsUpdated")]
public partial class ConversationRateLimitsUpdate
{
    public ConversationRateLimitDetailsItem TokenDetails
        => _tokenDetails ??= AllDetails.FirstOrDefault(item => item.Name == "tokens");
    private ConversationRateLimitDetailsItem _tokenDetails;
    public ConversationRateLimitDetailsItem RequestDetails
        => _tokenDetails ??= AllDetails.FirstOrDefault(item => item.Name == "requests");

    [CodeGenMember("RateLimits")]
    public IReadOnlyList<ConversationRateLimitDetailsItem> AllDetails { get; }
}