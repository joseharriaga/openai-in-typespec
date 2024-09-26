// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat;

internal partial class InternalChatCompletionRequestMessageContentPartRefusal : ChatMessageContentPart
{
    public InternalChatCompletionRequestMessageContentPartRefusal(string refusal)
        : this(ChatMessageContentPartKind.Refusal, serializedAdditionalRawData: null, refusal)
    { }

    internal InternalChatCompletionRequestMessageContentPartRefusal(
        ChatMessageContentPartKind kind,
        IDictionary<string, BinaryData> serializedAdditionalRawData,
        string refusal)
            : base(kind, serializedAdditionalRawData)
    {
        Refusal = refusal;
    }

    internal InternalChatCompletionRequestMessageContentPartRefusal() : this(null)
    { }
}
