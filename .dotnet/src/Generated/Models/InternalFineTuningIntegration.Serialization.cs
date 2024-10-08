// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.FineTuning
{
    [PersistableModelProxy(typeof(UnknownFineTuningIntegration))]
    internal partial class InternalFineTuningIntegration : IJsonModel<InternalFineTuningIntegration>
    {
        void IJsonModel<InternalFineTuningIntegration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalFineTuningIntegration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalFineTuningIntegration)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Type);
            }
            if (SerializedAdditionalRawData != null)
            {
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
            }
            writer.WriteEndObject();
        }

        InternalFineTuningIntegration IJsonModel<InternalFineTuningIntegration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalFineTuningIntegration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalFineTuningIntegration)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalFineTuningIntegration(document.RootElement, options);
        }

        internal static InternalFineTuningIntegration DeserializeInternalFineTuningIntegration(JsonElement element, ModelReaderWriterOptions options = null)
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
                    case "wandb": return InternalFineTuningIntegrationWandb.DeserializeInternalFineTuningIntegrationWandb(element, options);
                }
            }
            return UnknownFineTuningIntegration.DeserializeUnknownFineTuningIntegration(element, options);
        }

        BinaryData IPersistableModel<InternalFineTuningIntegration>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalFineTuningIntegration>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalFineTuningIntegration)} does not support writing '{options.Format}' format.");
            }
        }

        InternalFineTuningIntegration IPersistableModel<InternalFineTuningIntegration>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalFineTuningIntegration>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalFineTuningIntegration(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalFineTuningIntegration)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalFineTuningIntegration>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static InternalFineTuningIntegration FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalFineTuningIntegration(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
