// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.Chat
{
    internal partial class InternalChatCompletionRequestMessageContentPartText
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public InternalChatCompletionRequestMessageContentPartText(string text)
        {
            Argument.AssertNotNull(text, nameof(text));

            Text = text;
        }

        internal InternalChatCompletionRequestMessageContentPartText(InternalChatCompletionRequestMessageContentPartTextType @type, string text, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Type = @type;
            Text = text;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public InternalChatCompletionRequestMessageContentPartTextType Type { get; } = "text";

        public string Text { get; set; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
