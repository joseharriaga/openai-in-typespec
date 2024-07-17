// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.VectorStores
{
    [PersistableModelProxy(typeof(InternalUnknownFileChunkingStrategyRequestParamProxy))]
    internal partial class InternalFileChunkingStrategyRequestParam : IJsonModel<InternalFileChunkingStrategyRequestParam>
    {
        void IJsonModel<InternalFileChunkingStrategyRequestParam>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalFileChunkingStrategyRequestParam>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalFileChunkingStrategyRequestParam)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Type);
            }
            foreach (var item in SerializedAdditionalRawData ?? new System.Collections.Generic.Dictionary<string, BinaryData>())
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

        InternalFileChunkingStrategyRequestParam IJsonModel<InternalFileChunkingStrategyRequestParam>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalFileChunkingStrategyRequestParam>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalFileChunkingStrategyRequestParam)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalFileChunkingStrategyRequestParam(document.RootElement, options);
        }

        internal static InternalFileChunkingStrategyRequestParam DeserializeInternalFileChunkingStrategyRequestParam(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "auto": return InternalAutoChunkingStrategyRequestParam.DeserializeInternalAutoChunkingStrategyRequestParam(element, options);
                    case "static": return InternalStaticChunkingStrategyRequestParam.DeserializeInternalStaticChunkingStrategyRequestParam(element, options);
                }
            }
            return InternalUnknownFileChunkingStrategyRequestParamProxy.DeserializeInternalUnknownFileChunkingStrategyRequestParamProxy(element, options);
        }

        BinaryData IPersistableModel<InternalFileChunkingStrategyRequestParam>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalFileChunkingStrategyRequestParam>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalFileChunkingStrategyRequestParam)} does not support writing '{options.Format}' format.");
            }
        }

        InternalFileChunkingStrategyRequestParam IPersistableModel<InternalFileChunkingStrategyRequestParam>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalFileChunkingStrategyRequestParam>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalFileChunkingStrategyRequestParam(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalFileChunkingStrategyRequestParam)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalFileChunkingStrategyRequestParam>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static InternalFileChunkingStrategyRequestParam FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalFileChunkingStrategyRequestParam(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
