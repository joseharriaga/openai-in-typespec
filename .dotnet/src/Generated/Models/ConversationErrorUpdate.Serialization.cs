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
    public partial class ConversationErrorUpdate : IJsonModel<ConversationErrorUpdate>
    {
        internal ConversationErrorUpdate()
        {
        }

        void IJsonModel<ConversationErrorUpdate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationErrorUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationErrorUpdate)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("error") != true)
            {
                writer.WritePropertyName("error"u8);
                writer.WriteObjectValue<InternalRealtimeResponseError>(_error, options);
            }
        }

        ConversationErrorUpdate IJsonModel<ConversationErrorUpdate>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (ConversationErrorUpdate)JsonModelCreateCore(ref reader, options);

        protected override ConversationUpdate JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationErrorUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationErrorUpdate)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationErrorUpdate(document.RootElement, options);
        }

        internal static ConversationErrorUpdate DeserializeConversationErrorUpdate(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalRealtimeResponseError error = default;
            string eventId = default;
            RealtimeConversation.ConversationUpdateKind kind = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("error"u8))
                {
                    error = InternalRealtimeResponseError.DeserializeInternalRealtimeResponseError(prop.Value, options);
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
            return new ConversationErrorUpdate(error, eventId, kind, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ConversationErrorUpdate>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationErrorUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ConversationErrorUpdate)} does not support writing '{options.Format}' format.");
            }
        }

        ConversationErrorUpdate IPersistableModel<ConversationErrorUpdate>.Create(BinaryData data, ModelReaderWriterOptions options) => (ConversationErrorUpdate)PersistableModelCreateCore(data, options);

        protected override ConversationUpdate PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationErrorUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeConversationErrorUpdate(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ConversationErrorUpdate)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConversationErrorUpdate>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ConversationErrorUpdate conversationErrorUpdate)
        {
            return BinaryContent.Create(conversationErrorUpdate, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ConversationErrorUpdate(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeConversationErrorUpdate(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
