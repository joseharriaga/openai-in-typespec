// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.FineTuning
{
    public readonly partial struct FineTuningHyperparameters : IJsonModel<FineTuningHyperparameters>, IJsonModel<object>
    {
        public FineTuningHyperparameters()
        {
        }

        void IJsonModel<FineTuningHyperparameters>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        private void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FineTuningHyperparameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FineTuningHyperparameters)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("n_epochs") != true)
            {
                writer.WritePropertyName("n_epochs"u8);
#if NET6_0_OR_GREATER
                writer.WriteRawValue(_CycleCount);
#else
                using (JsonDocument document = JsonDocument.Parse(_CycleCount))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            if (_additionalBinaryDataProperties?.ContainsKey("batch_size") != true)
            {
                writer.WritePropertyName("batch_size"u8);
#if NET6_0_OR_GREATER
                writer.WriteRawValue(_BatchSize);
#else
                using (JsonDocument document = JsonDocument.Parse(_BatchSize))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            if (_additionalBinaryDataProperties?.ContainsKey("learning_rate_multiplier") != true)
            {
                writer.WritePropertyName("learning_rate_multiplier"u8);
#if NET6_0_OR_GREATER
                writer.WriteRawValue(_LearningRateMultiplier);
#else
                using (JsonDocument document = JsonDocument.Parse(_LearningRateMultiplier))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            if (true && _additionalBinaryDataProperties != null)
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

        FineTuningHyperparameters IJsonModel<FineTuningHyperparameters>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        private FineTuningHyperparameters JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FineTuningHyperparameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FineTuningHyperparameters)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFineTuningHyperparameters(document.RootElement, options);
        }

        internal static FineTuningHyperparameters DeserializeFineTuningHyperparameters(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return default;
            }
            BinaryData cycleCount = default;
            BinaryData batchSize = default;
            BinaryData learningRateMultiplier = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("n_epochs"u8))
                {
                    cycleCount = BinaryData.FromString(prop.Value.GetRawText());
                    continue;
                }
                if (prop.NameEquals("batch_size"u8))
                {
                    batchSize = BinaryData.FromString(prop.Value.GetRawText());
                    continue;
                }
                if (prop.NameEquals("learning_rate_multiplier"u8))
                {
                    learningRateMultiplier = BinaryData.FromString(prop.Value.GetRawText());
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new FineTuningHyperparameters(cycleCount, batchSize, learningRateMultiplier, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<FineTuningHyperparameters>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        private BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FineTuningHyperparameters>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(FineTuningHyperparameters)} does not support writing '{options.Format}' format.");
            }
        }

        FineTuningHyperparameters IPersistableModel<FineTuningHyperparameters>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        private FineTuningHyperparameters PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FineTuningHyperparameters>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeFineTuningHyperparameters(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FineTuningHyperparameters)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<FineTuningHyperparameters>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(FineTuningHyperparameters fineTuningHyperparameters)
        {
            return BinaryContent.Create(fineTuningHyperparameters, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator FineTuningHyperparameters(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeFineTuningHyperparameters(document.RootElement, ModelSerializationExtensions.WireOptions);
        }

        void IJsonModel<object>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<FineTuningHyperparameters>)this).Write(writer, options);

        object IJsonModel<object>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<FineTuningHyperparameters>)this).Create(ref reader, options);

        BinaryData IPersistableModel<object>.Write(ModelReaderWriterOptions options) => ((IPersistableModel<FineTuningHyperparameters>)this).Write(options);

        string IPersistableModel<object>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<FineTuningHyperparameters>)this).GetFormatFromOptions(options);

        object IPersistableModel<object>.Create(BinaryData data, ModelReaderWriterOptions options) => ((IPersistableModel<FineTuningHyperparameters>)this).Create(data, options);
    }
}
