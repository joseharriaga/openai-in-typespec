namespace OpenAI.Assistants;

/*
 * This file stubs and performs minimal customization to generated public types for the OpenAI.Assistants namespace
 * that are not otherwise attributed elsewhere.
 */

[CodeGenModel("AssistantObjectToolResources")]
public partial class ToolResources { }

[CodeGenModel("AssistantObjectToolResourcesCodeInterpreter")]
public partial class CodeInterpreterToolResources { }

[CodeGenModel("AssistantToolsCode")]
public partial class CodeInterpreterToolDefinition : ToolDefinition { }

[CodeGenModel("AssistantObjectToolResourcesFileSearch")]
public partial class FileSearchToolResources { }

[CodeGenModel("AssistantToolsFileSearch")]
public partial class FileSearchToolDefinition : ToolDefinition { }

[CodeGenModel("ThreadMessageStatus")]
public readonly partial struct MessageStatus { }

[CodeGenModel("MessageObjectIncompleteDetails")]
public partial class MessageFailureDetails { }

[CodeGenModel("CreateMessageRequestAttachment")]
public partial class MessageCreationAttachment { }

[CodeGenModel("MessageFailureDetailsReason")]
public readonly partial struct MessageFailureReason { }

[CodeGenModel("RunCompletionUsage")]
public partial class RunTokenUsage { }

[CodeGenModel("RunObjectLastError")]
public partial class RunError { }

[CodeGenModel("RunErrorCode")]
public readonly partial struct RunErrorCode { }

[CodeGenModel("RunObjectIncompleteDetails")]
public partial class RunIncompleteDetails { }

[CodeGenModel("TruncationObject")]
public partial class RunTruncationStrategy { }

[CodeGenModel("RunTruncationStrategyType")]
public readonly partial struct RunTruncationStrategyType { }

[CodeGenModel("RunIncompleteDetailsReason")]
public readonly partial struct RunIncompleteReason { }

[CodeGenModel("RunStepType")]
public readonly partial struct RunStepType { }

[CodeGenModel("RunStepStatus")]
public readonly partial struct RunStepStatus { }

[CodeGenModel("RunStepObjectLastError")]
public partial class RunStepError { }

[CodeGenModel("RunStepErrorCode")]
public readonly partial struct RunStepErrorCode { }

[CodeGenModel("RunStepCompletionUsage")]
public partial class RunStepTokenUsage { }

[CodeGenModel("RunStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject")]
public partial class RunStepCodeInterpreterOutput { }
