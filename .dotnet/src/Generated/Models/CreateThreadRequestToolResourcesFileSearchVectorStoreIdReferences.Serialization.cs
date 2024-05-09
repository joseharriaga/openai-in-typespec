// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences : IJsonModel<CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences>
    {
        void IJsonModel<CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(VectorStoreIds))
            {
                writer.WritePropertyName("vector_store_ids"u8);
                writer.WriteStartArray();
                foreach (var item in VectorStoreIds)
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

        CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences IJsonModel<CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences(document.RootElement, options);
        }

        internal static CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences DeserializeCreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<string> vectorStoreIds = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("vector_store_ids"u8))
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
                    vectorStoreIds = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences(vectorStoreIds ?? new ChangeTrackingList<string>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences)} does not support writing '{options.Format}' format.");
            }
        }

        CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences IPersistableModel<CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeCreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static CreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCreateThreadRequestToolResourcesFileSearchVectorStoreIdReferences(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
