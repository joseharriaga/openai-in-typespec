// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;
using OpenAI.Chat;

namespace Azure.AI.OpenAI
{
    public partial class AzureChatSearchDataSourceParametersFieldsMapping : IJsonModel<AzureChatSearchDataSourceParametersFieldsMapping>
    {
        void IJsonModel<AzureChatSearchDataSourceParametersFieldsMapping>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureChatSearchDataSourceParametersFieldsMapping>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AzureChatSearchDataSourceParametersFieldsMapping)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(TitleField))
            {
                writer.WritePropertyName("title_field"u8);
                writer.WriteStringValue(TitleField);
            }
            if (Optional.IsDefined(UrlField))
            {
                writer.WritePropertyName("url_field"u8);
                writer.WriteStringValue(UrlField);
            }
            if (Optional.IsDefined(FilepathField))
            {
                writer.WritePropertyName("filepath_field"u8);
                writer.WriteStringValue(FilepathField);
            }
            if (Optional.IsCollectionDefined(ContentFields))
            {
                writer.WritePropertyName("content_fields"u8);
                writer.WriteStartArray();
                foreach (var item in ContentFields)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(ContentFieldsSeparator))
            {
                writer.WritePropertyName("content_fields_separator"u8);
                writer.WriteStringValue(ContentFieldsSeparator);
            }
            if (Optional.IsCollectionDefined(VectorFields))
            {
                writer.WritePropertyName("vector_fields"u8);
                writer.WriteStartArray();
                foreach (var item in VectorFields)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(ImageVectorFields))
            {
                writer.WritePropertyName("image_vector_fields"u8);
                writer.WriteStartArray();
                foreach (var item in ImageVectorFields)
                {
                    writer.WriteStringValue(item);
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

        AzureChatSearchDataSourceParametersFieldsMapping IJsonModel<AzureChatSearchDataSourceParametersFieldsMapping>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureChatSearchDataSourceParametersFieldsMapping>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AzureChatSearchDataSourceParametersFieldsMapping)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAzureChatSearchDataSourceParametersFieldsMapping(document.RootElement, options);
        }

        internal static AzureChatSearchDataSourceParametersFieldsMapping DeserializeAzureChatSearchDataSourceParametersFieldsMapping(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string titleField = default;
            string urlField = default;
            string filepathField = default;
            IReadOnlyList<string> contentFields = default;
            string contentFieldsSeparator = default;
            IReadOnlyList<string> vectorFields = default;
            IReadOnlyList<string> imageVectorFields = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("title_field"u8))
                {
                    titleField = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("url_field"u8))
                {
                    urlField = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("filepath_field"u8))
                {
                    filepathField = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("content_fields"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    contentFields = array;
                    continue;
                }
                if (property.NameEquals("content_fields_separator"u8))
                {
                    contentFieldsSeparator = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("vector_fields"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    vectorFields = array;
                    continue;
                }
                if (property.NameEquals("image_vector_fields"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    imageVectorFields = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new AzureChatSearchDataSourceParametersFieldsMapping(
                titleField,
                urlField,
                filepathField,
                contentFields ?? new ChangeTrackingList<string>(),
                contentFieldsSeparator,
                vectorFields ?? new ChangeTrackingList<string>(),
                imageVectorFields ?? new ChangeTrackingList<string>(),
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<AzureChatSearchDataSourceParametersFieldsMapping>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureChatSearchDataSourceParametersFieldsMapping>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(AzureChatSearchDataSourceParametersFieldsMapping)} does not support writing '{options.Format}' format.");
            }
        }

        AzureChatSearchDataSourceParametersFieldsMapping IPersistableModel<AzureChatSearchDataSourceParametersFieldsMapping>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureChatSearchDataSourceParametersFieldsMapping>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeAzureChatSearchDataSourceParametersFieldsMapping(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AzureChatSearchDataSourceParametersFieldsMapping)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<AzureChatSearchDataSourceParametersFieldsMapping>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static AzureChatSearchDataSourceParametersFieldsMapping FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeAzureChatSearchDataSourceParametersFieldsMapping(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
