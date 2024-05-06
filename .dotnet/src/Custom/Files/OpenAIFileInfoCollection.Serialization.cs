using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Files;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Files.OpenAIFileInfoCollection>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
public partial class OpenAIFileInfoCollection : IJsonModel<OpenAIFileInfoCollection>
{
    // CUSTOM:
    // - Serialized the Items property.
    // - Recovered the serialization of _serializedAdditionalRawData. See https://github.com/Azure/autorest.csharp/issues/4636.
    void IJsonModel<OpenAIFileInfoCollection>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<OpenAIFileInfoCollection>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(OpenAIFileInfoCollection)} does not support writing '{format}' format.");
        }

        writer.WriteStartObject();
        writer.WritePropertyName("data"u8);
        writer.WriteStartArray();
        foreach (var item in Items)
        {
            writer.WriteObjectValue<OpenAIFileInfo>(item, options);
        }
        writer.WriteEndArray();
        writer.WritePropertyName("object"u8);
        writer.WriteStringValue(Object.ToString());
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

    // CUSTOM: Recovered the deserialization of _serializedAdditionalRawData. See https://github.com/Azure/autorest.csharp/issues/4636.
    internal static OpenAIFileInfoCollection DeserializeOpenAIFileInfoCollection(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        IReadOnlyList<OpenAIFileInfo> data = default;
        ListFilesResponseObject @object = default;
        IDictionary<string, BinaryData> serializedAdditionalRawData = default;
        Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("data"u8))
            {
                List<OpenAIFileInfo> array = new List<OpenAIFileInfo>();
                foreach (var item in property.Value.EnumerateArray())
                {
                    array.Add(OpenAIFileInfo.DeserializeOpenAIFileInfo(item, options));
                }
                data = array;
                continue;
            }
            if (property.NameEquals("object"u8))
            {
                @object = new ListFilesResponseObject(property.Value.GetString());
                continue;
            }
            if (options.Format != "W")
            {
                rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
        }
        serializedAdditionalRawData = rawDataDictionary;
        return new OpenAIFileInfoCollection(data, @object, serializedAdditionalRawData);
    }

}
