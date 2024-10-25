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
    internal partial class InternalMessageContentTextAnnotationsFilePathObjectFilePath : IJsonModel<InternalMessageContentTextAnnotationsFilePathObjectFilePath>
    {
        internal InternalMessageContentTextAnnotationsFilePathObjectFilePath()
        {
        }

        void IJsonModel<InternalMessageContentTextAnnotationsFilePathObjectFilePath>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentTextAnnotationsFilePathObjectFilePath>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageContentTextAnnotationsFilePathObjectFilePath)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("file_id") != true)
            {
                writer.WritePropertyName("file_id"u8);
            }
            writer.WriteStringValue(FileId);
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

        InternalMessageContentTextAnnotationsFilePathObjectFilePath IJsonModel<InternalMessageContentTextAnnotationsFilePathObjectFilePath>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalMessageContentTextAnnotationsFilePathObjectFilePath JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentTextAnnotationsFilePathObjectFilePath>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageContentTextAnnotationsFilePathObjectFilePath)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalMessageContentTextAnnotationsFilePathObjectFilePath(document.RootElement, options);
        }

        internal static InternalMessageContentTextAnnotationsFilePathObjectFilePath DeserializeInternalMessageContentTextAnnotationsFilePathObjectFilePath(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string fileId = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("file_id"u8))
                {
                    fileId = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalMessageContentTextAnnotationsFilePathObjectFilePath(fileId, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalMessageContentTextAnnotationsFilePathObjectFilePath>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentTextAnnotationsFilePathObjectFilePath>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalMessageContentTextAnnotationsFilePathObjectFilePath)} does not support writing '{options.Format}' format.");
            }
        }

        InternalMessageContentTextAnnotationsFilePathObjectFilePath IPersistableModel<InternalMessageContentTextAnnotationsFilePathObjectFilePath>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalMessageContentTextAnnotationsFilePathObjectFilePath PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentTextAnnotationsFilePathObjectFilePath>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalMessageContentTextAnnotationsFilePathObjectFilePath(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalMessageContentTextAnnotationsFilePathObjectFilePath)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalMessageContentTextAnnotationsFilePathObjectFilePath>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalMessageContentTextAnnotationsFilePathObjectFilePath internalMessageContentTextAnnotationsFilePathObjectFilePath)
        {
            return BinaryContent.Create(internalMessageContentTextAnnotationsFilePathObjectFilePath, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalMessageContentTextAnnotationsFilePathObjectFilePath(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalMessageContentTextAnnotationsFilePathObjectFilePath(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
