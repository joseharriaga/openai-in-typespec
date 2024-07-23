// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI.Assistants
{
    internal partial class InternalMessageContentTextAnnotationsBingSearchUrlCitation : IJsonModel<InternalMessageContentTextAnnotationsBingSearchUrlCitation>
    {
        void IJsonModel<InternalMessageContentTextAnnotationsBingSearchUrlCitation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentTextAnnotationsBingSearchUrlCitation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageContentTextAnnotationsBingSearchUrlCitation)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("text") != true)
            {
                writer.WritePropertyName("text"u8);
                writer.WriteStringValue(Text);
            }
            if (SerializedAdditionalRawData?.ContainsKey("url_citation") != true)
            {
                writer.WritePropertyName("url_citation"u8);
                writer.WriteObjectValue(UrlCitation, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("start_index") != true)
            {
                writer.WritePropertyName("start_index"u8);
                writer.WriteNumberValue(StartIndex);
            }
            if (SerializedAdditionalRawData?.ContainsKey("end_index") != true)
            {
                writer.WritePropertyName("end_index"u8);
                writer.WriteNumberValue(EndIndex);
            }
            if (SerializedAdditionalRawData?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Type);
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

        InternalMessageContentTextAnnotationsBingSearchUrlCitation IJsonModel<InternalMessageContentTextAnnotationsBingSearchUrlCitation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentTextAnnotationsBingSearchUrlCitation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageContentTextAnnotationsBingSearchUrlCitation)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalMessageContentTextAnnotationsBingSearchUrlCitation(document.RootElement, options);
        }

        internal static InternalMessageContentTextAnnotationsBingSearchUrlCitation DeserializeInternalMessageContentTextAnnotationsBingSearchUrlCitation(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string text = default;
            InternalMessageContentTextAnnotationsBingSearchUrlCitationUrlCitation urlCitation = default;
            int startIndex = default;
            int endIndex = default;
            string type = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("text"u8))
                {
                    text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("url_citation"u8))
                {
                    urlCitation = InternalMessageContentTextAnnotationsBingSearchUrlCitationUrlCitation.DeserializeInternalMessageContentTextAnnotationsBingSearchUrlCitationUrlCitation(property.Value, options);
                    continue;
                }
                if (property.NameEquals("start_index"u8))
                {
                    startIndex = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("end_index"u8))
                {
                    endIndex = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalMessageContentTextAnnotationsBingSearchUrlCitation(
                type,
                serializedAdditionalRawData,
                text,
                urlCitation,
                startIndex,
                endIndex);
        }

        BinaryData IPersistableModel<InternalMessageContentTextAnnotationsBingSearchUrlCitation>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentTextAnnotationsBingSearchUrlCitation>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalMessageContentTextAnnotationsBingSearchUrlCitation)} does not support writing '{options.Format}' format.");
            }
        }

        InternalMessageContentTextAnnotationsBingSearchUrlCitation IPersistableModel<InternalMessageContentTextAnnotationsBingSearchUrlCitation>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentTextAnnotationsBingSearchUrlCitation>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalMessageContentTextAnnotationsBingSearchUrlCitation(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalMessageContentTextAnnotationsBingSearchUrlCitation)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalMessageContentTextAnnotationsBingSearchUrlCitation>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static new InternalMessageContentTextAnnotationsBingSearchUrlCitation FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalMessageContentTextAnnotationsBingSearchUrlCitation(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal override BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}

