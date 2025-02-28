// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    public partial class ConversationTurnDetectionOptions : IJsonModel<ConversationTurnDetectionOptions>
    {
        internal ConversationTurnDetectionOptions()
        {
        }

        void IJsonModel<ConversationTurnDetectionOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationTurnDetectionOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationTurnDetectionOptions)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Kind.ToSerialString());
            }
            if (_additionalBinaryDataProperties != null)
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

        ConversationTurnDetectionOptions IJsonModel<ConversationTurnDetectionOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual ConversationTurnDetectionOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationTurnDetectionOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationTurnDetectionOptions)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationTurnDetectionOptions(document.RootElement, options);
        }

        BinaryData IPersistableModel<ConversationTurnDetectionOptions>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationTurnDetectionOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ConversationTurnDetectionOptions)} does not support writing '{options.Format}' format.");
            }
        }

        ConversationTurnDetectionOptions IPersistableModel<ConversationTurnDetectionOptions>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual ConversationTurnDetectionOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationTurnDetectionOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeConversationTurnDetectionOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ConversationTurnDetectionOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConversationTurnDetectionOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ConversationTurnDetectionOptions conversationTurnDetectionOptions)
        {
            if (conversationTurnDetectionOptions == null)
            {
                return null;
            }
            return BinaryContent.Create(conversationTurnDetectionOptions, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ConversationTurnDetectionOptions(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeConversationTurnDetectionOptions(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
