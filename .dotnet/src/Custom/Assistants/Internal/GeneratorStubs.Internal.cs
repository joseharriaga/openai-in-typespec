using System.Collections.Generic;
using OpenAI.Assistants;

namespace OpenAI.Internal.Models;

[CodeGenModel("DeleteAssistantResponse")]
internal partial class InternalDeleteAssistantResponse { private readonly object Object; }

[CodeGenModel("DeleteThreadResponse")]
internal partial class InternalDeleteThreadResponse { private readonly object Object; }

[CodeGenModel("DeleteMessageResponse")]
internal partial class InternalDeleteMessageResponse { private readonly object Object; }

[CodeGenModel("CreateThreadAndRunRequest")]
internal partial class InternalCreateThreadAndRunRequest
{
    public string Model { get; set; }
    public ToolResourceDefinitions ToolResources { get; set; }
}

[CodeGenModel("SubmitToolOutputsRunRequest")]
internal partial class InternalSubmitToolOutputsRunRequest { }


[CodeGenModel("CreateAssistantRequestModel")]
internal readonly partial struct InternalCreateAssistantRequestModel { }

[CodeGenModel("ThreadObjectToolResources")]
internal partial class InternalThreadObjectToolResources { }

[CodeGenModel("ThreadObjectToolResourcesCodeInterpreter")]
internal partial class InternalThreadObjectToolResourcesCodeInterpreter { }

[CodeGenModel("ThreadObjectToolResourcesFileSearch")]
internal partial class InternalThreadObjectToolResourcesFileSearch { }

[CodeGenModel("MessageContentImageUrlObjectImageUrl")]
internal partial class InternalMessageContentImageUrlObjectImageUrl
{
    [CodeGenMember("Detail")]
    internal string InternalDetail { get; }
}

[CodeGenModel("MessageContentImageFileObjectImageFile")]
internal partial class InternalMessageContentItemFileObjectImageFile
{
    [CodeGenMember("Detail")]
    internal string InternalDetail { get; set; }
}

[CodeGenModel("MessageDeltaContentImageFileObjectImageFile")]
internal partial class InternalMessageDeltaContentImageFileObjectImageFile
{
    [CodeGenMember("Detail")]
    internal string InternalDetail { get; set; }
}

[CodeGenModel("MessageDeltaContentImageUrlObjectImageUrl")]
internal partial class InternalMessageDeltaContentImageUrlObjectImageUrl
{
    [CodeGenMember("Detail")]
    internal string InternalDetail { get; }
}

[CodeGenModel("MessageDeltaContentTextObjectText")]
internal partial class InternalMessageDeltaContentTextObjectText { }

[CodeGenModel("UnknownMessageDeltaContent")]
internal partial class InternalUnknownMessageDeltaContent { }

[CodeGenModel("UnknownAssistantToolDefinition")]
internal partial class InternalUnknownAssistantToolDefinition { }

[CodeGenModel("MessageContentTextObjectText")]
internal partial class InternalMessageContentTextObjectText { }

[CodeGenModel("UnknownMessageTextContentAnnotation")]
internal partial class InternalUnknownMessageTextContentAnnotation { }

[CodeGenModel("UnknownMessageDeltaTextContentAnnotation")]
internal partial class InternalUnknownMessageDeltaTextContentAnnotation { }

[CodeGenModel("UnknownRunStepDetails")]
internal partial class InternalUnknownRunStepDetails { }

[CodeGenModel("UnknownRunStepObjectStepDetails")]
internal partial class InternalUnknownRunStepObjectStepDetails { }

[CodeGenModel("UnknownRunStepDetailsToolCallsObjectToolCallsObject")]
internal partial class InternalUnknownRunStepDetailsToolCallsObjectToolCallsObject { }

[CodeGenModel("UnknownRunStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject")]
internal partial class InternalUnknownRunStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject { }

[CodeGenModel("RunStepDetailsMessageCreationObjectMessageCreation")]
internal partial class InternalRunStepDetailsMessageCreationObjectMessageCreation { }

[CodeGenModel("RunStepDetailsToolCallsFunctionObjectFunction")]
internal partial class InternalRunStepDetailsToolCallsFunctionObjectFunction { }

[CodeGenModel("RunStepDetailsToolCallsCodeObjectCodeInterpreter")]
internal partial class InternalRunStepDetailsToolCallsCodeObjectCodeInterpreter { }

[CodeGenModel("RunStepDetailsToolCallsCodeOutputImageObjectImage")]
internal partial class InternalRunStepDetailsToolCallsCodeOutputImageObjectImage { }

[CodeGenModel("MessageContentTextAnnotationsFileCitationObjectFileCitation")]
internal partial class InternalMessageContentTextAnnotationsFileCitationObjectFileCitation { }

[CodeGenModel("MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation")]
internal partial class InternalMessageDeltaContentTextAnnotationsFileCitationObjectFileCitation { }

[CodeGenModel("MessageContentTextAnnotationsFilePathObjectFilePath")]
internal partial class InternalMessageContentTextAnnotationsFilePathObjectFilePath { }

[CodeGenModel("MessageDeltaContentTextAnnotationsFilePathObjectFilePath")]
internal partial class InternalMessageDeltaContentTextAnnotationsFilePathObjectFilePath { }

[CodeGenModel("RunObjectRequiredAction")]
internal partial class InternalRunRequiredAction { private readonly object Object; }

[CodeGenModel("RunObjectRequiredActionSubmitToolOutputs")]
internal partial class InternalRunObjectRequiredActionSubmitToolOutputs { private readonly object Type; }

[CodeGenModel("RunToolCallObjectFunction")]
internal partial class InternalRunToolCallObjectFunction { }

internal interface IInternalListResponse<T>
{
    IReadOnlyList<T> Data { get; }
    string FirstId { get; }
    string LastId { get; }
    bool HasMore { get; }
}

[CodeGenModel("ListAssistantsResponse")]
internal partial class InternalListAssistantsResponse : IInternalListResponse<Assistant> { private readonly object Object; }

[CodeGenModel("ListThreadsResponse")]
internal partial class InternalListThreadsResponse : IInternalListResponse<AssistantThread> { private readonly object Object; }

[CodeGenModel("ListMessagesResponse")]
internal partial class InternalListMessagesResponse : IInternalListResponse<ThreadMessage> { private readonly object Object; }

[CodeGenModel("ListRunsResponse")]
internal partial class InternalListRunsResponse : IInternalListResponse<ThreadRun> { private readonly object Object; }

[CodeGenModel("ListRunStepsResponse")]
internal partial class InternalListRunStepsResponse : IInternalListResponse<RunStep> { private readonly object Object; }