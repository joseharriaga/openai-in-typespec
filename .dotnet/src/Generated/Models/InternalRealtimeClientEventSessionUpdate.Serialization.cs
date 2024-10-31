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
    internal partial class InternalRealtimeClientEventSessionUpdate : IJsonModel<InternalRealtimeClientEventSessionUpdate>
    {
        internal InternalRealtimeClientEventSessionUpdate()
        {
        }

        void IJsonModel<InternalRealtimeClientEventSessionUpdate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeClientEventSessionUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeClientEventSessionUpdate)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(EventId) && _additionalBinaryDataProperties?.ContainsKey("event_id") != true)
            {
                writer.WritePropertyName("event_id"u8);
                writer.WriteStringValue(EventId);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("session") != true)
            {
                writer.WritePropertyName("session"u8);
                writer.WriteObjectValue(Session, options);
            }
        }

        InternalRealtimeClientEventSessionUpdate IJsonModel<InternalRealtimeClientEventSessionUpdate>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalRealtimeClientEventSessionUpdate)JsonModelCreateCore(ref reader, options);

        protected override InternalRealtimeClientEvent JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeClientEventSessionUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeClientEventSessionUpdate)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeClientEventSessionUpdate(document.RootElement, options);
        }

        internal static InternalRealtimeClientEventSessionUpdate DeserializeInternalRealtimeClientEventSessionUpdate(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string eventId = default;
            ConversationSessionOptions session = default;
            InternalRealtimeClientEventType kind = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("event_id"u8))
                {
                    eventId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("session"u8))
                {
                    session = ConversationSessionOptions.DeserializeConversationSessionOptions(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    kind = new InternalRealtimeClientEventType(prop.Value.GetString());
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalRealtimeClientEventSessionUpdate(eventId, session, kind, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalRealtimeClientEventSessionUpdate>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeClientEventSessionUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeClientEventSessionUpdate)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeClientEventSessionUpdate IPersistableModel<InternalRealtimeClientEventSessionUpdate>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalRealtimeClientEventSessionUpdate)PersistableModelCreateCore(data, options);

        protected override InternalRealtimeClientEvent PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeClientEventSessionUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeClientEventSessionUpdate(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeClientEventSessionUpdate)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeClientEventSessionUpdate>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRealtimeClientEventSessionUpdate internalRealtimeClientEventSessionUpdate)
        {
            if (internalRealtimeClientEventSessionUpdate == null)
            {
                return null;
            }
            return BinaryContent.Create(internalRealtimeClientEventSessionUpdate, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRealtimeClientEventSessionUpdate(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeClientEventSessionUpdate(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
