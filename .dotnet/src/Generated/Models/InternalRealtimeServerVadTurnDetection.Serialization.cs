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
    internal partial class InternalRealtimeServerVadTurnDetection : IJsonModel<InternalRealtimeServerVadTurnDetection>
    {
        void IJsonModel<InternalRealtimeServerVadTurnDetection>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeServerVadTurnDetection>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeServerVadTurnDetection)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Threshold) && _additionalBinaryDataProperties?.ContainsKey("threshold") != true)
            {
                writer.WritePropertyName("threshold"u8);
                writer.WriteNumberValue(Threshold.Value);
            }
            if (Optional.IsDefined(PrefixPaddingMs) && _additionalBinaryDataProperties?.ContainsKey("prefix_padding_ms") != true)
            {
                writer.WritePropertyName("prefix_padding_ms"u8);
                SerializePrefixPaddingMs(writer, options);
            }
            if (Optional.IsDefined(SilenceDurationMs) && _additionalBinaryDataProperties?.ContainsKey("silence_duration_ms") != true)
            {
                writer.WritePropertyName("silence_duration_ms"u8);
                SerializeSilenceDurationMs(writer, options);
            }
        }

        InternalRealtimeServerVadTurnDetection IJsonModel<InternalRealtimeServerVadTurnDetection>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRealtimeServerVadTurnDetection)JsonModelCreateCore(ref reader, options);

        protected override ConversationTurnDetectionOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeServerVadTurnDetection>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeServerVadTurnDetection)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeServerVadTurnDetection(document.RootElement, options);
        }

        internal static InternalRealtimeServerVadTurnDetection DeserializeInternalRealtimeServerVadTurnDetection(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ConversationTurnDetectionKind kind = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            float? threshold = default;
            TimeSpan? prefixPaddingMs = default;
            TimeSpan? silenceDurationMs = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("type"u8))
                {
                    kind = prop.Value.GetString().ToConversationTurnDetectionKind();
                    continue;
                }
                if (prop.NameEquals("threshold"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    threshold = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("prefix_padding_ms"u8))
                {
                    DeserializeMillisecondDuration(prop, ref prefixPaddingMs);
                    continue;
                }
                if (prop.NameEquals("silence_duration_ms"u8))
                {
                    DeserializeMillisecondDuration(prop, ref silenceDurationMs);
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalRealtimeServerVadTurnDetection(kind, additionalBinaryDataProperties, threshold, prefixPaddingMs, silenceDurationMs);
        }

        BinaryData IPersistableModel<InternalRealtimeServerVadTurnDetection>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeServerVadTurnDetection>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeServerVadTurnDetection)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeServerVadTurnDetection IPersistableModel<InternalRealtimeServerVadTurnDetection>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRealtimeServerVadTurnDetection)PersistableModelCreateCore(data, options);

        protected override ConversationTurnDetectionOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeServerVadTurnDetection>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeServerVadTurnDetection(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeServerVadTurnDetection)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeServerVadTurnDetection>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRealtimeServerVadTurnDetection internalRealtimeServerVadTurnDetection)
        {
            if (internalRealtimeServerVadTurnDetection == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRealtimeServerVadTurnDetection, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRealtimeServerVadTurnDetection(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeServerVadTurnDetection(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
