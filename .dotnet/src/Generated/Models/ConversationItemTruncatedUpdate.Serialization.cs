// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationItemTruncatedUpdate : IJsonModel<ConversationItemTruncatedUpdate>
    {
        void IJsonModel<ConversationItemTruncatedUpdate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ConversationItemTruncatedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationItemTruncatedUpdate)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("item_id") != true)
            {
                writer.WritePropertyName("item_id"u8);
                writer.WriteStringValue(ItemId);
            }
            if (SerializedAdditionalRawData?.ContainsKey("audio_end_ms") != true)
            {
                writer.WritePropertyName("audio_end_ms"u8);
                writer.WriteNumberValue(AudioEndMs);
            }
            if (SerializedAdditionalRawData?.ContainsKey("index") != true)
            {
                writer.WritePropertyName("index"u8);
                writer.WriteNumberValue(Index);
            }
            if (SerializedAdditionalRawData?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Kind.ToSerialString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("event_id") != true)
            {
                if (EventId != null)
                {
                    writer.WritePropertyName("event_id"u8);
                    writer.WriteStringValue(EventId);
                }
                else
                {
                    writer.WriteNull("event_id");
                }
            }
            if (SerializedAdditionalRawData != null)
            {
                foreach (var item in SerializedAdditionalRawData)
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
            writer.WriteEndObject();
        }

        ConversationItemTruncatedUpdate IJsonModel<ConversationItemTruncatedUpdate>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ConversationItemTruncatedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationItemTruncatedUpdate)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationItemTruncatedUpdate(document.RootElement, options);
        }

        internal static ConversationItemTruncatedUpdate DeserializeConversationItemTruncatedUpdate(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string itemId = default;
            int audioEndMs = default;
            int index = default;
            ConversationUpdateKind type = default;
            string eventId = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("item_id"u8))
                {
                    itemId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("audio_end_ms"u8))
                {
                    audioEndMs = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("index"u8))
                {
                    index = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString().ToConversationUpdateKind();
                    continue;
                }
                if (property.NameEquals("event_id"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        eventId = null;
                        continue;
                    }
                    eventId = property.Value.GetString();
                    continue;
                }
                if (true)
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ConversationItemTruncatedUpdate(
                type,
                eventId,
                serializedAdditionalRawData,
                itemId,
                audioEndMs,
                index);
        }

        BinaryData IPersistableModel<ConversationItemTruncatedUpdate>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ConversationItemTruncatedUpdate>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ConversationItemTruncatedUpdate)} does not support writing '{options.Format}' format.");
            }
        }

        ConversationItemTruncatedUpdate IPersistableModel<ConversationItemTruncatedUpdate>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ConversationItemTruncatedUpdate>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeConversationItemTruncatedUpdate(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ConversationItemTruncatedUpdate)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConversationItemTruncatedUpdate>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static new ConversationItemTruncatedUpdate FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeConversationItemTruncatedUpdate(document.RootElement);
        }

        internal override BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
