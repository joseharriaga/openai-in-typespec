// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI
{
    public partial class ContentFilterResultForResponse : IJsonModel<ContentFilterResultForResponse>
    {
        void IJsonModel<ContentFilterResultForResponse>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ContentFilterResultForResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ContentFilterResultForResponse)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("sexual") != true && Optional.IsDefined(Sexual))
            {
                writer.WritePropertyName("sexual"u8);
                writer.WriteObjectValue(Sexual, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("hate") != true && Optional.IsDefined(Hate))
            {
                writer.WritePropertyName("hate"u8);
                writer.WriteObjectValue(Hate, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("violence") != true && Optional.IsDefined(Violence))
            {
                writer.WritePropertyName("violence"u8);
                writer.WriteObjectValue(Violence, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("self_harm") != true && Optional.IsDefined(SelfHarm))
            {
                writer.WritePropertyName("self_harm"u8);
                writer.WriteObjectValue(SelfHarm, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("profanity") != true && Optional.IsDefined(Profanity))
            {
                writer.WritePropertyName("profanity"u8);
                writer.WriteObjectValue(Profanity, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("custom_blocklists") != true && Optional.IsDefined(CustomBlocklists))
            {
                writer.WritePropertyName("custom_blocklists"u8);
                writer.WriteObjectValue(CustomBlocklists, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("error") != true && Optional.IsDefined(Error))
            {
                writer.WritePropertyName("error"u8);
                writer.WriteObjectValue<InternalAzureContentFilterResultForPromptContentFilterResultsError>(Error, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("protected_material_text") != true && Optional.IsDefined(ProtectedMaterialText))
            {
                writer.WritePropertyName("protected_material_text"u8);
                writer.WriteObjectValue(ProtectedMaterialText, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("protected_material_code") != true && Optional.IsDefined(ProtectedMaterialCode))
            {
                writer.WritePropertyName("protected_material_code"u8);
                writer.WriteObjectValue(ProtectedMaterialCode, options);
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

        ContentFilterResultForResponse IJsonModel<ContentFilterResultForResponse>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ContentFilterResultForResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ContentFilterResultForResponse)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeContentFilterResultForResponse(document.RootElement, options);
        }

        internal static ContentFilterResultForResponse DeserializeContentFilterResultForResponse(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ContentFilterSeverityResult sexual = default;
            ContentFilterSeverityResult hate = default;
            ContentFilterSeverityResult violence = default;
            ContentFilterSeverityResult selfHarm = default;
            ContentFilterDetectionResult profanity = default;
            ContentFilterBlocklistResult customBlocklists = default;
            InternalAzureContentFilterResultForPromptContentFilterResultsError error = default;
            ContentFilterDetectionResult protectedMaterialText = default;
            ContentFilterProtectedMaterialResult protectedMaterialCode = default;
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
                    sexual = ContentFilterSeverityResult.DeserializeContentFilterSeverityResult(property.Value, options);
                    continue;
                }
                if (property.NameEquals("hate"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hate = ContentFilterSeverityResult.DeserializeContentFilterSeverityResult(property.Value, options);
                    continue;
                }
                if (property.NameEquals("violence"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    violence = ContentFilterSeverityResult.DeserializeContentFilterSeverityResult(property.Value, options);
                    continue;
                }
                if (property.NameEquals("self_harm"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    selfHarm = ContentFilterSeverityResult.DeserializeContentFilterSeverityResult(property.Value, options);
                    continue;
                }
                if (property.NameEquals("profanity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    profanity = ContentFilterDetectionResult.DeserializeContentFilterDetectionResult(property.Value, options);
                    continue;
                }
                if (property.NameEquals("custom_blocklists"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    customBlocklists = ContentFilterBlocklistResult.DeserializeContentFilterBlocklistResult(property.Value, options);
                    continue;
                }
                if (property.NameEquals("error"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    error = InternalAzureContentFilterResultForPromptContentFilterResultsError.DeserializeInternalAzureContentFilterResultForPromptContentFilterResultsError(property.Value, options);
                    continue;
                }
                if (property.NameEquals("protected_material_text"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    protectedMaterialText = ContentFilterDetectionResult.DeserializeContentFilterDetectionResult(property.Value, options);
                    continue;
                }
                if (property.NameEquals("protected_material_code"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    protectedMaterialCode = ContentFilterProtectedMaterialResult.DeserializeContentFilterProtectedMaterialResult(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ContentFilterResultForResponse(
                sexual,
                hate,
                violence,
                selfHarm,
                profanity,
                customBlocklists,
                error,
                protectedMaterialText,
                protectedMaterialCode,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ContentFilterResultForResponse>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ContentFilterResultForResponse>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ContentFilterResultForResponse)} does not support writing '{options.Format}' format.");
            }
        }

        ContentFilterResultForResponse IPersistableModel<ContentFilterResultForResponse>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ContentFilterResultForResponse>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeContentFilterResultForResponse(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ContentFilterResultForResponse)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ContentFilterResultForResponse>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static ContentFilterResultForResponse FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeContentFilterResultForResponse(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
