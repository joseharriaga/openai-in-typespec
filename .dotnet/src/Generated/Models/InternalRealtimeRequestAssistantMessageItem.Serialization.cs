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
    internal partial class InternalRealtimeRequestAssistantMessageItem : IJsonModel<InternalRealtimeRequestAssistantMessageItem>
    {
        internal InternalRealtimeRequestAssistantMessageItem()
        {
        }

        void IJsonModel<InternalRealtimeRequestAssistantMessageItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestAssistantMessageItem>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeRequestAssistantMessageItem)} does not support writing '{format}' format.");
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

        InternalRealtimeRequestAssistantMessageItem IJsonModel<InternalRealtimeRequestAssistantMessageItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRealtimeRequestAssistantMessageItem)JsonModelCreateCore(ref reader, options);

        protected override ConversationItem JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestAssistantMessageItem>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeRequestAssistantMessageItem)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeRequestAssistantMessageItem(document.RootElement, options);
        }

        internal static InternalRealtimeRequestAssistantMessageItem DeserializeInternalRealtimeRequestAssistantMessageItem(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<ConversationContentPart> content = default;
            ConversationMessageRole role = default;
            ConversationItemStatus? status = default;
            InternalRealtimeRequestItemType @type = default;
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
                    @type = new InternalRealtimeRequestItemType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("id"u8))
                {
                    id = prop.Value.GetString();
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalRealtimeRequestAssistantMessageItem(
                content,
                role,
                status,
                @type,
                id,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRealtimeRequestAssistantMessageItem>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestAssistantMessageItem>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeRequestAssistantMessageItem)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeRequestAssistantMessageItem IPersistableModel<InternalRealtimeRequestAssistantMessageItem>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRealtimeRequestAssistantMessageItem)PersistableModelCreateCore(data, options);

        protected override ConversationItem PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeRequestAssistantMessageItem>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeRequestAssistantMessageItem(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeRequestAssistantMessageItem)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeRequestAssistantMessageItem>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRealtimeRequestAssistantMessageItem internalRealtimeRequestAssistantMessageItem)
        {
            if (internalRealtimeRequestAssistantMessageItem == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRealtimeRequestAssistantMessageItem, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRealtimeRequestAssistantMessageItem(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeRequestAssistantMessageItem(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
