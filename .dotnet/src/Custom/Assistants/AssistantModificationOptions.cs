using System.Collections.Generic;

namespace OpenAI.Assistants;

/// <summary>
/// Represents additional options available when modifying an existing <see cref="Assistant"/>.
/// </summary>
[CodeGenModel("ModifyAssistantRequest")]
public partial class AssistantModificationOptions
{
    /// <summary>
    /// The replacement model that the assistant should use.
    /// </summary>
    public string Model { get; set; }

    /// <summary>
    /// <para>
    /// A list of tool enabled on the assistant.
    /// </para>
    /// There can be a maximum of 128 tools per assistant. Tools can be of types `code_interpreter`, `file_search`, or `function`.
    /// </summary>
    [CodeGenMember("Tools")]
    public IList<ToolDefinition> DefaultTools { get; } = new ChangeTrackingList<ToolDefinition>();

    // CUSTOM: reuse common request/response models for tool resources. Note that modification operations use the
    //          response models (which do not contain resource initialization helpers).

    /// <summary>
    /// A replacement set of resources that are made available to the assistant's tools.
    /// The resources are specific to the type of tool.
    /// For example, the `code_interpreter` tool requires a list of file IDs, while the `file_search` tool requires a list of vector store IDs.
    /// </summary>
    [CodeGenMember("ToolResources")]
    public ToolResources ToolResources { get; set; }
}