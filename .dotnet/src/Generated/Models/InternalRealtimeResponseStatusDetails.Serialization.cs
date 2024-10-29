// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    [PersistableModelProxy(typeof(UnknownRealtimeResponseStatusDetails))]
    internal abstract partial class InternalRealtimeResponseStatusDetails : IJsonModel<InternalRealtimeResponseStatusDetails>
    {
        internal InternalRealtimeResponseStatusDetails()
        {
        }

        void IJsonModel<InternalRealtimeResponseStatusDetails>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseStatusDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeResponseStatusDetails)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Type.ToString());
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
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

        InternalRealtimeResponseStatusDetails IJsonModel<InternalRealtimeResponseStatusDetails>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalRealtimeResponseStatusDetails JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseStatusDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeResponseStatusDetails)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeResponseStatusDetails(document.RootElement, options);
        }

        internal static InternalRealtimeResponseStatusDetails DeserializeInternalRealtimeResponseStatusDetails(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "cancelled":
                        return InternalRealtimeResponseCancelledStatusDetails.DeserializeInternalRealtimeResponseCancelledStatusDetails(element, options);
                    case "incomplete":
                        return InternalRealtimeResponseIncompleteStatusDetails.DeserializeInternalRealtimeResponseIncompleteStatusDetails(element, options);
                    case "failed":
                        return RealtimeResponseFailedStatusDetails.DeserializeRealtimeResponseFailedStatusDetails(element, options);
                }
            }
            return UnknownRealtimeResponseStatusDetails.DeserializeUnknownRealtimeResponseStatusDetails(element, options);
        }

        BinaryData IPersistableModel<InternalRealtimeResponseStatusDetails>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseStatusDetails>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeResponseStatusDetails)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeResponseStatusDetails IPersistableModel<InternalRealtimeResponseStatusDetails>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalRealtimeResponseStatusDetails PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseStatusDetails>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeResponseStatusDetails(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeResponseStatusDetails)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeResponseStatusDetails>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRealtimeResponseStatusDetails internalRealtimeResponseStatusDetails)
        {
            return BinaryContent.Create(internalRealtimeResponseStatusDetails, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRealtimeResponseStatusDetails(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeResponseStatusDetails(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}