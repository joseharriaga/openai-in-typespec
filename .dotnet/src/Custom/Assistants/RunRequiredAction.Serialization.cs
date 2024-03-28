using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants;

public abstract partial class RunRequiredAction : IJsonModel<IList<RunRequiredAction>>
{
    IList<RunRequiredAction> IJsonModel<IList<RunRequiredAction>>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeRunRequiredActions, ref reader, options);

    IList<RunRequiredAction> IPersistableModel<IList<RunRequiredAction>>.Create(BinaryData data, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeRunRequiredActions, data, options);

    void IJsonModel<IList<RunRequiredAction>>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance<IList<RunRequiredAction>,RunRequiredAction>(this, SerializeRunRequiredActions, writer, options);

    BinaryData IPersistableModel<IList<RunRequiredAction>>.Write(ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance<IList<RunRequiredAction>,RunRequiredAction>(this, options);

    string IPersistableModel<IList<RunRequiredAction>>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    internal static IList<RunRequiredAction> DeserializeRunRequiredActions(
        JsonElement element,
        ModelReaderWriterOptions? options = default)
    {
        options ??= new ModelReaderWriterOptions("W");

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }

        List<RunRequiredAction> actions = null;

        foreach (var topProperty in element.EnumerateObject())
        {
            if (topProperty.NameEquals("submit_tool_outputs"u8))
            {
                foreach (var submitObjectProperty in topProperty.Value.EnumerateObject())
                {
                    if (submitObjectProperty.NameEquals("tool_calls"u8))
                    {
                        foreach (var toolCallObject in submitObjectProperty.Value.EnumerateArray())
                        {
                            foreach (var toolCallProperty in toolCallObject.EnumerateObject())
                            {
                                if ((toolCallProperty.NameEquals("type"u8) && toolCallProperty.Value.ValueEquals("function"u8))
                                    || (toolCallProperty.NameEquals("function"u8)))
                                {
                                    actions ??= [];
                                    actions.Add(RequiredFunctionToolCall.DeserializeRequiredFunctionToolCall(
                                        toolCallObject,
                                        options));
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
        }

        return actions;
    }

    internal static void SerializeRunRequiredActions(RunRequiredAction runRequiredAction, Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        runRequiredAction.WriteDerived(writer, options);
        writer.WriteEndObject();
    }

    internal abstract void WriteDerived(Utf8JsonWriter writer, ModelReaderWriterOptions options);
}
