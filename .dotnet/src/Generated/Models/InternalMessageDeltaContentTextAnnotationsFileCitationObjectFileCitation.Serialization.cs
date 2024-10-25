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
    internal partial class InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation : IJsonModel<InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>
    {
        void IJsonModel<InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(FileId) && _additionalBinaryDataProperties?.ContainsKey("file_id") != true)
            {
                writer.WritePropertyName("file_id"u8);
                writer.WriteStringValue(FileId);
            }
            if (Optional.IsDefined(Quote) && _additionalBinaryDataProperties?.ContainsKey("quote") != true)
            {
                writer.WritePropertyName("quote"u8);
                writer.WriteStringValue(Quote);
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

        InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation IJsonModel<InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation(document.RootElement, options);
        }

        internal static InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation DeserializeInternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string fileId = default;
            string quote = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("file_id"u8))
                {
                    fileId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("quote"u8))
                {
                    quote = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation(fileId, quote, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation)} does not support writing '{options.Format}' format.");
            }
        }

        InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation IPersistableModel<InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation internalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation)
        {
            return BinaryContent.Create(internalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
