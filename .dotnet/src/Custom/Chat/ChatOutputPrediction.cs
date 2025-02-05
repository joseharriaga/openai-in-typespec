using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Chat;

[CodeGenModel("ChatOutputPrediction")]
public partial class ChatOutputPrediction
{
    public static ChatOutputPrediction CreateStaticContentPrediction(IEnumerable<ChatMessageContentPart> contentParts)
        => new InternalChatOutputPredictionContent(new ChatMessageContent(contentParts));

    public static ChatOutputPrediction CreateStaticContentPrediction(string content)
        => new InternalChatOutputPredictionContent([ChatMessageContentPart.CreateTextPart(content)]);
}