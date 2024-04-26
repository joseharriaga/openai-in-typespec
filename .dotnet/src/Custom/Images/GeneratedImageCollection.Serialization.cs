using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Images;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Images.GeneratedImageCollection>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
public partial class GeneratedImageCollection : IJsonModel<GeneratedImageCollection>
{
    // CUSTOM:
    // - Serialized the Items property.
    // - Recovered the serialization of _serializedAdditionalRawData. See https://github.com/Azure/autorest.csharp/issues/4636.
    void IJsonModel<GeneratedImageCollection>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<GeneratedImageCollection>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(GeneratedImageCollection)} does not support writing '{format}' format.");
        }

        writer.WriteStartObject();
        writer.WritePropertyName("created"u8);
        writer.WriteNumberValue(CreatedAt, "U");
        writer.WritePropertyName("data"u8);
        writer.WriteStartArray();
        foreach (var item in Items)
        {
            writer.WriteObjectValue<GeneratedImage>(item, options);
        }
        writer.WriteEndArray();
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
    internal static GeneratedImageCollection DeserializeImagesResponse(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= new ModelReaderWriterOptions("W");

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        DateTimeOffset created = default;
        IReadOnlyList<GeneratedImage> data = default;
        IDictionary<string, BinaryData> serializedAdditionalRawData = default;
        Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("created"u8))
            {
                created = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                continue;
            }
            if (property.NameEquals("data"u8))
            {
                List<GeneratedImage> array = new List<GeneratedImage>();
                foreach (var item in property.Value.EnumerateArray())
                {
                    array.Add(GeneratedImage.DeserializeGeneratedImage(item, options));
                }
                data = array;
                continue;
            }
            if (options.Format != "W")
            {
                rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
        }
        serializedAdditionalRawData = rawDataDictionary;
        return new GeneratedImageCollection(created, data, serializedAdditionalRawData);
    }
}
