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
    internal partial class InternalMessageContentItemFileObjectImageFile : IJsonModel<InternalMessageContentItemFileObjectImageFile>
    {
        internal InternalMessageContentItemFileObjectImageFile()
        {
        }

        void IJsonModel<InternalMessageContentItemFileObjectImageFile>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentItemFileObjectImageFile>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageContentItemFileObjectImageFile)} does not support writing '{format}' format.");
            }
            writer.WritePropertyName("file_id"u8);
            writer.WriteStringValue(FileId);
            if (Optional.IsDefined(Detail))
            {
                writer.WritePropertyName("detail"u8);
                writer.WriteStringValue(Detail.ToSerialString());
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

        InternalMessageContentItemFileObjectImageFile IJsonModel<InternalMessageContentItemFileObjectImageFile>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalMessageContentItemFileObjectImageFile JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentItemFileObjectImageFile>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageContentItemFileObjectImageFile)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalMessageContentItemFileObjectImageFile(document.RootElement, options);
        }

        internal static InternalMessageContentItemFileObjectImageFile DeserializeInternalMessageContentItemFileObjectImageFile(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string fileId = default;
            string detail = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("file_id"u8))
                {
                    fileId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("detail"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        detail = null;
                        continue;
                    }
                    detail = prop.Value.GetString().ToString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalMessageContentItemFileObjectImageFile(fileId, detail, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalMessageContentItemFileObjectImageFile>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentItemFileObjectImageFile>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalMessageContentItemFileObjectImageFile)} does not support writing '{options.Format}' format.");
            }
        }

        InternalMessageContentItemFileObjectImageFile IPersistableModel<InternalMessageContentItemFileObjectImageFile>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalMessageContentItemFileObjectImageFile PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentItemFileObjectImageFile>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalMessageContentItemFileObjectImageFile(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalMessageContentItemFileObjectImageFile)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalMessageContentItemFileObjectImageFile>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalMessageContentItemFileObjectImageFile internalMessageContentItemFileObjectImageFile)
        {
            return BinaryContent.Create(internalMessageContentItemFileObjectImageFile, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalMessageContentItemFileObjectImageFile(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalMessageContentItemFileObjectImageFile(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
