// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI.Models;

namespace OpenAI.FineTuning
{
    public partial class FineTuningOptions : IJsonModel<FineTuningOptions>
    {
        void IJsonModel<FineTuningOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FineTuningOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FineTuningOptions)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("model") != true)
            {
                writer.WritePropertyName("model"u8);
                writer.WriteStringValue(Model.ToString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("training_file") != true)
            {
                writer.WritePropertyName("training_file"u8);
                writer.WriteStringValue(TrainingFile);
            }
            if (SerializedAdditionalRawData?.ContainsKey("hyperparameters") != true && Optional.IsDefined(Hyperparameters))
            {
                writer.WritePropertyName("hyperparameters"u8);
                writer.WriteObjectValue<HyperparameterOptions>(Hyperparameters, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("suffix") != true && Optional.IsDefined(Suffix))
            {
                if (Suffix != null)
                {
                    writer.WritePropertyName("suffix"u8);
                    writer.WriteStringValue(Suffix);
                }
                else
                {
                    writer.WriteNull("suffix");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("validation_file") != true && Optional.IsDefined(ValidationFile))
            {
                if (ValidationFile != null)
                {
                    writer.WritePropertyName("validation_file"u8);
                    writer.WriteStringValue(ValidationFile);
                }
                else
                {
                    writer.WriteNull("validation_file");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("integrations") != true && Optional.IsCollectionDefined(Integrations))
            {
                if (Integrations != null)
                {
                    writer.WritePropertyName("integrations"u8);
                    writer.WriteStartArray();
                    foreach (var item in Integrations)
                    {
                        writer.WriteObjectValue<FineTuningIntegration>(item, options);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("integrations");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("seed") != true && Optional.IsDefined(Seed))
            {
                if (Seed != null)
                {
                    writer.WritePropertyName("seed"u8);
                    writer.WriteNumberValue(Seed.Value);
                }
                else
                {
                    writer.WriteNull("seed");
                }
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

        FineTuningOptions IJsonModel<FineTuningOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FineTuningOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FineTuningOptions)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFineTuningOptions(document.RootElement, options);
        }

        internal static FineTuningOptions DeserializeFineTuningOptions(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            CreateFineTuningJobRequestModel model = default;
            string trainingFile = default;
            HyperparameterOptions hyperparameters = default;
            string suffix = default;
            string validationFile = default;
            IList<FineTuningIntegration> integrations = default;
            int? seed = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("model"u8))
                {
                    model = new CreateFineTuningJobRequestModel(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("training_file"u8))
                {
                    trainingFile = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("hyperparameters"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hyperparameters = HyperparameterOptions.DeserializeHyperparameterOptions(property.Value, options);
                    continue;
                }
                if (property.NameEquals("suffix"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        suffix = null;
                        continue;
                    }
                    suffix = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("validation_file"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        validationFile = null;
                        continue;
                    }
                    validationFile = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("integrations"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FineTuningIntegration> array = new List<FineTuningIntegration>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FineTuningIntegration.DeserializeFineTuningIntegration(item, options));
                    }
                    integrations = array;
                    continue;
                }
                if (property.NameEquals("seed"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        seed = null;
                        continue;
                    }
                    seed = property.Value.GetInt32();
                    continue;
                }
                if (true)
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new FineTuningOptions(
                model,
                trainingFile,
                hyperparameters,
                suffix,
                validationFile,
                integrations ?? new ChangeTrackingList<FineTuningIntegration>(),
                seed,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<FineTuningOptions>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FineTuningOptions>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(FineTuningOptions)} does not support writing '{options.Format}' format.");
            }
        }

        FineTuningOptions IPersistableModel<FineTuningOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FineTuningOptions>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeFineTuningOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FineTuningOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<FineTuningOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static FineTuningOptions FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeFineTuningOptions(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
