// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI.Chat;

namespace OpenAI.Assistants
{
    internal partial class InternalChatCompletionRequestMessageContentPartRefusal
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        public InternalChatCompletionRequestMessageContentPartRefusal(string refusal)
        {
            Argument.AssertNotNull(refusal, nameof(refusal));

            Refusal = refusal;
        }

        internal InternalChatCompletionRequestMessageContentPartRefusal(InternalChatCompletionRequestMessageContentPartRefusalType type, string refusal, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Type = type;
            Refusal = refusal;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal InternalChatCompletionRequestMessageContentPartRefusal()
        {
        }

        public InternalChatCompletionRequestMessageContentPartRefusalType Type { get; } = InternalChatCompletionRequestMessageContentPartRefusalType.Refusal;

        public string Refusal { get; }
    }
}
