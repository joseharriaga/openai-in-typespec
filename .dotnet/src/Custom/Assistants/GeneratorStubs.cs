using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

[CodeGenModel("CreateAssistantRequestToolResources")]
public partial class ToolResourceDefinitions { }

[CodeGenModel("CreateAssistantRequestToolResourcesCodeInterpreter")]
public partial class CodeInterpreterToolResourceDefinitions { }

[CodeGenModel("CreateAssistantRequestToolResourcesFileSearch")]
public partial class FileSearchToolResourceDefinitions { }

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

[CodeGenModel("MessageTextContentAnnotation")]
public partial class MessageTextContentAnnotation { }

[CodeGenModel("MessageDeltaTextContentAnnotation")]
public partial class MessageDeltaTextContentAnnotation { }

[CodeGenModel("MessageDeltaContentTextAnnotationsFileCitationObject")]
public partial class FileCitationTextDeltaContentAnnotation
{
    [CodeGenMember("FileCitation")]
    internal InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation InternalFileCitation { get; set; }
}

[CodeGenModel("MessageDeltaContentTextAnnotationsFilePathObject")]
public partial class FilePathTextDeltaContentAnnotation
{
    [CodeGenMember("FilePath")]
    internal InternalMessageDeltaContentTextAnnotationsFilePathObjectFilePath InternalFilePath { get; set; }
}

[CodeGenModel("RunObjectLastError")]
public partial class RunError { }

[CodeGenModel("RunObjectLastErrorCode")]
public readonly partial struct RunErrorCode { }

[CodeGenModel("RunObjectIncompleteDetails")]
public partial class RunIncompleteDetails { }

[CodeGenModel("TruncationObject")]
public partial class RunTruncationStrategy { }

[CodeGenModel("TruncationObjectType")]
public readonly partial struct RunTruncationStrategyType { }

[CodeGenModel("RunIncompleteDetailsReason")]
public readonly partial struct RunIncompleteReason { }

[CodeGenModel("RunStepType")]
public readonly partial struct RunStepType { }

[CodeGenModel("RunStepStatus")]
public readonly partial struct RunStepStatus { }

[CodeGenModel("RunStepObjectLastError")]
public partial class RunStepError { }

[CodeGenModel("RunStepObjectLastErrorCode")]
public readonly partial struct RunStepErrorCode { }

[CodeGenModel("RunStepCompletionUsage")]
public partial class RunStepTokenUsage { }

[CodeGenModel("RunStepObjectStepDetails")]
public abstract partial class RunStepDetails { }

[CodeGenModel("RunStepDetailsToolCallsObjectToolCallsObject")]
public partial class RunStepToolCallDetails { }

[CodeGenModel("RunStepDetailsToolCallsFileSearchObject")]
public partial class RunStepFileSearchToolCallDetails { }

[CodeGenModel("RunStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject")]
public partial class RunStepCodeInterpreterOutput { }

[CodeGenModel("RunStepDetailsToolCallsCodeOutputLogsObject")]
public partial class RunStepCodeInterpreterLogOutput { }