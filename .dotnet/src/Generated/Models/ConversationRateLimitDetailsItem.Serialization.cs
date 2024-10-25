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
    public partial class ConversationRateLimitDetailsItem : IJsonModel<ConversationRateLimitDetailsItem>
    {
        internal ConversationRateLimitDetailsItem()
        {
        }

        void IJsonModel<ConversationRateLimitDetailsItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationRateLimitDetailsItem>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationRateLimitDetailsItem)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("name") != true)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("limit") != true)
            {
                writer.WritePropertyName("limit"u8);
                writer.WriteNumberValue(Limit);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("remaining") != true)
            {
                writer.WritePropertyName("remaining"u8);
                writer.WriteNumberValue(Remaining);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("reset_seconds") != true)
            {
                writer.WritePropertyName("reset_seconds"u8);
                writer.WriteNumberValue(ResetSeconds);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
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

        ConversationRateLimitDetailsItem IJsonModel<ConversationRateLimitDetailsItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual ConversationRateLimitDetailsItem JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationRateLimitDetailsItem>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationRateLimitDetailsItem)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationRateLimitDetailsItem(document.RootElement, options);
        }

        internal static ConversationRateLimitDetailsItem DeserializeConversationRateLimitDetailsItem(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            int limit = default;
            int remaining = default;
            float resetSeconds = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("limit"u8))
                {
                    limit = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("remaining"u8))
                {
                    remaining = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("reset_seconds"u8))
                {
                    resetSeconds = prop.Value.GetSingle();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new ConversationRateLimitDetailsItem(name, limit, remaining, resetSeconds, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ConversationRateLimitDetailsItem>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationRateLimitDetailsItem>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ConversationRateLimitDetailsItem)} does not support writing '{options.Format}' format.");
            }
        }

        ConversationRateLimitDetailsItem IPersistableModel<ConversationRateLimitDetailsItem>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual ConversationRateLimitDetailsItem PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationRateLimitDetailsItem>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeConversationRateLimitDetailsItem(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ConversationRateLimitDetailsItem)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConversationRateLimitDetailsItem>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ConversationRateLimitDetailsItem conversationRateLimitDetailsItem)
        {
            return BinaryContent.Create(conversationRateLimitDetailsItem, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ConversationRateLimitDetailsItem(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeConversationRateLimitDetailsItem(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
