// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Chat
{
    internal partial class InternalChatCompletionMessageToolCallChunkFunction : IJsonModel<InternalChatCompletionMessageToolCallChunkFunction>
    {
        void IJsonModel<InternalChatCompletionMessageToolCallChunkFunction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalChatCompletionMessageToolCallChunkFunction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalChatCompletionMessageToolCallChunkFunction)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Name) && _additionalBinaryDataProperties?.ContainsKey("name") != true)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Arguments) && _additionalBinaryDataProperties?.ContainsKey("arguments") != true)
            {
                writer.WritePropertyName("arguments"u8);
                this.SerializeArgumentsValue(writer, options);
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

        InternalChatCompletionMessageToolCallChunkFunction IJsonModel<InternalChatCompletionMessageToolCallChunkFunction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalChatCompletionMessageToolCallChunkFunction JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalChatCompletionMessageToolCallChunkFunction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalChatCompletionMessageToolCallChunkFunction)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalChatCompletionMessageToolCallChunkFunction(document.RootElement, options);
        }

        internal static InternalChatCompletionMessageToolCallChunkFunction DeserializeInternalChatCompletionMessageToolCallChunkFunction(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            BinaryData arguments = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("arguments"u8))
                {
                    DeserializeArgumentsValue(prop, ref arguments);
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new InternalChatCompletionMessageToolCallChunkFunction(name, arguments, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalChatCompletionMessageToolCallChunkFunction>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalChatCompletionMessageToolCallChunkFunction>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalChatCompletionMessageToolCallChunkFunction)} does not support writing '{options.Format}' format.");
            }
        }

        InternalChatCompletionMessageToolCallChunkFunction IPersistableModel<InternalChatCompletionMessageToolCallChunkFunction>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalChatCompletionMessageToolCallChunkFunction PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalChatCompletionMessageToolCallChunkFunction>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalChatCompletionMessageToolCallChunkFunction(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalChatCompletionMessageToolCallChunkFunction)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalChatCompletionMessageToolCallChunkFunction>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalChatCompletionMessageToolCallChunkFunction internalChatCompletionMessageToolCallChunkFunction)
        {
            if (internalChatCompletionMessageToolCallChunkFunction == null)
            {
                return null;
            }
            return BinaryContent.Create(internalChatCompletionMessageToolCallChunkFunction, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalChatCompletionMessageToolCallChunkFunction(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalChatCompletionMessageToolCallChunkFunction(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
