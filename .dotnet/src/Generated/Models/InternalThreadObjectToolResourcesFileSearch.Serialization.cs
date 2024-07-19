// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants
{
    internal partial class InternalThreadObjectToolResourcesFileSearch : IJsonModel<InternalThreadObjectToolResourcesFileSearch>
    {
        void IJsonModel<InternalThreadObjectToolResourcesFileSearch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalThreadObjectToolResourcesFileSearch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalThreadObjectToolResourcesFileSearch)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("vector_store_ids") != true && Optional.IsCollectionDefined(VectorStoreIds))
            {
                writer.WritePropertyName("vector_store_ids"u8);
                writer.WriteStartArray();
                foreach (var item in VectorStoreIds)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
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

        InternalThreadObjectToolResourcesFileSearch IJsonModel<InternalThreadObjectToolResourcesFileSearch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalThreadObjectToolResourcesFileSearch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalThreadObjectToolResourcesFileSearch)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalThreadObjectToolResourcesFileSearch(document.RootElement, options);
        }

        internal static InternalThreadObjectToolResourcesFileSearch DeserializeInternalThreadObjectToolResourcesFileSearch(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<string> vectorStoreIds = default;
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
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalThreadObjectToolResourcesFileSearch(vectorStoreIds ?? new ChangeTrackingList<string>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalThreadObjectToolResourcesFileSearch>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalThreadObjectToolResourcesFileSearch>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalThreadObjectToolResourcesFileSearch)} does not support writing '{options.Format}' format.");
            }
        }

        InternalThreadObjectToolResourcesFileSearch IPersistableModel<InternalThreadObjectToolResourcesFileSearch>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalThreadObjectToolResourcesFileSearch>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalThreadObjectToolResourcesFileSearch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalThreadObjectToolResourcesFileSearch)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalThreadObjectToolResourcesFileSearch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static InternalThreadObjectToolResourcesFileSearch FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalThreadObjectToolResourcesFileSearch(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
