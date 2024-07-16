// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.FineTuning
{
    internal partial class InternalCreateFineTuningJobRequestHyperparameters : IJsonModel<InternalCreateFineTuningJobRequestHyperparameters>
    {
        void IJsonModel<InternalCreateFineTuningJobRequestHyperparameters>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateFineTuningJobRequestHyperparameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateFineTuningJobRequestHyperparameters)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (!SerializedAdditionalRawData.ContainsKey("batch_size") && Optional.IsDefined(BatchSize))
            {
                writer.WritePropertyName("batch_size"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(BatchSize);
#else
                using (JsonDocument document = JsonDocument.Parse(BatchSize))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            if (!SerializedAdditionalRawData.ContainsKey("learning_rate_multiplier") && Optional.IsDefined(LearningRateMultiplier))
            {
                writer.WritePropertyName("learning_rate_multiplier"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(LearningRateMultiplier);
#else
                using (JsonDocument document = JsonDocument.Parse(LearningRateMultiplier))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            if (!SerializedAdditionalRawData.ContainsKey("n_epochs") && Optional.IsDefined(NEpochs))
            {
                writer.WritePropertyName("n_epochs"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(NEpochs);
#else
                using (JsonDocument document = JsonDocument.Parse(NEpochs))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
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

        InternalCreateFineTuningJobRequestHyperparameters IJsonModel<InternalCreateFineTuningJobRequestHyperparameters>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateFineTuningJobRequestHyperparameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateFineTuningJobRequestHyperparameters)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalCreateFineTuningJobRequestHyperparameters(document.RootElement, options);
        }

        internal static InternalCreateFineTuningJobRequestHyperparameters DeserializeInternalCreateFineTuningJobRequestHyperparameters(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BinaryData batchSize = default;
            BinaryData learningRateMultiplier = default;
            BinaryData nEpochs = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("batch_size"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    batchSize = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("learning_rate_multiplier"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    learningRateMultiplier = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("n_epochs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    nEpochs = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalCreateFineTuningJobRequestHyperparameters(batchSize, learningRateMultiplier, nEpochs, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalCreateFineTuningJobRequestHyperparameters>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateFineTuningJobRequestHyperparameters>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalCreateFineTuningJobRequestHyperparameters)} does not support writing '{options.Format}' format.");
            }
        }

        InternalCreateFineTuningJobRequestHyperparameters IPersistableModel<InternalCreateFineTuningJobRequestHyperparameters>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateFineTuningJobRequestHyperparameters>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalCreateFineTuningJobRequestHyperparameters(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalCreateFineTuningJobRequestHyperparameters)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalCreateFineTuningJobRequestHyperparameters>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static InternalCreateFineTuningJobRequestHyperparameters FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalCreateFineTuningJobRequestHyperparameters(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
