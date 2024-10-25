// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Files
{
    public partial class FileDeletionResult : IJsonModel<FileDeletionResult>
    {
        internal FileDeletionResult()
        {
        }

        void IJsonModel<FileDeletionResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FileDeletionResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FileDeletionResult)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("deleted") != true)
            {
                writer.WritePropertyName("deleted"u8);
            }
            writer.WriteBooleanValue(Deleted);
            if (_additionalBinaryDataProperties?.ContainsKey("id") != true)
            {
                writer.WritePropertyName("id"u8);
            }
            writer.WriteStringValue(FileId);
            if (_additionalBinaryDataProperties?.ContainsKey("object") != true)
            {
                writer.WritePropertyName("object"u8);
            }
            writer.WriteStringValue(this.Object.ToString());
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

        FileDeletionResult IJsonModel<FileDeletionResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual FileDeletionResult JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FileDeletionResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FileDeletionResult)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFileDeletionResult(document.RootElement, options);
        }

        internal static FileDeletionResult DeserializeFileDeletionResult(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool deleted = default;
            string fileId = default;
            InternalDeleteFileResponseObject @object = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("deleted"u8))
                {
                    deleted = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("id"u8))
                {
                    fileId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("object"u8))
                {
                    @object = new InternalDeleteFileResponseObject(prop.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new FileDeletionResult(deleted, fileId, @object, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<FileDeletionResult>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FileDeletionResult>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(FileDeletionResult)} does not support writing '{options.Format}' format.");
            }
        }

        FileDeletionResult IPersistableModel<FileDeletionResult>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual FileDeletionResult PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FileDeletionResult>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeFileDeletionResult(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FileDeletionResult)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<FileDeletionResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(FileDeletionResult fileDeletionResult)
        {
            return BinaryContent.Create(fileDeletionResult, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator FileDeletionResult(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeFileDeletionResult(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
