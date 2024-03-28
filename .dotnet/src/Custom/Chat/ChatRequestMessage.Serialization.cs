using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Chat;

public abstract partial class ChatRequestMessage : IJsonModel<ChatRequestMessage>
{
    ChatRequestMessage IJsonModel<ChatRequestMessage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeChatRequestMessage, ref reader, options);

    ChatRequestMessage IPersistableModel<ChatRequestMessage>.Create(BinaryData data, ModelReaderWriterOptions options)
    => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeChatRequestMessage, data, options);

    void IJsonModel<ChatRequestMessage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance(this, SerializeChatRequestMessage, writer, options);

    BinaryData IPersistableModel<ChatRequestMessage>.Write(ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance(this, options);

    string IPersistableModel<ChatRequestMessage>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    internal static ChatRequestMessage DeserializeChatRequestMessage(JsonElement element, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    internal static void SerializeChatRequestMessage(ChatRequestMessage instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("role"u8, instance.Role switch
        {
            ChatRole.System => "system",
            ChatRole.User => "user",
            ChatRole.Assistant => "assistant",
            ChatRole.Tool => "tool",
            ChatRole.Function => "function",
            _ => throw new ArgumentException(nameof(instance.Role))
        });
        if (Optional.IsDefined(instance.Content))
        {
            writer.WritePropertyName("content"u8);
            if (instance.Content.Span.Length == 0)
            {
                writer.WriteNullValue();
            }
            else if (instance.Content.Span.Length == 1)
            {
                if (instance.Content.Span[0].ContentKind == ChatMessageContentKind.Text)
                {
                    writer.WriteStringValue(instance.Content.Span[0].ToText());
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            else if (instance.Content.Span.Length > 1)
            {
                writer.WriteStartArray();
                foreach (ChatMessageContent contentItem in instance.Content.Span)
                {
                    writer.WriteStartObject();
                    if (contentItem.ContentKind == ChatMessageContentKind.Text)
                    {
                        writer.WriteString("type"u8, "text"u8);
                        writer.WriteString("text"u8, contentItem.ToText());
                    }
                    else if (contentItem.ContentKind == ChatMessageContentKind.Image)
                    {
                        writer.WriteString("type"u8, "image_url"u8);
                        writer.WritePropertyName("image_url"u8);
                        writer.WriteStartObject();
                        writer.WriteString("url"u8, contentItem.ToUri().AbsoluteUri);
                        writer.WriteEndObject();
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
            }
        }
        instance.WriteDerivedAdditions(writer, options);
        writer.WriteEndObject();
    }

    internal abstract void WriteDerivedAdditions(Utf8JsonWriter writer, ModelReaderWriterOptions options);
}
