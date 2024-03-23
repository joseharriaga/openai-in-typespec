using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Assistants;

public abstract partial class ToolDefinition :  IJsonModel<ToolDefinition>
{
    ToolDefinition IJsonModel<ToolDefinition>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeToolDefinition, ref reader, options);

    ToolDefinition IPersistableModel<ToolDefinition>.Create(BinaryData data, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeToolDefinition, data, options);

    string IPersistableModel<ToolDefinition>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    void IJsonModel<ToolDefinition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        ModelSerializationHelpers.AssertSupportedJsonWriteFormat(this, options);
        writer.WriteStartObject();
        WriteDerived(writer, options);
        writer.WriteEndObject();
    }

    BinaryData IPersistableModel<ToolDefinition>.Write(ModelReaderWriterOptions options)
    {
        ModelSerializationHelpers.AssertSupportedPersistableWriteFormat(this, options);
        return ModelReaderWriter.Write(this, options);
    }

    internal abstract void WriteDerived(Utf8JsonWriter writer, ModelReaderWriterOptions options);

    internal static ToolDefinition DeserializeToolDefinition(
        JsonElement element,
        ModelReaderWriterOptions? options = default)
    {
        options ??= new ModelReaderWriterOptions("W");

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("type"u8))
            {
                if (property.Value.ValueEquals("code_interpreter"u8))
                {
                    return CodeInterpreterToolDefinition.DeserializeCodeInterpreterToolDefinition(element, options);
                }
                else if (property.Value.ValueEquals("retrieval"u8))
                {
                    return RetrievalToolDefinition.DeserializeRetrievalToolDefinition(element, options);
                }
                else if (property.Value.ValueEquals("function"u8))
                {
                    return FunctionToolDefinition.DeserializeFunctionToolDefinition(element, options);
                }
                else
                {
                    throw new ArgumentException(property.Value.GetString());
                }
            }
        }
        throw new ArgumentException(nameof(element));
    }

}
