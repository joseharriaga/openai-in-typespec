using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace OpenAI.Chat;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Chat.InternalChatCompletionResponseMessage>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
internal partial class InternalChatCompletionResponseMessage : IJsonModel<InternalChatCompletionResponseMessage>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SerializeContentValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void DeserializeContentValue(JsonProperty property, ref IReadOnlyList<ChatMessageContentPart> content, ModelReaderWriterOptions options = null)
    {
        throw new NotImplementedException();
    }

    void IJsonModel<InternalChatCompletionResponseMessage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<InternalChatCompletionResponseMessage>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(InternalChatCompletionResponseMessage)} does not support writing '{format}' format.");
        }

        writer.WriteStartObject();
        if (Optional.IsCollectionDefined(Content))
        {
            if (Content[0] != null)
            {
                writer.WritePropertyName("content"u8);
                writer.WriteStringValue(Content[0].Text);
            }
            else
            {
                writer.WriteNull("content");
            }
        }
        if (Optional.IsCollectionDefined(ToolCalls))
        {
            writer.WritePropertyName("tool_calls"u8);
            writer.WriteStartArray();
            foreach (var item in ToolCalls)
            {
                writer.WriteObjectValue(item, options);
            }
            writer.WriteEndArray();
        }
        writer.WritePropertyName("role"u8);
        writer.WriteStringValue(Role.ToSerialString());
        if (Optional.IsDefined(FunctionCall))
        {
            writer.WritePropertyName("function_call"u8);
            writer.WriteObjectValue<ChatFunctionCall>(FunctionCall, options);
        }
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

    internal static InternalChatCompletionResponseMessage DeserializeInternalChatCompletionResponseMessage(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        IReadOnlyList<ChatMessageContentPart> content = default;
        IReadOnlyList<ChatToolCall> toolCalls = default;
        ChatMessageRole role = default;
        ChatFunctionCall functionCall = default;
        IDictionary<string, BinaryData> serializedAdditionalRawData = default;
        Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("content"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                List<ChatMessageContentPart> array = new List<ChatMessageContentPart>();
                array.Add(ChatMessageContentPart.CreateTextMessageContentPart(property.Value.GetString()));
                content = array;
                continue;
            }
            if (property.NameEquals("tool_calls"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                List<ChatToolCall> array = new List<ChatToolCall>();
                foreach (var item in property.Value.EnumerateArray())
                {
                    array.Add(ChatToolCall.DeserializeChatToolCall(item, options));
                }
                toolCalls = array;
                continue;
            }
            if (property.NameEquals("role"u8))
            {
                role = property.Value.GetString().ToChatMessageRole();
                continue;
            }
            if (property.NameEquals("function_call"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                functionCall = ChatFunctionCall.DeserializeChatFunctionCall(property.Value, options);
                continue;
            }
            if (true)
            {
                rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
        }
        serializedAdditionalRawData = rawDataDictionary;
        return new InternalChatCompletionResponseMessage(content ?? new ChangeTrackingList<ChatMessageContentPart>(), toolCalls ?? new ChangeTrackingList<ChatToolCall>(), role, functionCall, serializedAdditionalRawData);
    }
}
