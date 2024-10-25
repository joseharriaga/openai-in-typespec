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
    internal partial class InternalMessageContentTextAnnotationsFileCitationObjectFileCitation : IJsonModel<InternalMessageContentTextAnnotationsFileCitationObjectFileCitation>
    {
        internal InternalMessageContentTextAnnotationsFileCitationObjectFileCitation()
        {
        }

        void IJsonModel<InternalMessageContentTextAnnotationsFileCitationObjectFileCitation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentTextAnnotationsFileCitationObjectFileCitation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageContentTextAnnotationsFileCitationObjectFileCitation)} does not support writing '{format}' format.");
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

        InternalMessageContentTextAnnotationsFileCitationObjectFileCitation IJsonModel<InternalMessageContentTextAnnotationsFileCitationObjectFileCitation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalMessageContentTextAnnotationsFileCitationObjectFileCitation JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentTextAnnotationsFileCitationObjectFileCitation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageContentTextAnnotationsFileCitationObjectFileCitation)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalMessageContentTextAnnotationsFileCitationObjectFileCitation(document.RootElement, options);
        }

        internal static InternalMessageContentTextAnnotationsFileCitationObjectFileCitation DeserializeInternalMessageContentTextAnnotationsFileCitationObjectFileCitation(JsonElement element, ModelReaderWriterOptions options)
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
            return new InternalMessageContentTextAnnotationsFileCitationObjectFileCitation(fileId, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalMessageContentTextAnnotationsFileCitationObjectFileCitation>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentTextAnnotationsFileCitationObjectFileCitation>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalMessageContentTextAnnotationsFileCitationObjectFileCitation)} does not support writing '{options.Format}' format.");
            }
        }

        InternalMessageContentTextAnnotationsFileCitationObjectFileCitation IPersistableModel<InternalMessageContentTextAnnotationsFileCitationObjectFileCitation>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalMessageContentTextAnnotationsFileCitationObjectFileCitation PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentTextAnnotationsFileCitationObjectFileCitation>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalMessageContentTextAnnotationsFileCitationObjectFileCitation(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalMessageContentTextAnnotationsFileCitationObjectFileCitation)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalMessageContentTextAnnotationsFileCitationObjectFileCitation>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalMessageContentTextAnnotationsFileCitationObjectFileCitation internalMessageContentTextAnnotationsFileCitationObjectFileCitation)
        {
            return BinaryContent.Create(internalMessageContentTextAnnotationsFileCitationObjectFileCitation, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalMessageContentTextAnnotationsFileCitationObjectFileCitation(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalMessageContentTextAnnotationsFileCitationObjectFileCitation(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
