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

[CodeGenModel("ThreadMessageStatus")]
public readonly partial struct MessageStatus { }

[CodeGenModel("MessageObjectIncompleteDetails")]
public partial class MessageFailureDetails { }

[CodeGenModel("MessageFailureDetailsReason")]
public readonly partial struct MessageFailureReason { }

[CodeGenModel("RunCompletionUsage")]
public partial class RunTokenUsage { }

[CodeGenModel("ThreadRunStatus")]
public readonly partial struct RunStatus { }
