﻿namespace OpenAI.Assistants;

/*
 * This file stubs and performs minimal customization to generated public types for the OpenAI.Assistants namespace
 * that are not otherwise attributed elsewhere.
 */

[CodeGenModel("AssistantToolsCode")]
public partial class CodeInterpreterTool : AssistantTool { }

[CodeGenModel("AssistantToolsFileSearch")]
public partial class FileSearchTool : AssistantTool { }

[CodeGenModel("ThreadMessageStatus")]
public readonly partial struct MessageStatus { }

[CodeGenModel("MessageObjectIncompleteDetails")]
public partial class MessageFailureDetails { }

[CodeGenModel("MessageFailureDetailsReason")]
public readonly partial struct MessageFailureReason { }

[CodeGenModel("RunObjectLastError")]
public partial class RunError { }

[CodeGenModel("RunErrorCode")]
public readonly partial struct RunErrorCode { }

[CodeGenModel("RunObjectIncompleteDetails")]
public partial class RunIncompleteDetails { }

[CodeGenModel("RunIncompleteDetailsReason")]
public readonly partial struct RunIncompleteReason { }

[CodeGenModel("RunStepType")]
public readonly partial struct RunStepKind { }

[CodeGenModel("RunStepStatus")]
public readonly partial struct RunStepStatus { }

[CodeGenModel("RunStepObjectLastError")]
public partial class RunStepError { }

[CodeGenModel("RunStepErrorCode")]
public readonly partial struct RunStepErrorCode { }

[CodeGenModel("RunStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject")]
public partial class RunStepCodeInterpreterOutput { }
