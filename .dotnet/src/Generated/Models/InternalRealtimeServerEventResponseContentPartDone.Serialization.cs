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
    internal partial class InternalRealtimeServerEventResponseContentPartDone : IJsonModel<InternalRealtimeServerEventResponseContentPartDone>
    {
        internal InternalRealtimeServerEventResponseContentPartDone()
        {
        }

        void IJsonModel<InternalRealtimeServerEventResponseContentPartDone>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeServerEventResponseContentPartDone>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeServerEventResponseContentPartDone)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("event_id") != true)
            {
                writer.WritePropertyName("event_id"u8);
                writer.WriteStringValue(EventId);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("response_id") != true)
            {
                writer.WritePropertyName("response_id"u8);
                writer.WriteStringValue(ResponseId);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("item_id") != true)
            {
                writer.WritePropertyName("item_id"u8);
                writer.WriteStringValue(ItemId);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("output_index") != true)
            {
                writer.WritePropertyName("output_index"u8);
                writer.WriteNumberValue(OutputIndex);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("content_index") != true)
            {
                writer.WritePropertyName("content_index"u8);
                writer.WriteNumberValue(ContentIndex);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("part") != true)
            {
                writer.WritePropertyName("part"u8);
                writer.WriteObjectValue<ConversationContentPart>(_internalContentPart, options);
            }
        }

        InternalRealtimeServerEventResponseContentPartDone IJsonModel<InternalRealtimeServerEventResponseContentPartDone>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRealtimeServerEventResponseContentPartDone)JsonModelCreateCore(ref reader, options);

        protected override ConversationUpdate JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeServerEventResponseContentPartDone>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeServerEventResponseContentPartDone)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeServerEventResponseContentPartDone(document.RootElement, options);
        }

        internal static InternalRealtimeServerEventResponseContentPartDone DeserializeInternalRealtimeServerEventResponseContentPartDone(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string eventId = default;
            string responseId = default;
            string itemId = default;
            int outputIndex = default;
            int contentIndex = default;
            ConversationContentPart internalContentPart = default;
            RealtimeConversation.ConversationUpdateKind kind = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("event_id"u8))
                {
                    eventId = prop.Value.GetString();
                    continue;
                }
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
                if (prop.NameEquals("content_index"u8))
                {
                    contentIndex = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("part"u8))
                {
                    internalContentPart = ConversationContentPart.DeserializeConversationContentPart(prop.Value, options);
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
            return new InternalRealtimeServerEventResponseContentPartDone(
                eventId,
                responseId,
                itemId,
                outputIndex,
                contentIndex,
                internalContentPart,
                kind,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRealtimeServerEventResponseContentPartDone>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeServerEventResponseContentPartDone>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeServerEventResponseContentPartDone)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeServerEventResponseContentPartDone IPersistableModel<InternalRealtimeServerEventResponseContentPartDone>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRealtimeServerEventResponseContentPartDone)PersistableModelCreateCore(data, options);

        protected override ConversationUpdate PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeServerEventResponseContentPartDone>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeServerEventResponseContentPartDone(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeServerEventResponseContentPartDone)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeServerEventResponseContentPartDone>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRealtimeServerEventResponseContentPartDone internalRealtimeServerEventResponseContentPartDone)
        {
            if (internalRealtimeServerEventResponseContentPartDone == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRealtimeServerEventResponseContentPartDone, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRealtimeServerEventResponseContentPartDone(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeServerEventResponseContentPartDone(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
