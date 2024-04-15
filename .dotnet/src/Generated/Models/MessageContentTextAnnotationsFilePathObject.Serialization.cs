// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class MessageContentTextAnnotationsFilePathObject : IJsonModel<MessageContentTextAnnotationsFilePathObject>
    {
        void IJsonModel<MessageContentTextAnnotationsFilePathObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageContentTextAnnotationsFilePathObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MessageContentTextAnnotationsFilePathObject)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type.ToString());
            writer.WritePropertyName("text"u8);
            writer.WriteStringValue(Text);
            writer.WritePropertyName("file_path"u8);
            writer.WriteObjectValue<MessageContentTextAnnotationsFilePathObjectFilePath>(FilePath, options);
            writer.WritePropertyName("start_index"u8);
            writer.WriteNumberValue(StartIndex);
            writer.WritePropertyName("end_index"u8);
            writer.WriteNumberValue(EndIndex);
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

        MessageContentTextAnnotationsFilePathObject IJsonModel<MessageContentTextAnnotationsFilePathObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageContentTextAnnotationsFilePathObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MessageContentTextAnnotationsFilePathObject)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMessageContentTextAnnotationsFilePathObject(document.RootElement, options);
        }

        internal static MessageContentTextAnnotationsFilePathObject DeserializeMessageContentTextAnnotationsFilePathObject(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            MessageContentTextAnnotationsFilePathObjectType type = default;
            string text = default;
            MessageContentTextAnnotationsFilePathObjectFilePath filePath = default;
            long startIndex = default;
            long endIndex = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    type = new MessageContentTextAnnotationsFilePathObjectType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("text"u8))
                {
                    text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("file_path"u8))
                {
                    filePath = MessageContentTextAnnotationsFilePathObjectFilePath.DeserializeMessageContentTextAnnotationsFilePathObjectFilePath(property.Value, options);
                    continue;
                }
                if (property.NameEquals("start_index"u8))
                {
                    startIndex = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("end_index"u8))
                {
                    endIndex = property.Value.GetInt64();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new MessageContentTextAnnotationsFilePathObject(
                type,
                text,
                filePath,
                startIndex,
                endIndex,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<MessageContentTextAnnotationsFilePathObject>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageContentTextAnnotationsFilePathObject>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(MessageContentTextAnnotationsFilePathObject)} does not support writing '{options.Format}' format.");
            }
        }

        MessageContentTextAnnotationsFilePathObject IPersistableModel<MessageContentTextAnnotationsFilePathObject>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageContentTextAnnotationsFilePathObject>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeMessageContentTextAnnotationsFilePathObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MessageContentTextAnnotationsFilePathObject)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MessageContentTextAnnotationsFilePathObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static MessageContentTextAnnotationsFilePathObject FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeMessageContentTextAnnotationsFilePathObject(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestBody. </summary>
        internal virtual BinaryContent ToBinaryBody()
        {
            return BinaryContent.Create(this, new ModelReaderWriterOptions("W"));
        }
    }
}
