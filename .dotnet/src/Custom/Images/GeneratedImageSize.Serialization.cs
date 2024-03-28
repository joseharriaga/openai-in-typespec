using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Images;

/// <summary>
/// Represents the available output dimensions for generated images.
/// </summary>
public readonly partial struct GeneratedImageSize : IJsonModel<GeneratedImageSize>
{
    GeneratedImageSize IJsonModel<GeneratedImageSize>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeGeneratedImageSize, ref reader, options);

    GeneratedImageSize IPersistableModel<GeneratedImageSize>.Create(BinaryData data, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeGeneratedImageSize, data, options);

    void IJsonModel<GeneratedImageSize>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance(this, SerializeGeneratedImageSize, writer, options);

    BinaryData IPersistableModel<GeneratedImageSize>.Write(ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance(this, options);

    string IPersistableModel<GeneratedImageSize>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    internal static GeneratedImageSize DeserializeGeneratedImageSize(JsonElement element, ModelReaderWriterOptions options = default)
    {
        if (element.ValueKind != JsonValueKind.String)
        {
            throw new ArgumentException(nameof(element));
        }

        string[] parts = element.GetString()!.Split('x');
        if (parts.Length != 2 || !int.TryParse(parts[0], out int width) || !int.TryParse(parts[1], out int height))
        {
            throw new ArgumentException(nameof(element));
        }
        return new GeneratedImageSize(width, height);
    }

    internal static void SerializeGeneratedImageSize(GeneratedImageSize instance, Utf8JsonWriter writer, ModelReaderWriterOptions _)
        => writer.WriteStringValue($"{instance.Width}x{instance.Height}");
}