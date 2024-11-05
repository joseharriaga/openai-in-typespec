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
    public partial class ConversationSessionConfiguredUpdate : IJsonModel<ConversationSessionConfiguredUpdate>
    {
        internal ConversationSessionConfiguredUpdate()
        {
        }

        void IJsonModel<ConversationSessionConfiguredUpdate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationSessionConfiguredUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationSessionConfiguredUpdate)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("session") != true)
            {
                writer.WritePropertyName("session"u8);
                writer.WriteObjectValue<InternalRealtimeResponseSession>(_internalSession, options);
            }
        }

        ConversationSessionConfiguredUpdate IJsonModel<ConversationSessionConfiguredUpdate>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (ConversationSessionConfiguredUpdate)JsonModelCreateCore(ref reader, options);

        protected override ConversationUpdate JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationSessionConfiguredUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationSessionConfiguredUpdate)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationSessionConfiguredUpdate(document.RootElement, options);
        }

        internal static ConversationSessionConfiguredUpdate DeserializeConversationSessionConfiguredUpdate(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalRealtimeResponseSession internalSession = default;
            string eventId = default;
            RealtimeConversation.ConversationUpdateKind kind = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("session"u8))
                {
                    internalSession = InternalRealtimeResponseSession.DeserializeInternalRealtimeResponseSession(prop.Value, options);
                    continue;
                }
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
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new ConversationSessionConfiguredUpdate(internalSession, eventId, kind, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ConversationSessionConfiguredUpdate>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationSessionConfiguredUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ConversationSessionConfiguredUpdate)} does not support writing '{options.Format}' format.");
            }
        }

        ConversationSessionConfiguredUpdate IPersistableModel<ConversationSessionConfiguredUpdate>.Create(BinaryData data, ModelReaderWriterOptions options) => (ConversationSessionConfiguredUpdate)PersistableModelCreateCore(data, options);

        protected override ConversationUpdate PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationSessionConfiguredUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeConversationSessionConfiguredUpdate(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ConversationSessionConfiguredUpdate)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConversationSessionConfiguredUpdate>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ConversationSessionConfiguredUpdate conversationSessionConfiguredUpdate)
        {
            if (conversationSessionConfiguredUpdate == null)
            {
                return null;
            }
            return BinaryContent.Create(conversationSessionConfiguredUpdate, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ConversationSessionConfiguredUpdate(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeConversationSessionConfiguredUpdate(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
