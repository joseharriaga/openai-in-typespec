using OpenAI.ClientShared.Internal;
using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Images;

public partial class GeneratedImage : IJsonModel<GeneratedImage>
{
    GeneratedImage IJsonModel<GeneratedImage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeGeneratedImage, ref reader, options);

    GeneratedImage IPersistableModel<GeneratedImage>.Create(BinaryData data, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeGeneratedImage, data, options);

    string IPersistableModel<GeneratedImage>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    void IJsonModel<GeneratedImage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        ModelSerializationHelpers.AssertSupportedJsonWriteFormat(this, options);
        writer.WriteStartObject();
        if (Optional.IsDefined(ImageBytes))
        {
            string base64Image = Convert.ToBase64String(ImageBytes!.ToArray());
            writer.WriteString("b64_json"u8, base64Image);
        }
        if (Optional.IsDefined(ImageUri))
        {
            writer.WriteString("url"u8, ImageUri!.AbsoluteUri);
        }
        if (Optional.IsDefined(RevisedPrompt))
        {
            writer.WriteString("revised_prompt"u8, RevisedPrompt!);
        }
        writer.WriteEndObject();
    }

    BinaryData IPersistableModel<GeneratedImage>.Write(ModelReaderWriterOptions options)
    {
        ModelSerializationHelpers.AssertSupportedPersistableWriteFormat(this, options);
        return ModelReaderWriter.Write(this, options);
    }

    internal static GeneratedImage DeserializeGeneratedImage(JsonElement element, ModelReaderWriterOptions? options = default)
    {
        if (element.ValueKind != JsonValueKind.Object)
        {
            throw new ArgumentException(nameof(element));
        }

        BinaryData? b64Json = null;
        Uri? uri = null;
        string? revisedPrompt = null;

        foreach (JsonProperty property in element.EnumerateObject())
        {
            if (property.NameEquals("b64_json"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                b64Json = BinaryData.FromBytes(property.Value.GetBytesFromBase64("D")!);
                continue;
            }
            if (property.NameEquals("url"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                uri = new Uri(property.Value.GetString());
                continue;
            }
            if (property.NameEquals("revised_prompt"u8))
            {
                revisedPrompt = property.Value.GetString();
                continue;
            }
        }

        return new GeneratedImage(createdAt: default, uri, b64Json, revisedPrompt);
    }
}