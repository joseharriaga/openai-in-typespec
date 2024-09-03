// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Chat
{
    [PersistableModelProxy(typeof(InternalUnknownChatResponseFormat))]
    public partial class ChatResponseFormat : IJsonModel<ChatResponseFormat>
    {
        ChatResponseFormat IJsonModel<ChatResponseFormat>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChatResponseFormat>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatResponseFormat)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeChatResponseFormat(document.RootElement, options);
        }

        internal static ChatResponseFormat DeserializeChatResponseFormat(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "json_object": return InternalChatResponseFormatJsonObject.DeserializeInternalChatResponseFormatJsonObject(element, options);
                    case "json_schema": return InternalChatResponseFormatJsonSchema.DeserializeInternalChatResponseFormatJsonSchema(element, options);
                    case "text": return InternalChatResponseFormatText.DeserializeInternalChatResponseFormatText(element, options);
                }
            }
            return InternalUnknownChatResponseFormat.DeserializeInternalUnknownChatResponseFormat(element, options);
        }

        BinaryData IPersistableModel<ChatResponseFormat>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChatResponseFormat>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ChatResponseFormat)} does not support writing '{options.Format}' format.");
            }
        }

        ChatResponseFormat IPersistableModel<ChatResponseFormat>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChatResponseFormat>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeChatResponseFormat(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ChatResponseFormat)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ChatResponseFormat>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static ChatResponseFormat FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeChatResponseFormat(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
