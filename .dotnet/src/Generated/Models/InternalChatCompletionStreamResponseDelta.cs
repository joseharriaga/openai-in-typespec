// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat
{
    internal partial class InternalChatCompletionStreamResponseDelta
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }

        internal InternalChatCompletionStreamResponseDelta(IReadOnlyList<ChatMessageContentPart> content, StreamingChatFunctionCallUpdate functionCall, IReadOnlyList<StreamingChatToolCallUpdate> toolCalls, ChatMessageRole? role, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Content = content;
            FunctionCall = functionCall;
            ToolCalls = toolCalls;
            Role = role;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }
        public StreamingChatFunctionCallUpdate FunctionCall { get; }
        public IReadOnlyList<StreamingChatToolCallUpdate> ToolCalls { get; }
    }
}
