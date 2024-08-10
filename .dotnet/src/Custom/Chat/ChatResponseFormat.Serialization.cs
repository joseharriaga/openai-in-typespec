using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI.Internal;
using OpenAI.Models;

namespace OpenAI.Chat;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Chat.ChatResponseFormat>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Chat.ChatResponseFormat>.Create", typeof(Utf8JsonReader), typeof(ModelReaderWriterOptions))]
[CodeGenSuppress("global::System.ClientModel.Primitives.IPersistableModel<OpenAI.Chat.ChatResponseFormat>.Write", typeof(ModelReaderWriterOptions))]
[CodeGenSuppress("global::System.ClientModel.Primitives.IPersistableModel<OpenAI.Chat.ChatResponseFormat>.Create", typeof(BinaryData), typeof(ModelReaderWriterOptions))]
[CodeGenSuppress("global::System.ClientModel.Primitives.IPersistableModel<OpenAI.Chat.ChatResponseFormat>.GetFormatFromOptions", typeof(ModelReaderWriterOptions))]
public partial class ChatResponseFormat : IJsonModel<ChatResponseFormat>
{
    internal static void SerializeChatResponseFormat(ChatResponseFormat instance, Utf8JsonWriter writer, ModelReaderWriterOptions options = null)
    {
#if NET6_0_OR_GREATER
        writer.WriteRawValue(instance._binaryValue);
#else
        using JsonDocument document = JsonDocument.Parse(instance._binaryValue);
        document.RootElement.WriteTo(writer);
#endif
    }

    internal static ChatResponseFormat DeserializeChatResponseFormat(JsonElement element, ModelReaderWriterOptions options = null)
    {
        return element.ValueKind switch
        {
            JsonValueKind.String => BinaryData.FromString(element.GetString()),
            JsonValueKind.Object => BinaryData.FromObjectAsJson(element),
            _ => null,
        };
    }

    ChatResponseFormat IJsonModel<ChatResponseFormat>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.DeserializeNewInstance(this, DeserializeChatResponseFormat, ref reader, options);

    ChatResponseFormat IPersistableModel<ChatResponseFormat>.Create(BinaryData data, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.DeserializeNewInstance(this, DeserializeChatResponseFormat, data, options);

    string IPersistableModel<ChatResponseFormat>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    void IJsonModel<ChatResponseFormat>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, SerializeChatResponseFormat, writer, options);

    BinaryData IPersistableModel<ChatResponseFormat>.Write(ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, options);
}