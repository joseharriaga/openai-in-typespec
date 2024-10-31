// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationOutputTokenUsageDetails : IJsonModel<ConversationOutputTokenUsageDetails>
    {
        internal ConversationOutputTokenUsageDetails()
        {
        }

        void IJsonModel<ConversationOutputTokenUsageDetails>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationOutputTokenUsageDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationOutputTokenUsageDetails)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("text_tokens") != true)
            {
                writer.WritePropertyName("text_tokens"u8);
                writer.WriteNumberValue(TextTokens);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("audio_tokens") != true)
            {
                writer.WritePropertyName("audio_tokens"u8);
                writer.WriteNumberValue(AudioTokens);
            }
            if (true && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    if (ModelSerializationExtensions.IsSentinelValue(item.Value))
                    {
                        continue;
                    }
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        ConversationOutputTokenUsageDetails IJsonModel<ConversationOutputTokenUsageDetails>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual ConversationOutputTokenUsageDetails JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationOutputTokenUsageDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationOutputTokenUsageDetails)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationOutputTokenUsageDetails(document.RootElement, options);
        }

        internal static ConversationOutputTokenUsageDetails DeserializeConversationOutputTokenUsageDetails(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int textTokens = default;
            int audioTokens = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("text_tokens"u8))
                {
                    textTokens = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("audio_tokens"u8))
                {
                    audioTokens = prop.Value.GetInt32();
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new ConversationOutputTokenUsageDetails(textTokens, audioTokens, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ConversationOutputTokenUsageDetails>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationOutputTokenUsageDetails>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ConversationOutputTokenUsageDetails)} does not support writing '{options.Format}' format.");
            }
        }

        ConversationOutputTokenUsageDetails IPersistableModel<ConversationOutputTokenUsageDetails>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual ConversationOutputTokenUsageDetails PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationOutputTokenUsageDetails>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeConversationOutputTokenUsageDetails(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ConversationOutputTokenUsageDetails)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConversationOutputTokenUsageDetails>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ConversationOutputTokenUsageDetails conversationOutputTokenUsageDetails)
        {
            if (conversationOutputTokenUsageDetails == null)
            {
                return null;
            }
            return BinaryContent.Create(conversationOutputTokenUsageDetails, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ConversationOutputTokenUsageDetails(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeConversationOutputTokenUsageDetails(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
