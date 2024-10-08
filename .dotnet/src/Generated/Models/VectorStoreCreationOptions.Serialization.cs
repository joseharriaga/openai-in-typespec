// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.VectorStores
{
    public partial class VectorStoreCreationOptions : IJsonModel<VectorStoreCreationOptions>
    {
        void IJsonModel<VectorStoreCreationOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStoreCreationOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VectorStoreCreationOptions)} does not support writing '{format}' format.");
            }
            if (Optional.IsCollectionDefined(FileIds))
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
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsCollectionDefined(Metadata))
            {
                if (Metadata != null)
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
                else
                {
                    writer.WriteNull("metadata"u8);
                }
            }
            if (Optional.IsDefined(ExpirationPolicy))
            {
                writer.WritePropertyName("expires_after"u8);
                writer.WriteObjectValue<VectorStoreExpirationPolicy>(ExpirationPolicy, options);
            }
            if (Optional.IsDefined(ChunkingStrategy))
            {
                writer.WritePropertyName("chunking_strategy"u8);
                writer.WriteObjectValue<FileChunkingStrategy>(ChunkingStrategy, options);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
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
        }

        VectorStoreCreationOptions IJsonModel<VectorStoreCreationOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual VectorStoreCreationOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStoreCreationOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VectorStoreCreationOptions)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVectorStoreCreationOptions(document.RootElement, options);
        }

        internal static VectorStoreCreationOptions DeserializeVectorStoreCreationOptions(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<string> fileIds = default;
            string name = default;
            IDictionary<string, string> metadata = default;
            VectorStoreExpirationPolicy expirationPolicy = default;
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
                if (prop.NameEquals("name"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        name = null;
                        continue;
                    }
                    name = prop.Value.GetString();
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
                if (prop.NameEquals("expires_after"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        expirationPolicy = null;
                        continue;
                    }
                    expirationPolicy = VectorStoreExpirationPolicy.DeserializeVectorStoreExpirationPolicy(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("chunking_strategy"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        chunkingStrategy = null;
                        continue;
                    }
                    chunkingStrategy = FileChunkingStrategy.DeserializeFileChunkingStrategy(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new VectorStoreCreationOptions(
                fileIds ?? new ChangeTrackingList<string>(),
                name,
                metadata ?? new ChangeTrackingDictionary<string, string>(),
                expirationPolicy,
                chunkingStrategy,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<VectorStoreCreationOptions>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStoreCreationOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(VectorStoreCreationOptions)} does not support writing '{options.Format}' format.");
            }
        }

        VectorStoreCreationOptions IPersistableModel<VectorStoreCreationOptions>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual VectorStoreCreationOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStoreCreationOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeVectorStoreCreationOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(VectorStoreCreationOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<VectorStoreCreationOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(VectorStoreCreationOptions vectorStoreCreationOptions)
        {
            return BinaryContent.Create(vectorStoreCreationOptions, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator VectorStoreCreationOptions(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeVectorStoreCreationOptions(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
