using OpenAI.Internal.Models;
using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;

namespace OpenAI.Images;

/// <summary>
/// Represents the available output dimensions for generated images.
/// </summary>
public readonly partial struct GeneratedImageSize : IJsonModel<GeneratedImageSize>
{
    GeneratedImageSize IJsonModel<GeneratedImageSize>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IJsonModel<GeneratedImageSize>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(GeneratedImageSize)} does not support '{format}' format.");
        }

        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeGeneratedImageSize(document.RootElement, options).Value;
    }

    GeneratedImageSize IPersistableModel<GeneratedImageSize>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<GeneratedImageSize>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                {
                    using JsonDocument document = JsonDocument.Parse(data);
                    return DeserializeGeneratedImageSize(document.RootElement, options).Value;
                }
            default:
                throw new FormatException($"The model {nameof(GeneratedImageSize)} does not support '{options.Format}' format.");
        }
    }

    string IPersistableModel<GeneratedImageSize>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    void IJsonModel<GeneratedImageSize>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IJsonModel<GeneratedImageSize>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(ChatCompletionFunctionCallOption)} does not support '{format}' format.");
        }
        writer.WriteStringValue($"{Width}x{Height}");
    }

    BinaryData IPersistableModel<GeneratedImageSize>.Write(ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<GeneratedImageSize>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                return ModelReaderWriter.Write(this, options);
            default:
                throw new FormatException($"The model {nameof(GeneratedImageSize)} does not support '{options.Format}' format.");
        }
    }

    internal static GeneratedImageSize? DeserializeGeneratedImageSize(JsonElement element, ModelReaderWriterOptions options = null)
    {
        if (element.ValueKind != JsonValueKind.String)
        {
            return null;
        }
        string[] parts = element.GetString().Split('x');
        if (parts.Length != 2 || !int.TryParse(parts[0], out int width) || !int.TryParse(parts[1], out int height))
        {
            return null;
        }
        return new GeneratedImageSize(width, height);
    }
}