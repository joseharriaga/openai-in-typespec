namespace OpenAI.Assistants;

/*
 * This file stubs and performs minimal customization to generated internal types for the OpenAI.Assistants namespace.
 */

[CodeGenModel("SubmitToolOutputsRunRequest")]
internal partial class InternalSubmitToolOutputsRunRequest { }

[CodeGenModel("CreateAssistantRequestModel")]
internal readonly partial struct InternalCreateAssistantRequestModel { }

[CodeGenModel("MessageContentTextObjectAnnotation")]
internal partial class MessageContentTextObjectAnnotation { }

[CodeGenModel("MessageContentTextAnnotationsFileCitationObject")]
internal partial class MessageContentTextAnnotationsFileCitationObject { }

[CodeGenModel("MessageContentTextAnnotationsFilePathObject")]
internal partial class MessageContentTextAnnotationsFilePathObject { }

[CodeGenModel("MessageDeltaContentImageFileObjectImageFile")]
internal partial class MessageDeltaContentImageFileObjectImageFile
{
    [CodeGenMember("Detail")]
    internal string Detail { get; set; }
}

[CodeGenModel("MessageDeltaContentImageUrlObjectImageUrl")]
internal partial class MessageDeltaContentImageUrlObjectImageUrl
{
    [CodeGenMember("Detail")]
    internal string Detail { get; }
}

[CodeGenModel("MessageDeltaContentImageFileObject")]
internal partial class MessageDeltaContentImageFileObject { private readonly string Type; }

[CodeGenModel("MessageDeltaContentImageUrlObject")]
internal partial class MessageDeltaContentImageUrlObject { private readonly string Type; }

[CodeGenModel("MessageDeltaObjectDelta")]
internal partial class MessageDeltaObjectDelta
{
    [CodeGenMember("Role")]
    internal MessageRole Role { get; }
}

[CodeGenModel("MessageDeltaContentTextObject")]
internal partial class MessageDeltaContentTextObject { }

[CodeGenModel("MessageDeltaContentTextObjectText")]
internal partial class MessageDeltaContentTextObjectText { }

[CodeGenModel("MessageDeltaContentTextAnnotationsFileCitationObject")]
internal partial class MessageDeltaContentTextAnnotationsFileCitationObject { }

[CodeGenModel("MessageDeltaTextContentAnnotation")]
internal partial class MessageDeltaTextContentAnnotation { }

[CodeGenModel("MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation")]
internal partial class MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation { }

[CodeGenModel("RunStepDeltaObject")]
internal partial class InternalRunStepDelta { private readonly object Object; }

[CodeGenModel("RunStepDeltaObjectDelta")]
internal partial class InternalRunStepDeltaObjectDelta { }

[CodeGenModel("MessageDeltaContentTextAnnotationsFilePathObject")]
internal partial class MessageDeltaContentTextAnnotationsFilePathObject { }

[CodeGenModel("MessageDeltaContentTextAnnotationsFilePathObjectFilePath")]
internal partial class MessageDeltaContentTextAnnotationsFilePathObjectFilePath { }

[CodeGenModel("UnknownMessageDeltaContent")]
internal partial class UnknownMessageDeltaContent { }

[CodeGenModel("UnknownAssistantToolDefinition")]
internal partial class UnknownAssistantToolDefinition { }

[CodeGenModel("UnknownRunStepDeltaStepDetailsToolCallsObjectToolCallsObject")]
internal partial class UnknownRunStepDeltaStepDetailsToolCallsObjectToolCallsObject { }

[CodeGenModel("MessageDeltaContent")]
internal partial class MessageDeltaContent { }

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
    public ToolResources ToolResources { get; set; }
    public AssistantResponseFormat ResponseFormat { get; set; }
    public ToolConstraint ToolChoice { get; set; }
}

[CodeGenModel("MessageContentImageUrlObjectImageUrl")]
internal partial class InternalMessageContentImageUrlObjectImageUrl
{
    [CodeGenMember("Detail")]
    internal string Detail { get; }
}

[CodeGenModel("MessageContentImageFileObjectImageFile")]
internal partial class InternalMessageContentItemFileObjectImageFile
{
    [CodeGenMember("Detail")]
    internal string Detail { get; set; }
}

[CodeGenModel("MessageContentTextObjectText")]
internal partial class MessageContentTextObjectText { }

[CodeGenModel("UnknownMessageContentTextObjectAnnotation")]
internal partial class UnknownMessageContentTextObjectAnnotation { }

[CodeGenModel("UnknownMessageDeltaTextContentAnnotation")]
internal partial class UnknownMessageDeltaTextContentAnnotation { }

[CodeGenModel("UnknownRunStepDetails")]
internal partial class UnknownRunStepDetails { }

[CodeGenModel("UnknownRunStepObjectStepDetails")]
internal partial class UnknownRunStepObjectStepDetails { }

[CodeGenModel("UnknownRunStepDetailsToolCallsObjectToolCallsObject")]
internal partial class UnknownRunStepDetailsToolCallsObjectToolCallsObject { }

[CodeGenModel("UnknownRunStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject")]
internal partial class UnknownRunStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject { }

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

[CodeGenModel("MessageContentTextAnnotationsFilePathObjectFilePath")]
internal partial class InternalMessageContentTextAnnotationsFilePathObjectFilePath { }

[CodeGenModel("RunObjectRequiredAction")]
internal partial class InternalRunRequiredAction { private readonly object Type; }

[CodeGenModel("RunObjectRequiredActionSubmitToolOutputs")]
internal partial class InternalRunObjectRequiredActionSubmitToolOutputs { private readonly object Type; }

[CodeGenModel("RunToolCallObjectFunction")]
internal partial class InternalRunToolCallObjectFunction { }

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

[CodeGenModel("RunStepDetailsToolCallsFileSearchObject")]
internal partial class InternalRunStepFileSearchToolCallDetails { }

[CodeGenModel("RunStepDetailsToolCallsCodeOutputLogsObject")]
internal partial class InternalRunStepDetailsToolCallsCodeOutputLogsObject
{
    [CodeGenMember("Logs")]
    internal string InternalLogs { get; }
}

[CodeGenModel("RunTruncationStrategyType")]
internal readonly partial struct InternalRunTruncationStrategyType { }

[CodeGenModel("AssistantsNamedToolChoiceType")]
internal readonly partial struct InternalAssistantsNamedToolChoiceType { }

[CodeGenModel("RunStepDeltaStepDetailsToolCallsCodeObject")]
internal partial class InternalRunStepDeltaStepDetailsToolCallsCodeObject { }

[CodeGenModel("RunStepUpdateCodeInterpreterOutput")]
internal abstract partial class InternalRunStepUpdateCodeInterpreterOutput { }

[CodeGenModel("RunStepDeltaStepDetailsToolCallsCodeOutputImageObject")]
internal partial class InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject { }

[CodeGenModel("RunStepDeltaStepDetailsToolCallsCodeOutputLogsObject")]
internal partial class InternalRunStepDeltaStepDetailsToolCallsCodeOutputLogsObject
{
    [CodeGenMember("Logs")]
    public string InternalLogs { get; set; }
}

[CodeGenModel("RunStepDeltaStepDetailsMessageCreationObject")]
internal partial class InternalRunStepDeltaStepDetailsMessageCreationObject { }

[CodeGenModel("RunStepDeltaStepDetailsToolCallsObject")]
internal partial class InternalRunStepDeltaStepDetailsToolCallsObject { }

[CodeGenModel("RunStepDeltaStepDetailsToolCallsFileSearchObject")]
internal partial class InternalRunStepDeltaStepDetailsToolCallsFileSearchObject { }

[CodeGenModel("RunStepDeltaStepDetailsToolCallsFunctionObject")]
internal partial class InternalRunStepDeltaStepDetailsToolCallsFunctionObject { }

[CodeGenModel("RunStepDeltaStepDetailsToolCallsObjectToolCallsObject")]
internal partial class InternalRunStepDeltaStepDetailsToolCallsObjectToolCallsObject { }

[CodeGenModel("RunStepDeltaStepDetailsMessageCreationObjectMessageCreation")]
internal partial class InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation { }

[CodeGenModel("RunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreter")]
internal partial class InternalRunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreter { }

[CodeGenModel("RunStepDeltaStepDetailsToolCallsCodeOutputImageObjectImage")]
internal partial class InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObjectImage { }

[CodeGenModel("RunStepDeltaStepDetails")]
internal partial class InternalRunStepDeltaStepDetails { }

[CodeGenModel("UnknownRunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject")]
internal partial class UnknownRunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject { }

[CodeGenModel("UnknownRunStepDeltaStepDetails")]
internal partial class UnknownRunStepDeltaStepDetails { }

[CodeGenModel("RunStepDeltaStepDetailsToolCallsFunctionObjectFunction")]
internal partial class InternalRunStepDeltaStepDetailsToolCallsFunctionObjectFunction { }