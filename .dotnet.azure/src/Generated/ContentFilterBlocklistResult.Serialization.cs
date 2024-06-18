// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI
{
    public partial class ContentFilterBlocklistResult : IJsonModel<ContentFilterBlocklistResult>
    {
        void IJsonModel<ContentFilterBlocklistResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ContentFilterBlocklistResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ContentFilterBlocklistResult)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("filtered"u8);
            writer.WriteBooleanValue(Filtered);
            if (Optional.IsCollectionDefined(InternalDetails))
            {
                writer.WritePropertyName("details"u8);
                writer.WriteStartArray();
                foreach (var item in InternalDetails)
                {
                    writer.WriteObjectValue<InternalAzureContentFilterBlocklistResultDetail>(item, options);
                }
                writer.WriteEndArray();
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

        ContentFilterBlocklistResult IJsonModel<ContentFilterBlocklistResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ContentFilterBlocklistResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ContentFilterBlocklistResult)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeContentFilterBlocklistResult(document.RootElement, options);
        }

        internal static ContentFilterBlocklistResult DeserializeContentFilterBlocklistResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool filtered = default;
            IReadOnlyList<InternalAzureContentFilterBlocklistResultDetail> details = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("filtered"u8))
                {
                    filtered = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("details"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InternalAzureContentFilterBlocklistResultDetail> array = new List<InternalAzureContentFilterBlocklistResultDetail>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InternalAzureContentFilterBlocklistResultDetail.DeserializeInternalAzureContentFilterBlocklistResultDetail(item, options));
                    }
                    details = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ContentFilterBlocklistResult(filtered, details ?? new ChangeTrackingList<InternalAzureContentFilterBlocklistResultDetail>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ContentFilterBlocklistResult>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ContentFilterBlocklistResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ContentFilterBlocklistResult)} does not support writing '{options.Format}' format.");
            }
        }

        ContentFilterBlocklistResult IPersistableModel<ContentFilterBlocklistResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ContentFilterBlocklistResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeContentFilterBlocklistResult(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ContentFilterBlocklistResult)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ContentFilterBlocklistResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static ContentFilterBlocklistResult FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeContentFilterBlocklistResult(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}