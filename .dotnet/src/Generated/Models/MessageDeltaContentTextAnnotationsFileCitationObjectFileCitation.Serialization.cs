// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation : IJsonModel<MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>
    {
        void IJsonModel<MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(FileId))
            {
                writer.WritePropertyName("file_id"u8);
                writer.WriteStringValue(FileId);
            }
            if (Optional.IsDefined(Quote))
            {
                writer.WritePropertyName("quote"u8);
                writer.WriteStringValue(Quote);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
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
            writer.WriteEndObject();
        }

        MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation IJsonModel<MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation(document.RootElement, options);
        }

        internal static MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation DeserializeMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string fileId = default;
            string quote = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("file_id"u8))
                {
                    fileId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("quote"u8))
                {
                    quote = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation(fileId, quote, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation)} does not support writing '{options.Format}' format.");
            }
        }

        MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation IPersistableModel<MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
