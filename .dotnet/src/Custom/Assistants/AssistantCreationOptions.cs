using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI.Assistants;

// namespace OpenAI.Assistants;
namespace OpenAI.Internal.Models;

/// <summary>
/// Represents additional options available when creating a new <see cref="Assistant"/>.
/// </summary>
[CodeGenModel("CreateAssistantRequest")]
[CodeGenSerialization(nameof(InternalToolElementRouter), SerializationValueHook = nameof(SerializeTools),
DeserializationValueHook = nameof(DeserializeTools))]
internal partial class AssistantCreationOptions
{
    [CodeGenMember("Tools")]
    private IList<JsonElement> InternalToolElementRouter
    {
        get => [];
        set
        {
            foreach (JsonElement element in value)
            {
                Tools.Add(ToolDefinition.DeserializeToolDefinition(element, options: null));
            }
        }
    }

    /// <summary>
    /// A list of tools enabled on the assistant. There can be a maximum of 128 tools per assistant. Tools can be of types code_interpreter, file_search, or function.
    /// </summary>
    public IList<ToolDefinition> Tools { get; } = [];

    private static void SerializeTools(Utf8JsonWriter writer)
    {
        throw new NotImplementedException();
    }

    private static void DeserializeTools(JsonProperty property, ref IList<JsonElement> vestigialTools)
    {
        List<JsonElement> elements = [.. property.Value.EnumerateArray()];
        vestigialTools = elements;
    }
}