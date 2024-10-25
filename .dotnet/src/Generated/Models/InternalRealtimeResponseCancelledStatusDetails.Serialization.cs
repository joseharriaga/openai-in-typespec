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
    internal partial class InternalRealtimeResponseCancelledStatusDetails : IJsonModel<InternalRealtimeResponseCancelledStatusDetails>
    {
        internal InternalRealtimeResponseCancelledStatusDetails()
        {
        }

        void IJsonModel<InternalRealtimeResponseCancelledStatusDetails>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseCancelledStatusDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeResponseCancelledStatusDetails)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("reason") != true)
            {
                writer.WritePropertyName("reason"u8);
            }
            writer.WriteStringValue(Reason.ToString());
        }

        InternalRealtimeResponseCancelledStatusDetails IJsonModel<InternalRealtimeResponseCancelledStatusDetails>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRealtimeResponseCancelledStatusDetails)JsonModelCreateCore(ref reader, options);

        protected override InternalRealtimeResponseStatusDetails JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseCancelledStatusDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeResponseCancelledStatusDetails)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeResponseCancelledStatusDetails(document.RootElement, options);
        }

        internal static InternalRealtimeResponseCancelledStatusDetails DeserializeInternalRealtimeResponseCancelledStatusDetails(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalRealtimeResponseCancelledStatusDetailsReason reason = default;
            ConversationStatus @type = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("reason"u8))
                {
                    reason = new InternalRealtimeResponseCancelledStatusDetailsReason(prop.Value.GetString());
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
            return new InternalRealtimeResponseCancelledStatusDetails(reason, @type, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRealtimeResponseCancelledStatusDetails>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseCancelledStatusDetails>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeResponseCancelledStatusDetails)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeResponseCancelledStatusDetails IPersistableModel<InternalRealtimeResponseCancelledStatusDetails>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRealtimeResponseCancelledStatusDetails)PersistableModelCreateCore(data, options);

        protected override InternalRealtimeResponseStatusDetails PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseCancelledStatusDetails>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeResponseCancelledStatusDetails(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeResponseCancelledStatusDetails)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeResponseCancelledStatusDetails>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRealtimeResponseCancelledStatusDetails internalRealtimeResponseCancelledStatusDetails)
        {
            return BinaryContent.Create(internalRealtimeResponseCancelledStatusDetails, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRealtimeResponseCancelledStatusDetails(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeResponseCancelledStatusDetails(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
