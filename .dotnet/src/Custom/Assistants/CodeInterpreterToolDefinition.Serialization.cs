using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Assistants.CodeInterpreterToolDefinition>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
public partial class CodeInterpreterToolDefinition : IJsonModel<CodeInterpreterToolDefinition>
{
    void IJsonModel<CodeInterpreterToolDefinition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, SerializeCodeInterpreterToolDefinition, writer, options);

    internal static void SerializeCodeInterpreterToolDefinition(CodeInterpreterToolDefinition instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => instance.SerializeToolDefinition(writer, options);

    protected override void SerializeToolDefinition(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("type"u8);
        writer.WriteStringValue(Type);
        writer.WriteSerializedAdditionalRawData(_serializedAdditionalRawData, options);
        writer.WriteEndObject();
    }
}