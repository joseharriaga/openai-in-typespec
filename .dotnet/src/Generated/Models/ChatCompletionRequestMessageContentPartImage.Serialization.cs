// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class ChatCompletionRequestMessageContentPartImage : IJsonModel<ChatCompletionRequestMessageContentPartImage>
    {
        void IJsonModel<ChatCompletionRequestMessageContentPartImage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChatCompletionRequestMessageContentPartImage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatCompletionRequestMessageContentPartImage)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type.ToString());
            writer.WritePropertyName("image_url"u8);
            writer.WriteObjectValue<ChatCompletionRequestMessageContentPartImageImageUrl>(ImageUrl, options);
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

        ChatCompletionRequestMessageContentPartImage IJsonModel<ChatCompletionRequestMessageContentPartImage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChatCompletionRequestMessageContentPartImage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatCompletionRequestMessageContentPartImage)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeChatCompletionRequestMessageContentPartImage(document.RootElement, options);
        }

        internal static ChatCompletionRequestMessageContentPartImage DeserializeChatCompletionRequestMessageContentPartImage(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ChatCompletionRequestMessageContentPartImageType type = default;
            ChatCompletionRequestMessageContentPartImageImageUrl imageUrl = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    type = new ChatCompletionRequestMessageContentPartImageType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("image_url"u8))
                {
                    imageUrl = ChatCompletionRequestMessageContentPartImageImageUrl.DeserializeChatCompletionRequestMessageContentPartImageImageUrl(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ChatCompletionRequestMessageContentPartImage(type, imageUrl, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ChatCompletionRequestMessageContentPartImage>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChatCompletionRequestMessageContentPartImage>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ChatCompletionRequestMessageContentPartImage)} does not support writing '{options.Format}' format.");
            }
        }

        ChatCompletionRequestMessageContentPartImage IPersistableModel<ChatCompletionRequestMessageContentPartImage>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChatCompletionRequestMessageContentPartImage>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeChatCompletionRequestMessageContentPartImage(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ChatCompletionRequestMessageContentPartImage)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ChatCompletionRequestMessageContentPartImage>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static ChatCompletionRequestMessageContentPartImage FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeChatCompletionRequestMessageContentPartImage(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestBody. </summary>
        internal virtual BinaryContent ToBinaryBody()
        {
            return BinaryContent.Create(this, new ModelReaderWriterOptions("W"));
        }
    }
}
