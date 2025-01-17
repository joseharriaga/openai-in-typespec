// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat
{
    internal partial class InternalChatCompletionStreamResponseDelta
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal InternalChatCompletionStreamResponseDelta(StreamingChatResponseAudioUpdate audio, StreamingChatFunctionCallUpdate functionCall, IReadOnlyList<StreamingChatToolCallUpdate> toolCalls, string refusal, Chat.ChatMessageRole? role, ChatMessageContent content, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Audio = audio;
            FunctionCall = functionCall;
            ToolCalls = toolCalls;
            Refusal = refusal;
            Role = role;
            Content = content;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public StreamingChatResponseAudioUpdate Audio { get; }

        public StreamingChatFunctionCallUpdate FunctionCall { get; }

        public IReadOnlyList<StreamingChatToolCallUpdate> ToolCalls { get; }

        public string Refusal { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
