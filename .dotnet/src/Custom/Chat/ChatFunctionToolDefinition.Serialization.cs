using System;
using OpenAI.ClientShared.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Chat;

public partial class ChatFunctionToolDefinition : IJsonModel<ChatFunctionToolDefinition>
{
    void IJsonModel<ChatFunctionToolDefinition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatFunctionToolDefinition>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(ChatFunctionToolDefinition)} does not support '{format}' format.");
        }
        writer.WriteStartObject();
        writer.WriteString("type"u8, "function"u8);
        writer.WritePropertyName("function"u8);
        writer.WriteStartObject();
        writer.WriteString("name"u8, Name);
        if (!string.IsNullOrEmpty(Description))
        {
            writer.WriteString("description"u8, Description);
        }
        if (OptionalProperty.IsDefined(Parameters))
        {
            writer.WritePropertyName("parameters"u8);
            writer.WriteRawValue(Parameters);
        }
        writer.WriteEndObject();
        writer.WriteEndObject();
    }

    ChatFunctionToolDefinition IJsonModel<ChatFunctionToolDefinition>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatFunctionToolDefinition>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(ChatFunctionToolDefinition)} does not support '{format}' format.");
        }

        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeChatFunctionToolDefinition(document.RootElement, options);
    }

    BinaryData IPersistableModel<ChatFunctionToolDefinition>.Write(ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatFunctionToolDefinition>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                return ModelReaderWriter.Write(this, options);
            default:
                throw new FormatException($"The model {nameof(ChatFunctionToolDefinition)} does not support '{options.Format}' format.");
        }
    }

    ChatFunctionToolDefinition IPersistableModel<ChatFunctionToolDefinition>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatFunctionToolDefinition>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                {
                    using JsonDocument document = JsonDocument.Parse(data);
                    return DeserializeChatFunctionToolDefinition(document.RootElement, options);
                }
            default:
                throw new FormatException($"The model {nameof(ChatFunctionToolDefinition)} does not support '{options.Format}' format.");
        }
    }

    string IPersistableModel<ChatFunctionToolDefinition>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    internal static ChatFunctionToolDefinition DeserializeChatFunctionToolDefinition(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= new ModelReaderWriterOptions("W");

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }

        throw new NotImplementedException();
    }
}
