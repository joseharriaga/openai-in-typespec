// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;
using OpenAI.RealtimeConversation;

namespace OpenAI.Models
{
    internal partial class UnknownRealtimeRequestMessageItem : IJsonModel<InternalRealtimeRequestMessageItem>
    {
        internal UnknownRealtimeRequestMessageItem()
        {
        }

        void IJsonModel<InternalRealtimeRequestMessageItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestMessageItem>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeRequestMessageItem)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
        }

        InternalRealtimeRequestMessageItem IJsonModel<InternalRealtimeRequestMessageItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (UnknownRealtimeRequestMessageItem)JsonModelCreateCore(ref reader, options);

        protected override ConversationItem JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestMessageItem>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeRequestMessageItem)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeRequestMessageItem(document.RootElement, options);
        }

        internal static UnknownRealtimeRequestMessageItem DeserializeUnknownRealtimeRequestMessageItem(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ConversationMessageRole role = default;
            ConversationItemStatus? status = default;
            InternalRealtimeRequestItemType @type = default;
            string id = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("role"u8))
                {
                    role = new ConversationMessageRole(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("status"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        status = null;
                        continue;
                    }
                    status = new ConversationItemStatus(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    @type = new InternalRealtimeRequestItemType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("id"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        id = null;
                        continue;
                    }
                    id = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new UnknownRealtimeRequestMessageItem(role, status, @type, id, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRealtimeRequestMessageItem>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestMessageItem>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeRequestMessageItem)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeRequestMessageItem IPersistableModel<InternalRealtimeRequestMessageItem>.Create(BinaryData data, ModelReaderWriterOptions options) => (UnknownRealtimeRequestMessageItem)PersistableModelCreateCore(data, options);

        protected override ConversationItem PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestMessageItem>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeRequestMessageItem(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeRequestMessageItem)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeRequestMessageItem>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
