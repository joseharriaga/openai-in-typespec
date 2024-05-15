using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants;

/// <summary>
/// Represents additional options available when creating a new <see cref="ThreadRun"/>.
/// </summary>
[CodeGenModel("CreateRunRequest")]
[CodeGenSuppress("RunCreationOptions", typeof(string))]
// [CodeGenSerialization(nameof(ResponseFormat), SerializationValueHook=nameof(SerializeResponseValue), DeserializationValueHook=nameof(DeserializeResponseValue))]
public partial class RunCreationOptions
{
    // CUSTOM: assistant_id/stream visibility hidden so that they can be promoted to required method parameters
    [CodeGenMember("AssistantId")]
    internal string AssistantId { get; set; }

    [CodeGenMember("Stream")]
    internal bool? Stream { get; set; }

    /// <inheritdoc cref="AssistantResponseFormat"/>
    [CodeGenMember("ResponseFormat")]
    public AssistantResponseFormat ResponseFormat { get; init; }

    /// <summary>
    /// A run-specific model name that will override the assistant's defined model. If not provided, the assistant's
    /// selection will be used.
    /// </summary>
    [CodeGenMember("Model")]
    public string ModelOverride { get; init; }

    /// <summary>
    /// A run specific replacement for the assistant's default instructions that will override the assistant-level
    /// instructions. If not specified, the assistant's instructions will be used.
    /// </summary>
    [CodeGenMember("Instructions")]
    public string InstructionsOverride { get; init; }

    /// <summary>
    /// Run-specific additional instructions that will be appended to the assistant-level instructions solely for this
    /// run. Unlike <see cref="InstructionsOverride"/>, the assistant's instructions are preserved and these additional
    /// instructions are concatenated.
    /// </summary>
    [CodeGenMember("AdditionalInstructions")]
    public string AdditionalInstructions { get; init; }

    /// <summary>
    /// A run-specific collection of tool definitions that will override the assistant-level defaults. If not provided,
    /// the assistant's defined tools will be used. Available tools include:
    /// <para>
    /// <list type="bullet">
    /// <item>
    ///     <c>code_interpreter</c> - <see cref="CodeInterpreterToolDefinition"/> 
    ///     - works with data, math, and computer code
    /// </item>
    /// <item>
    ///     <c>file_search</c> - <see cref="FileSearchToolDefinition"/> 
    ///     - dynamically enriches an Run's context with content from vector stores
    /// </item>
    /// <item>
    ///     <c>function</c> - <see cref="FunctionToolDefinition"/>
    ///     - enables caller-provided custom functions for actions and enrichment
    /// </item>
    /// </list>
    /// </para>
    /// </summary>
    public IList<ToolDefinition> ToolsOverride { get; } = new ChangeTrackingList<ToolDefinition>();

    public RunCreationOptions()
    {
        AdditionalMessages = new ChangeTrackingList<MessageCreationOptions>();
        Tools = new ChangeTrackingList<ToolDefinition>();
        Metadata = new ChangeTrackingDictionary<string, string>();
    }

    private void SerializeResponseValue(Utf8JsonWriter writer) => writer.WriteObjectValue(ResponseFormat);
    private void DeserializeResponseValue(JsonProperty property, ref AssistantResponseFormat responseFormat)
        => responseFormat = AssistantResponseFormat.DeserializeAssistantResponseFormat(property.Value);
}