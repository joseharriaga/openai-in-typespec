// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.VectorStores
{
    internal partial class InternalAutoChunkingStrategy : IJsonModel<InternalAutoChunkingStrategy>
    {
        void IJsonModel<InternalAutoChunkingStrategy>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAutoChunkingStrategy>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAutoChunkingStrategy)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (!SerializedAdditionalRawData.ContainsKey("type"))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Type);
            }
            foreach (var item in SerializedAdditionalRawData)
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
            writer.WriteEndObject();
        }

        InternalAutoChunkingStrategy IJsonModel<InternalAutoChunkingStrategy>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAutoChunkingStrategy>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAutoChunkingStrategy)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalAutoChunkingStrategy(document.RootElement, options);
        }

        internal static InternalAutoChunkingStrategy DeserializeInternalAutoChunkingStrategy(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string type = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalAutoChunkingStrategy(type, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalAutoChunkingStrategy>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAutoChunkingStrategy>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalAutoChunkingStrategy)} does not support writing '{options.Format}' format.");
            }
        }

        InternalAutoChunkingStrategy IPersistableModel<InternalAutoChunkingStrategy>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAutoChunkingStrategy>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalAutoChunkingStrategy(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalAutoChunkingStrategy)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalAutoChunkingStrategy>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static new InternalAutoChunkingStrategy FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalAutoChunkingStrategy(document.RootElement);
        }

        internal override BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
