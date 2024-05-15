using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Assistants;

public partial class ToolConstraint : IJsonModel<ToolConstraint>
{
    void IJsonModel<ToolConstraint>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ToolConstraint>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(ToolConstraint)} does not support writing '{format}' format.");
        }

        if (!string.IsNullOrEmpty(_predefinedValue))
        {
            writer.WriteStringValue(_predefinedValue);
        }
        else
        {
            writer.WriteObjectValue(_innerTypeObject, options);
        }
    }

    ToolConstraint IJsonModel<ToolConstraint>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ToolConstraint>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(ToolConstraint)} does not support reading '{format}' format.");
        }

        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeToolConstraint(document.RootElement, options);
    }

    internal static ToolConstraint DeserializeToolConstraint(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        string value = null;
        bool isPredefined = true;

        if (element.ValueKind == JsonValueKind.String)
        {
            value = element.GetString();
        }
        else
        {
            isPredefined = false;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    value = property.Value.GetString();
                    continue;
                }
            }
        }

        return new ToolConstraint(value, isPredefined);
    }

    BinaryData IPersistableModel<ToolConstraint>.Write(ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ToolConstraint>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                return ModelReaderWriter.Write(this, options);
            default:
                throw new FormatException($"The model {nameof(ToolConstraint)} does not support writing '{options.Format}' format.");
        }
    }

    ToolConstraint IPersistableModel<ToolConstraint>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ToolConstraint>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                {
                    using JsonDocument document = JsonDocument.Parse(data);
                    return DeserializeToolConstraint(document.RootElement, options);
                }
            default:
                throw new FormatException($"The model {nameof(ToolConstraint)} does not support reading '{options.Format}' format.");
        }
    }

    string IPersistableModel<ToolConstraint>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
}
