// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;
using OpenAI.VectorStores;

namespace OpenAI.Assistants
{
    public partial class VectorStoreCreationHelper : IJsonModel<VectorStoreCreationHelper>
    {
        void IJsonModel<VectorStoreCreationHelper>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStoreCreationHelper>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VectorStoreCreationHelper)} does not support writing '{format}' format.");
            }
            if (Optional.IsCollectionDefined(FileIds) && _additionalBinaryDataProperties?.ContainsKey("file_ids") != true)
            {
                writer.WritePropertyName("file_ids"u8);
                writer.WriteStartArray();
                foreach (string item in FileIds)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Metadata) && _additionalBinaryDataProperties?.ContainsKey("metadata") != true)
            {
                writer.WritePropertyName("metadata"u8);
                writer.WriteStartObject();
                foreach (var item in Metadata)
                {
                    writer.WritePropertyName(item.Key);
                    if (item.Value == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(ChunkingStrategy) && _additionalBinaryDataProperties?.ContainsKey("chunking_strategy") != true)
            {
                writer.WritePropertyName("chunking_strategy"u8);
                writer.WriteObjectValue<FileChunkingStrategy>(ChunkingStrategy, options);
            }
            if (_additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
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

        VectorStoreCreationHelper IJsonModel<VectorStoreCreationHelper>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual VectorStoreCreationHelper JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStoreCreationHelper>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VectorStoreCreationHelper)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVectorStoreCreationHelper(document.RootElement, options);
        }

        internal static VectorStoreCreationHelper DeserializeVectorStoreCreationHelper(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<string> fileIds = default;
            IDictionary<string, string> metadata = default;
            FileChunkingStrategy chunkingStrategy = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("file_ids"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(item.GetString());
                        }
                    }
                    fileIds = array;
                    continue;
                }
                if (prop.NameEquals("metadata"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var prop0 in prop.Value.EnumerateObject())
                    {
                        if (prop0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(prop0.Name, null);
                        }
                        else
                        {
                            dictionary.Add(prop0.Name, prop0.Value.GetString());
                        }
                    }
                    metadata = dictionary;
                    continue;
                }
                if (prop.NameEquals("chunking_strategy"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    chunkingStrategy = FileChunkingStrategy.DeserializeFileChunkingStrategy(prop.Value, options);
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new VectorStoreCreationHelper(fileIds ?? new ChangeTrackingList<string>(), metadata ?? new ChangeTrackingDictionary<string, string>(), chunkingStrategy, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<VectorStoreCreationHelper>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStoreCreationHelper>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(VectorStoreCreationHelper)} does not support writing '{options.Format}' format.");
            }
        }

        VectorStoreCreationHelper IPersistableModel<VectorStoreCreationHelper>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual VectorStoreCreationHelper PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStoreCreationHelper>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeVectorStoreCreationHelper(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(VectorStoreCreationHelper)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<VectorStoreCreationHelper>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(VectorStoreCreationHelper vectorStoreCreationHelper)
        {
            if (vectorStoreCreationHelper == null)
            {
                return null;
            }
            return BinaryContent.Create(vectorStoreCreationHelper, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator VectorStoreCreationHelper(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeVectorStoreCreationHelper(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
