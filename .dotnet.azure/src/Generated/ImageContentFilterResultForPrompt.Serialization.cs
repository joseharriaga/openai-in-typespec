// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI
{
    public partial class ImageContentFilterResultForPrompt : IJsonModel<ImageContentFilterResultForPrompt>
    {
        void IJsonModel<ImageContentFilterResultForPrompt>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ImageContentFilterResultForPrompt>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ImageContentFilterResultForPrompt)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (!SerializedAdditionalRawData.ContainsKey("profanity") && Optional.IsDefined(Profanity))
            {
                writer.WritePropertyName("profanity"u8);
                writer.WriteObjectValue(Profanity, options);
            }
            if (!SerializedAdditionalRawData.ContainsKey("custom_blocklists") && Optional.IsDefined(CustomBlocklists))
            {
                writer.WritePropertyName("custom_blocklists"u8);
                writer.WriteObjectValue(CustomBlocklists, options);
            }
            if (!SerializedAdditionalRawData.ContainsKey("jailbreak"))
            {
                writer.WritePropertyName("jailbreak"u8);
                writer.WriteObjectValue(Jailbreak, options);
            }
            if (!SerializedAdditionalRawData.ContainsKey("sexual") && Optional.IsDefined(Sexual))
            {
                writer.WritePropertyName("sexual"u8);
                writer.WriteObjectValue(Sexual, options);
            }
            if (!SerializedAdditionalRawData.ContainsKey("violence") && Optional.IsDefined(Violence))
            {
                writer.WritePropertyName("violence"u8);
                writer.WriteObjectValue(Violence, options);
            }
            if (!SerializedAdditionalRawData.ContainsKey("hate") && Optional.IsDefined(Hate))
            {
                writer.WritePropertyName("hate"u8);
                writer.WriteObjectValue(Hate, options);
            }
            if (!SerializedAdditionalRawData.ContainsKey("self_harm") && Optional.IsDefined(SelfHarm))
            {
                writer.WritePropertyName("self_harm"u8);
                writer.WriteObjectValue(SelfHarm, options);
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

        ImageContentFilterResultForPrompt IJsonModel<ImageContentFilterResultForPrompt>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ImageContentFilterResultForPrompt>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ImageContentFilterResultForPrompt)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeImageContentFilterResultForPrompt(document.RootElement, options);
        }

        internal static ImageContentFilterResultForPrompt DeserializeImageContentFilterResultForPrompt(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ContentFilterDetectionResult profanity = default;
            ContentFilterBlocklistResult customBlocklists = default;
            ContentFilterDetectionResult jailbreak = default;
            ContentFilterSeverityResult sexual = default;
            ContentFilterSeverityResult violence = default;
            ContentFilterSeverityResult hate = default;
            ContentFilterSeverityResult selfHarm = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
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
                if (property.NameEquals("jailbreak"u8))
                {
                    jailbreak = ContentFilterDetectionResult.DeserializeContentFilterDetectionResult(property.Value, options);
                    continue;
                }
                if (property.NameEquals("sexual"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sexual = ContentFilterSeverityResult.DeserializeContentFilterSeverityResult(property.Value, options);
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
                if (property.NameEquals("hate"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hate = ContentFilterSeverityResult.DeserializeContentFilterSeverityResult(property.Value, options);
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
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ImageContentFilterResultForPrompt(
                sexual,
                violence,
                hate,
                selfHarm,
                serializedAdditionalRawData,
                profanity,
                customBlocklists,
                jailbreak);
        }

        BinaryData IPersistableModel<ImageContentFilterResultForPrompt>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ImageContentFilterResultForPrompt>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ImageContentFilterResultForPrompt)} does not support writing '{options.Format}' format.");
            }
        }

        ImageContentFilterResultForPrompt IPersistableModel<ImageContentFilterResultForPrompt>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ImageContentFilterResultForPrompt>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeImageContentFilterResultForPrompt(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ImageContentFilterResultForPrompt)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ImageContentFilterResultForPrompt>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static new ImageContentFilterResultForPrompt FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeImageContentFilterResultForPrompt(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal override BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
