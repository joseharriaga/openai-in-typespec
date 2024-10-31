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
    public partial class ConversationInputSpeechFinishedUpdate : IJsonModel<ConversationInputSpeechFinishedUpdate>
    {
        internal ConversationInputSpeechFinishedUpdate()
        {
        }

        void IJsonModel<ConversationInputSpeechFinishedUpdate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationInputSpeechFinishedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationInputSpeechFinishedUpdate)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("audio_end_ms") != true)
            {
                writer.WritePropertyName("audio_end_ms"u8);
                writer.WriteNumberValue(AudioEndMs);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("item_id") != true)
            {
                writer.WritePropertyName("item_id"u8);
                writer.WriteStringValue(ItemId);
            }
        }

        ConversationInputSpeechFinishedUpdate IJsonModel<ConversationInputSpeechFinishedUpdate>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (ConversationInputSpeechFinishedUpdate)JsonModelCreateCore(ref reader, options);

        protected override ConversationUpdate JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationInputSpeechFinishedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationInputSpeechFinishedUpdate)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationInputSpeechFinishedUpdate(document.RootElement, options);
        }

        internal static ConversationInputSpeechFinishedUpdate DeserializeConversationInputSpeechFinishedUpdate(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int audioEndMs = default;
            string itemId = default;
            string eventId = default;
            RealtimeConversation.ConversationUpdateKind kind = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("audio_end_ms"u8))
                {
                    audioEndMs = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("item_id"u8))
                {
                    itemId = prop.Value.GetString();
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
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new ConversationInputSpeechFinishedUpdate(audioEndMs, itemId, eventId, kind, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ConversationInputSpeechFinishedUpdate>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationInputSpeechFinishedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ConversationInputSpeechFinishedUpdate)} does not support writing '{options.Format}' format.");
            }
        }

        ConversationInputSpeechFinishedUpdate IPersistableModel<ConversationInputSpeechFinishedUpdate>.Create(BinaryData data, ModelReaderWriterOptions options) => (ConversationInputSpeechFinishedUpdate)PersistableModelCreateCore(data, options);

        protected override ConversationUpdate PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationInputSpeechFinishedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeConversationInputSpeechFinishedUpdate(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ConversationInputSpeechFinishedUpdate)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConversationInputSpeechFinishedUpdate>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ConversationInputSpeechFinishedUpdate conversationInputSpeechFinishedUpdate)
        {
            if (conversationInputSpeechFinishedUpdate == null)
            {
                return null;
            }
            return BinaryContent.Create(conversationInputSpeechFinishedUpdate, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ConversationInputSpeechFinishedUpdate(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeConversationInputSpeechFinishedUpdate(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
