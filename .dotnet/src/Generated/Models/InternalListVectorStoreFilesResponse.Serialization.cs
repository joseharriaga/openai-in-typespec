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
    internal partial class InternalListVectorStoreFilesResponse : IJsonModel<InternalListVectorStoreFilesResponse>
    {
        internal InternalListVectorStoreFilesResponse()
        {
        }

        void IJsonModel<InternalListVectorStoreFilesResponse>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalListVectorStoreFilesResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalListVectorStoreFilesResponse)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("object") != true)
            {
                writer.WritePropertyName("object"u8);
            }
            writer.WriteStringValue(Object.ToString());
            if (options.Format != "W" && _additionalBinaryDataProperties?.ContainsKey("data") != true)
            {
                writer.WritePropertyName("data"u8);
                writer.WriteStartArray();
                foreach (VectorStoreFileAssociation item in Data)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (_additionalBinaryDataProperties?.ContainsKey("first_id") != true)
            {
                writer.WritePropertyName("first_id"u8);
            }
            writer.WriteStringValue(FirstId);
            if (_additionalBinaryDataProperties?.ContainsKey("last_id") != true)
            {
                writer.WritePropertyName("last_id"u8);
            }
            writer.WriteStringValue(LastId);
            if (_additionalBinaryDataProperties?.ContainsKey("has_more") != true)
            {
                writer.WritePropertyName("has_more"u8);
            }
            writer.WriteBooleanValue(HasMore);
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

        InternalListVectorStoreFilesResponse IJsonModel<InternalListVectorStoreFilesResponse>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalListVectorStoreFilesResponse JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalListVectorStoreFilesResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalListVectorStoreFilesResponse)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalListVectorStoreFilesResponse(document.RootElement, options);
        }

        internal static InternalListVectorStoreFilesResponse DeserializeInternalListVectorStoreFilesResponse(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalListVectorStoreFilesResponseObject @object = default;
            IReadOnlyList<VectorStoreFileAssociation> data = default;
            string firstId = default;
            string lastId = default;
            bool hasMore = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("object"u8))
                {
                    @object = new InternalListVectorStoreFilesResponseObject(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("data"u8))
                {
                    List<VectorStoreFileAssociation> array = new List<VectorStoreFileAssociation>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(VectorStoreFileAssociation.DeserializeVectorStoreFileAssociation(item, options));
                    }
                    data = array;
                    continue;
                }
                if (prop.NameEquals("first_id"u8))
                {
                    firstId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("last_id"u8))
                {
                    lastId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("has_more"u8))
                {
                    hasMore = prop.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalListVectorStoreFilesResponse(
                @object,
                data,
                firstId,
                lastId,
                hasMore,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalListVectorStoreFilesResponse>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalListVectorStoreFilesResponse>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalListVectorStoreFilesResponse)} does not support writing '{options.Format}' format.");
            }
        }

        InternalListVectorStoreFilesResponse IPersistableModel<InternalListVectorStoreFilesResponse>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalListVectorStoreFilesResponse PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalListVectorStoreFilesResponse>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalListVectorStoreFilesResponse(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalListVectorStoreFilesResponse)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalListVectorStoreFilesResponse>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalListVectorStoreFilesResponse internalListVectorStoreFilesResponse)
        {
            return BinaryContent.Create(internalListVectorStoreFilesResponse, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalListVectorStoreFilesResponse(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalListVectorStoreFilesResponse(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
