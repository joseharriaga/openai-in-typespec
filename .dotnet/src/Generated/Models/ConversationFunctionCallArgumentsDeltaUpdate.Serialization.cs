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
    public partial class ConversationFunctionCallArgumentsDeltaUpdate : IJsonModel<ConversationFunctionCallArgumentsDeltaUpdate>
    {
        internal ConversationFunctionCallArgumentsDeltaUpdate()
        {
        }

        void IJsonModel<ConversationFunctionCallArgumentsDeltaUpdate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationFunctionCallArgumentsDeltaUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationFunctionCallArgumentsDeltaUpdate)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("response_id") != true)
            {
                writer.WritePropertyName("response_id"u8);
            }
            writer.WriteStringValue(ResponseId);
            if (_additionalBinaryDataProperties?.ContainsKey("item_id") != true)
            {
                writer.WritePropertyName("item_id"u8);
            }
            writer.WriteStringValue(ItemId);
            if (_additionalBinaryDataProperties?.ContainsKey("output_index") != true)
            {
                writer.WritePropertyName("output_index"u8);
            }
            writer.WriteNumberValue(OutputIndex);
            if (_additionalBinaryDataProperties?.ContainsKey("call_id") != true)
            {
                writer.WritePropertyName("call_id"u8);
            }
            writer.WriteStringValue(CallId);
            if (_additionalBinaryDataProperties?.ContainsKey("delta") != true)
            {
                writer.WritePropertyName("delta"u8);
            }
            writer.WriteStringValue(Delta);
        }

        ConversationFunctionCallArgumentsDeltaUpdate IJsonModel<ConversationFunctionCallArgumentsDeltaUpdate>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (ConversationFunctionCallArgumentsDeltaUpdate)JsonModelCreateCore(ref reader, options);

        protected override ConversationUpdate JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationFunctionCallArgumentsDeltaUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationFunctionCallArgumentsDeltaUpdate)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationFunctionCallArgumentsDeltaUpdate(document.RootElement, options);
        }

        internal static ConversationFunctionCallArgumentsDeltaUpdate DeserializeConversationFunctionCallArgumentsDeltaUpdate(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string responseId = default;
            string itemId = default;
            int outputIndex = default;
            string callId = default;
            string delta = default;
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
                if (prop.NameEquals("item_id"u8))
                {
                    itemId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("output_index"u8))
                {
                    outputIndex = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("call_id"u8))
                {
                    callId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("delta"u8))
                {
                    delta = prop.Value.GetString();
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
            return new ConversationFunctionCallArgumentsDeltaUpdate(
                responseId,
                itemId,
                outputIndex,
                callId,
                delta,
                eventId,
                kind,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ConversationFunctionCallArgumentsDeltaUpdate>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationFunctionCallArgumentsDeltaUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ConversationFunctionCallArgumentsDeltaUpdate)} does not support writing '{options.Format}' format.");
            }
        }

        ConversationFunctionCallArgumentsDeltaUpdate IPersistableModel<ConversationFunctionCallArgumentsDeltaUpdate>.Create(BinaryData data, ModelReaderWriterOptions options) => (ConversationFunctionCallArgumentsDeltaUpdate)PersistableModelCreateCore(data, options);

        protected override ConversationUpdate PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationFunctionCallArgumentsDeltaUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeConversationFunctionCallArgumentsDeltaUpdate(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ConversationFunctionCallArgumentsDeltaUpdate)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConversationFunctionCallArgumentsDeltaUpdate>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ConversationFunctionCallArgumentsDeltaUpdate conversationFunctionCallArgumentsDeltaUpdate)
        {
            return BinaryContent.Create(conversationFunctionCallArgumentsDeltaUpdate, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ConversationFunctionCallArgumentsDeltaUpdate(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeConversationFunctionCallArgumentsDeltaUpdate(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
