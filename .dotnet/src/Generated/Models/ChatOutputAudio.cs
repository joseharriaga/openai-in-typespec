// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat
{
    public partial class ChatOutputAudio
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal ChatOutputAudio(string id, DateTimeOffset expiresAt, string transcript, BinaryData audioBytes)
        {
            Id = id;
            ExpiresAt = expiresAt;
            Transcript = transcript;
            AudioBytes = audioBytes;
        }

        internal ChatOutputAudio(string id, DateTimeOffset expiresAt, string transcript, BinaryData audioBytes, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Id = id;
            ExpiresAt = expiresAt;
            Transcript = transcript;
            AudioBytes = audioBytes;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string Id { get; }

        public DateTimeOffset ExpiresAt { get; }

        public string Transcript { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
