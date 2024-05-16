using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Assistants;

public partial class AssistantResponseFormat : IJsonModel<AssistantResponseFormat>
{
    void IJsonModel<AssistantResponseFormat>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        if (_isPlainString)
        {
            writer.WriteStringValue(_value);
        }
        else
        {
            var format = options.Format == "W" ? ((IPersistableModel<AssistantResponseFormat>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AssistantResponseFormat)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(_value);
            writer.WriteEndObject();
        }


    }

    AssistantResponseFormat IJsonModel<AssistantResponseFormat>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<AssistantResponseFormat>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(AssistantResponseFormat)} does not support reading '{format}' format.");
        }

        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeAssistantResponseFormat(document.RootElement, options);
    }

    internal static AssistantResponseFormat DeserializeAssistantResponseFormat(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        string value = null;
        bool isStringLiteral = true;

        if (element.ValueKind == JsonValueKind.String)
        {
            value = element.GetString();
        }
        else
        {
            isStringLiteral = false;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    value = property.Value.GetString();
                    continue;
                }
            }
        }
        return new AssistantResponseFormat(value, isStringLiteral);
    }

    BinaryData IPersistableModel<AssistantResponseFormat>.Write(ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<AssistantResponseFormat>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                return ModelReaderWriter.Write(this, options);
            default:
                throw new FormatException($"The model {nameof(AssistantResponseFormat)} does not support writing '{options.Format}' format.");
        }
    }

    AssistantResponseFormat IPersistableModel<AssistantResponseFormat>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<AssistantResponseFormat>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                {
                    using JsonDocument document = JsonDocument.Parse(data);
                    return DeserializeAssistantResponseFormat(document.RootElement, options);
                }
            default:
                throw new FormatException($"The model {nameof(AssistantResponseFormat)} does not support reading '{options.Format}' format.");
        }
    }

    string IPersistableModel<AssistantResponseFormat>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
}
