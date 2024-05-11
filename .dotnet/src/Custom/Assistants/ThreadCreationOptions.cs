namespace OpenAI.Assistants;

/// <summary>
/// Represents additional options available when creating a new <see cref="Assistant"/>.
/// </summary>
[CodeGenModel("CreateThreadRequest")]
public partial class ThreadCreationOptions
{
    [CodeGenMember("ToolResources")]
    ToolResourceDefinitions ToolResources { get; set; }
}