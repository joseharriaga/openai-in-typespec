// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    [PersistableModelProxy(typeof(UnknownRealtimeResponseItem))]
    internal abstract partial class InternalRealtimeResponseItem : IJsonModel<InternalRealtimeResponseItem>
    {
        internal InternalRealtimeResponseItem()
        {
        }

        void IJsonModel<InternalRealtimeResponseItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseItem>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeResponseItem)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("object") != true)
            {
                writer.WritePropertyName("object"u8);
            }
            writer.WriteStringValue(Object.ToString());
            if (_additionalBinaryDataProperties?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
            }
            writer.WriteStringValue(Type.ToString());
            if (_additionalBinaryDataProperties?.ContainsKey("id") != true)
            {
                if (Id != null)
                {
                    writer.WritePropertyName("id"u8);
                    writer.WriteStringValue(Id);
                }
                else
                {
                    writer.WriteNull("id"u8);
                }
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

        InternalRealtimeResponseItem IJsonModel<InternalRealtimeResponseItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalRealtimeResponseItem JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseItem>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalRealtimeResponseItem)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalRealtimeResponseItem(document.RootElement, options);
        }

        internal static InternalRealtimeResponseItem DeserializeInternalRealtimeResponseItem(JsonElement element, ModelReaderWriterOptions options)
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
                        return InternalRealtimeResponseMessageItem.DeserializeInternalRealtimeResponseMessageItem(element, options);
                    case "function_call":
                        return InternalRealtimeResponseFunctionCallItem.DeserializeInternalRealtimeResponseFunctionCallItem(element, options);
                    case "function_call_output":
                        return InternalRealtimeResponseFunctionCallOutputItem.DeserializeInternalRealtimeResponseFunctionCallOutputItem(element, options);
                }
            }
            return UnknownRealtimeResponseItem.DeserializeUnknownRealtimeResponseItem(element, options);
        }

        BinaryData IPersistableModel<InternalRealtimeResponseItem>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseItem>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeResponseItem)} does not support writing '{options.Format}' format.");
            }
        }

        InternalRealtimeResponseItem IPersistableModel<InternalRealtimeResponseItem>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalRealtimeResponseItem PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalRealtimeResponseItem>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalRealtimeResponseItem(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalRealtimeResponseItem)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalRealtimeResponseItem>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalRealtimeResponseItem internalRealtimeResponseItem)
        {
            return BinaryContent.Create(internalRealtimeResponseItem, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalRealtimeResponseItem(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalRealtimeResponseItem(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
