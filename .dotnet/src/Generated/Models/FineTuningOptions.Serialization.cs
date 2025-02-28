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
    internal partial class FineTuningOptions : IJsonModel<FineTuningOptions>
    {
        internal FineTuningOptions()
        {
        }

        void IJsonModel<FineTuningOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FineTuningOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FineTuningOptions)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("model") != true)
            {
                writer.WritePropertyName("model"u8);
                writer.WriteStringValue(Model.ToString());
            }
            if (_additionalBinaryDataProperties?.ContainsKey("training_file") != true)
            {
                writer.WritePropertyName("training_file"u8);
                writer.WriteStringValue(TrainingFile);
            }
            if (Optional.IsDefined(Hyperparameters) && _additionalBinaryDataProperties?.ContainsKey("hyperparameters") != true)
            {
                writer.WritePropertyName("hyperparameters"u8);
                writer.WriteObjectValue(Hyperparameters, options);
            }
            if (Optional.IsDefined(Suffix) && _additionalBinaryDataProperties?.ContainsKey("suffix") != true)
            {
                writer.WritePropertyName("suffix"u8);
                writer.WriteStringValue(Suffix);
            }
            if (Optional.IsDefined(ValidationFile) && _additionalBinaryDataProperties?.ContainsKey("validation_file") != true)
            {
                writer.WritePropertyName("validation_file"u8);
                writer.WriteStringValue(ValidationFile);
            }
            if (Optional.IsCollectionDefined(Integrations) && _additionalBinaryDataProperties?.ContainsKey("integrations") != true)
            {
                writer.WritePropertyName("integrations"u8);
                writer.WriteStartArray();
                foreach (FineTuningIntegration item in Integrations)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Seed) && _additionalBinaryDataProperties?.ContainsKey("seed") != true)
            {
                writer.WritePropertyName("seed"u8);
                writer.WriteNumberValue(Seed.Value);
            }
            if (Optional.IsDefined(Method) && _additionalBinaryDataProperties?.ContainsKey("method") != true)
            {
                writer.WritePropertyName("method"u8);
                writer.WriteObjectValue(Method, options);
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

        FineTuningOptions IJsonModel<FineTuningOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual FineTuningOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FineTuningOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FineTuningOptions)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFineTuningOptions(document.RootElement, options);
        }

        internal static FineTuningOptions DeserializeFineTuningOptions(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalCreateFineTuningJobRequestModel model = default;
            string trainingFile = default;
            HyperparameterOptions hyperparameters = default;
            string suffix = default;
            string validationFile = default;
            IList<FineTuningIntegration> integrations = default;
            int? seed = default;
            InternalTodoFineTuneMethod @method = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("model"u8))
                {
                    model = new InternalCreateFineTuningJobRequestModel(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("training_file"u8))
                {
                    trainingFile = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("hyperparameters"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hyperparameters = HyperparameterOptions.DeserializeHyperparameterOptions(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("suffix"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        suffix = null;
                        continue;
                    }
                    suffix = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("validation_file"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        validationFile = null;
                        continue;
                    }
                    validationFile = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("integrations"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FineTuningIntegration> array = new List<FineTuningIntegration>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(FineTuningIntegration.DeserializeFineTuningIntegration(item, options));
                    }
                    integrations = array;
                    continue;
                }
                if (prop.NameEquals("seed"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        seed = null;
                        continue;
                    }
                    seed = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("method"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    @method = InternalTodoFineTuneMethod.DeserializeInternalTodoFineTuneMethod(prop.Value, options);
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new FineTuningOptions(
                model,
                trainingFile,
                hyperparameters,
                suffix,
                validationFile,
                integrations ?? new ChangeTrackingList<FineTuningIntegration>(),
                seed,
                @method,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<FineTuningOptions>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FineTuningOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(FineTuningOptions)} does not support writing '{options.Format}' format.");
            }
        }

        FineTuningOptions IPersistableModel<FineTuningOptions>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual FineTuningOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FineTuningOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeFineTuningOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FineTuningOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<FineTuningOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(FineTuningOptions fineTuningOptions)
        {
            if (fineTuningOptions == null)
            {
                return null;
            }
            return BinaryContent.Create(fineTuningOptions, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator FineTuningOptions(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeFineTuningOptions(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
