// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    [PersistableModelProxy(typeof(UnknownRealtimeRequestItem))]
    public abstract partial class ConversationItem : IJsonModel<ConversationItem>
    {
        internal ConversationItem()
        {
        }

        void IJsonModel<ConversationItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationItem>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationItem)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
            }
            writer.WriteStringValue(Type.ToString());
            if (Optional.IsDefined(Id) && _additionalBinaryDataProperties?.ContainsKey("id") != true)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
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

        ConversationItem IJsonModel<ConversationItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual ConversationItem JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationItem>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConversationItem)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationItem(document.RootElement, options);
        }

        internal static ConversationItem DeserializeConversationItem(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "message":
                        return InternalRealtimeRequestMessageItem.DeserializeInternalRealtimeRequestMessageItem(element, options);
                    case "function_call":
                        return InternalRealtimeRequestFunctionCallItem.DeserializeInternalRealtimeRequestFunctionCallItem(element, options);
                    case "function_call_output":
                        return InternalRealtimeRequestFunctionCallOutputItem.DeserializeInternalRealtimeRequestFunctionCallOutputItem(element, options);
                }
            }
            return UnknownRealtimeRequestItem.DeserializeUnknownRealtimeRequestItem(element, options);
        }

        BinaryData IPersistableModel<ConversationItem>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationItem>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ConversationItem)} does not support writing '{options.Format}' format.");
            }
        }

        ConversationItem IPersistableModel<ConversationItem>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual ConversationItem PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConversationItem>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeConversationItem(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ConversationItem)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ConversationItem>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ConversationItem conversationItem)
        {
            return BinaryContent.Create(conversationItem, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ConversationItem(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeConversationItem(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
