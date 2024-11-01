// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Assistants
{
    [PersistableModelProxy(typeof(UnknownMessageContentTextObjectAnnotation))]
    internal abstract partial class InternalMessageContentTextObjectAnnotation : IJsonModel<InternalMessageContentTextObjectAnnotation>
    {
        internal InternalMessageContentTextObjectAnnotation()
        {
        }

        void IJsonModel<InternalMessageContentTextObjectAnnotation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentTextObjectAnnotation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageContentTextObjectAnnotation)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Type);
            }
            if (true && _additionalBinaryDataProperties != null)
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

        InternalMessageContentTextObjectAnnotation IJsonModel<InternalMessageContentTextObjectAnnotation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalMessageContentTextObjectAnnotation JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentTextObjectAnnotation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageContentTextObjectAnnotation)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalMessageContentTextObjectAnnotation(document.RootElement, options);
        }

        internal static InternalMessageContentTextObjectAnnotation DeserializeInternalMessageContentTextObjectAnnotation(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "file_citation":
                        return InternalMessageContentTextAnnotationsFileCitationObject.DeserializeInternalMessageContentTextAnnotationsFileCitationObject(element, options);
                    case "file_path":
                        return InternalMessageContentTextAnnotationsFilePathObject.DeserializeInternalMessageContentTextAnnotationsFilePathObject(element, options);
                }
            }
            return UnknownMessageContentTextObjectAnnotation.DeserializeUnknownMessageContentTextObjectAnnotation(element, options);
        }

        BinaryData IPersistableModel<InternalMessageContentTextObjectAnnotation>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentTextObjectAnnotation>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalMessageContentTextObjectAnnotation)} does not support writing '{options.Format}' format.");
            }
        }

        InternalMessageContentTextObjectAnnotation IPersistableModel<InternalMessageContentTextObjectAnnotation>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalMessageContentTextObjectAnnotation PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalMessageContentTextObjectAnnotation>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalMessageContentTextObjectAnnotation(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalMessageContentTextObjectAnnotation)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalMessageContentTextObjectAnnotation>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalMessageContentTextObjectAnnotation internalMessageContentTextObjectAnnotation)
        {
            if (internalMessageContentTextObjectAnnotation == null)
            {
                return null;
            }
            return BinaryContent.Create(internalMessageContentTextObjectAnnotation, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalMessageContentTextObjectAnnotation(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalMessageContentTextObjectAnnotation(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
