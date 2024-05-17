using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text.Json;

namespace OpenAI.Assistants;

public partial class AssistantResponseFormat : IJsonModel<AssistantResponseFormat>
{
    void IJsonModel<AssistantResponseFormat>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        if (_plainTextValue is not null)
        {
            writer.WriteStringValue(_plainTextValue);
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
            writer.WriteStringValue(_objectType);
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

        string plainTextValue = null;
        string objectType = null;
        IDictionary<string, BinaryData> rawDataDictionary = new ChangeTrackingDictionary<string, BinaryData>();

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        else if (element.ValueKind == JsonValueKind.String)
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
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
        }
        return new AssistantResponseFormat(plainTextValue, objectType, rawDataDictionary);
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
