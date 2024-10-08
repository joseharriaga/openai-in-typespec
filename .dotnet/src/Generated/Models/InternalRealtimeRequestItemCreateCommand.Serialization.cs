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
    internal partial class InternalRealtimeRequestItemCreateCommand : IJsonModel<InternalRealtimeRequestItemCreateCommand>
    {
        internal InternalRealtimeRequestItemCreateCommand()
        {
        }

        void IJsonModel<InternalRealtimeRequestItemCreateCommand>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestItemCreateCommand>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeRequestItemCreateCommand)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(PreviousItemId))
            {
                writer.WritePropertyName("previous_item_id"u8);
                writer.WriteStringValue(PreviousItemId);
            }
            writer.WritePropertyName("item"u8);
            writer.WriteObjectValue(Item, options);
        }

        InternalRealtimeRequestItemCreateCommand IJsonModel<InternalRealtimeRequestItemCreateCommand>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRealtimeRequestItemCreateCommand)JsonModelCreateCore(ref reader, options);

        protected override InternalRealtimeRequestCommand JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestItemCreateCommand>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeRequestItemCreateCommand)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeRequestItemCreateCommand(document.RootElement, options);
        }

        internal static InternalRealtimeRequestItemCreateCommand DeserializeInternalRealtimeRequestItemCreateCommand(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string previousItemId = default;
            ConversationItem item = default;
            InternalRealtimeRequestCommandType kind = default;
            string eventId = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("previous_item_id"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        previousItemId = null;
                        continue;
                    }
                    previousItemId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("item"u8))
                {
                    item = ConversationItem.DeserializeConversationItem(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    kind = new InternalRealtimeRequestCommandType(prop.Value.GetString());
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
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalRealtimeRequestItemCreateCommand(previousItemId, item, kind, eventId, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRealtimeRequestItemCreateCommand>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestItemCreateCommand>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeRequestItemCreateCommand)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeRequestItemCreateCommand IPersistableModel<InternalRealtimeRequestItemCreateCommand>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRealtimeRequestItemCreateCommand)PersistableModelCreateCore(data, options);

        protected override InternalRealtimeRequestCommand PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestItemCreateCommand>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeRequestItemCreateCommand(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeRequestItemCreateCommand)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeRequestItemCreateCommand>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRealtimeRequestItemCreateCommand internalRealtimeRequestItemCreateCommand)
        {
            return BinaryContent.Create(internalRealtimeRequestItemCreateCommand, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRealtimeRequestItemCreateCommand(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeRequestItemCreateCommand(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
