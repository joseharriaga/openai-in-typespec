using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Chat;

public abstract partial class ChatToolCall : IJsonModel<ChatToolCall>
{
    ChatToolCall IJsonModel<ChatToolCall>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeChatToolCall, ref reader, options);

    ChatToolCall IPersistableModel<ChatToolCall>.Create(BinaryData data, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeChatToolCall, data, options);

    void IJsonModel<ChatToolCall>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance(this, SerializeChatToolCall, writer, options);

    BinaryData IPersistableModel<ChatToolCall>.Write(ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance(this, options);

    string IPersistableModel<ChatToolCall>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    internal static ChatToolCall DeserializeChatToolCall(JsonElement element, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    internal static void SerializeChatToolCall(ChatToolCall instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("id"u8, instance.Id);
        instance.WriteDerivedAdditions(writer, options);
        writer.WriteEndObject();
    }

    internal abstract void WriteDerivedAdditions(Utf8JsonWriter writer, ModelReaderWriterOptions options);
}