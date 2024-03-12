using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Chat;

public partial class ChatFunctionConstraint : IJsonModel<ChatFunctionConstraint>
{
    ChatFunctionConstraint IJsonModel<ChatFunctionConstraint>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatFunctionConstraint>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(ChatFunctionConstraint)} does not support '{format}' format.");
        }

        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeChatFunctionConstraint(document.RootElement, options);
    }

    ChatFunctionConstraint IPersistableModel<ChatFunctionConstraint>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatFunctionConstraint>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                {
                    using JsonDocument document = JsonDocument.Parse(data);
                    return DeserializeChatFunctionConstraint(document.RootElement, options);
                }
            default:
                throw new FormatException($"The model {nameof(ChatFunctionConstraint)} does not support '{options.Format}' format.");
        }
    }

    string IPersistableModel<ChatFunctionConstraint>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    void IJsonModel<ChatFunctionConstraint>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatFunctionConstraint>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(ChatFunctionConstraint)} does not support '{format}' format.");
        }

        if (_isPredefined)
        {
            writer.WriteStringValue(_value);
        }
        else
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(_value);
            writer.WriteEndObject();
        }
    }

    BinaryData IPersistableModel<ChatFunctionConstraint>.Write(ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatFunctionConstraint>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                return ModelReaderWriter.Write(this, options);
            default:
                throw new FormatException($"The model {nameof(ChatFunctionConstraint)} does not support '{options.Format}' format.");
        }
    }

    internal static ChatFunctionConstraint DeserializeChatFunctionConstraint(JsonElement element, ModelReaderWriterOptions options)
    {
        if (element.ValueKind == JsonValueKind.String)
        {
            return new ChatFunctionConstraint(element.GetString(), isPredefined: true);
        }

        string functionName = null;

        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("name"u8))
            {
                functionName = property.Value.GetString();
                continue;
            }
        }

        return new ChatFunctionConstraint(functionName);
    }
}
