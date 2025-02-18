// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Assistants
{
    internal partial class InternalThreadObjectToolResourcesFileSearch : IJsonModel<InternalThreadObjectToolResourcesFileSearch>
    {
        void IJsonModel<InternalThreadObjectToolResourcesFileSearch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalThreadObjectToolResourcesFileSearch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalThreadObjectToolResourcesFileSearch)} does not support writing '{format}' format.");
            }
            if (Optional.IsCollectionDefined(VectorStoreIds) && _additionalBinaryDataProperties?.ContainsKey("vector_store_ids") != true)
            {
                writer.WritePropertyName("vector_store_ids"u8);
                writer.WriteStartArray();
                foreach (string item in VectorStoreIds)
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

        InternalThreadObjectToolResourcesFileSearch IJsonModel<InternalThreadObjectToolResourcesFileSearch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalThreadObjectToolResourcesFileSearch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalThreadObjectToolResourcesFileSearch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalThreadObjectToolResourcesFileSearch)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalThreadObjectToolResourcesFileSearch(document.RootElement, options);
        }

        internal static InternalThreadObjectToolResourcesFileSearch DeserializeInternalThreadObjectToolResourcesFileSearch(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<string> vectorStoreIds = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("vector_store_ids"u8))
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
                    vectorStoreIds = array;
                    continue;
                }
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new InternalThreadObjectToolResourcesFileSearch(vectorStoreIds ?? new ChangeTrackingList<string>(), additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalThreadObjectToolResourcesFileSearch>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalThreadObjectToolResourcesFileSearch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalThreadObjectToolResourcesFileSearch)} does not support writing '{options.Format}' format.");
            }
        }

        InternalThreadObjectToolResourcesFileSearch IPersistableModel<InternalThreadObjectToolResourcesFileSearch>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalThreadObjectToolResourcesFileSearch PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalThreadObjectToolResourcesFileSearch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalThreadObjectToolResourcesFileSearch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalThreadObjectToolResourcesFileSearch)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalThreadObjectToolResourcesFileSearch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalThreadObjectToolResourcesFileSearch internalThreadObjectToolResourcesFileSearch)
        {
            if (internalThreadObjectToolResourcesFileSearch == null)
            {
                return null;
            }
            return BinaryContent.Create(internalThreadObjectToolResourcesFileSearch, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalThreadObjectToolResourcesFileSearch(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalThreadObjectToolResourcesFileSearch(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
