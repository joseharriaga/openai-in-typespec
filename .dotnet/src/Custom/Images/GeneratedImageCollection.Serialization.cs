using OpenAI.ClientShared.Internal;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Images;

public partial class GeneratedImageCollection : IJsonModel<GeneratedImageCollection>
{
    GeneratedImageCollection IJsonModel<GeneratedImageCollection>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeGeneratedImageCollection, ref reader, options)!;

    GeneratedImageCollection IPersistableModel<GeneratedImageCollection>.Create(BinaryData data, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeGeneratedImageCollection, data, options);

    void IJsonModel<GeneratedImageCollection>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance(this, SerializeGeneratedImageCollection, writer, options);

    BinaryData IPersistableModel<GeneratedImageCollection>.Write(ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance(this, options);

    string IPersistableModel<GeneratedImageCollection>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    internal static GeneratedImageCollection DeserializeGeneratedImageCollection(JsonElement element, ModelReaderWriterOptions? options = default)
    {
        if (element.ValueKind != JsonValueKind.Object)
        {
            throw new ArgumentException(nameof(element));
        }

        DateTimeOffset? createdAt = null;
        List<GeneratedImage> images = [];

        foreach (JsonProperty property in element.EnumerateObject())
        {
            if (property.NameEquals("created"u8))
            {
                createdAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                continue;
            }
            if (property.NameEquals("data"u8))
            {
                foreach (JsonElement item in property.Value.EnumerateArray())
                {
                    GeneratedImage image = GeneratedImage.DeserializeGeneratedImage(item, options)!;
                    images.Add(image);
                }
                continue;
            }
        }

        foreach (GeneratedImage image in images)
        {
            image.CreatedAt = createdAt!.Value;
        }

        return new GeneratedImageCollection(images, createdAt!.Value);
    }

    internal static GeneratedImageCollection FromResponse(PipelineResponse response)
    {
        using var document = JsonDocument.Parse(response.Content);
        return DeserializeGeneratedImageCollection(document.RootElement);
    }

    internal static void SerializeGeneratedImageCollection(GeneratedImageCollection instance, Utf8JsonWriter writer, ModelReaderWriterOptions _)
    {
        writer.WriteStartObject();
        writer.WriteNumber("created"u8, instance.CreatedAt.ToUnixTimeSeconds());
        writer.WriteStartArray();
        foreach (GeneratedImage generatedImage in instance)
        {
            writer.WriteObjectValue(generatedImage);
        }
        writer.WriteEndArray();
        writer.WriteEndObject();
    }
}