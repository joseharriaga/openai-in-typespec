using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Chat;

[CodeGenModel("ChatOutputPredictionType")]
public readonly partial struct ChatOutputPredictionKind
{
    // CUSTOM: Rename for clarity.
    [CodeGenMember("Content")]
    public static ChatOutputPredictionKind StaticContent { get; } = new ChatOutputPredictionKind(ContentValue);
}