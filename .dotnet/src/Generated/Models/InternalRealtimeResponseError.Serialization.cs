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
    internal partial class InternalRealtimeResponseError : IJsonModel<InternalRealtimeResponseError>
    {
        internal InternalRealtimeResponseError()
        {
        }

        void IJsonModel<InternalRealtimeResponseError>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseError>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeResponseError)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Type);
            }
            if (Optional.IsDefined(Code) && _additionalBinaryDataProperties?.ContainsKey("code") != true)
            {
                writer.WritePropertyName("code"u8);
                writer.WriteStringValue(Code);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("message") != true)
            {
                writer.WritePropertyName("message"u8);
                writer.WriteStringValue(Message);
            }
            if (Optional.IsDefined(Param) && _additionalBinaryDataProperties?.ContainsKey("param") != true)
            {
                writer.WritePropertyName("param"u8);
                writer.WriteStringValue(Param);
            }
            if (Optional.IsDefined(EventId) && _additionalBinaryDataProperties?.ContainsKey("event_id") != true)
            {
                writer.WritePropertyName("event_id"u8);
                writer.WriteStringValue(EventId);
            }
            if (true && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    if (ModelSerializationExtensions.IsSentinelValue(item.Value))
                    {
                        continue;
                    }
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        InternalRealtimeResponseError IJsonModel<InternalRealtimeResponseError>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalRealtimeResponseError JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseError>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeResponseError)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeResponseError(document.RootElement, options);
        }

        internal static InternalRealtimeResponseError DeserializeInternalRealtimeResponseError(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string @type = default;
            string code = default;
            string message = default;
            string @param = default;
            string eventId = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("type"u8))
                {
                    @type = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("code"u8))
                {
                    code = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("message"u8))
                {
                    message = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("param"u8))
                {
                    @param = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("event_id"u8))
                {
                    eventId = prop.Value.GetString();
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalRealtimeResponseError(
                @type,
                code,
                message,
                @param,
                eventId,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRealtimeResponseError>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseError>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeResponseError)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeResponseError IPersistableModel<InternalRealtimeResponseError>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalRealtimeResponseError PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseError>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeResponseError(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeResponseError)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeResponseError>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRealtimeResponseError internalRealtimeResponseError)
        {
            if (internalRealtimeResponseError == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRealtimeResponseError, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRealtimeResponseError(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeResponseError(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
