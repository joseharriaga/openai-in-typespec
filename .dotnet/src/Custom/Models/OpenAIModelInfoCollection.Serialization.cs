using OpenAI.Models;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

namespace OpenAI.Models;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Models.OpenAIModelInfoCollection>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
public partial class OpenAIModelInfoCollection : IJsonModel<OpenAIModelInfoCollection>
{
    // CUSTOM:
    // - Serialized the Items property.
    // - Recovered the serialization of _serializedAdditionalRawData. See https://github.com/Azure/autorest.csharp/issues/4636.
    void IJsonModel<OpenAIModelInfoCollection>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<OpenAIModelInfoCollection>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(OpenAIModelInfoCollection)} does not support writing '{format}' format.");
        }

        writer.WriteStartObject();
        writer.WritePropertyName("object"u8);
        writer.WriteStringValue(Object.ToString());
        writer.WritePropertyName("data"u8);
        writer.WriteStartArray();
        foreach (var item in Items)
        {
            writer.WriteObjectValue<OpenAIModelInfo>(item, options);
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
    internal static OpenAIModelInfoCollection DeserializeOpenAIModelInfoCollection(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        ListModelsResponseObject @object = default;
        IReadOnlyList<OpenAIModelInfo> data = default;
        IDictionary<string, BinaryData> serializedAdditionalRawData = default;
        Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("object"u8))
            {
                @object = new ListModelsResponseObject(property.Value.GetString());
                continue;
            }
            if (property.NameEquals("data"u8))
            {
                List<OpenAIModelInfo> array = new List<OpenAIModelInfo>();
                foreach (var item in property.Value.EnumerateArray())
                {
                    array.Add(OpenAIModelInfo.DeserializeOpenAIModelInfo(item, options));
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
        return new OpenAIModelInfoCollection(@object, data, serializedAdditionalRawData);
    }
}