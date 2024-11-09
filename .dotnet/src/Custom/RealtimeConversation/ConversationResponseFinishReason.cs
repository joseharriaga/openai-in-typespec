using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
[CodeGenModel("RealtimeResponseStatusDetailsReason")]
public readonly partial struct ConversationResponseFinishReason
{
    // CUSTOM: contrived type to combine succesful in_progress status with the related reason property
    public static ConversationResponseFinishReason InProgress { get; } = new(InternalRealtimeResponseStatusKind.InProgress.ToString());

    // CUSTOM: contrived type to represent the absence of an incompletion finish reason for successful completion
    public static ConversationResponseFinishReason Completed { get; } = new(InternalRealtimeResponseStatusKind.Completed.ToString());

    // CUSTOM: contrived type to combine failed status with the related reason property
    public static ConversationResponseFinishReason Failed { get; } = new(InternalRealtimeResponseStatusKind.Failed.ToString());
}