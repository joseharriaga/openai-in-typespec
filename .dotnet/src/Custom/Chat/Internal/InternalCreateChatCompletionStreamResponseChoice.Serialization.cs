using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Chat;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Chat.InternalCreateChatCompletionStreamResponseChoice>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
internal partial class InternalCreateChatCompletionStreamResponseChoice : IJsonModel<InternalCreateChatCompletionStreamResponseChoice>
{
    // CUSTOM:
    // - Made FinishReason nullable.
    void IJsonModel<InternalCreateChatCompletionStreamResponseChoice>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<InternalCreateChatCompletionStreamResponseChoice>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(InternalCreateChatCompletionStreamResponseChoice)} does not support writing '{format}' format.");
        }

        writer.WriteStartObject();
        writer.WritePropertyName("delta"u8);
        writer.WriteObjectValue(Delta, options);
        if (Optional.IsDefined(Logprobs))
        {
            if (Logprobs != null)
            {
                writer.WritePropertyName("logprobs"u8);
                writer.WriteObjectValue<ChatLogProbabilityInfo>(Logprobs, options);
            }
            else
            {
                writer.WriteNull("logprobs");
            }
        }
        if (Optional.IsDefined(FinishReason))
        {
            if (FinishReason != null)
            {
                writer.WritePropertyName("finish_reason"u8);
                writer.WriteStringValue(FinishReason.Value.ToSerialString());
            }
            else
            {
                writer.WriteNull("finish_reason");
            }
        }
        writer.WritePropertyName("index"u8);
        writer.WriteNumberValue(Index);
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

    internal static InternalCreateChatCompletionStreamResponseChoice DeserializeInternalCreateChatCompletionStreamResponseChoice(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        InternalChatCompletionStreamResponseDelta delta = default;
        ChatLogProbabilityInfo logprobs = default;
        ChatFinishReason? finishReason = default;
        int index = default;
        IDictionary<string, BinaryData> serializedAdditionalRawData = default;
        Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("delta"u8))
            {
                delta = InternalChatCompletionStreamResponseDelta.DeserializeInternalChatCompletionStreamResponseDelta(property.Value, options);
                continue;
            }
            if (property.NameEquals("logprobs"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    logprobs = null;
                    continue;
                }
                logprobs = ChatLogProbabilityInfo.DeserializeChatLogProbabilityInfo(property.Value, options);
                continue;
            }
            if (property.NameEquals("finish_reason"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    finishReason = null;
                    continue;
                }
                finishReason = property.Value.GetString().ToChatFinishReason();
                continue;
            }
            if (property.NameEquals("index"u8))
            {
                index = property.Value.GetInt32();
                continue;
            }
            if (true)
            {
                rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
        }
        serializedAdditionalRawData = rawDataDictionary;
        return new InternalCreateChatCompletionStreamResponseChoice(delta, logprobs, finishReason, index, serializedAdditionalRawData);
    }
}
