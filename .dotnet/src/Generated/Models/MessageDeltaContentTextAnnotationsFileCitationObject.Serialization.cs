// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class MessageDeltaContentTextAnnotationsFileCitationObject : IJsonModel<MessageDeltaContentTextAnnotationsFileCitationObject>
    {
        void IJsonModel<MessageDeltaContentTextAnnotationsFileCitationObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageDeltaContentTextAnnotationsFileCitationObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MessageDeltaContentTextAnnotationsFileCitationObject)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("index"u8);
            writer.WriteNumberValue(Index);
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type.ToString());
            writer.WritePropertyName("file_citation"u8);
            writer.WriteObjectValue<MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation>(FileCitation, options);
            if (Optional.IsDefined(StartIndex))
            {
                writer.WritePropertyName("start_index"u8);
                writer.WriteNumberValue(StartIndex.Value);
            }
            if (Optional.IsDefined(EndIndex))
            {
                writer.WritePropertyName("end_index"u8);
                writer.WriteNumberValue(EndIndex.Value);
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

        MessageDeltaContentTextAnnotationsFileCitationObject IJsonModel<MessageDeltaContentTextAnnotationsFileCitationObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageDeltaContentTextAnnotationsFileCitationObject>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MessageDeltaContentTextAnnotationsFileCitationObject)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMessageDeltaContentTextAnnotationsFileCitationObject(document.RootElement, options);
        }

        internal static MessageDeltaContentTextAnnotationsFileCitationObject DeserializeMessageDeltaContentTextAnnotationsFileCitationObject(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            long index = default;
            MessageDeltaContentTextAnnotationsFileCitationObjectType type = default;
            MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation fileCitation = default;
            long? startIndex = default;
            long? endIndex = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("index"u8))
                {
                    index = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new MessageDeltaContentTextAnnotationsFileCitationObjectType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("file_citation"u8))
                {
                    fileCitation = MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation.DeserializeMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation(property.Value, options);
                    continue;
                }
                if (property.NameEquals("start_index"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    startIndex = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("end_index"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    endIndex = property.Value.GetInt64();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new MessageDeltaContentTextAnnotationsFileCitationObject(
                index,
                type,
                fileCitation,
                startIndex,
                endIndex,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<MessageDeltaContentTextAnnotationsFileCitationObject>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageDeltaContentTextAnnotationsFileCitationObject>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(MessageDeltaContentTextAnnotationsFileCitationObject)} does not support writing '{options.Format}' format.");
            }
        }

        MessageDeltaContentTextAnnotationsFileCitationObject IPersistableModel<MessageDeltaContentTextAnnotationsFileCitationObject>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageDeltaContentTextAnnotationsFileCitationObject>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeMessageDeltaContentTextAnnotationsFileCitationObject(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MessageDeltaContentTextAnnotationsFileCitationObject)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MessageDeltaContentTextAnnotationsFileCitationObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static MessageDeltaContentTextAnnotationsFileCitationObject FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeMessageDeltaContentTextAnnotationsFileCitationObject(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestBody. </summary>
        internal virtual BinaryContent ToBinaryBody()
        {
            return BinaryContent.Create(this, new ModelReaderWriterOptions("W"));
        }
    }
}
