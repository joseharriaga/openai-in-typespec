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
    internal partial class InternalRealtimeClientEventConversationItemDelete : IJsonModel<InternalRealtimeClientEventConversationItemDelete>
    {
        internal InternalRealtimeClientEventConversationItemDelete()
        {
        }

        void IJsonModel<InternalRealtimeClientEventConversationItemDelete>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeClientEventConversationItemDelete>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeClientEventConversationItemDelete)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(EventId) && _additionalBinaryDataProperties?.ContainsKey("event_id") != true)
            {
                writer.WritePropertyName("event_id"u8);
                writer.WriteStringValue(EventId);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("item_id") != true)
            {
                writer.WritePropertyName("item_id"u8);
                writer.WriteStringValue(ItemId);
            }
        }

        InternalRealtimeClientEventConversationItemDelete IJsonModel<InternalRealtimeClientEventConversationItemDelete>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRealtimeClientEventConversationItemDelete)JsonModelCreateCore(ref reader, options);

        protected override InternalRealtimeClientEvent JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeClientEventConversationItemDelete>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeClientEventConversationItemDelete)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeClientEventConversationItemDelete(document.RootElement, options);
        }

        internal static InternalRealtimeClientEventConversationItemDelete DeserializeInternalRealtimeClientEventConversationItemDelete(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string eventId = default;
            string itemId = default;
            InternalRealtimeClientEventType kind = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("event_id"u8))
                {
                    eventId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("item_id"u8))
                {
                    itemId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    kind = new InternalRealtimeClientEventType(prop.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalRealtimeClientEventConversationItemDelete(eventId, itemId, kind, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRealtimeClientEventConversationItemDelete>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeClientEventConversationItemDelete>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeClientEventConversationItemDelete)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeClientEventConversationItemDelete IPersistableModel<InternalRealtimeClientEventConversationItemDelete>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRealtimeClientEventConversationItemDelete)PersistableModelCreateCore(data, options);

        protected override InternalRealtimeClientEvent PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeClientEventConversationItemDelete>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeClientEventConversationItemDelete(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeClientEventConversationItemDelete)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeClientEventConversationItemDelete>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRealtimeClientEventConversationItemDelete internalRealtimeClientEventConversationItemDelete)
        {
            if (internalRealtimeClientEventConversationItemDelete == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRealtimeClientEventConversationItemDelete, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRealtimeClientEventConversationItemDelete(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeClientEventConversationItemDelete(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
