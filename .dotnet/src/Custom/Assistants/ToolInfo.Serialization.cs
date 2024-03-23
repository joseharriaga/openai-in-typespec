using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Assistants;

public abstract partial class ToolInfo :  IJsonModel<ToolInfo>
{
    ToolInfo IJsonModel<ToolInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeToolInfo, ref reader, options);

    ToolInfo IPersistableModel<ToolInfo>.Create(BinaryData data, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeToolInfo, data, options);

    string IPersistableModel<ToolInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    void IJsonModel<ToolInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        ModelSerializationHelpers.AssertSupportedJsonWriteFormat(this, options);
        writer.WriteStartObject();
        WriteDerived(writer, options);
        writer.WriteEndObject();
    }

    BinaryData IPersistableModel<ToolInfo>.Write(ModelReaderWriterOptions options)
    {
        ModelSerializationHelpers.AssertSupportedPersistableWriteFormat(this, options);
        return ModelReaderWriter.Write(this, options);
    }

    internal abstract void WriteDerived(Utf8JsonWriter writer, ModelReaderWriterOptions options);

    internal static ToolInfo DeserializeToolInfo(
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
                    return CodeInterpreterToolInfo.DeserializeCodeInterpreterToolInfo(element, options);
                }
                else if (property.Value.ValueEquals("retrieval"u8))
                {
                    return RetrievalToolInfo.DeserializeRetrievalToolInfo(element, options);
                }
                else if (property.Value.ValueEquals("function"u8))
                {
                    return FunctionToolInfo.DeserializeFunctionToolInfo(element, options);
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
