using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Assistants;

public partial class ToolOutput : IJsonModel<ToolOutput>
{
    ToolOutput IJsonModel<ToolOutput>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeToolOutput, ref reader, options);

    ToolOutput IPersistableModel<ToolOutput>.Create(BinaryData data, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeToolOutput, data, options);

    void IJsonModel<ToolOutput>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance(this, SerializeToolOutput, writer, options);

    BinaryData IPersistableModel<ToolOutput>.Write(ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance(this, options);

    string IPersistableModel<ToolOutput>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    internal static ToolOutput DeserializeToolOutput(
        JsonElement element,
        ModelReaderWriterOptions? options = default)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }

        string id = null;
        string output = null;

        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("tool_call_id"u8))
            {
                id = property.Value.ToString();
                continue;
            }
            if (property.NameEquals("output"u8))
            {
                output = property.Value.ToString();
                continue;
            }
        }
        return new ToolOutput(id, output);
    }

    internal static void SerializeToolOutput(ToolOutput instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        if (Optional.IsDefined(instance.Id))
        {
            writer.WriteString("tool_call_id"u8, instance.Id);
        }
        if (Optional.IsDefined(instance.Output))
        {
            writer.WriteString("output"u8, instance.Output);
        }
        writer.WriteEndObject();
    }
}
