using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Assistants;

public abstract partial class MessageContent : IJsonModel<MessageContent>
{
    MessageContent IJsonModel<MessageContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeMessageContent, ref reader, options);

    MessageContent IPersistableModel<MessageContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeMessageContent, data, options);

    void IJsonModel<MessageContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance(this, SerializeMessageContent, writer, options);

    BinaryData IPersistableModel<MessageContent>.Write(ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance(this, options);

    string IPersistableModel<MessageContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    internal static MessageContent DeserializeMessageContent(JsonElement element, ModelReaderWriterOptions options)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("type"u8))
            {
                if (property.Value.ValueEquals("text"u8))
                {
                    return MessageTextContent.DeserializeMessageTextContent(element, options);
                }
                else if (property.Value.ValueEquals("image_file"u8))
                {
                    return MessageImageFileContent.DeserializeMessageImageFileContent(element, options);
                }
                else
                {
                    throw new ArgumentException(property.Value.GetString());
                }
            }
        }
        throw new ArgumentException(nameof(element));
    }

    internal static void SerializeMessageContent(MessageContent instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        instance.WriteDerived(writer, options);
        writer.WriteEndObject();
    }

    internal abstract void WriteDerived(Utf8JsonWriter writer, ModelReaderWriterOptions options);
}
