// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.VectorStores
{
    public partial class VectorStoreFileAssociation : IJsonModel<VectorStoreFileAssociation>
    {
        void IJsonModel<VectorStoreFileAssociation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VectorStoreFileAssociation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VectorStoreFileAssociation)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("id") != true)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(FileId);
            }
            if (SerializedAdditionalRawData?.ContainsKey("object") != true)
            {
                writer.WritePropertyName("object"u8);
                writer.WriteStringValue(Object.ToString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("usage_bytes") != true)
            {
                writer.WritePropertyName("usage_bytes"u8);
                writer.WriteNumberValue(Size);
            }
            if (SerializedAdditionalRawData?.ContainsKey("created_at") != true)
            {
                writer.WritePropertyName("created_at"u8);
                writer.WriteNumberValue(CreatedAt, "U");
            }
            if (SerializedAdditionalRawData?.ContainsKey("vector_store_id") != true)
            {
                writer.WritePropertyName("vector_store_id"u8);
                writer.WriteStringValue(VectorStoreId);
            }
            if (SerializedAdditionalRawData?.ContainsKey("status") != true)
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.ToSerialString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("last_error") != true)
            {
                if (LastError != null)
                {
                    writer.WritePropertyName("last_error"u8);
                    writer.WriteObjectValue(LastError, options);
                }
                else
                {
                    writer.WriteNull("last_error");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("chunking_strategy") != true && Optional.IsDefined(ChunkingStrategy))
            {
                writer.WritePropertyName("chunking_strategy"u8);
                writer.WriteObjectValue<FileChunkingStrategy>(ChunkingStrategy, options);
            }
            foreach (var item in SerializedAdditionalRawData ?? new System.Collections.Generic.Dictionary<string, BinaryData>())
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

        VectorStoreFileAssociation IJsonModel<VectorStoreFileAssociation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VectorStoreFileAssociation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VectorStoreFileAssociation)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVectorStoreFileAssociation(document.RootElement, options);
        }

        internal static VectorStoreFileAssociation DeserializeVectorStoreFileAssociation(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            InternalVectorStoreFileObjectObject @object = default;
            int usageBytes = default;
            DateTimeOffset createdAt = default;
            string vectorStoreId = default;
            VectorStoreFileAssociationStatus status = default;
            VectorStoreFileAssociationError? lastError = default;
            FileChunkingStrategy chunkingStrategy = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("object"u8))
                {
                    @object = new InternalVectorStoreFileObjectObject(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("usage_bytes"u8))
                {
                    usageBytes = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("created_at"u8))
                {
                    createdAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("vector_store_id"u8))
                {
                    vectorStoreId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetString().ToVectorStoreFileAssociationStatus();
                    continue;
                }
                if (property.NameEquals("last_error"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        lastError = null;
                        continue;
                    }
                    lastError = VectorStoreFileAssociationError.DeserializeVectorStoreFileAssociationError(property.Value, options);
                    continue;
                }
                if (property.NameEquals("chunking_strategy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    chunkingStrategy = FileChunkingStrategy.DeserializeFileChunkingStrategy(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new VectorStoreFileAssociation(
                id,
                @object,
                usageBytes,
                createdAt,
                vectorStoreId,
                status,
                lastError,
                chunkingStrategy,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<VectorStoreFileAssociation>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VectorStoreFileAssociation>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(VectorStoreFileAssociation)} does not support writing '{options.Format}' format.");
            }
        }

        VectorStoreFileAssociation IPersistableModel<VectorStoreFileAssociation>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VectorStoreFileAssociation>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeVectorStoreFileAssociation(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(VectorStoreFileAssociation)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<VectorStoreFileAssociation>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static VectorStoreFileAssociation FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeVectorStoreFileAssociation(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
