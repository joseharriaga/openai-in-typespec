using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace OpenAI.Chat;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Chat.AssistantChatMessage>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
public partial class AssistantChatMessage : IJsonModel<AssistantChatMessage>
{
    void IJsonModel<AssistantChatMessage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, SerializeAssistantChatMessage, writer, options);

    internal static void SerializeAssistantChatMessage(AssistantChatMessage instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => instance.WriteCore(writer, options);

    internal override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("role"u8);
        writer.WriteStringValue(Role.ToSerialString());

        // Content is optional, can be a single string or a collection of ChatMessageContentPart.
        if (Optional.IsDefined(Content) && Content.IsInnerCollectionDefined() && Content.Count > 0)
        {
            // AssistantChatMessage contrives a ChatMessageContent instance to expose the otherwise unrelated audio
            // information as multimodal content. For serialization, we need to ensure the underlying, non-projected
            // representation is populated.
            if (Audio is null)
            {
                ChatMessageContentPart audioReferenceContentPart
                    = Content.FirstOrDefault(contentPart => !string.IsNullOrEmpty(contentPart.AudioCorrelationId));
                if (audioReferenceContentPart is not null)
                {
                    Audio = new(audioReferenceContentPart.AudioCorrelationId);
                }
            }

            if (Content.Any(contentPart => !contentPart.IsContrived))
            {
                writer.WritePropertyName("content"u8);
                if (Content.Count == 1 && Content[0].Text != null)
                {
                    writer.WriteStringValue(Content[0].Text);
                }
                else
                {
                    writer.WriteStartArray();
                    foreach (ChatMessageContentPart part in Content)
                    {
                        if (!part.IsContrived)
                        {
                            writer.WriteObjectValue(part, options);
                        }
                    }
                    writer.WriteEndArray();
                }
            }
        }

        writer.WriteOptionalProperty("refusal"u8, Refusal, options);
        writer.WriteOptionalProperty("name"u8, ParticipantName, options);
        writer.WriteOptionalCollection("tool_calls"u8, ToolCalls, options);
        writer.WriteOptionalProperty("function_call"u8, FunctionCall, options);
        writer.WriteOptionalProperty("audio"u8, Audio, options);
        writer.WriteSerializedAdditionalRawData(SerializedAdditionalRawData, options);
        writer.WriteEndObject();
    }

    internal static AssistantChatMessage DeserializeAssistantChatMessage(JsonElement element, ModelReaderWriterOptions options = null)
    {
        string refusal = default;
        string name = default;
        InternalChatCompletionRequestAssistantMessageAudio audio = default;
        IList<ChatToolCall> toolCalls = default;
        ChatFunctionCall functionCall = default;
        ChatMessageRole role = default;
        ChatMessageContent content = default;
        IDictionary<string, BinaryData> serializedAdditionalRawData = default;
        Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("refusal"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    refusal = null;
                    continue;
                }
                refusal = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("name"u8))
            {
                name = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("audio"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    audio = null;
                    continue;
                }
                audio = InternalChatCompletionRequestAssistantMessageAudio.DeserializeInternalChatCompletionRequestAssistantMessageAudio(property.Value, options);
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
            if (property.NameEquals("function_call"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    functionCall = null;
                    continue;
                }
                functionCall = ChatFunctionCall.DeserializeChatFunctionCall(property.Value, options);
                continue;
            }
            if (property.NameEquals("role"u8))
            {
                role = property.Value.GetString().ToChatMessageRole();
                continue;
            }
            if (property.NameEquals("content"u8))
            {
                DeserializeContentValue(property, ref content);
                continue;
            }
            if (true)
            {
                rawDataDictionary ??= new Dictionary<string, BinaryData>();
                rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
        }
        serializedAdditionalRawData = rawDataDictionary;
        // CUSTOM: Initialize Content collection property.
        //         If applicable, prepend a contrived content part representing an ID-based audio reference.
        content ??= new();
        if (audio is not null)
        {
            content.Insert(0, new ChatMessageContentPart(ChatMessageContentPartKind.Audio, audioReference: new(audio.Id)));
        }
        return new AssistantChatMessage(
            role,
            content,
            serializedAdditionalRawData,
            refusal,
            name,
            audio,
            toolCalls ?? new ChangeTrackingList<ChatToolCall>(),
            functionCall);
    }
}
