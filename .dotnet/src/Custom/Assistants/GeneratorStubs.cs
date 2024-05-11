namespace OpenAI.Assistants;

[CodeGenModel("CreateAssistantRequestToolResources")]
public partial class ToolResourceDefinitions { }

[CodeGenModel("CreateAssistantRequestToolResourcesCodeInterpreter")]
public partial class CodeInterpreterToolResourceDefinitions { }

[CodeGenModel("CreateAssistantRequestToolResourcesFileSearch")]
public partial class FileSearchToolResourceDefinitions { }

[CodeGenModel("AssistantObjectToolResourcesCodeInterpreter")]
public partial class AssistantCodeInterpreterToolResources { }

[CodeGenModel("AssistantObjectToolResources")]
public partial class AssistantToolResources { }

[CodeGenModel("AssistantObjectToolResourcesFileSearch")]
public partial class AssistantFileSearchToolResources { }

[CodeGenModel("UnknownMessageContentItem")]
internal partial class InternalUnknownMessageContentItem { }

[CodeGenModel("UnknownAssistantToolDefinition")]
internal partial class InternalUnknownAssistantToolDefinition { }

[CodeGenModel("MessageContentImageFileObjectImageFile")]
internal partial class InternalMessageContentItemFileObjectImageFile
{
    [CodeGenMember("Detail")]
    public MessageImageDetail? Detail { get; }
}