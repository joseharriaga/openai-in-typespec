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

    string IPersistableModel<GeneratedImageCollection>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    void IJsonModel<GeneratedImageCollection>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        ModelSerializationHelpers.AssertSupportedJsonWriteFormat(this, options);
        writer.WriteStartObject();
        writer.WriteNumber("created"u8, CreatedAt.ToUnixTimeSeconds());
        writer.WriteStartArray();
        foreach (GeneratedImage generatedImage in this)
        {
            writer.WriteObjectValue(generatedImage);
        }
        writer.WriteEndArray();
        writer.WriteEndObject();
    }

    BinaryData IPersistableModel<GeneratedImageCollection>.Write(ModelReaderWriterOptions options)
    {
        ModelSerializationHelpers.AssertSupportedPersistableWriteFormat(this, options);
        return ModelReaderWriter.Write(this, options);
    }

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

    internal static GeneratedImageCollection? FromResponse(PipelineResponse response)
    {
        using var document = JsonDocument.Parse(response.Content);
        return DeserializeGeneratedImageCollection(document.RootElement);
    }
}