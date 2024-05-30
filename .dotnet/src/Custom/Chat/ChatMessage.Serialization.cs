using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace OpenAI.Chat;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Chat.ChatMessage>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
public abstract partial class ChatMessage : IJsonModel<ChatMessage>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SerializeContentValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void DeserializeContentValue(JsonProperty property, ref IList<ChatMessageContentPart> content, ModelReaderWriterOptions options = null)
    {
        throw new NotImplementedException();
    }

    void IJsonModel<ChatMessage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, SerializeChatMessage, writer, options);

    internal static void SerializeChatMessage(ChatMessage instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        instance.SerializeChatMessage(writer, options);
    }

    protected virtual void SerializeChatMessage(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    internal static ChatMessage DeserializeChatMessage(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        if (element.TryGetProperty("role", out JsonElement discriminator))
        {
            switch (discriminator.GetString())
            {
                case "assistant": return AssistantChatMessage.DeserializeAssistantChatMessage(element, options);
                case "function": return FunctionChatMessage.DeserializeFunctionChatMessage(element, options);
                case "system": return SystemChatMessage.DeserializeSystemChatMessage(element, options);
                case "tool": return ToolChatMessage.DeserializeToolChatMessage(element, options);
                case "user": return UserChatMessage.DeserializeUserChatMessage(element, options);
            }
        }
        return UnknownChatMessage.DeserializeUnknownChatMessage(element, options);
    }
}
