// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI
{
    internal partial class InternalAzureOpenAIDalleErrorInnerError : IJsonModel<InternalAzureOpenAIDalleErrorInnerError>
    {
        void IJsonModel<InternalAzureOpenAIDalleErrorInnerError>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureOpenAIDalleErrorInnerError>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAzureOpenAIDalleErrorInnerError)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("code") != true && Optional.IsDefined(Code))
            {
                writer.WritePropertyName("code"u8);
                writer.WriteStringValue(Code.Value.ToString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("revised_prompt") != true && Optional.IsDefined(RevisedPrompt))
            {
                writer.WritePropertyName("revised_prompt"u8);
                writer.WriteStringValue(RevisedPrompt);
            }
            if (SerializedAdditionalRawData?.ContainsKey("content_filter_results") != true && Optional.IsDefined(ContentFilterResults))
            {
                writer.WritePropertyName("content_filter_results"u8);
                writer.WriteObjectValue(ContentFilterResults, options);
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

        InternalAzureOpenAIDalleErrorInnerError IJsonModel<InternalAzureOpenAIDalleErrorInnerError>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureOpenAIDalleErrorInnerError>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAzureOpenAIDalleErrorInnerError)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalAzureOpenAIDalleErrorInnerError(document.RootElement, options);
        }

        internal static InternalAzureOpenAIDalleErrorInnerError DeserializeInternalAzureOpenAIDalleErrorInnerError(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalAzureOpenAIDalleErrorInnerErrorCode? code = default;
            string revisedPrompt = default;
            ImageContentFilterResultForPrompt contentFilterResults = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    code = new InternalAzureOpenAIDalleErrorInnerErrorCode(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("revised_prompt"u8))
                {
                    revisedPrompt = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("content_filter_results"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    contentFilterResults = ImageContentFilterResultForPrompt.DeserializeImageContentFilterResultForPrompt(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalAzureOpenAIDalleErrorInnerError(code, revisedPrompt, contentFilterResults, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalAzureOpenAIDalleErrorInnerError>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureOpenAIDalleErrorInnerError>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalAzureOpenAIDalleErrorInnerError)} does not support writing '{options.Format}' format.");
            }
        }

        InternalAzureOpenAIDalleErrorInnerError IPersistableModel<InternalAzureOpenAIDalleErrorInnerError>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureOpenAIDalleErrorInnerError>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalAzureOpenAIDalleErrorInnerError(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalAzureOpenAIDalleErrorInnerError)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalAzureOpenAIDalleErrorInnerError>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static InternalAzureOpenAIDalleErrorInnerError FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalAzureOpenAIDalleErrorInnerError(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}

