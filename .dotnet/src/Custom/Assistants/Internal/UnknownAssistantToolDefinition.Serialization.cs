using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Assistants.ToolDefinition>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
internal partial class UnknownAssistantToolDefinition : IJsonModel<ToolDefinition>
{
    void IJsonModel<ToolDefinition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance<ToolDefinition, UnknownAssistantToolDefinition>(this, SerializeUnknownAssistantToolDefinition, writer, options);

    internal static void SerializeUnknownAssistantToolDefinition(UnknownAssistantToolDefinition instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
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
