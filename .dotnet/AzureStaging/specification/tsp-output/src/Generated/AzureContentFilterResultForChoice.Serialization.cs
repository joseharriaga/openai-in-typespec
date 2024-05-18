// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI
{
    public partial class AzureContentFilterResultForChoice : IJsonModel<AzureContentFilterResultForChoice>
    {
        void IJsonModel<AzureContentFilterResultForChoice>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureContentFilterResultForChoice>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AzureContentFilterResultForChoice)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Sexual))
            {
                writer.WritePropertyName("sexual"u8);
                writer.WriteObjectValue(Sexual, options);
            }
            if (Optional.IsDefined(Violence))
            {
                writer.WritePropertyName("violence"u8);
                writer.WriteObjectValue(Violence, options);
            }
            if (Optional.IsDefined(Hate))
            {
                writer.WritePropertyName("hate"u8);
                writer.WriteObjectValue(Hate, options);
            }
            if (Optional.IsDefined(SelfHarm))
            {
                writer.WritePropertyName("self_harm"u8);
                writer.WriteObjectValue(SelfHarm, options);
            }
            if (Optional.IsDefined(Profanity))
            {
                writer.WritePropertyName("profanity"u8);
                writer.WriteObjectValue(Profanity, options);
            }
            if (Optional.IsDefined(CustomBlocklists))
            {
                writer.WritePropertyName("custom_blocklists"u8);
                writer.WriteObjectValue(CustomBlocklists, options);
            }
            writer.WritePropertyName("error"u8);
            writer.WriteObjectValue(Error, options);
            if (Optional.IsDefined(ProtectedMaterialText))
            {
                writer.WritePropertyName("protected_material_text"u8);
                writer.WriteObjectValue(ProtectedMaterialText, options);
            }
            if (Optional.IsDefined(ProtectedMaterialCode))
            {
                writer.WritePropertyName("protected_material_code"u8);
                writer.WriteObjectValue(ProtectedMaterialCode, options);
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

        AzureContentFilterResultForChoice IJsonModel<AzureContentFilterResultForChoice>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureContentFilterResultForChoice>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AzureContentFilterResultForChoice)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAzureContentFilterResultForChoice(document.RootElement, options);
        }

        internal static AzureContentFilterResultForChoice DeserializeAzureContentFilterResultForChoice(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            AzureContentFilterSeverityResult sexual = default;
            AzureContentFilterSeverityResult violence = default;
            AzureContentFilterSeverityResult hate = default;
            AzureContentFilterSeverityResult selfHarm = default;
            AzureContentFilterDetectionResult profanity = default;
            AzureContentFilterBlocklistResult customBlocklists = default;
            AzureContentFilterResultForPromptContentFilterResultsError error = default;
            AzureContentFilterDetectionResult protectedMaterialText = default;
            AzureContentFilterResultForChoiceProtectedMaterialCode protectedMaterialCode = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sexual"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sexual = AzureContentFilterSeverityResult.DeserializeAzureContentFilterSeverityResult(property.Value, options);
                    continue;
                }
                if (property.NameEquals("violence"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    violence = AzureContentFilterSeverityResult.DeserializeAzureContentFilterSeverityResult(property.Value, options);
                    continue;
                }
                if (property.NameEquals("hate"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hate = AzureContentFilterSeverityResult.DeserializeAzureContentFilterSeverityResult(property.Value, options);
                    continue;
                }
                if (property.NameEquals("self_harm"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    selfHarm = AzureContentFilterSeverityResult.DeserializeAzureContentFilterSeverityResult(property.Value, options);
                    continue;
                }
                if (property.NameEquals("profanity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    profanity = AzureContentFilterDetectionResult.DeserializeAzureContentFilterDetectionResult(property.Value, options);
                    continue;
                }
                if (property.NameEquals("custom_blocklists"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    customBlocklists = AzureContentFilterBlocklistResult.DeserializeAzureContentFilterBlocklistResult(property.Value, options);
                    continue;
                }
                if (property.NameEquals("error"u8))
                {
                    error = AzureContentFilterResultForPromptContentFilterResultsError.DeserializeAzureContentFilterResultForPromptContentFilterResultsError(property.Value, options);
                    continue;
                }
                if (property.NameEquals("protected_material_text"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    protectedMaterialText = AzureContentFilterDetectionResult.DeserializeAzureContentFilterDetectionResult(property.Value, options);
                    continue;
                }
                if (property.NameEquals("protected_material_code"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    protectedMaterialCode = AzureContentFilterResultForChoiceProtectedMaterialCode.DeserializeAzureContentFilterResultForChoiceProtectedMaterialCode(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new AzureContentFilterResultForChoice(
                sexual,
                violence,
                hate,
                selfHarm,
                profanity,
                customBlocklists,
                error,
                protectedMaterialText,
                protectedMaterialCode,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<AzureContentFilterResultForChoice>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureContentFilterResultForChoice>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(AzureContentFilterResultForChoice)} does not support writing '{options.Format}' format.");
            }
        }

        AzureContentFilterResultForChoice IPersistableModel<AzureContentFilterResultForChoice>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureContentFilterResultForChoice>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeAzureContentFilterResultForChoice(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AzureContentFilterResultForChoice)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<AzureContentFilterResultForChoice>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static AzureContentFilterResultForChoice FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeAzureContentFilterResultForChoice(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
