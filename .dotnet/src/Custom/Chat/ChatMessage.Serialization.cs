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
        => throw new NotImplementedException();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected static void DeserializeContentValue(JsonProperty property, ref IList<ChatMessageContentPart> content, ModelReaderWriterOptions options = null)
    {
        content ??= new ChangeTrackingList<ChatMessageContentPart>();
        if (property.Value.ValueKind == JsonValueKind.String)
        {
            content.Add(ChatMessageContentPart.CreateTextMessageContentPart(property.Value.GetString()));
        }
        else
        {
            foreach (var item in property.Value.EnumerateArray())
            {
                content.Add(ChatMessageContentPart.DeserializeChatMessageContentPart(item, options));
            }
        }
    }

    void IJsonModel<ChatMessage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, SerializeChatMessage, writer, options);

    internal static void SerializeChatMessage(ChatMessage instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => instance.SerializeChatMessage(writer, options);

    protected abstract void SerializeChatMessage(Utf8JsonWriter writer, ModelReaderWriterOptions options);
}
