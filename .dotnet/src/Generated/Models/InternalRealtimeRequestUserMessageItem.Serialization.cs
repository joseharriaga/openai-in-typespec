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
    internal partial class InternalRealtimeRequestUserMessageItem : IJsonModel<InternalRealtimeRequestUserMessageItem>
    {
        internal InternalRealtimeRequestUserMessageItem()
        {
        }

        void IJsonModel<InternalRealtimeRequestUserMessageItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestUserMessageItem>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeRequestUserMessageItem)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("content") != true)
            {
                writer.WritePropertyName("content"u8);
                writer.WriteStartArray();
                foreach (ConversationContentPart item in Content)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
        }

        InternalRealtimeRequestUserMessageItem IJsonModel<InternalRealtimeRequestUserMessageItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRealtimeRequestUserMessageItem)JsonModelCreateCore(ref reader, options);

        protected override ConversationItem JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestUserMessageItem>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeRequestUserMessageItem)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeRequestUserMessageItem(document.RootElement, options);
        }

        internal static InternalRealtimeRequestUserMessageItem DeserializeInternalRealtimeRequestUserMessageItem(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<ConversationContentPart> content = default;
            ConversationMessageRole role = default;
            ConversationItemStatus? status = default;
            InternalRealtimeItemType @type = default;
            string id = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("content"u8))
                {
                    List<ConversationContentPart> array = new List<ConversationContentPart>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(ConversationContentPart.DeserializeConversationContentPart(item, options));
                    }
                    content = array;
                    continue;
                }
                if (prop.NameEquals("role"u8))
                {
                    role = new ConversationMessageRole(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("status"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = new ConversationItemStatus(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    @type = new InternalRealtimeItemType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("id"u8))
                {
                    id = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalRealtimeRequestUserMessageItem(
                content,
                role,
                status,
                @type,
                id,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRealtimeRequestUserMessageItem>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestUserMessageItem>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeRequestUserMessageItem)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeRequestUserMessageItem IPersistableModel<InternalRealtimeRequestUserMessageItem>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRealtimeRequestUserMessageItem)PersistableModelCreateCore(data, options);

        protected override ConversationItem PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestUserMessageItem>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeRequestUserMessageItem(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeRequestUserMessageItem)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeRequestUserMessageItem>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRealtimeRequestUserMessageItem internalRealtimeRequestUserMessageItem)
        {
            if (internalRealtimeRequestUserMessageItem == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRealtimeRequestUserMessageItem, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRealtimeRequestUserMessageItem(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeRequestUserMessageItem(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
