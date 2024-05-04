// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class FineTuningJobCheckpointMetrics : IJsonModel<FineTuningJobCheckpointMetrics>
    {
        void IJsonModel<FineTuningJobCheckpointMetrics>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FineTuningJobCheckpointMetrics>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FineTuningJobCheckpointMetrics)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Step))
            {
                writer.WritePropertyName("step"u8);
                writer.WriteNumberValue(Step.Value);
            }
            if (Optional.IsDefined(TrainLoss))
            {
                writer.WritePropertyName("train_loss"u8);
                writer.WriteNumberValue(TrainLoss.Value);
            }
            if (Optional.IsDefined(TrainMeanTokenAccuracy))
            {
                writer.WritePropertyName("train_mean_token_accuracy"u8);
                writer.WriteNumberValue(TrainMeanTokenAccuracy.Value);
            }
            if (Optional.IsDefined(ValidLoss))
            {
                writer.WritePropertyName("valid_loss"u8);
                writer.WriteNumberValue(ValidLoss.Value);
            }
            if (Optional.IsDefined(ValidMeanTokenAccuracy))
            {
                writer.WritePropertyName("valid_mean_token_accuracy"u8);
                writer.WriteNumberValue(ValidMeanTokenAccuracy.Value);
            }
            if (Optional.IsDefined(FullValidLoss))
            {
                writer.WritePropertyName("full_valid_loss"u8);
                writer.WriteNumberValue(FullValidLoss.Value);
            }
            if (Optional.IsDefined(FullValidMeanTokenAccuracy))
            {
                writer.WritePropertyName("full_valid_mean_token_accuracy"u8);
                writer.WriteNumberValue(FullValidMeanTokenAccuracy.Value);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
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

        FineTuningJobCheckpointMetrics IJsonModel<FineTuningJobCheckpointMetrics>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FineTuningJobCheckpointMetrics>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FineTuningJobCheckpointMetrics)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFineTuningJobCheckpointMetrics(document.RootElement, options);
        }

        internal static FineTuningJobCheckpointMetrics DeserializeFineTuningJobCheckpointMetrics(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            float? step = default;
            float? trainLoss = default;
            float? trainMeanTokenAccuracy = default;
            float? validLoss = default;
            float? validMeanTokenAccuracy = default;
            float? fullValidLoss = default;
            float? fullValidMeanTokenAccuracy = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("step"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    step = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("train_loss"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    trainLoss = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("train_mean_token_accuracy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    trainMeanTokenAccuracy = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("valid_loss"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    validLoss = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("valid_mean_token_accuracy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    validMeanTokenAccuracy = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("full_valid_loss"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    fullValidLoss = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("full_valid_mean_token_accuracy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    fullValidMeanTokenAccuracy = property.Value.GetSingle();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new FineTuningJobCheckpointMetrics(
                step,
                trainLoss,
                trainMeanTokenAccuracy,
                validLoss,
                validMeanTokenAccuracy,
                fullValidLoss,
                fullValidMeanTokenAccuracy,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<FineTuningJobCheckpointMetrics>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FineTuningJobCheckpointMetrics>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(FineTuningJobCheckpointMetrics)} does not support writing '{options.Format}' format.");
            }
        }

        FineTuningJobCheckpointMetrics IPersistableModel<FineTuningJobCheckpointMetrics>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FineTuningJobCheckpointMetrics>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeFineTuningJobCheckpointMetrics(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FineTuningJobCheckpointMetrics)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<FineTuningJobCheckpointMetrics>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static FineTuningJobCheckpointMetrics FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeFineTuningJobCheckpointMetrics(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
