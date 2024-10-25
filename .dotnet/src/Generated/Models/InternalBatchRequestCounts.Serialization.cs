// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Batch
{
    internal partial class InternalBatchRequestCounts : IJsonModel<InternalBatchRequestCounts>
    {
        internal InternalBatchRequestCounts()
        {
        }

        void IJsonModel<InternalBatchRequestCounts>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalBatchRequestCounts>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalBatchRequestCounts)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("total") != true)
            {
                writer.WritePropertyName("total"u8);
                writer.WriteNumberValue(Total);
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

        InternalBatchRequestCounts IJsonModel<InternalBatchRequestCounts>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalBatchRequestCounts JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalBatchRequestCounts>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalBatchRequestCounts)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalBatchRequestCounts(document.RootElement, options);
        }

        internal static InternalBatchRequestCounts DeserializeInternalBatchRequestCounts(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int total = default;
            int completed = default;
            int failed = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("total"u8))
                {
                    total = prop.Value.GetInt32();
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
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalBatchRequestCounts(total, completed, failed, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalBatchRequestCounts>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalBatchRequestCounts>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalBatchRequestCounts)} does not support writing '{options.Format}' format.");
            }
        }

        InternalBatchRequestCounts IPersistableModel<InternalBatchRequestCounts>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalBatchRequestCounts PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalBatchRequestCounts>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalBatchRequestCounts(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalBatchRequestCounts)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalBatchRequestCounts>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalBatchRequestCounts internalBatchRequestCounts)
        {
            return BinaryContent.Create(internalBatchRequestCounts, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalBatchRequestCounts(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalBatchRequestCounts(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
