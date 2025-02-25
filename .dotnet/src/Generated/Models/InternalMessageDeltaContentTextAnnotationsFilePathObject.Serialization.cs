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
    internal partial class InternalMessageDeltaContentTextAnnotationsFilePathObject : IJsonModel<InternalMessageDeltaContentTextAnnotationsFilePathObject>
    {
        internal InternalMessageDeltaContentTextAnnotationsFilePathObject()
        {
        }

        void IJsonModel<InternalMessageDeltaContentTextAnnotationsFilePathObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextAnnotationsFilePathObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextAnnotationsFilePathObject)} does not support writing '{format}' format.");
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
            if (Optional.IsDefined(FilePath) && _additionalBinaryDataProperties?.ContainsKey("file_path") != true)
            {
                writer.WritePropertyName("file_path"u8);
                writer.WriteObjectValue(FilePath, options);
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

        InternalMessageDeltaContentTextAnnotationsFilePathObject IJsonModel<InternalMessageDeltaContentTextAnnotationsFilePathObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalMessageDeltaContentTextAnnotationsFilePathObject)JsonModelCreateCore(ref reader, options);

        protected override InternalMessageDeltaTextContentAnnotation JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextAnnotationsFilePathObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextAnnotationsFilePathObject)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalMessageDeltaContentTextAnnotationsFilePathObject(document.RootElement, options);
        }

        internal static InternalMessageDeltaContentTextAnnotationsFilePathObject DeserializeInternalMessageDeltaContentTextAnnotationsFilePathObject(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string @type = "file_path";
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            int index = default;
            string text = default;
            InternalMessageDeltaContentTextAnnotationsFilePathObjectFilePath filePath = default;
            int? startIndex = default;
            int? endIndex = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("type"u8))
                {
                    @type = prop.Value.GetString();
                    continue;
                }
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
                if (prop.NameEquals("file_path"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    filePath = InternalMessageDeltaContentTextAnnotationsFilePathObjectFilePath.DeserializeInternalMessageDeltaContentTextAnnotationsFilePathObjectFilePath(prop.Value, options);
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
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new InternalMessageDeltaContentTextAnnotationsFilePathObject(
                @type,
                additionalBinaryDataProperties,
                index,
                text,
                filePath,
                startIndex,
                endIndex);
        }

        BinaryData IPersistableModel<InternalMessageDeltaContentTextAnnotationsFilePathObject>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextAnnotationsFilePathObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextAnnotationsFilePathObject)} does not support writing '{options.Format}' format.");
            }
        }

        InternalMessageDeltaContentTextAnnotationsFilePathObject IPersistableModel<InternalMessageDeltaContentTextAnnotationsFilePathObject>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalMessageDeltaContentTextAnnotationsFilePathObject)PersistableModelCreateCore(data, options);

        protected override InternalMessageDeltaTextContentAnnotation PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageDeltaContentTextAnnotationsFilePathObject>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalMessageDeltaContentTextAnnotationsFilePathObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalMessageDeltaContentTextAnnotationsFilePathObject)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalMessageDeltaContentTextAnnotationsFilePathObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalMessageDeltaContentTextAnnotationsFilePathObject internalMessageDeltaContentTextAnnotationsFilePathObject)
        {
            if (internalMessageDeltaContentTextAnnotationsFilePathObject == null)
            {
                return null;
            }
            return BinaryContent.Create(internalMessageDeltaContentTextAnnotationsFilePathObject, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalMessageDeltaContentTextAnnotationsFilePathObject(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalMessageDeltaContentTextAnnotationsFilePathObject(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
