function Edit-GeneratedOpenAIClient {
    $root = Split-Path $PSScriptRoot -Parent

    $directory = Join-Path -Path $root -ChildPath "src\Generated"
    $file = Get-ChildItem -Path $directory -Filter "OpenAIClient.cs"

    $content = Get-Content -Path $file -Raw

    Write-Output "Editing $($file.FullName)"

    $content = $content -creplace "private (OpenAI.)?(?<var>\w+) _cached(\w+);", "private OpenAI.Internal.`${var} _cached`${var};"
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.AudioClient _cachedAudioClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.AssistantClient _cachedAssistantClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.BatchClient _cachedBatchClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.ChatClient _cachedChatClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.EmbeddingClient _cachedEmbeddingClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.FileClient _cachedFileClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.FineTuningClient _cachedFineTuningClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.ImageClient _cachedImageClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.InternalAssistantMessageClient _cachedInternalAssistantMessageClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.InternalAssistantRunClient _cachedInternalAssistantRunClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.InternalAssistantThreadClient _cachedInternalAssistantThreadClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.LegacyCompletionClient _cachedLegacyCompletionClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.ModelClient _cachedModelClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.ModerationClient _cachedModerationClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.VectorStoreClient _cachedVectorStoreClient;", ""
    $content = $content -creplace "public virtual (OpenAI.)?(?<var>\w+) Get(\w+)Client", "internal OpenAI.Internal.`${var} Get`${var}Client"
    $content = $content -creplace "ref _cached(\w+), new (OpenAI.)?(?<var>\w+)", "ref _cached`${var}, new OpenAI.Internal.`${var}"

    $content | Set-Content -Path $file.FullName -NoNewline
}

function Edit-GeneratedSubclients {
    $root = Split-Path $PSScriptRoot -Parent

    $directory = Join-Path -Path $root -ChildPath "src\Generated"
    $files = Get-ChildItem -Path $($directory + "\*") -Include "*.cs" -Exclude "OpenAIClient.cs", "OpenAIClientOptions.cs", "OpenAIModelFactory.cs"

    $exclusions = @(
        "AssistantClient.cs",
        "AudioClient.cs",
        "BatchClient.cs",
        "ChatClient.cs",
        "EmbeddingClient.cs",
        "FileClient.cs",
        "FineTuningClient.cs",
        "ImageClient.cs",
        "InternalAssistantMessageClient.cs",
        "InternalAssistantRunClient.cs",
        "InternalAssistantThreadClient.cs",
        "LegacyCompletionClient.cs",
        "ModelClient.cs",
        "ModerationClient.cs",
        "VectorStoreClient.cs"
    )

    foreach ($file in $files) {
        if ($exclusions -contains $file.Name) {
            continue
        }

        $content = Get-Content -Path $file -Raw

        Write-Output "Editing $($file.FullName)"

        $content = $content -creplace "public partial class", "internal partial class"
        $content = $content -creplace "public readonly partial struct", "internal readonly partial struct"
        $content = $content -creplace "public static partial class", "internal static partial class"
        $content = $content -creplace "namespace OpenAI", "namespace OpenAI.Internal"
        $content = $content -creplace "using OpenAI.Models;", "using OpenAI.Internal.Models;"

        $content | Set-Content -Path $file.FullName -NoNewline
    }
}

function Edit-GeneratedModels {
    $root = Split-Path $PSScriptRoot -Parent

    $directory = Join-Path -Path $root -ChildPath "src\Generated\Models"
    $files = Get-ChildItem -Path $($directory + "\*") -Include "*.cs"
    
    $exclusions = @(
        # Project common
        "ListOrder.cs",
        "OpenAIError.cs",
        "OpenAIError.Serialization.cs",
        "OpenAIErrorResponse.cs",
        "OpenAIErrorResponse.Serialization.cs",
        "InternalFunctionDefinition.cs",
        "InternalFunctionDefinition.Serialization.cs",

        # OpenAI.Assistants namespace
        "Assistant.cs",
        "Assistant.Serialization.cs",
        "AssistantCreationOptions.cs",
        "AssistantCreationOptions.Serialization.cs",
        "AssistantModificationOptions.cs",
        "AssistantModificationOptions.Serialization.cs",
        "AssistantThread.cs",
        "AssistantThread.Serialization.cs",
        "AssistantTool.cs",
        "AssistantTool.Serialization.cs",
        "CodeInterpreterTool.cs",
        "CodeInterpreterTool.Serialization.cs",
        "CodeInterpreterToolResources.cs",
        "CodeInterpreterToolResources.Serialization.cs",
        "FileCitationTextContentAnnotation.cs",
        "FileCitationTextContentAnnotation.Serialization.cs",
        "FilePathTextContentAnnotation.cs",
        "FilePathTextContentAnnotation.Serialization.cs",
        "FileSearchTool.cs",
        "FileSearchTool.Serialization.cs",
        "FileSearchToolResources.cs",
        "FileSearchToolResources.Serialization.cs",
        "FunctionTool.cs",
        "FunctionTool.Serialization.cs",
        "InternalCreateAssistantRequestModel.cs",
        "InternalCreateThreadAndRunRequest.cs",
        "InternalCreateThreadAndRunRequest.Serialization.cs",
        "InternalDeleteAssistantResponse.cs",
        "InternalDeleteAssistantResponse.Serialization.cs",
        "InternalDeleteMessageResponse.cs",
        "InternalDeleteMessageResponse.Serialization.cs",
        "InternalDeleteThreadResponse.cs",
        "InternalDeleteThreadResponse.Serialization.cs",
        "InternalListAssistantsResponse.cs",
        "InternalListAssistantsResponse.Serialization.cs",
        "InternalListMessagesResponse.cs",
        "InternalListMessagesResponse.Serialization.cs",
        "InternalListRunsResponse.cs",
        "InternalListRunsResponse.Serialization.cs",
        "InternalListRunStepsResponse.cs",
        "InternalListRunStepsResponse.Serialization.cs",
        "InternalListThreadsResponse.cs",
        "InternalListThreadsResponse.Serialization.cs",
        "InternalMessageContentImageUrlObjectImageUrl.cs",
        "InternalMessageContentImageUrlObjectImageUrl.Serialization.cs",
        "InternalMessageContentItemFileObjectImageFile.cs",
        "InternalMessageContentItemFileObjectImageFile.Serialization.cs",
        "InternalMessageContentTextAnnotationsFileCitationObjectFileCitation.cs",
        "InternalMessageContentTextAnnotationsFileCitationObjectFileCitation.Serialization.cs",
        "InternalMessageContentTextAnnotationsFilePathObjectFilePath.cs",
        "InternalMessageContentTextAnnotationsFilePathObjectFilePath.Serialization.cs",
        "InternalMessageImageFileContent.cs",
        "InternalMessageImageFileContent.Serialization.cs",
        "InternalMessageImageUrlContent.cs",
        "InternalMessageImageUrlContent.Serialization.cs",
        "InternalRequestMessageTextContent.cs",
        "InternalRequestMessageTextContent.Serialization.cs",
        "InternalRequiredFunctionToolCall.cs",
        "InternalRequiredFunctionToolCall.Serialization.cs",
        "InternalResponseMessageTextContent.cs",
        "InternalResponseMessageTextContent.Serialization.cs",
        "InternalRunObjectRequiredActionSubmitToolOutputs.cs",
        "InternalRunObjectRequiredActionSubmitToolOutputs.Serialization.cs",
        "InternalRunRequiredAction.cs",
        "InternalRunRequiredAction.Serialization.cs",
        "InternalRunStepCodeInterpreterLogOutput.cs",
        "InternalRunStepCodeInterpreterLogOutput.Serialization.cs",
        "InternalRunStepCodeInterpreterToolCallDetails.cs",
        "InternalRunStepCodeInterpreterToolCallDetails.Serialization.cs",
        "InternalRunStepDelta.cs",
        "InternalRunStepDelta.Serialization.cs",
        "InternalRunStepDeltaObjectDelta.cs",
        "InternalRunStepDeltaObjectDelta.Serialization.cs",
        "InternalRunStepDeltaStepDetails.cs",
        "InternalRunStepDeltaStepDetails.Serialization.cs",
        "InternalRunStepDeltaStepDetailsMessageCreationObject.cs",
        "InternalRunStepDeltaStepDetailsMessageCreationObject.Serialization.cs",
        "InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation.cs",
        "InternalRunStepDeltaStepDetailsMessageCreationObjectMessageCreation.Serialization.cs",
        "InternalRunStepDeltaStepDetailsToolCallsCodeObject.cs",
        "InternalRunStepDeltaStepDetailsToolCallsCodeObject.Serialization.cs",
        "InternalRunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreter.cs",
        "InternalRunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreter.Serialization.cs",
        "InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject.cs",
        "InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObject.Serialization.cs",
        "InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObjectImage.cs",
        "InternalRunStepDeltaStepDetailsToolCallsCodeOutputImageObjectImage.Serialization.cs",
        "InternalRunStepDeltaStepDetailsToolCallsCodeOutputLogsObject.cs",
        "InternalRunStepDeltaStepDetailsToolCallsCodeOutputLogsObject.Serialization.cs",
        "InternalRunStepDeltaStepDetailsToolCallsFileSearchObject.cs",
        "InternalRunStepDeltaStepDetailsToolCallsFileSearchObject.Serialization.cs",
        "InternalRunStepDeltaStepDetailsToolCallsFunctionObject.cs",
        "InternalRunStepDeltaStepDetailsToolCallsFunctionObject.Serialization.cs",
        "InternalRunStepDeltaStepDetailsToolCallsFunctionObjectFunction.cs",
        "InternalRunStepDeltaStepDetailsToolCallsFunctionObjectFunction.Serialization.cs",
        "InternalRunStepDeltaStepDetailsToolCallsObject.cs",
        "InternalRunStepDeltaStepDetailsToolCallsObject.Serialization.cs",
        "InternalRunStepDeltaStepDetailsToolCallsObjectToolCallsObject.cs",
        "InternalRunStepDeltaStepDetailsToolCallsObjectToolCallsObject.Serialization.cs",
        "InternalRunStepDetailsMessageCreationObject.cs",
        "InternalRunStepDetailsMessageCreationObject.Serialization.cs",
        "InternalRunStepDetailsMessageCreationObjectMessageCreation.cs",
        "InternalRunStepDetailsMessageCreationObjectMessageCreation.Serialization.cs",
        "InternalRunStepDetailsToolCallsCodeObjectCodeInterpreter.cs",
        "InternalRunStepDetailsToolCallsCodeObjectCodeInterpreter.Serialization.cs",
        "InternalRunStepDetailsToolCallsCodeOutputImageObject.cs",
        "InternalRunStepDetailsToolCallsCodeOutputImageObject.Serialization.cs",
        "InternalRunStepDetailsToolCallsCodeOutputImageObjectImage.cs",
        "InternalRunStepDetailsToolCallsCodeOutputImageObjectImage.Serialization.cs",
        "InternalRunStepDetailsToolCallsCodeOutputLogsObject.cs",
        "InternalRunStepDetailsToolCallsCodeOutputLogsObject.Serialization.cs",
        "InternalRunStepDetailsToolCallsFunctionObjectFunction.cs",
        "InternalRunStepDetailsToolCallsFunctionObjectFunction.Serialization.cs",
        "InternalRunStepDetailsToolCallsObject.cs",
        "InternalRunStepDetailsToolCallsObject.Serialization.cs",
        "InternalRunStepFileSearchToolCallDetails.cs",
        "InternalRunStepFileSearchToolCallDetails.Serialization.cs",
        "InternalRunStepFunctionToolCallDetails.cs",
        "InternalRunStepFunctionToolCallDetails.Serialization.cs",
        "InternalRunStepToolCallDetailsCollection.cs",
        "InternalRunStepToolCallDetailsCollection.Serialization.cs",
        "InternalRunToolCallObjectFunction.cs",
        "InternalRunToolCallObjectFunction.Serialization.cs",
        "InternalRunTruncationStrategyType.cs",
        "InternalSubmitToolOutputsRunRequest.cs",
        "InternalSubmitToolOutputsRunRequest.Serialization.cs",
        "MessageContent.cs",
        "MessageContent.Serialization.cs",
        "MessageContentTextAnnotationsFileCitationObject.cs",
        "MessageContentTextAnnotationsFileCitationObject.Serialization.cs",
        "MessageContentTextAnnotationsFilePathObject.cs",
        "MessageContentTextAnnotationsFilePathObject.Serialization.cs",
        "MessageContentTextObjectAnnotation.cs",
        "MessageContentTextObjectAnnotation.cs",
        "MessageContentTextObjectAnnotation.Serialization.cs",
        "MessageContentTextObjectAnnotation.Serialization.cs",
        "MessageContentTextObjectText.cs",
        "MessageContentTextObjectText.Serialization.cs",
        "MessageCreationAttachment.cs",
        "MessageCreationAttachment.Serialization.cs",
        "MessageCreationOptions.cs",
        "MessageCreationOptions.Serialization.cs",
        "MessageDeltaContent.cs",
        "MessageDeltaContent.Serialization.cs",
        "MessageDeltaContentImageFileObject.cs",
        "MessageDeltaContentImageFileObject.Serialization.cs"
        "MessageDeltaContentImageFileObjectImageFile.cs",
        "MessageDeltaContentImageFileObjectImageFile.Serialization.cs",
        "MessageDeltaContentImageUrlObject.cs",
        "MessageDeltaContentImageUrlObject.Serialization.cs",
        "MessageDeltaContentImageUrlObjectImageUrl.cs",
        "MessageDeltaContentImageUrlObjectImageUrl.Serialization.cs",
        "MessageDeltaContentTextAnnotationsFileCitationObject.cs",
        "MessageDeltaContentTextAnnotationsFileCitationObject.Serialization.cs",
        "MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation.cs",
        "MessageDeltaContentTextAnnotationsFileCitationObjectFileCitation.Serialization.cs",
        "MessageDeltaContentTextAnnotationsFilePathObject.cs",
        "MessageDeltaContentTextAnnotationsFilePathObject.Serialization.cs",
        "MessageDeltaContentTextAnnotationsFilePathObjectFilePath.cs",
        "MessageDeltaContentTextAnnotationsFilePathObjectFilePath.Serialization.cs",
        "MessageDeltaContentTextObject.cs",
        "MessageDeltaContentTextObject.cs",
        "MessageDeltaContentTextObject.Serialization.cs",
        "MessageDeltaContentTextObject.Serialization.cs",
        "MessageDeltaContentTextObjectText.cs",
        "MessageDeltaContentTextObjectText.Serialization.cs",
        "MessageDeltaObjectDelta.cs",
        "MessageDeltaObjectDelta.Serialization.cs",
        "MessageDeltaTextContentAnnotation.cs",
        "MessageDeltaTextContentAnnotation.Serialization.cs",
        "MessageFailureDetails.cs",
        "MessageFailureDetails.Serialization.cs",
        "MessageFailureReason.cs",
        "MessageImageDetail.Serialization.cs",
        "MessageModificationOptions.cs",
        "MessageModificationOptions.Serialization.cs",
        "MessageRole.Serialization.cs",
        "MessageStatus.cs",
        "RunCreationOptions.cs",
        "RunCreationOptions.Serialization.cs",
        "RunError.cs",
        "RunError.Serialization.cs",
        "RunErrorCode.cs",
        "RunIncompleteDetails.cs",
        "RunIncompleteDetails.Serialization.cs",
        "RunIncompleteReason.cs",
        "RunModificationOptions.cs",
        "RunModificationOptions.Serialization.cs",
        "RunStatus.cs",
        "RunStep.cs",
        "RunStep.Serialization.cs",
        "RunStepCodeInterpreterOutput.cs",
        "RunStepCodeInterpreterOutput.Serialization.cs",
        "RunStepDetails.cs",
        "RunStepDetails.Serialization.cs",
        "RunStepError.cs",
        "RunStepError.Serialization.cs",
        "RunStepErrorCode.cs",
        "RunStepStatus.cs",
        "RunStepTokenUsage.cs",
        "RunStepTokenUsage.Serialization.cs",
        "RunStepToolCall.cs",
        "RunStepToolCall.Serialization.cs",
        "RunStepType.cs",
        "RunStepUpdateCodeInterpreterOutput.cs",
        "RunStepUpdateCodeInterpreterOutput.Serialization.cs",
        "RunTokenUsage.cs",
        "RunTokenUsage.Serialization.cs",
        "RunTruncationStrategy.cs",
        "RunTruncationStrategy.Serialization.cs",
        "ThreadCreationOptions.cs",
        "ThreadCreationOptions.cs",
        "ThreadCreationOptions.Serialization.cs",
        "ThreadCreationOptions.Serialization.cs",
        "ThreadMessage.cs",
        "ThreadMessage.Serialization.cs",
        "ThreadModificationOptions.cs",
        "ThreadModificationOptions.Serialization.cs",
        "ThreadRun.cs",
        "ThreadRun.Serialization.cs",
        "ToolConstraint.cs",
        "ToolConstraint.Serialization.cs",
        "ToolOutput.cs",
        "ToolOutput.Serialization.cs",
        "ToolResources.cs",
        "ToolResources.Serialization.cs",
        "UnknownAssistantTool.cs",
        "UnknownAssistantTool.Serialization.cs",
        "UnknownMessageContentTextObjectAnnotation.cs",
        "UnknownMessageContentTextObjectAnnotation.Serialization.cs",
        "UnknownMessageDeltaContent.cs",
        "UnknownMessageDeltaContent.Serialization.cs",
        "UnknownMessageDeltaTextContentAnnotation.cs",
        "UnknownMessageDeltaTextContentAnnotation.Serialization.cs",
        "UnknownRunStepDeltaStepDetails.cs",
        "UnknownRunStepDeltaStepDetails.Serialization.cs",
        "UnknownRunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject.cs",
        "UnknownRunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject.cs",
        "UnknownRunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject.Serialization.cs",
        "UnknownRunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject.Serialization.cs",
        "UnknownRunStepDeltaStepDetailsToolCallsObjectToolCallsObject.cs",
        "UnknownRunStepDeltaStepDetailsToolCallsObjectToolCallsObject.Serialization.cs",
        "UnknownRunStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject.cs",
        "UnknownRunStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject.Serialization.cs",
        "UnknownRunStepDetailsToolCallsObjectToolCallsObject.cs",
        "UnknownRunStepDetailsToolCallsObjectToolCallsObject.Serialization.cs",
        "UnknownRunStepObjectStepDetails.cs",
        "UnknownRunStepObjectStepDetails.Serialization.cs",
        "VectorStoreCreationHelper.cs",
        "VectorStoreCreationHelper.Serialization.cs",

        # OpenAI.Audio namespace
        "AudioTranscription.cs",
        "AudioTranscription.Serialization.cs",
        "AudioTranscriptionFormat.Serialization.cs",
        "AudioTranscriptionOptions.cs",
        "AudioTranscriptionOptions.Serialization.cs",
        "AudioTranslation.cs",
        "AudioTranslation.Serialization.cs",
        "AudioTranslationFormat.Serialization.cs",
        "AudioTranslationOptions.cs",
        "AudioTranslationOptions.Serialization.cs",
        "InternalCreateSpeechRequestModel.cs",
        "InternalCreateTranscriptionRequestModel.cs",
        "InternalCreateTranscriptionResponseVerboseJsonTask.cs",
        "InternalCreateTranslationRequestModel.cs"
        "InternalCreateTranslationResponseVerboseJsonTask.cs",
        "GeneratedSpeechFormat.Serialization.cs",
        "GeneratedSpeechVoice.Serialization.cs",
        "SpeechGenerationOptions.cs",
        "SpeechGenerationOptions.Serialization.cs",
        "TranscribedSegment.cs",
        "TranscribedSegment.Serialization.cs",
        "TranscribedWord.cs",
        "TranscribedWord.Serialization.cs",

        # OpenAI.Chat namespace
        "AssistantChatMessage.cs",
        "AssistantChatMessage.Serialization.cs",
        "ChatCompletion.cs",
        "ChatCompletion.Serialization.cs",
        "ChatCompletionOptions.cs",
        "ChatCompletionOptions.Serialization.cs",
        "ChatFinishReason.Serialization.cs",
        "ChatFunction.cs",
        "ChatFunction.Serialization.cs",
        "ChatFunctionCall.cs",
        "ChatFunctionCall.Serialization.cs",
        "ChatFunctionChoice.cs",
        "ChatFunctionChoice.Serialization.cs",
        "ChatMessage.cs",
        "ChatMessage.Serialization.cs",
        "ChatMessageContentPart.cs",
        "ChatMessageContentPart.Serialization.cs",
        "ChatMessageRole.Serialization.cs",
        "ChatResponseFormat.cs",
        "ChatResponseFormat.Serialization.cs",
        "ChatTokenLogProbabilityInfo.cs",
        "ChatTokenLogProbabilityInfo.Serialization.cs",
        "ChatTokenTopLogProbabilityInfo.cs",
        "ChatTokenTopLogProbabilityInfo.Serialization.cs",
        "ChatTokenUsage.cs",
        "ChatTokenUsage.Serialization.cs",
        "ChatTool.cs",
        "ChatTool.Serialization.cs",
        "ChatToolCall.cs",
        "ChatToolCall.Serialization.cs",
        "ChatToolCallKind.cs",
        "ChatToolChoice.cs",
        "ChatToolChoice.Serialization.cs",
        "ChatToolKind.cs",
        "FunctionChatMessage.cs",
        "FunctionChatMessage.Serialization.cs",
        "ImageChatMessageContentPartDetail.cs",
        "InternalChatCompletionFunctionCallOption.cs",
        "InternalChatCompletionFunctionCallOption.Serialization.cs",
        "InternalChatCompletionMessageToolCallChunkFunction.cs",
        "InternalChatCompletionMessageToolCallChunkFunction.Serialization.cs",
        "InternalChatCompletionMessageToolCallChunkType.cs",
        "InternalChatCompletionMessageToolCallFunction.cs",
        "InternalChatCompletionMessageToolCallFunction.Serialization.cs",
        "InternalChatCompletionNamedToolChoice.cs",
        "InternalChatCompletionNamedToolChoice.Serialization.cs",
        "InternalChatCompletionNamedToolChoiceFunction.cs",
        "InternalChatCompletionNamedToolChoiceFunction.Serialization.cs",
        "InternalChatCompletionNamedToolChoiceType.cs",
        "InternalChatCompletionRequestMessageContentPartImage.cs",
        "InternalChatCompletionRequestMessageContentPartImage.Serialization.cs",
        "InternalChatCompletionRequestMessageContentPartImageImageUrl.cs",
        "InternalChatCompletionRequestMessageContentPartImageImageUrl.Serialization.cs",
        "InternalChatCompletionRequestMessageContentPartImageType.cs",
        "InternalChatCompletionRequestMessageContentPartText.cs",
        "InternalChatCompletionRequestMessageContentPartText.Serialization.cs",
        "InternalChatCompletionRequestMessageContentPartTextType.cs",
        "InternalChatCompletionResponseMessage.cs",
        "InternalChatCompletionResponseMessage.Serialization.cs",
        "InternalChatCompletionResponseMessageFunctionCall.cs",
        "InternalChatCompletionResponseMessageFunctionCall.Serialization.cs",
        "InternalChatCompletionResponseMessageRole.cs",
        "InternalChatCompletionStreamOptions.cs",
        "InternalChatCompletionStreamOptions.Serialization.cs",
        "InternalChatCompletionStreamResponseDelta.cs",
        "InternalChatCompletionStreamResponseDelta.Serialization.cs",
        "InternalChatCompletionStreamResponseDeltaRole.cs",
        "InternalChatResponseFormatType.cs",
        "InternalCreateChatCompletionFunctionResponse.cs",
        "InternalCreateChatCompletionFunctionResponse.Serialization.cs",
        "InternalCreateChatCompletionFunctionResponseChoice.cs",
        "InternalCreateChatCompletionFunctionResponseChoice.Serialization.cs",
        "InternalCreateChatCompletionFunctionResponseChoiceFinishReason.cs",
        "InternalCreateChatCompletionFunctionResponseObject.cs",
        "InternalCreateChatCompletionRequestModel.cs",
        "InternalCreateChatCompletionResponseChoice.cs",
        "InternalCreateChatCompletionResponseChoice.Serialization.cs",
        "InternalCreateChatCompletionResponseChoiceLogprobs.cs",
        "InternalCreateChatCompletionResponseChoiceLogprobs.Serialization.cs",
        "InternalCreateChatCompletionResponseObject.cs",
        "InternalCreateChatCompletionStreamResponseChoice.cs",
        "InternalCreateChatCompletionStreamResponseChoice.Serialization.cs",
        "InternalCreateChatCompletionStreamResponseChoiceFinishReason.cs",
        "InternalCreateChatCompletionStreamResponseChoiceLogprobs.cs",
        "InternalCreateChatCompletionStreamResponseChoiceLogprobs.Serialization.cs",
        "InternalCreateChatCompletionStreamResponseObject.cs",
        "InternalCreateChatCompletionStreamResponseUsage.cs",
        "InternalCreateChatCompletionStreamResponseUsage.Serialization.cs",
        "SystemChatMessage.cs",
        "SystemChatMessage.Serialization.cs",
        "StreamingChatCompletionUpdate.cs",
        "StreamingChatCompletionUpdate.Serialization.cs",
        "StreamingChatFunctionCallUpdate.cs",
        "StreamingChatFunctionCallUpdate.Serialization.cs",
        "StreamingChatToolCallUpdate.cs",
        "StreamingChatToolCallUpdate.Serialization.cs",
        "ToolChatMessage.cs",
        "ToolChatMessage.Serialization.cs",
        "UnknownChatMessage.cs",
        "UnknownChatMessage.Serialization.cs",
        "UserChatMessage.cs",
        "UserChatMessage.Serialization.cs", 

        # OpenAI.Embeddings namespace
        "Embedding.cs",
        "Embedding.Serialization.cs",
        "EmbeddingCollection.cs",
        "EmbeddingCollection.Serialization.cs",
        "EmbeddingGenerationOptions.cs",
        "EmbeddingGenerationOptions.Serialization.cs",
        "EmbeddingTokenUsage.cs",
        "EmbeddingTokenUsage.Serialization.cs",
        "InternalCreateEmbeddingRequestModel.cs",
        "InternalCreateEmbeddingResponseObject.cs",
        "InternalEmbeddingGenerationOptionsEncodingFormat.cs",
        "InternalEmbeddingObject.cs",

        # OpenAI.Files namespace
        "FileUploadPurpose.cs",
        "InternalDeleteFileResponse.cs",
        "InternalDeleteFileResponse.Serialization.cs",
        "InternalFileUploadOptions.cs",
        "InternalFileUploadOptions.Serialization.cs",
        "InternalListFilesResponseObject.cs",
        "InternalOpenAIFileObject.cs",
        "OpenAIFileInfo.cs",
        "OpenAIFileInfo.Serialization.cs",
        "OpenAIFileInfoCollection.cs",
        "OpenAIFileInfoCollection.Serialization.cs",
        "OpenAIFilePurpose.cs",
        "OpenAIFileStatus.cs",

        # OpenAI.FineTuning namespace
        "InternalCreateFineTuningJobRequest.cs",
        "InternalCreateFineTuningJobRequest.Serialization.cs",
        "InternalCreateFineTuningJobRequestHyperparameters.cs",
        "InternalCreateFineTuningJobRequestHyperparameters.Serialization.cs",
        "InternalCreateFineTuningJobRequestIntegration.cs",
        "InternalCreateFineTuningJobRequestIntegration.Serialization.cs",
        "InternalCreateFineTuningJobRequestIntegrationType.cs",
        "InternalCreateFineTuningJobRequestIntegrationType.Serialization.cs",
        "InternalCreateFineTuningJobRequestIntegrationWandb.cs",
        "InternalCreateFineTuningJobRequestIntegrationWandb.Serialization.cs",
        "InternalCreateFineTuningJobRequestModel.cs",
        "InternalFineTuningIntegration.cs",
        "InternalFineTuningIntegration.Serialization.cs",
        "InternalFineTuningIntegrationType.cs",
        "InternalFineTuningIntegrationWandb.cs",
        "InternalFineTuningIntegrationWandb.Serialization.cs",
        "InternalFineTuningJob.cs",
        "InternalFineTuningJob.Serialization.cs",
        "InternalFineTuningJobCheckpoint.cs",
        "InternalFineTuningJobCheckpoint.Serialization.cs",
        "InternalFineTuningJobCheckpointMetrics.cs",
        "InternalFineTuningJobCheckpointMetrics.Serialization.cs",
        "InternalFineTuningJobCheckpointObject.cs",
        "InternalFineTuningJobError.cs",
        "InternalFineTuningJobError.Serialization.cs",
        "InternalFineTuningJobEvent.cs",
        "InternalFineTuningJobEvent.Serialization.cs",
        "InternalFineTuningJobEventLevel.cs",
        "InternalFineTuningJobEventObject.cs",
        "InternalFineTuningJobHyperparameters.cs",
        "InternalFineTuningJobHyperparameters.Serialization.cs",
        "InternalFineTuningJobObject.cs",
        "InternalFineTuningJobStatus.cs",
        "InternalListFineTuningJobCheckpointsResponse.cs",
        "InternalListFineTuningJobCheckpointsResponse.Serialization.cs",
        "InternalListFineTuningJobCheckpointsResponseObject.cs",
        "InternalListFineTuningJobEventsResponse.cs",
        "InternalListFineTuningJobEventsResponse.Serialization.cs",
        "InternalListFineTuningJobEventsResponseObject.cs",
        "InternalListPaginatedFineTuningJobsResponse.cs",
        "InternalListPaginatedFineTuningJobsResponse.Serialization.cs",
        "InternalListPaginatedFineTuningJobsResponseObject.cs",

        # OpenAI.Images namespace
        "GeneratedImage.cs",
        "GeneratedImage.Serialization.cs",
        "GeneratedImageCollection.cs",
        "GeneratedImageCollection.Serialization.cs",
        "GeneratedImageFormat.Serialization.cs",
        "GeneratedImageQuality.Serialization.cs",
        "GeneratedImageSize.cs",
        "GeneratedImageStyle.Serialization.cs",
        "ImageEditOptions.cs",
        "ImageEditOptions.Serialization.cs",
        "ImageEditOptionsResponseFormat.cs",
        "ImageEditOptionsSize.cs",
        "ImageGenerationOptions.cs",
        "ImageGenerationOptions.Serialization.cs",
        "ImageVariationOptions.cs",
        "ImageVariationOptions.Serialization.cs",
        "InternalCreateImageEditRequestModel.cs",
        "InternalCreateImageRequestModel.cs",
        "InternalCreateImageVariationRequestModel.cs",
        "InternalImageVariationOptionsResponseFormat.cs",
        "InternalImageVariationOptionsSize.cs",

        # OpenAI.LegacyCompletions namespace
        "InternalCreateCompletionRequest.cs",
        "InternalCreateCompletionRequest.Serialization.cs",
        "InternalCreateCompletionRequestModel.cs",
        "InternalCreateCompletionResponse.cs",
        "InternalCreateCompletionResponse.Serialization.cs",
        "InternalCreateCompletionResponseChoice.cs",
        "InternalCreateCompletionResponseChoice.Serialization.cs",
        "InternalCreateCompletionResponseChoiceFinishReason.cs",
        "InternalCreateCompletionResponseChoiceLogprobs.cs",
        "InternalCreateCompletionResponseChoiceLogprobs.Serialization.cs",
        "InternalCreateCompletionResponseObject.cs",

        # OpenAI.Models namespace
        "InternalDeleteModelResponse.cs",
        "InternalDeleteModelResponse.Serialization.cs",
        "InternalListModelsResponseObject.cs",
        "InternalModelObject.cs",
        "OpenAIModelInfo.cs",
        "OpenAIModelInfo.Serialization.cs",
        "OpenAIModelInfoCollection.cs",
        "OpenAIModelInfoCollection.Serialization.cs",

        # OpenAI.Moderation namespace
        "InternalCreateModerationRequestModel.cs",
        "ModerationCategories.cs",
        "ModerationCategories.Serialization.cs",
        "ModerationCategoryScores.cs",
        "ModerationCategoryScores.Serialization.cs",
        "ModerationCollection.cs",
        "ModerationCollection.Serialization.cs",
        "ModerationOptions.cs",
        "ModerationOptions.Serialization.cs",
        "ModerationResult.cs",
        "ModerationResult.Serialization.cs",

        # OpenAI.VectorStores namespace
        "InternalBatchCompletionTimeframe.cs",
        "InternalBatchError.cs",
        "InternalBatchError.Serialization.cs",
        "InternalBatchJob.cs",
        "InternalBatchJob.Serialization.cs",
        "InternalBatchJobStatus.cs",
        "InternalBatchObject.cs",
        "InternalBatchOperationEndpoint.cs",
        "InternalBatchErrors.cs",
        "InternalBatchErrors.Serialization.cs",
        "InternalBatchErrorsObject.cs",
        "InternalBatchRequestCounts.cs",
        "InternalBatchRequestCounts.Serialization.cs",
        "InternalCreateBatchRequest.cs",
        "InternalCreateBatchRequest.Serialization.cs",
        "InternalListBatchesResponse.cs",
        "InternalListBatchesResponse.Serialization.cs",
        
        # VectorStoreClient types
        "InternalCreateVectorStoreFileBatchRequest.cs",
        "InternalCreateVectorStoreFileBatchRequest.Serialization.cs",
        "InternalCreateVectorStoreFileRequest.cs",
        "InternalCreateVectorStoreFileRequest.Serialization.cs",
        "InternalDeleteVectorStoreFileResponse.cs",
        "InternalDeleteVectorStoreFileResponse.Serialization.cs",
        "InternalDeleteVectorStoreResponse.cs",
        "InternalDeleteVectorStoreResponse.Serialization.cs",
        "InternalListVectorStoreFilesResponse.cs",
        "InternalListVectorStoreFilesResponse.Serialization.cs",
        "InternalListVectorStoresResponse.cs",
        "InternalListVectorStoresResponse.Serialization.cs",
        "VectorStore.cs",
        "VectorStore.Serialization.cs",
        "VectorStoreBatchFileJob.cs",
        "VectorStoreBatchFileJob.Serialization.cs",
        "VectorStoreBatchFileJobStatus.cs",
        "VectorStoreCreationOptions.cs",
        "VectorStoreCreationOptions.Serialization.cs",
        "VectorStoreExpirationAnchor.Serialization.cs",
        "VectorStoreExpirationPolicy.cs",
        "VectorStoreExpirationPolicy.Serialization.cs",
        "VectorStoreFileAssociation.cs",
        "VectorStoreFileAssociation.Serialization.cs",
        "VectorStoreFileAssociationError.cs",
        "VectorStoreFileAssociationError.Serialization.cs",
        "VectorStoreFileAssociationErrorCode.cs",
        "VectorStoreFileAssociationStatus.Serialization.cs",
        "VectorStoreFileCounts.cs",
        "VectorStoreFileCounts.Serialization.cs",
        "VectorStoreFileStatusFilter.cs",
        "VectorStoreFileStatusFilter.cs",
        "VectorStoreModificationOptions.cs",
        "VectorStoreModificationOptions.Serialization.cs",
        "VectorStoreStatus.Serialization.cs"
    )

    foreach ($file in $files) {
        if ($exclusions -contains $file.Name) {
            continue
        }

        $content = Get-Content -Path $file -Raw
        if ($content -contains "namespace OpenAI.Internal") {
            continue
        }

        Write-Output "Editing $($file.FullName)"

        $content = $content -creplace "public partial class", "internal partial class"
        $content = $content -creplace "public abstract partial class", "internal abstract partial class"
        $content = $content -creplace "public readonly partial struct", "internal readonly partial struct"
        $content = $content -creplace "public static partial class", "internal static partial class"
        $content = $content -creplace "namespace OpenAI", "namespace OpenAI.Internal"
        $content = $content -creplace "using OpenAI.Models;", "using OpenAI.Internal.Models;"

        $content | Set-Content -Path $file.FullName -NoNewline
    }
}

function Edit-GeneratedModelFactory {
    $root = Split-Path $PSScriptRoot -Parent

    $directory = Join-Path -Path $root -ChildPath "src\Generated"
    $file = Get-ChildItem -Path $directory -Filter "OpenAIModelFactory.cs"

    $content = Get-Content -Path $file -Raw

    Write-Output "Editing $($file.FullName)"

    $content = $content -creplace "using OpenAI.Models;", "using OpenAI.Internal.Models;"

    $content | Set-Content -Path $file.FullName -NoNewline
}

Edit-GeneratedOpenAIClient
Edit-GeneratedSubclients
Edit-GeneratedModels
Edit-GeneratedModelFactory
