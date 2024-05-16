using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants;

public partial class ToolConstraint : IJsonModel<ToolConstraint>
{
    void IJsonModel<ToolConstraint>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        if (_plainTextValue is not null)
        {
            writer.WriteStringValue(_plainTextValue);
        }
        else
        {
            var format = options.Format == "W" ? ((IPersistableModel<ToolConstraint>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ToolConstraint)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(_objectType.ToString());
            if (Optional.IsDefined(_objectFunctionName))
            {
                writer.WritePropertyName("function"u8);
                writer.WriteStartObject();
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(_objectFunctionName);
                writer.WriteEndObject();
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
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

        string plainTextValue = null;
        string objectType = null;
        string objectFunctionName = null;
        IDictionary<string, BinaryData> rawDataDictionary = new ChangeTrackingDictionary<string, BinaryData>();

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        if (element.ValueKind == JsonValueKind.String)
        {
            plainTextValue = element.GetString();
        }
        else
        {
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    objectType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("function"u8))
                {
                    foreach (JsonProperty functionProperty in property.Value.EnumerateObject())
                    {
                        if (functionProperty.NameEquals("name"u8))
                        {
                            objectFunctionName = functionProperty.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
        }

        return new ToolConstraint(plainTextValue, objectType, objectFunctionName, rawDataDictionary);
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
