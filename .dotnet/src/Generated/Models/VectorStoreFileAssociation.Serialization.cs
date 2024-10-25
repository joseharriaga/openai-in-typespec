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
    public partial class VectorStoreFileAssociation : IJsonModel<VectorStoreFileAssociation>
    {
        internal VectorStoreFileAssociation()
        {
        }

        void IJsonModel<VectorStoreFileAssociation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStoreFileAssociation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VectorStoreFileAssociation)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("created_at") != true)
            {
                writer.WritePropertyName("created_at"u8);
                writer.WriteNumberValue(CreatedAt, "U");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("vector_store_id") != true)
            {
                writer.WritePropertyName("vector_store_id"u8);
                writer.WriteStringValue(VectorStoreId);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("status") != true)
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.ToSerialString());
            }
            if (_additionalBinaryDataProperties?.ContainsKey("last_error") != true)
            {
                if (LastError != null)
                {
                    writer.WritePropertyName("last_error"u8);
                    writer.WriteObjectValue(LastError, options);
                }
                else
                {
                    writer.WriteNull("lastError"u8);
                }
            }
            if (_additionalBinaryDataProperties?.ContainsKey("object") != true)
            {
                writer.WritePropertyName("object"u8);
                writer.WriteStringValue(this.Object.ToString());
            }
            if (_additionalBinaryDataProperties?.ContainsKey("id") != true)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(FileId);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("usage_bytes") != true)
            {
                writer.WritePropertyName("usage_bytes"u8);
                writer.WriteNumberValue(Size);
            }
            if (Optional.IsDefined(ChunkingStrategy) && _additionalBinaryDataProperties?.ContainsKey("chunking_strategy") != true)
            {
                writer.WritePropertyName("chunking_strategy"u8);
                writer.WriteObjectValue<FileChunkingStrategy>(ChunkingStrategy, options);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
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

        VectorStoreFileAssociation IJsonModel<VectorStoreFileAssociation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual VectorStoreFileAssociation JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStoreFileAssociation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VectorStoreFileAssociation)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVectorStoreFileAssociation(document.RootElement, options);
        }

        internal static VectorStoreFileAssociation DeserializeVectorStoreFileAssociation(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            DateTimeOffset createdAt = default;
            string vectorStoreId = default;
            VectorStores.VectorStoreFileAssociationStatus status = default;
            VectorStoreFileAssociationError lastError = default;
            InternalVectorStoreFileObjectObject @object = default;
            string fileId = default;
            int size = default;
            FileChunkingStrategy chunkingStrategy = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("created_at"u8))
                {
                    createdAt = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                    continue;
                }
                if (prop.NameEquals("vector_store_id"u8))
                {
                    vectorStoreId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("status"u8))
                {
                    status = prop.Value.GetString().ToVectorStoreFileAssociationStatus();
                    continue;
                }
                if (prop.NameEquals("last_error"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        lastError = null;
                        continue;
                    }
                    lastError = VectorStoreFileAssociationError.DeserializeVectorStoreFileAssociationError(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("object"u8))
                {
                    @object = new InternalVectorStoreFileObjectObject(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("id"u8))
                {
                    fileId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("usage_bytes"u8))
                {
                    size = prop.Value.GetInt32();
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
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new VectorStoreFileAssociation(
                createdAt,
                vectorStoreId,
                status,
                lastError,
                @object,
                fileId,
                size,
                chunkingStrategy,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<VectorStoreFileAssociation>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStoreFileAssociation>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(VectorStoreFileAssociation)} does not support writing '{options.Format}' format.");
            }
        }

        VectorStoreFileAssociation IPersistableModel<VectorStoreFileAssociation>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual VectorStoreFileAssociation PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VectorStoreFileAssociation>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeVectorStoreFileAssociation(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(VectorStoreFileAssociation)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<VectorStoreFileAssociation>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(VectorStoreFileAssociation vectorStoreFileAssociation)
        {
            return BinaryContent.Create(vectorStoreFileAssociation, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator VectorStoreFileAssociation(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeVectorStoreFileAssociation(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
