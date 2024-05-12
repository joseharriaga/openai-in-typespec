// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants
{
    public partial class FileCitationTextContentAnnotation : IJsonModel<FileCitationTextContentAnnotation>
    {
        void IJsonModel<FileCitationTextContentAnnotation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FileCitationTextContentAnnotation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FileCitationTextContentAnnotation)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("text"u8);
            writer.WriteStringValue(Text);
            writer.WritePropertyName("file_citation"u8);
            writer.WriteObjectValue<InternalMessageContentTextAnnotationsFileCitationObjectFileCitation>(_internalFileCitation, options);
            writer.WritePropertyName("start_index"u8);
            writer.WriteNumberValue(StartIndex);
            writer.WritePropertyName("end_index"u8);
            writer.WriteNumberValue(EndIndex);
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type);
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

        FileCitationTextContentAnnotation IJsonModel<FileCitationTextContentAnnotation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FileCitationTextContentAnnotation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FileCitationTextContentAnnotation)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFileCitationTextContentAnnotation(document.RootElement, options);
        }

        internal static FileCitationTextContentAnnotation DeserializeFileCitationTextContentAnnotation(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string text = default;
            InternalMessageContentTextAnnotationsFileCitationObjectFileCitation fileCitation = default;
            int startIndex = default;
            int endIndex = default;
            string type = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("text"u8))
                {
                    text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("file_citation"u8))
                {
                    fileCitation = InternalMessageContentTextAnnotationsFileCitationObjectFileCitation.DeserializeInternalMessageContentTextAnnotationsFileCitationObjectFileCitation(property.Value, options);
                    continue;
                }
                if (property.NameEquals("start_index"u8))
                {
                    startIndex = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("end_index"u8))
                {
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
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new FileCitationTextContentAnnotation(
                type,
                serializedAdditionalRawData,
                text,
                fileCitation,
                startIndex,
                endIndex);
        }

        BinaryData IPersistableModel<FileCitationTextContentAnnotation>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FileCitationTextContentAnnotation>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(FileCitationTextContentAnnotation)} does not support writing '{options.Format}' format.");
            }
        }

        FileCitationTextContentAnnotation IPersistableModel<FileCitationTextContentAnnotation>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FileCitationTextContentAnnotation>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeFileCitationTextContentAnnotation(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FileCitationTextContentAnnotation)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<FileCitationTextContentAnnotation>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static new FileCitationTextContentAnnotation FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeFileCitationTextContentAnnotation(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal override BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
