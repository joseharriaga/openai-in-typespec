using System;
using System.Collections.Generic;

namespace OpenAI.Assistants;

/// <summary>
/// Represents additional options available when modifying an existing <see cref="Assistant"/>.
/// </summary>
[CodeGenModel("ModifyAssistantRequest")]
public partial class AssistantModificationOptions
{
    public string Model { get; set; }

    public IList<ToolDefinition> Tools { get; } = new ChangeTrackingList<ToolDefinition>();

    public ToolResourceDefinitions ToolResources { get; set; }
}