// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat
{
    public partial class ChatResponseFormat
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        private protected ChatResponseFormat(string @type)
        {
            Type = @type;
        }

        internal ChatResponseFormat(string @type, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Type = @type;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        internal string Type { get; set; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
