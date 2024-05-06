﻿// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Moderations;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Moderations.ModerationCollection>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
public partial class ModerationCollection : IJsonModel<ModerationCollection>
{
    // CUSTOM:
    // - Serialized the Items property.
    // - Recovered the deserialization of _serializedAdditionalRawData. See https://github.com/Azure/autorest.csharp/issues/4636.
    void IJsonModel<ModerationCollection>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ModerationCollection>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(ModerationCollection)} does not support writing '{format}' format.");
        }

        writer.WriteStartObject();
        writer.WritePropertyName("id"u8);
        writer.WriteStringValue(Id);
        writer.WritePropertyName("model"u8);
        writer.WriteStringValue(Model);
        writer.WritePropertyName("results"u8);
        writer.WriteStartArray();
        foreach (var item in Items)
        {
            writer.WriteObjectValue<Moderation>(item, options);
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
    internal static ModerationCollection DeserializeModerationCollection(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        string id = default;
        string model = default;
        IReadOnlyList<Moderation> results = default;
        IDictionary<string, BinaryData> serializedAdditionalRawData = default;
        Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("id"u8))
            {
                id = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("model"u8))
            {
                model = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("results"u8))
            {
                List<Moderation> array = new List<Moderation>();
                foreach (var item in property.Value.EnumerateArray())
                {
                    array.Add(Moderation.DeserializeModeration(item, options));
                }
                results = array;
                continue;
            }
            if (options.Format != "W")
            {
                rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
        }
        serializedAdditionalRawData = rawDataDictionary;
        return new ModerationCollection(id, model, results, serializedAdditionalRawData);
    }
}
