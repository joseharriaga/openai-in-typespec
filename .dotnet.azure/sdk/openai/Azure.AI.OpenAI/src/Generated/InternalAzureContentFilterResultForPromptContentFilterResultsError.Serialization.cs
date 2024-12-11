// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI
{
    internal partial class InternalAzureContentFilterResultForPromptContentFilterResultsError : IJsonModel<InternalAzureContentFilterResultForPromptContentFilterResultsError>
    {
        void IJsonModel<InternalAzureContentFilterResultForPromptContentFilterResultsError>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureContentFilterResultForPromptContentFilterResultsError>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAzureContentFilterResultForPromptContentFilterResultsError)} does not support writing '{format}' format.");
            }

            if (SerializedAdditionalRawData?.ContainsKey("code") != true)
            {
                writer.WritePropertyName("code"u8);
                writer.WriteNumberValue(Code);
            }
            if (SerializedAdditionalRawData?.ContainsKey("message") != true)
            {
                writer.WritePropertyName("message"u8);
                writer.WriteStringValue(Message);
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
        }

        InternalAzureContentFilterResultForPromptContentFilterResultsError IJsonModel<InternalAzureContentFilterResultForPromptContentFilterResultsError>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureContentFilterResultForPromptContentFilterResultsError>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAzureContentFilterResultForPromptContentFilterResultsError)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalAzureContentFilterResultForPromptContentFilterResultsError(document.RootElement, options);
        }

        internal static InternalAzureContentFilterResultForPromptContentFilterResultsError DeserializeInternalAzureContentFilterResultForPromptContentFilterResultsError(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int code = default;
            string message = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"u8))
                {
                    code = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("message"u8))
                {
                    message = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalAzureContentFilterResultForPromptContentFilterResultsError(code, message, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalAzureContentFilterResultForPromptContentFilterResultsError>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureContentFilterResultForPromptContentFilterResultsError>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalAzureContentFilterResultForPromptContentFilterResultsError)} does not support writing '{options.Format}' format.");
            }
        }

        InternalAzureContentFilterResultForPromptContentFilterResultsError IPersistableModel<InternalAzureContentFilterResultForPromptContentFilterResultsError>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalAzureContentFilterResultForPromptContentFilterResultsError>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalAzureContentFilterResultForPromptContentFilterResultsError(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalAzureContentFilterResultForPromptContentFilterResultsError)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalAzureContentFilterResultForPromptContentFilterResultsError>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static InternalAzureContentFilterResultForPromptContentFilterResultsError FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalAzureContentFilterResultForPromptContentFilterResultsError(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
