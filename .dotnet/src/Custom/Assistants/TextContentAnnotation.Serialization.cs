using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Assistants;

public abstract partial class TextContentAnnotation : IJsonModel<TextContentAnnotation>
{
    TextContentAnnotation IJsonModel<TextContentAnnotation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeTextContentAnnotation, ref reader, options);

    TextContentAnnotation IPersistableModel<TextContentAnnotation>.Create(BinaryData data, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeTextContentAnnotation, data, options);

    void IJsonModel<TextContentAnnotation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance(this, SerializeTextContentAnnotation, writer, options);

    BinaryData IPersistableModel<TextContentAnnotation>.Write(ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance(this, options);

    string IPersistableModel<TextContentAnnotation>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    internal static TextContentAnnotation DeserializeTextContentAnnotation(
      JsonElement element,
      ModelReaderWriterOptions options = default)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("type"u8))
            {
                if (property.Value.ValueEquals("file_citation"u8))
                {
                    return TextContentFileCitationAnnotation.DeserializeTextContentFileCitationAnnotation(element, options);
                }
                else if (property.Value.ValueEquals("file_path"u8))
                {
                    return TextContentFilePathAnnotation.DeserializeTextContentFilePathAnnotation(element, options);
                }
                else
                {
                    throw new ArgumentException(property.Value.GetString());
                }
            }
        }
        throw new ArgumentException(nameof(element));
    }

    internal static void SerializeTextContentAnnotation(TextContentAnnotation textContentAnnotation, Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        textContentAnnotation.WriteDerived(writer, options);
        writer.WriteEndObject();
    }

    internal abstract void WriteDerived(Utf8JsonWriter writer, ModelReaderWriterOptions options);
}
