using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Chat;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Chat.ChatToolChoice>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
public partial class ChatToolChoice : IJsonModel<ChatToolChoice>
{
    void IJsonModel<ChatToolChoice>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        if (_isPlainString)
        {
            writer.WriteStringValue(_string);
        }
        else
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChatToolChoice>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatToolChoice)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(_type.ToString());
            writer.WritePropertyName("function"u8);
            writer.WriteObjectValue(_function, options);
            if (true && _serializedAdditionalRawData != null)
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
    }

    internal static ChatToolChoice DeserializeChatToolChoice(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        else if (element.ValueKind == JsonValueKind.String)
        {
            return new ChatToolChoice(element.ToString());
        }
        else
        {
            InternalChatCompletionNamedToolChoiceType type = default;
            InternalChatCompletionNamedToolChoiceFunction function = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    type = new InternalChatCompletionNamedToolChoiceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("function"u8))
                {
                    function = InternalChatCompletionNamedToolChoiceFunction.DeserializeInternalChatCompletionNamedToolChoiceFunction(property.Value, options);
                    continue;
                }
                if (true)
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ChatToolChoice(function.Name, serializedAdditionalRawData);
        }
    }
}