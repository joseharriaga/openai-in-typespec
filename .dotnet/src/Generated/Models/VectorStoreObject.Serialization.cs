// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class VectorStoreObject : IJsonModel<VectorStoreObject>
    {
        void IJsonModel<VectorStoreObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VectorStoreObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VectorStoreObject)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            writer.WritePropertyName("object"u8);
            writer.WriteStringValue(Object);
            writer.WritePropertyName("created_at"u8);
            writer.WriteNumberValue(CreatedAt, "U");
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("usage_bytes"u8);
            writer.WriteNumberValue(UsageBytes);
            writer.WritePropertyName("file_counts"u8);
            writer.WriteObjectValue(FileCounts, options);
            writer.WritePropertyName("status"u8);
            writer.WriteStringValue(Status);
            if (Optional.IsDefined(ExpiresAfter))
            {
                if (ExpiresAfter != null)
                {
                    writer.WritePropertyName("expires_after"u8);
                    writer.WriteObjectValue(ExpiresAfter, options);
                }
                else
                {
                    writer.WriteNull("expires_after");
                }
            }
            if (Optional.IsDefined(ExpiresAt))
            {
                if (ExpiresAt != null)
                {
                    writer.WritePropertyName("expires_at"u8);
                    writer.WriteStringValue(ExpiresAt.Value, "O");
                }
                else
                {
                    writer.WriteNull("expires_at");
                }
            }
            if (LastActiveAt != null)
            {
                writer.WritePropertyName("last_active_at"u8);
                writer.WriteStringValue(LastActiveAt.Value, "O");
            }
            else
            {
                writer.WriteNull("last_active_at");
            }
            if (Metadata != null && Optional.IsCollectionDefined(Metadata))
            {
                writer.WritePropertyName("metadata"u8);
                writer.WriteStartObject();
                foreach (var item in Metadata)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteNull("metadata");
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

        VectorStoreObject IJsonModel<VectorStoreObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VectorStoreObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VectorStoreObject)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVectorStoreObject(document.RootElement, options);
        }

        internal static VectorStoreObject DeserializeVectorStoreObject(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            string @object = default;
            DateTimeOffset createdAt = default;
            string name = default;
            int usageBytes = default;
            VectorStoreObjectFileCounts fileCounts = default;
            string status = default;
            VectorStoreExpirationAfter expiresAfter = default;
            DateTimeOffset? expiresAt = default;
            DateTimeOffset? lastActiveAt = default;
            IReadOnlyDictionary<string, string> metadata = default;
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
                    @object = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("created_at"u8))
                {
                    createdAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("usage_bytes"u8))
                {
                    usageBytes = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("file_counts"u8))
                {
                    fileCounts = VectorStoreObjectFileCounts.DeserializeVectorStoreObjectFileCounts(property.Value, options);
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("expires_after"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        expiresAfter = null;
                        continue;
                    }
                    expiresAfter = VectorStoreExpirationAfter.DeserializeVectorStoreExpirationAfter(property.Value, options);
                    continue;
                }
                if (property.NameEquals("expires_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        expiresAt = null;
                        continue;
                    }
                    expiresAt = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("last_active_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        lastActiveAt = null;
                        continue;
                    }
                    lastActiveAt = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("metadata"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        metadata = new ChangeTrackingDictionary<string, string>();
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    metadata = dictionary;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new VectorStoreObject(
                id,
                @object,
                createdAt,
                name,
                usageBytes,
                fileCounts,
                status,
                expiresAfter,
                expiresAt,
                lastActiveAt,
                metadata,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<VectorStoreObject>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VectorStoreObject>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(VectorStoreObject)} does not support writing '{options.Format}' format.");
            }
        }

        VectorStoreObject IPersistableModel<VectorStoreObject>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VectorStoreObject>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeVectorStoreObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(VectorStoreObject)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<VectorStoreObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static VectorStoreObject FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeVectorStoreObject(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
