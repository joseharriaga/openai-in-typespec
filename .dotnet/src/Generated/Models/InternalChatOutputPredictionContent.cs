// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.Chat
{
    internal partial class InternalChatOutputPredictionContent : ChatOutputPrediction
    {
        public InternalChatOutputPredictionContent(ChatMessageContent content) : base(InternalChatOutputPredictionKind.StaticContent)
        {
            Argument.AssertNotNull(content, nameof(content));

            Content = content;
        }

        internal InternalChatOutputPredictionContent(InternalChatOutputPredictionKind @type, IDictionary<string, BinaryData> additionalBinaryDataProperties, ChatMessageContent content) : base(@type, additionalBinaryDataProperties)
        {
            Content = content;
        }
    }
}
