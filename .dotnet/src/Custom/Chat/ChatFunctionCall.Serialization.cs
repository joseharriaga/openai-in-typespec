using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Chat;

public partial class ChatFunctionCall : IJsonModel<ChatFunctionCall>
{
    ChatFunctionCall IJsonModel<ChatFunctionCall>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeChatFunctionCall, ref reader, options);

    ChatFunctionCall IPersistableModel<ChatFunctionCall>.Create(BinaryData data, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeChatFunctionCall, data, options);

    void IJsonModel<ChatFunctionCall>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance(this, SerializeChatFunctionCall, writer, options);

    BinaryData IPersistableModel<ChatFunctionCall>.Write(ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance(this, options);

    string IPersistableModel<ChatFunctionCall>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    internal static ChatFunctionCall DeserializeChatFunctionCall(JsonElement element, ModelReaderWriterOptions options)
    {
        if (element.ValueKind != JsonValueKind.Object)
        {
            return null;
        }

        string functionName = null;
        string arguments = null;

        foreach (JsonProperty property in element.EnumerateObject())
        {
            if (property.NameEquals("name"u8))
            {
                functionName = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("arguments"u8))
            {
                arguments = property.Value.GetString();
                continue;
            }
        }
        return new ChatFunctionCall(functionName, arguments);
    }

    internal static void SerializeChatFunctionCall(ChatFunctionCall instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("name"u8, instance.FunctionName);
        writer.WriteString("arguments"u8, instance.Arguments);
        writer.WriteEndObject();
    }
}
