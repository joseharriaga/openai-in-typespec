// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI.Chat;

namespace OpenAI.FineTuning
{
    internal partial class InternalFineTuneChatCompletionRequestAssistantMessage : AssistantChatMessage
    {
        public InternalFineTuneChatCompletionRequestAssistantMessage()
        {
        }

        internal InternalFineTuneChatCompletionRequestAssistantMessage(string role, IList<ChatMessageContentPart> content, IDictionary<string, BinaryData> serializedAdditionalRawData, string refusal, string participantName, IList<ChatToolCall> toolCalls, ChatFunctionCall functionCall) : base(role, content, serializedAdditionalRawData, refusal, participantName, toolCalls, functionCall)
        {
        }
    }
}
