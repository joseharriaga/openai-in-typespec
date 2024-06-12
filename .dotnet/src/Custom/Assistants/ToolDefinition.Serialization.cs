using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace OpenAI.Assistants;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Assistants.ToolDefinition>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
public abstract partial class ToolDefinition : IJsonModel<ToolDefinition>
{
    void IJsonModel<ToolDefinition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, SerializeToolDefinition, writer, options);

    internal static void SerializeToolDefinition(ToolDefinition instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => instance.SerializeToolDefinition(writer, options);

    protected abstract void SerializeToolDefinition(Utf8JsonWriter writer, ModelReaderWriterOptions options);
}