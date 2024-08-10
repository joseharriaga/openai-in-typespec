using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI.Internal;
using OpenAI.Models;

namespace OpenAI.Assistants;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Assistants.AssistantResponseFormat>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Assistants.AssistantResponseFormat>.Create", typeof(Utf8JsonReader), typeof(ModelReaderWriterOptions))]
[CodeGenSuppress("global::System.ClientModel.Primitives.IPersistableModel<OpenAI.Assistants.AssistantResponseFormat>.Write", typeof(ModelReaderWriterOptions))]
[CodeGenSuppress("global::System.ClientModel.Primitives.IPersistableModel<OpenAI.Assistants.AssistantResponseFormat>.Create", typeof(BinaryData), typeof(ModelReaderWriterOptions))]
[CodeGenSuppress("global::System.ClientModel.Primitives.IPersistableModel<OpenAI.Assistants.AssistantResponseFormat>.GetFormatFromOptions", typeof(ModelReaderWriterOptions))]
public partial class AssistantResponseFormat : IJsonModel<AssistantResponseFormat>
{
    internal static void SerializeAssistantResponseFormat(AssistantResponseFormat instance, Utf8JsonWriter writer, ModelReaderWriterOptions options = null)
    {
        if (!string.IsNullOrEmpty(instance._plainTextValue))
        {
            writer.WriteStringValue(instance._plainTextValue);
        }
        else
        {
#if NET6_0_OR_GREATER
            writer.WriteRawValue(instance._binaryValue);
#else
            using JsonDocument document = JsonDocument.Parse(instance._binaryValue);
            document.RootElement.WriteTo(writer);
#endif
        }
    }

    internal static AssistantResponseFormat DeserializeAssistantResponseFormat(JsonElement element, ModelReaderWriterOptions options = null)
    {
        return element.ValueKind switch
        {
            JsonValueKind.String => new(element.GetString()),
            JsonValueKind.Object => new(BinaryData.FromObjectAsJson(element)),
            _ => null,
        };
    }

    AssistantResponseFormat IJsonModel<AssistantResponseFormat>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.DeserializeNewInstance(this, DeserializeAssistantResponseFormat, ref reader, options);

    AssistantResponseFormat IPersistableModel<AssistantResponseFormat>.Create(BinaryData data, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.DeserializeNewInstance(this, DeserializeAssistantResponseFormat, data, options);

    string IPersistableModel<AssistantResponseFormat>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    void IJsonModel<AssistantResponseFormat>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, SerializeAssistantResponseFormat, writer, options);

    BinaryData IPersistableModel<AssistantResponseFormat>.Write(ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, options);
}