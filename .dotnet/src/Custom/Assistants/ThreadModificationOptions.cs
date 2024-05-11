using System.Collections.Generic;

namespace OpenAI.Assistants;

/// <summary>
/// Represents additional options available when modifying an existing <see cref="AssistantThread"/>.
/// </summary>
[CodeGenModel("ModifyThreadRequest")]
public partial class ThreadModificationOptions
{
    [CodeGenMember("ToolResources")]
    public ToolResourceDefinitions ToolResources { get; set; }
}