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
    internal partial class InternalMessageDeltaContentTextAnnotationsFileCitationObject : IJsonModel<InternalMessageDeltaContentTextAnnotationsFileCitationObject>
    {
        internal InternalMessageDeltaContentTextAnnotationsFileCitationObject()
        {
        }

        void IJsonModel<InternalMessageDeltaContentTextAnnotationsFileCitationObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextAnnotationsFileCitationObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextAnnotationsFileCitationObject)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("index") != true)
            {
                writer.WritePropertyName("index"u8);
                writer.WriteNumberValue(Index);
            }
            if (Optional.IsDefined(Text) && _additionalBinaryDataProperties?.ContainsKey("text") != true)
            {
                writer.WritePropertyName("text"u8);
                writer.WriteStringValue(Text);
            }
            if (Optional.IsDefined(FileCitation) && _additionalBinaryDataProperties?.ContainsKey("file_citation") != true)
            {
                writer.WritePropertyName("file_citation"u8);
                writer.WriteObjectValue(FileCitation, options);
            }
            if (Optional.IsDefined(StartIndex) && _additionalBinaryDataProperties?.ContainsKey("start_index") != true)
            {
                writer.WritePropertyName("start_index"u8);
                writer.WriteNumberValue(StartIndex.Value);
            }
            if (Optional.IsDefined(EndIndex) && _additionalBinaryDataProperties?.ContainsKey("end_index") != true)
            {
                writer.WritePropertyName("end_index"u8);
                writer.WriteNumberValue(EndIndex.Value);
            }
        }

        InternalMessageDeltaContentTextAnnotationsFileCitationObject IJsonModel<InternalMessageDeltaContentTextAnnotationsFileCitationObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalMessageDeltaContentTextAnnotationsFileCitationObject)JsonModelCreateCore(ref reader, options);

        protected override InternalMessageDeltaTextContentAnnotation JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextAnnotationsFileCitationObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextAnnotationsFileCitationObject)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalMessageDeltaContentTextAnnotationsFileCitationObject(document.RootElement, options);
        }

        internal static InternalMessageDeltaContentTextAnnotationsFileCitationObject DeserializeInternalMessageDeltaContentTextAnnotationsFileCitationObject(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int index = default;
            string text = default;
            InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation fileCitation = default;
            int? startIndex = default;
            int? endIndex = default;
            string @type = "file_citation";
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("index"u8))
                {
                    index = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("text"u8))
                {
                    text = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("file_citation"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    fileCitation = InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation.DeserializeInternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("start_index"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    startIndex = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("end_index"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    endIndex = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    @type = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalMessageDeltaContentTextAnnotationsFileCitationObject(
                index,
                text,
                fileCitation,
                startIndex,
                endIndex,
                @type,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalMessageDeltaContentTextAnnotationsFileCitationObject>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextAnnotationsFileCitationObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextAnnotationsFileCitationObject)} does not support writing '{options.Format}' format.");
            }
        }

        InternalMessageDeltaContentTextAnnotationsFileCitationObject IPersistableModel<InternalMessageDeltaContentTextAnnotationsFileCitationObject>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalMessageDeltaContentTextAnnotationsFileCitationObject)PersistableModelCreateCore(data, options);

        protected override InternalMessageDeltaTextContentAnnotation PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextAnnotationsFileCitationObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalMessageDeltaContentTextAnnotationsFileCitationObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextAnnotationsFileCitationObject)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalMessageDeltaContentTextAnnotationsFileCitationObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalMessageDeltaContentTextAnnotationsFileCitationObject internalMessageDeltaContentTextAnnotationsFileCitationObject)
        {
            return BinaryContent.Create(internalMessageDeltaContentTextAnnotationsFileCitationObject, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalMessageDeltaContentTextAnnotationsFileCitationObject(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalMessageDeltaContentTextAnnotationsFileCitationObject(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
