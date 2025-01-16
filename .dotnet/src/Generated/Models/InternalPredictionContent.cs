// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.Chat
{
    internal partial class InternalPredictionContent
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public InternalPredictionContent(BinaryData content)
        {
            Argument.AssertNotNull(content, nameof(content));

            Content = content;
        }

        internal InternalPredictionContent(InternalPredictionContentType @type, BinaryData content, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Type = @type;
            Content = content;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public InternalPredictionContentType Type { get; } = "content";

        public BinaryData Content { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
