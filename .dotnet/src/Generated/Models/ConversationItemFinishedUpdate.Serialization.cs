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
    public partial class ConversationItemFinishedUpdate : IJsonModel<ConversationItemFinishedUpdate>
    {
        internal ConversationItemFinishedUpdate()
        {
        }

        void IJsonModel<ConversationItemFinishedUpdate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationItemFinishedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationItemFinishedUpdate)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("response_id") != true)
            {
                writer.WritePropertyName("response_id"u8);
            }
            writer.WriteStringValue(ResponseId);
            if (_additionalBinaryDataProperties?.ContainsKey("output_index") != true)
            {
                writer.WritePropertyName("output_index"u8);
            }
            writer.WriteNumberValue(OutputIndex);
            if (_additionalBinaryDataProperties?.ContainsKey("item") != true)
            {
                writer.WritePropertyName("item"u8);
            }
            writer.WriteObjectValue<InternalRealtimeResponseItem>(_internalItem, options);
        }

        ConversationItemFinishedUpdate IJsonModel<ConversationItemFinishedUpdate>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (ConversationItemFinishedUpdate)JsonModelCreateCore(ref reader, options);

        protected override ConversationUpdate JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationItemFinishedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationItemFinishedUpdate)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationItemFinishedUpdate(document.RootElement, options);
        }

        internal static ConversationItemFinishedUpdate DeserializeConversationItemFinishedUpdate(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string responseId = default;
            int outputIndex = default;
            InternalRealtimeResponseItem internalItem = default;
            string eventId = default;
            RealtimeConversation.ConversationUpdateKind kind = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("response_id"u8))
                {
                    responseId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("output_index"u8))
                {
                    outputIndex = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("item"u8))
                {
                    internalItem = InternalRealtimeResponseItem.DeserializeInternalRealtimeResponseItem(prop.Value, options);
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
            return new ConversationItemFinishedUpdate(
                responseId,
                outputIndex,
                internalItem,
                eventId,
                kind,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ConversationItemFinishedUpdate>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationItemFinishedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ConversationItemFinishedUpdate)} does not support writing '{options.Format}' format.");
            }
        }

        ConversationItemFinishedUpdate IPersistableModel<ConversationItemFinishedUpdate>.Create(BinaryData data, ModelReaderWriterOptions options) => (ConversationItemFinishedUpdate)PersistableModelCreateCore(data, options);

        protected override ConversationUpdate PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationItemFinishedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeConversationItemFinishedUpdate(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ConversationItemFinishedUpdate)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConversationItemFinishedUpdate>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ConversationItemFinishedUpdate conversationItemFinishedUpdate)
        {
            return BinaryContent.Create(conversationItemFinishedUpdate, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ConversationItemFinishedUpdate(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeConversationItemFinishedUpdate(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
