namespace OpenAI.Internal.Models;

[CodeGenModel("RunCompletionUsage")]
public partial class RunTokenUsage { }

[CodeGenModel("ThreadRunStatus")]
public readonly partial struct RunStatus { }

[CodeGenModel("ListAssistantsResponse")]
internal partial class InternalListAssistantsResponse { private readonly object Object; }

[CodeGenModel("DeleteAssistantResponse")]
internal partial class InternalDeleteAssistantResponse { private readonly object Object; }

[CodeGenModel("ListMessagesResponse")]
internal partial class InternalListMessagesResponse { private readonly object Object; }

[CodeGenModel("DeleteMessageResponse")]
internal partial class InternalDeleteMessageResponse { private readonly object Object; }

[CodeGenModel("CreateThreadAndRunRequest")]
internal partial class InternalCreateThreadAndRunRequest { }

[CodeGenModel("ListRunsResponse")]
internal partial class InternalListRunsResponse { private readonly object Object; }

[CodeGenModel("ListThreadsResponse")]
internal partial class InternalListThreadsResponse { private readonly object Object; }

[CodeGenModel("SubmitToolOutputsRunRequest")]
internal partial class InternalSubmitToolOutputsRunRequest { }

[CodeGenModel("ListRunStepsResponse")]
internal partial class InternalListRunStepsResponse { private readonly object Object; }

[CodeGenModel("DeleteThreadResponse")]
internal partial class InternalDeleteThreadResponse { private readonly object Object; }

[CodeGenModel("CreateAssistantRequestModel")]
internal readonly partial struct InternalCreateAssistantRequestModel { }