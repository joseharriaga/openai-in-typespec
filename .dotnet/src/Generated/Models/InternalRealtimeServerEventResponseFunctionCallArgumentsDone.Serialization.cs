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
    internal partial class InternalRealtimeServerEventResponseFunctionCallArgumentsDone : IJsonModel<InternalRealtimeServerEventResponseFunctionCallArgumentsDone>
    {
        internal InternalRealtimeServerEventResponseFunctionCallArgumentsDone()
        {
        }

        void IJsonModel<InternalRealtimeServerEventResponseFunctionCallArgumentsDone>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeServerEventResponseFunctionCallArgumentsDone>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeServerEventResponseFunctionCallArgumentsDone)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
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
            if (_additionalBinaryDataProperties?.ContainsKey("call_id") != true)
            {
                writer.WritePropertyName("call_id"u8);
                writer.WriteStringValue(CallId);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("arguments") != true)
            {
                writer.WritePropertyName("arguments"u8);
                writer.WriteStringValue(Arguments);
            }
        }

        InternalRealtimeServerEventResponseFunctionCallArgumentsDone IJsonModel<InternalRealtimeServerEventResponseFunctionCallArgumentsDone>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRealtimeServerEventResponseFunctionCallArgumentsDone)JsonModelCreateCore(ref reader, options);

        protected override ConversationUpdate JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeServerEventResponseFunctionCallArgumentsDone>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeServerEventResponseFunctionCallArgumentsDone)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeServerEventResponseFunctionCallArgumentsDone(document.RootElement, options);
        }

        internal static InternalRealtimeServerEventResponseFunctionCallArgumentsDone DeserializeInternalRealtimeServerEventResponseFunctionCallArgumentsDone(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string eventId = default;
            ConversationUpdateKind kind = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            string responseId = default;
            string itemId = default;
            int outputIndex = default;
            string callId = default;
            string arguments = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("event_id"u8))
                {
                    eventId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    kind = prop.Value.GetString().ToConversationUpdateKind();
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
                if (prop.NameEquals("call_id"u8))
                {
                    callId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("arguments"u8))
                {
                    arguments = prop.Value.GetString();
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalRealtimeServerEventResponseFunctionCallArgumentsDone(
                eventId,
                kind,
                additionalBinaryDataProperties,
                responseId,
                itemId,
                outputIndex,
                callId,
                arguments);
        }

        BinaryData IPersistableModel<InternalRealtimeServerEventResponseFunctionCallArgumentsDone>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeServerEventResponseFunctionCallArgumentsDone>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeServerEventResponseFunctionCallArgumentsDone)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeServerEventResponseFunctionCallArgumentsDone IPersistableModel<InternalRealtimeServerEventResponseFunctionCallArgumentsDone>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRealtimeServerEventResponseFunctionCallArgumentsDone)PersistableModelCreateCore(data, options);

        protected override ConversationUpdate PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeServerEventResponseFunctionCallArgumentsDone>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeServerEventResponseFunctionCallArgumentsDone(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeServerEventResponseFunctionCallArgumentsDone)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeServerEventResponseFunctionCallArgumentsDone>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRealtimeServerEventResponseFunctionCallArgumentsDone internalRealtimeServerEventResponseFunctionCallArgumentsDone)
        {
            if (internalRealtimeServerEventResponseFunctionCallArgumentsDone == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRealtimeServerEventResponseFunctionCallArgumentsDone, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRealtimeServerEventResponseFunctionCallArgumentsDone(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeServerEventResponseFunctionCallArgumentsDone(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
