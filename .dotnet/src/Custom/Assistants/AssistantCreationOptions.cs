using OpenAI.Internal.Models;
using System.Collections.Generic;

namespace OpenAI.Assistants;

/// <summary>
/// Represents additional options available when creating a new <see cref="Assistant"/>.
/// </summary>
[CodeGenModel("CreateAssistantRequest")]
public partial class AssistantCreationOptions
{
    // CUSTOM: visibility hidden to promote required property to method parameter
    internal string Model { get; set; }

    /// <summary>
    /// <para>
    /// A list of tool enabled on the assistant.
    /// </para>
    /// There can be a maximum of 128 tools per assistant. Tools can be of types `code_interpreter`, `file_search`, or `function`.
    /// </summary>
    [CodeGenMember("Tools")]
    public IList<ToolDefinition> Tools { get; } = new ChangeTrackingList<ToolDefinition>();

    /// <summary>
    /// <para>
    /// A set of resources that are made available to the assistant.
    /// </para>
    /// The resources are specific to the type of tool. For example, the `code_interpreter` tool requires a list of file IDs, while the `file_search` tool requires a list of vector store IDs.
    /// </summary>
    [CodeGenMember("ToolResources")]
    public ToolResourceDefinitions ToolResources { get; set; }

    internal AssistantCreationOptions(InternalCreateAssistantRequestModel model)
        : this()
    {
        Model = model.ToString();
    }

    /// <summary>
    /// Creates a new instance of <see cref="AssistantCreationOptions"/>.
    /// </summary>
    public AssistantCreationOptions()
    {
        Metadata = new ChangeTrackingDictionary<string, string>();
        Tools = new ChangeTrackingList<ToolDefinition>();
    }
}