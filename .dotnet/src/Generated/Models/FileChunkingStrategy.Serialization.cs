// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI;

namespace OpenAI.VectorStores
{
    [PersistableModelProxy(typeof(InternalUnknownFileChunkingStrategyResponseParamProxy))]
    public abstract partial class FileChunkingStrategy : IJsonModel<FileChunkingStrategy>
    {
        internal FileChunkingStrategy()
        {
        }

        void IJsonModel<FileChunkingStrategy>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FileChunkingStrategy>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FileChunkingStrategy)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
            }
            writer.WriteStringValue(Type);
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

        FileChunkingStrategy IJsonModel<FileChunkingStrategy>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual FileChunkingStrategy JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FileChunkingStrategy>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FileChunkingStrategy)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFileChunkingStrategy(document.RootElement, options);
        }

        internal static FileChunkingStrategy DeserializeFileChunkingStrategy(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "static":
                        return StaticFileChunkingStrategy.DeserializeStaticFileChunkingStrategy(element, options);
                    case "other":
                        return InternalUnknownChunkingStrategy.DeserializeInternalUnknownChunkingStrategy(element, options);
                    case "auto":
                        return InternalAutoChunkingStrategy.DeserializeInternalAutoChunkingStrategy(element, options);
                }
            }
            return InternalUnknownFileChunkingStrategyResponseParamProxy.DeserializeInternalUnknownFileChunkingStrategyResponseParamProxy(element, options);
        }

        BinaryData IPersistableModel<FileChunkingStrategy>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FileChunkingStrategy>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(FileChunkingStrategy)} does not support writing '{options.Format}' format.");
            }
        }

        FileChunkingStrategy IPersistableModel<FileChunkingStrategy>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual FileChunkingStrategy PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FileChunkingStrategy>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeFileChunkingStrategy(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FileChunkingStrategy)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<FileChunkingStrategy>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(FileChunkingStrategy fileChunkingStrategy)
        {
            return BinaryContent.Create(fileChunkingStrategy, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator FileChunkingStrategy(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeFileChunkingStrategy(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
