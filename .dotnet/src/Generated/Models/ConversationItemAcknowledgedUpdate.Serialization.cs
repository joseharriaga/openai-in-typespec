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
    public partial class ConversationItemAcknowledgedUpdate : IJsonModel<ConversationItemAcknowledgedUpdate>
    {
        internal ConversationItemAcknowledgedUpdate()
        {
        }

        void IJsonModel<ConversationItemAcknowledgedUpdate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationItemAcknowledgedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationItemAcknowledgedUpdate)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("item") != true)
            {
                writer.WritePropertyName("item"u8);
            }
            writer.WriteObjectValue<ConversationItem>(Item, options);
        }

        ConversationItemAcknowledgedUpdate IJsonModel<ConversationItemAcknowledgedUpdate>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (ConversationItemAcknowledgedUpdate)JsonModelCreateCore(ref reader, options);

        protected override ConversationUpdate JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationItemAcknowledgedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationItemAcknowledgedUpdate)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationItemAcknowledgedUpdate(document.RootElement, options);
        }

        internal static ConversationItemAcknowledgedUpdate DeserializeConversationItemAcknowledgedUpdate(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ConversationItem item = default;
            string eventId = default;
            RealtimeConversation.ConversationUpdateKind kind = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("item"u8))
                {
                    item = ConversationItem.DeserializeConversationItem(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("event_id"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        eventId = null;
                        continue;
                    }
                    eventId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    kind = prop.Value.GetString().ToConversationUpdateKind();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new ConversationItemAcknowledgedUpdate(item, eventId, kind, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ConversationItemAcknowledgedUpdate>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationItemAcknowledgedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ConversationItemAcknowledgedUpdate)} does not support writing '{options.Format}' format.");
            }
        }

        ConversationItemAcknowledgedUpdate IPersistableModel<ConversationItemAcknowledgedUpdate>.Create(BinaryData data, ModelReaderWriterOptions options) => (ConversationItemAcknowledgedUpdate)PersistableModelCreateCore(data, options);

        protected override ConversationUpdate PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationItemAcknowledgedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeConversationItemAcknowledgedUpdate(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ConversationItemAcknowledgedUpdate)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConversationItemAcknowledgedUpdate>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ConversationItemAcknowledgedUpdate conversationItemAcknowledgedUpdate)
        {
            return BinaryContent.Create(conversationItemAcknowledgedUpdate, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ConversationItemAcknowledgedUpdate(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeConversationItemAcknowledgedUpdate(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
