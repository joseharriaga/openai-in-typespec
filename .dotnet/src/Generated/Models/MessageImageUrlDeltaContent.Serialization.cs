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
    public partial class MessageImageUrlDeltaContent : IJsonModel<MessageImageUrlDeltaContent>
    {
        void IJsonModel<MessageImageUrlDeltaContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageImageUrlDeltaContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MessageImageUrlDeltaContent)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("index"u8);
            writer.WriteNumberValue(Index);
            if (Optional.IsDefined(_imageUrl))
            {
                writer.WritePropertyName("image_url"u8);
                writer.WriteObjectValue<InternalMessageDeltaContentImageUrlObjectImageUrl>(_imageUrl, options);
            }
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

        MessageImageUrlDeltaContent IJsonModel<MessageImageUrlDeltaContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageImageUrlDeltaContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MessageImageUrlDeltaContent)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMessageImageUrlDeltaContent(document.RootElement, options);
        }

        internal static MessageImageUrlDeltaContent DeserializeMessageImageUrlDeltaContent(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int index = default;
            InternalMessageDeltaContentImageUrlObjectImageUrl imageUrl = default;
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
                if (property.NameEquals("image_url"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    imageUrl = InternalMessageDeltaContentImageUrlObjectImageUrl.DeserializeInternalMessageDeltaContentImageUrlObjectImageUrl(property.Value, options);
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
            return new MessageImageUrlDeltaContent(type, serializedAdditionalRawData, index, imageUrl);
        }

        BinaryData IPersistableModel<MessageImageUrlDeltaContent>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageImageUrlDeltaContent>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(MessageImageUrlDeltaContent)} does not support writing '{options.Format}' format.");
            }
        }

        MessageImageUrlDeltaContent IPersistableModel<MessageImageUrlDeltaContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MessageImageUrlDeltaContent>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeMessageImageUrlDeltaContent(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MessageImageUrlDeltaContent)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MessageImageUrlDeltaContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static new MessageImageUrlDeltaContent FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeMessageImageUrlDeltaContent(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal override BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
