using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI.Assistants;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

/// <summary>
/// Represents additional options available when creating a new <see cref="Assistant"/>.
/// </summary>
[CodeGenModel("CreateAssistantRequest")]
[CodeGenSuppress("AssistantCreationOptions", typeof(InternalCreateAssistantRequestModel))]
public partial class AssistantCreationOptions
{
    public string Model { get; set; }

    public AssistantCreationOptions(string model)
        : this(new InternalCreateAssistantRequestModel(model))
    { }

    internal AssistantCreationOptions(InternalCreateAssistantRequestModel model)
    {
        Model = model.ToString();
        Metadata = new ChangeTrackingDictionary<string, string>();
        Tools = new ChangeTrackingList<ToolDefinition>();
    }
}