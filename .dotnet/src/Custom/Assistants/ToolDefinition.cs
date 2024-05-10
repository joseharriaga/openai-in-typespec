using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Assistants;

public abstract partial class ToolDefinition : IJsonModel<ToolDefinition>
{
    protected object Type;

    ToolDefinition IJsonModel<ToolDefinition>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    ToolDefinition IPersistableModel<ToolDefinition>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    string IPersistableModel<ToolDefinition>.GetFormatFromOptions(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    void IJsonModel<ToolDefinition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    BinaryData IPersistableModel<ToolDefinition>.Write(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    internal static ToolDefinition DeserializeToolDefinition(JsonElement element, ModelReaderWriterOptions options = null)
    {
        foreach (JsonProperty property in element.EnumerateObject())
        {
            if (property.NameEquals("type"u8))
            {
                return property.Value.GetString() switch
                {
                    "code_interpreter" => CodeInterpreterToolDefinition.DeserializeToolDefinition(element, options),
                    "file_search" => FileSearchToolDefinition.DeserializeFileSearchToolDefinition(element, options),
                    "function" => FunctionToolDefinition.DeserializeToolDefinition(element, options),
                    _ => null,
                };
            }
        }
        return null;
    }
}
