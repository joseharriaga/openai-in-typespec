// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI
{
    public partial class ContentFilterSeverityResult : IJsonModel<ContentFilterSeverityResult>
    {
        void IJsonModel<ContentFilterSeverityResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ContentFilterSeverityResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ContentFilterSeverityResult)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("filtered") != true)
            {
                writer.WritePropertyName("filtered"u8);
                writer.WriteBooleanValue(Filtered);
            }
            if (SerializedAdditionalRawData?.ContainsKey("severity") != true)
            {
                writer.WritePropertyName("severity"u8);
                writer.WriteStringValue(Severity.ToString());
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

        ContentFilterSeverityResult IJsonModel<ContentFilterSeverityResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ContentFilterSeverityResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ContentFilterSeverityResult)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeContentFilterSeverityResult(document.RootElement, options);
        }

        internal static ContentFilterSeverityResult DeserializeContentFilterSeverityResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool filtered = default;
            ContentFilterSeverity severity = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("filtered"u8))
                {
                    filtered = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("severity"u8))
                {
                    severity = new ContentFilterSeverity(property.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ContentFilterSeverityResult(filtered, severity, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ContentFilterSeverityResult>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ContentFilterSeverityResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ContentFilterSeverityResult)} does not support writing '{options.Format}' format.");
            }
        }

        ContentFilterSeverityResult IPersistableModel<ContentFilterSeverityResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ContentFilterSeverityResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeContentFilterSeverityResult(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ContentFilterSeverityResult)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ContentFilterSeverityResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static ContentFilterSeverityResult FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeContentFilterSeverityResult(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
