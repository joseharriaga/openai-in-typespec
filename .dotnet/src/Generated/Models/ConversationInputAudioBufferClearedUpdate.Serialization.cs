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
    public partial class ConversationInputAudioBufferClearedUpdate : IJsonModel<ConversationInputAudioBufferClearedUpdate>
    {
        internal ConversationInputAudioBufferClearedUpdate()
        {
        }

        void IJsonModel<ConversationInputAudioBufferClearedUpdate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationInputAudioBufferClearedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationInputAudioBufferClearedUpdate)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
        }

        ConversationInputAudioBufferClearedUpdate IJsonModel<ConversationInputAudioBufferClearedUpdate>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (ConversationInputAudioBufferClearedUpdate)JsonModelCreateCore(ref reader, options);

        protected override ConversationUpdate JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationInputAudioBufferClearedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationInputAudioBufferClearedUpdate)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationInputAudioBufferClearedUpdate(document.RootElement, options);
        }

        internal static ConversationInputAudioBufferClearedUpdate DeserializeConversationInputAudioBufferClearedUpdate(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string eventId = default;
            RealtimeConversation.ConversationUpdateKind kind = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
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
            return new ConversationInputAudioBufferClearedUpdate(eventId, kind, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ConversationInputAudioBufferClearedUpdate>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationInputAudioBufferClearedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ConversationInputAudioBufferClearedUpdate)} does not support writing '{options.Format}' format.");
            }
        }

        ConversationInputAudioBufferClearedUpdate IPersistableModel<ConversationInputAudioBufferClearedUpdate>.Create(BinaryData data, ModelReaderWriterOptions options) => (ConversationInputAudioBufferClearedUpdate)PersistableModelCreateCore(data, options);

        protected override ConversationUpdate PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationInputAudioBufferClearedUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeConversationInputAudioBufferClearedUpdate(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ConversationInputAudioBufferClearedUpdate)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConversationInputAudioBufferClearedUpdate>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ConversationInputAudioBufferClearedUpdate conversationInputAudioBufferClearedUpdate)
        {
            if (conversationInputAudioBufferClearedUpdate == null)
            {
                return null;
            }
            return BinaryContent.Create(conversationInputAudioBufferClearedUpdate, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ConversationInputAudioBufferClearedUpdate(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeConversationInputAudioBufferClearedUpdate(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
