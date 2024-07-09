// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI.Assistants;

namespace Azure.AI.OpenAI.Assistants;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.BingSearchToolDefinition>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
public partial class BingSearchToolDefinition : IJsonModel<BingSearchToolDefinition>
{
    void IJsonModel<BingSearchToolDefinition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance<ToolDefinition, BingSearchToolDefinition>(this, SerializeBingSearchToolDefinition, writer, options);

    internal static void SerializeBingSearchToolDefinition(BingSearchToolDefinition instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => instance.WriteCore(writer, options);
    
    protected override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("browser"u8);
        writer.WriteObjectValue<InternalBingSearchToolDefinitionBrowser>(_internalBrowser, options);
        writer.WritePropertyName("type"u8);
        writer.WriteStringValue(Type);
        writer.WriteSerializedAdditionalRawData(_serializedAdditionalRawData, options);
        writer.WriteEndObject();
    }
}