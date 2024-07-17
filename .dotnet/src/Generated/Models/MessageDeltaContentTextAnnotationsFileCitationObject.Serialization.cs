// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants
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
            if (SerializedAdditionalRawData?.ContainsKey("index") != true)
            {
                writer.WritePropertyName("index"u8);
                writer.WriteNumberValue(Index);
            }
            if (SerializedAdditionalRawData?.ContainsKey("text") != true && Optional.IsDefined(Text))
            {
                writer.WritePropertyName("text"u8);
                writer.WriteStringValue(Text);
            }
            if (SerializedAdditionalRawData?.ContainsKey("file_citation") != true && Optional.IsDefined(FileCitation))
            {
                writer.WritePropertyName("file_citation"u8);
                writer.WriteObjectValue(FileCitation, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("start_index") != true && Optional.IsDefined(StartIndex))
            {
                writer.WritePropertyName("start_index"u8);
                writer.WriteNumberValue(StartIndex.Value);
            }
            if (SerializedAdditionalRawData?.ContainsKey("end_index") != true && Optional.IsDefined(EndIndex))
            {
                writer.WritePropertyName("end_index"u8);
                writer.WriteNumberValue(EndIndex.Value);
            }
            if (SerializedAdditionalRawData?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Type);
            }
            foreach (var item in SerializedAdditionalRawData ?? new System.Collections.Generic.Dictionary<string, BinaryData>())
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
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int index = default;
            string text = default;
            MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation fileCitation = default;
            int? startIndex = default;
            int? endIndex = default;
            string type = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("index"u8))
                {
                    index = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("text"u8))
                {
                    text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("file_citation"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    fileCitation = MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation.DeserializeMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation(property.Value, options);
                    continue;
                }
                if (property.NameEquals("start_index"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    startIndex = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("end_index"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    endIndex = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new MessageDeltaContentTextAnnotationsFileCitationObject(
                type,
                serializedAdditionalRawData,
                index,
                text,
                fileCitation,
                startIndex,
                endIndex);
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

        internal static new MessageDeltaContentTextAnnotationsFileCitationObject FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeMessageDeltaContentTextAnnotationsFileCitationObject(document.RootElement);
        }

        internal override BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
