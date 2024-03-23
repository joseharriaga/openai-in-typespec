using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Assistants;

public partial class ToolOutput :  IJsonModel<ToolOutput>
{
    ToolOutput IJsonModel<ToolOutput>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeToolOutput, ref reader, options);

    ToolOutput IPersistableModel<ToolOutput>.Create(BinaryData data, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeToolOutput, data, options);

    string IPersistableModel<ToolOutput>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    void IJsonModel<ToolOutput>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        ModelSerializationHelpers.AssertSupportedJsonWriteFormat(this, options);
        writer.WriteStartObject();
        if (Optional.IsDefined(Id))
        {
            writer.WriteString("tool_call_id"u8, Id);
        }
        if (Optional.IsDefined(Output))
        {
            writer.WriteString("output"u8, Output);
        }
        writer.WriteEndObject();
    }

    BinaryData IPersistableModel<ToolOutput>.Write(ModelReaderWriterOptions options)
    {
        ModelSerializationHelpers.AssertSupportedPersistableWriteFormat(this, options);
        return ModelReaderWriter.Write(this, options);
    }

    internal static ToolOutput DeserializeToolOutput(
        JsonElement element,
        ModelReaderWriterOptions? options = default)
    {
        options ??= new ModelReaderWriterOptions("W");

        string id = null;
        string output = null;

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
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
}
