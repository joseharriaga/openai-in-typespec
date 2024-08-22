// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants
{
    internal partial class InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers : IJsonModel<InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers>
    {
        void IJsonModel<InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("vector_stores") != true && Optional.IsCollectionDefined(VectorStores))
            {
                writer.WritePropertyName("vector_stores"u8);
                writer.WriteStartArray();
                foreach (var item in VectorStores)
                {
                    writer.WriteObjectValue(item, options);
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

        InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers IJsonModel<InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers(document.RootElement, options);
        }

        internal static InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers DeserializeInternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<VectorStoreCreationHelper> vectorStores = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("vector_stores"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VectorStoreCreationHelper> array = new List<VectorStoreCreationHelper>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VectorStoreCreationHelper.DeserializeVectorStoreCreationHelper(item, options));
                    }
                    vectorStores = array;
                    continue;
                }
                if (true)
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers(vectorStores ?? new ChangeTrackingList<VectorStoreCreationHelper>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers)} does not support writing '{options.Format}' format.");
            }
        }

        InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers IPersistableModel<InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static InternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalCreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
