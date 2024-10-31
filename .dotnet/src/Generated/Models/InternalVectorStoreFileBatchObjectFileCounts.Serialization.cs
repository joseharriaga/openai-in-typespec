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
    internal partial class InternalVectorStoreFileBatchObjectFileCounts : IJsonModel<InternalVectorStoreFileBatchObjectFileCounts>
    {
        internal InternalVectorStoreFileBatchObjectFileCounts()
        {
        }

        void IJsonModel<InternalVectorStoreFileBatchObjectFileCounts>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalVectorStoreFileBatchObjectFileCounts>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalVectorStoreFileBatchObjectFileCounts)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("in_progress") != true)
            {
                writer.WritePropertyName("in_progress"u8);
                writer.WriteNumberValue(InProgress);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("completed") != true)
            {
                writer.WritePropertyName("completed"u8);
                writer.WriteNumberValue(Completed);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("failed") != true)
            {
                writer.WritePropertyName("failed"u8);
                writer.WriteNumberValue(Failed);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("cancelled") != true)
            {
                writer.WritePropertyName("cancelled"u8);
                writer.WriteNumberValue(Cancelled);
            }
            if (_additionalBinaryDataProperties?.ContainsKey("total") != true)
            {
                writer.WritePropertyName("total"u8);
                writer.WriteNumberValue(Total);
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

        InternalVectorStoreFileBatchObjectFileCounts IJsonModel<InternalVectorStoreFileBatchObjectFileCounts>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalVectorStoreFileBatchObjectFileCounts JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalVectorStoreFileBatchObjectFileCounts>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalVectorStoreFileBatchObjectFileCounts)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalVectorStoreFileBatchObjectFileCounts(document.RootElement, options);
        }

        internal static InternalVectorStoreFileBatchObjectFileCounts DeserializeInternalVectorStoreFileBatchObjectFileCounts(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int inProgress = default;
            int completed = default;
            int failed = default;
            int cancelled = default;
            int total = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("in_progress"u8))
                {
                    inProgress = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("completed"u8))
                {
                    completed = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("failed"u8))
                {
                    failed = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("cancelled"u8))
                {
                    cancelled = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("total"u8))
                {
                    total = prop.Value.GetInt32();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalVectorStoreFileBatchObjectFileCounts(
                inProgress,
                completed,
                failed,
                cancelled,
                total,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalVectorStoreFileBatchObjectFileCounts>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalVectorStoreFileBatchObjectFileCounts>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalVectorStoreFileBatchObjectFileCounts)} does not support writing '{options.Format}' format.");
            }
        }

        InternalVectorStoreFileBatchObjectFileCounts IPersistableModel<InternalVectorStoreFileBatchObjectFileCounts>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalVectorStoreFileBatchObjectFileCounts PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalVectorStoreFileBatchObjectFileCounts>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalVectorStoreFileBatchObjectFileCounts(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalVectorStoreFileBatchObjectFileCounts)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalVectorStoreFileBatchObjectFileCounts>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalVectorStoreFileBatchObjectFileCounts internalVectorStoreFileBatchObjectFileCounts)
        {
            if (internalVectorStoreFileBatchObjectFileCounts == null)
            {
                return null;
            }
            return BinaryContent.Create(internalVectorStoreFileBatchObjectFileCounts, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalVectorStoreFileBatchObjectFileCounts(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalVectorStoreFileBatchObjectFileCounts(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
