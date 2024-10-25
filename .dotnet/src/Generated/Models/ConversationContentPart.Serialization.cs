// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    [PersistableModelProxy(typeof(UnknownRealtimeContentPart))]
    public abstract partial class ConversationContentPart : IJsonModel<ConversationContentPart>
    {
        internal ConversationContentPart()
        {
        }

        void IJsonModel<ConversationContentPart>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationContentPart>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationContentPart)} does not support writing '{format}' format.");
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

        ConversationContentPart IJsonModel<ConversationContentPart>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual ConversationContentPart JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationContentPart>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationContentPart)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationContentPart(document.RootElement, options);
        }

        internal static ConversationContentPart DeserializeConversationContentPart(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "input_text":
                        return InternalRealtimeRequestTextContentPart.DeserializeInternalRealtimeRequestTextContentPart(element, options);
                    case "input_audio":
                        return InternalRealtimeRequestAudioContentPart.DeserializeInternalRealtimeRequestAudioContentPart(element, options);
                    case "text":
                        return InternalRealtimeResponseTextContentPart.DeserializeInternalRealtimeResponseTextContentPart(element, options);
                    case "audio":
                        return InternalRealtimeResponseAudioContentPart.DeserializeInternalRealtimeResponseAudioContentPart(element, options);
                }
            }
            return UnknownRealtimeContentPart.DeserializeUnknownRealtimeContentPart(element, options);
        }

        BinaryData IPersistableModel<ConversationContentPart>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationContentPart>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ConversationContentPart)} does not support writing '{options.Format}' format.");
            }
        }

        ConversationContentPart IPersistableModel<ConversationContentPart>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual ConversationContentPart PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationContentPart>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeConversationContentPart(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ConversationContentPart)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConversationContentPart>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ConversationContentPart conversationContentPart)
        {
            return BinaryContent.Create(conversationContentPart, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ConversationContentPart(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeConversationContentPart(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
