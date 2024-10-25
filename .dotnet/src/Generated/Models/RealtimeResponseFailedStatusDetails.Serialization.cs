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
    internal partial class RealtimeResponseFailedStatusDetails : IJsonModel<RealtimeResponseFailedStatusDetails>
    {
        internal RealtimeResponseFailedStatusDetails()
        {
        }

        void IJsonModel<RealtimeResponseFailedStatusDetails>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RealtimeResponseFailedStatusDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RealtimeResponseFailedStatusDetails)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("error") != true)
            {
                writer.WritePropertyName("error"u8);
            }
#if NET6_0_OR_GREATER
            writer.WriteRawValue(Error);
#else
            using (JsonDocument document = JsonDocument.Parse(Error))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
        }

        RealtimeResponseFailedStatusDetails IJsonModel<RealtimeResponseFailedStatusDetails>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (RealtimeResponseFailedStatusDetails)JsonModelCreateCore(ref reader, options);

        protected override InternalRealtimeResponseStatusDetails JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RealtimeResponseFailedStatusDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RealtimeResponseFailedStatusDetails)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRealtimeResponseFailedStatusDetails(document.RootElement, options);
        }

        internal static RealtimeResponseFailedStatusDetails DeserializeRealtimeResponseFailedStatusDetails(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BinaryData error = default;
            ConversationStatus @type = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("error"u8))
                {
                    error = BinaryData.FromString(prop.Value.GetRawText());
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    @type = new ConversationStatus(prop.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new RealtimeResponseFailedStatusDetails(error, @type, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<RealtimeResponseFailedStatusDetails>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RealtimeResponseFailedStatusDetails>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(RealtimeResponseFailedStatusDetails)} does not support writing '{options.Format}' format.");
            }
        }

        RealtimeResponseFailedStatusDetails IPersistableModel<RealtimeResponseFailedStatusDetails>.Create(BinaryData data, ModelReaderWriterOptions options) => (RealtimeResponseFailedStatusDetails)PersistableModelCreateCore(data, options);

        protected override InternalRealtimeResponseStatusDetails PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RealtimeResponseFailedStatusDetails>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeRealtimeResponseFailedStatusDetails(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RealtimeResponseFailedStatusDetails)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<RealtimeResponseFailedStatusDetails>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(RealtimeResponseFailedStatusDetails realtimeResponseFailedStatusDetails)
        {
            return BinaryContent.Create(realtimeResponseFailedStatusDetails, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator RealtimeResponseFailedStatusDetails(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeRealtimeResponseFailedStatusDetails(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
