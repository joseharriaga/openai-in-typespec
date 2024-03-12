using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Chat;

public partial class ChatToolConstraint : IJsonModel<ChatToolConstraint>
{
    ChatToolConstraint IJsonModel<ChatToolConstraint>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatToolConstraint>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(ChatToolConstraint)} does not support '{format}' format.");
        }

        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeChatToolConstraint(document.RootElement, options);
    }

    ChatToolConstraint IPersistableModel<ChatToolConstraint>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatToolConstraint>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                {
                    using JsonDocument document = JsonDocument.Parse(data);
                    return DeserializeChatToolConstraint(document.RootElement, options);
                }
            default:
                throw new FormatException($"The model {nameof(ChatToolConstraint)} does not support '{options.Format}' format.");
        }
    }

    string IPersistableModel<ChatToolConstraint>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    void IJsonModel<ChatToolConstraint>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatToolConstraint>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(ChatToolConstraint)} does not support '{format}' format.");
        }

        writer.WriteRawValue(_serializableData);
    }

    BinaryData IPersistableModel<ChatToolConstraint>.Write(ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatToolConstraint>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                return ModelReaderWriter.Write(this, options);
            default:
                throw new FormatException($"The model {nameof(ChatToolConstraint)} does not support '{options.Format}' format.");
        }
    }

    internal static ChatToolConstraint DeserializeChatToolConstraint(JsonElement element, ModelReaderWriterOptions options)
    {
        if (element.ValueKind == JsonValueKind.String)
        {
            return new ChatToolConstraint(predefinedLabel: element.GetString());
        }

        string functionName = null;

        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("function"u8))
            {
                foreach (JsonProperty functionProperty in property.Value.EnumerateObject())
                {
                    if (functionProperty.NameEquals("name"u8))
                    {
                        functionName = functionProperty.Value.GetString();
                        continue;
                    }
                }
            }
        }

        return new ChatToolConstraint(new ChatFunctionToolDefinition(functionName));
    }
}
