// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI.Chat
{
    public partial class DataSourceFieldMappings : IJsonModel<DataSourceFieldMappings>
    {
        void IJsonModel<DataSourceFieldMappings>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataSourceFieldMappings>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataSourceFieldMappings)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (!SerializedAdditionalRawData.ContainsKey("title_field") && Optional.IsDefined(TitleFieldName))
            {
                writer.WritePropertyName("title_field"u8);
                writer.WriteStringValue(TitleFieldName);
            }
            if (!SerializedAdditionalRawData.ContainsKey("url_field") && Optional.IsDefined(UrlFieldName))
            {
                writer.WritePropertyName("url_field"u8);
                writer.WriteStringValue(UrlFieldName);
            }
            if (!SerializedAdditionalRawData.ContainsKey("filepath_field") && Optional.IsDefined(FilepathFieldName))
            {
                writer.WritePropertyName("filepath_field"u8);
                writer.WriteStringValue(FilepathFieldName);
            }
            if (!SerializedAdditionalRawData.ContainsKey("content_fields") && Optional.IsCollectionDefined(ContentFieldNames))
            {
                writer.WritePropertyName("content_fields"u8);
                writer.WriteStartArray();
                foreach (var item in ContentFieldNames)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (!SerializedAdditionalRawData.ContainsKey("content_fields_separator") && Optional.IsDefined(ContentFieldSeparator))
            {
                writer.WritePropertyName("content_fields_separator"u8);
                writer.WriteStringValue(ContentFieldSeparator);
            }
            if (!SerializedAdditionalRawData.ContainsKey("vector_fields") && Optional.IsCollectionDefined(VectorFieldNames))
            {
                writer.WritePropertyName("vector_fields"u8);
                writer.WriteStartArray();
                foreach (var item in VectorFieldNames)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (!SerializedAdditionalRawData.ContainsKey("image_vector_fields") && Optional.IsCollectionDefined(ImageVectorFieldNames))
            {
                writer.WritePropertyName("image_vector_fields"u8);
                writer.WriteStartArray();
                foreach (var item in ImageVectorFieldNames)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
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

        DataSourceFieldMappings IJsonModel<DataSourceFieldMappings>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataSourceFieldMappings>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataSourceFieldMappings)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDataSourceFieldMappings(document.RootElement, options);
        }

        internal static DataSourceFieldMappings DeserializeDataSourceFieldMappings(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string titleField = default;
            string urlField = default;
            string filepathField = default;
            IList<string> contentFields = default;
            string contentFieldsSeparator = default;
            IList<string> vectorFields = default;
            IList<string> imageVectorFields = default;
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
            return new DataSourceFieldMappings(
                titleField,
                urlField,
                filepathField,
                contentFields ?? new ChangeTrackingList<string>(),
                contentFieldsSeparator,
                vectorFields ?? new ChangeTrackingList<string>(),
                imageVectorFields ?? new ChangeTrackingList<string>(),
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DataSourceFieldMappings>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataSourceFieldMappings>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(DataSourceFieldMappings)} does not support writing '{options.Format}' format.");
            }
        }

        DataSourceFieldMappings IPersistableModel<DataSourceFieldMappings>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataSourceFieldMappings>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDataSourceFieldMappings(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DataSourceFieldMappings)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<DataSourceFieldMappings>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static DataSourceFieldMappings FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeDataSourceFieldMappings(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
