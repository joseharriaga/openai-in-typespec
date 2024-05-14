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
        "ListOrder.cs",
        "FunctionDefinition.cs",
        "FunctionDefinition.Serialization.cs",

        # OpenAI.Assistants namespace
        "Assistant.cs",
        "Assistant.Serialization.cs",
        "AssistantCreationOptions.cs",
        "AssistantCreationOptions.Serialization.cs",
        "AssistantModificationOptions.cs",
        "AssistantModificationOptions.Serialization.cs",
        "AssistantThread.cs",
        "AssistantThread.Serialization.cs",
        "CodeInterpreterToolDefinition.cs",
        "CodeInterpreterToolDefinition.Serialization.cs",
        "CodeInterpreterToolResourceDefinitions.cs",
        "CodeInterpreterToolResourceDefinitions.Serialization.cs",
        "CodeInterpreterToolResources.cs",
        "CodeInterpreterToolResources.Serialization.cs",
        "FileCitationTextContentAnnotation.cs",
        "FileCitationTextContentAnnotation.Serialization.cs",
        "FilePathTextContentAnnotation.cs",
        "FilePathTextContentAnnotation.Serialization.cs",
        "FileSearchToolDefinition.cs",
        "FileSearchToolDefinition.Serialization.cs",
        "FileSearchToolResources.cs",
        "FileSearchToolResources.Serialization.cs",
        "FunctionToolDefinition.cs",
        "FunctionToolDefinition.Serialization.cs",
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
        "InternalRunStepCodeInterpreterImageOutput.cs",
        "InternalRunStepCodeInterpreterImageOutput.Serialization.cs",
        "InternalRunStepCodeInterpreterLogOutput.cs",
        "InternalRunStepCodeInterpreterLogOutput.Serialization.cs",
        "InternalRunStepCodeInterpreterToolCallDetails.cs",
        "InternalRunStepCodeInterpreterToolCallDetails.Serialization.cs",
        "InternalRunStepDetailsMessageCreationObjectMessageCreation.cs",
        "InternalRunStepDetailsMessageCreationObjectMessageCreation.Serialization.cs",
        "InternalRunStepDetailsToolCallsCodeObjectCodeInterpreter.cs",
        "InternalRunStepDetailsToolCallsCodeObjectCodeInterpreter.Serialization.cs",
        "InternalRunStepDetailsToolCallsCodeOutputImageObjectImage.cs",
        "InternalRunStepDetailsToolCallsCodeOutputImageObjectImage.Serialization.cs",
        "InternalRunStepDetailsToolCallsCodeOutputLogsObject.cs",
        "InternalRunStepDetailsToolCallsCodeOutputLogsObject.Serialization.cs",
        "InternalRunStepDetailsToolCallsFunctionObjectFunction.cs",
        "InternalRunStepDetailsToolCallsFunctionObjectFunction.Serialization.cs",
        "InternalRunStepFileSearchToolCallDetails.cs",
        "InternalRunStepFileSearchToolCallDetails.Serialization.cs",
        "InternalRunStepFunctionToolCallDetails.cs",
        "InternalRunStepFunctionToolCallDetails.Serialization.cs",
        "InternalRunStepMessageCreationDetails.cs",
        "InternalRunStepMessageCreationDetails.Serialization.cs",
        "InternalRunStepToolCallDetailsCollection.cs",
        "InternalRunStepToolCallDetailsCollection.Serialization.cs",
        "InternalRunToolCallObjectFunction.cs",
        "InternalRunToolCallObjectFunction.Serialization.cs",
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
        "RunStepDelta.cs",
        "RunStepDelta.Serialization.cs",
        "RunStepDeltaObjectDelta.cs",
        "RunStepDeltaObjectDelta.Serialization.cs",
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
        "RunTokenUsage.cs",
        "RunTokenUsage.Serialization.cs",
        "RunTruncationStrategy.cs",
        "RunTruncationStrategy.Serialization.cs",
        "RunTruncationStrategyType.cs",
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
        "ToolDefinition.cs",
        "ToolDefinition.Serialization.cs",
        "ToolOutput.cs",
        "ToolOutput.Serialization.cs",
        "ToolResourceDefinitions.cs",
        "ToolResourceDefinitions.Serialization.cs",
        "ToolResources.cs",
        "ToolResources.Serialization.cs",
        "UnknownAssistantToolDefinition.cs",
        "UnknownAssistantToolDefinition.Serialization.cs",
        "UnknownMessageContentTextObjectAnnotation.cs",
        "UnknownMessageContentTextObjectAnnotation.Serialization.cs",
        "UnknownMessageDeltaContent.cs",
        "UnknownMessageDeltaContent.Serialization.cs",
        "UnknownMessageDeltaTextContentAnnotation.cs",
        "UnknownMessageDeltaTextContentAnnotation.Serialization.cs",
        "UnknownRunStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject.cs",
        "UnknownRunStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject.Serialization.cs",
        "UnknownRunStepDetailsToolCallsObjectToolCallsObject.cs",
        "UnknownRunStepDetailsToolCallsObjectToolCallsObject.Serialization.cs",
        "UnknownRunStepObjectStepDetails.cs",
        "UnknownRunStepObjectStepDetails.Serialization.cs",

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
        "CreateTranscriptionResponseVerboseJsonTask.cs",
        "CreateTranslationResponseVerboseJsonTask.cs",
        "CreateSpeechRequestModel.cs",
        "CreateTranscriptionRequestModel.cs",
        "CreateTranslationRequestModel.cs"
        "GeneratedSpeechFormat.Serialization.cs",
        "GeneratedSpeechVoice.Serialization.cs",
        "SpeechGenerationOptions.cs",
        "SpeechGenerationOptions.Serialization.cs",
        "TranscribedSegment.cs",
        "TranscribedSegment.Serialization.cs",
        "TranscribedWord.cs",
        "TranscribedWord.Serialization.cs",

        "ChatCompletionOptions.cs",
        "ChatCompletionOptions.Serialization.cs",

        "CreateEmbeddingRequestModel.cs",
        "CreateEmbeddingResponseObject.cs",
        "Embedding.cs",
        "Embedding.Serialization.cs",
        "EmbeddingCollection.cs",
        "EmbeddingCollection.Serialization.cs",
        "EmbeddingObject.cs",
        "EmbeddingOptions.cs",
        "EmbeddingOptions.Serialization.cs",
        "EmbeddingOptionsEncodingFormat.cs",
        "EmbeddingTokenUsage.cs",
        "EmbeddingTokenUsage.Serialization.cs",

        "DeleteFileResponse.cs",
        "DeleteFileResponseObject.cs",
        "DeleteFileResponse.Serialization.cs",
        "ListFilesResponseObject.cs",
        "OpenAIFileInfo.cs",
        "OpenAIFileInfo.Serialization.cs",
        "OpenAIFileInfoCollection.cs",
        "OpenAIFileInfoCollection.Serialization.cs",
        "OpenAIFileObject.cs",
        "OpenAIFilePurpose.cs",
        "OpenAIFileStatus.cs",
        "UploadFileOptions.cs",
        "UploadFileOptions.Serialization.cs",
        "UploadFileOptionsPurpose.cs"

        "CreateFineTuningJobRequest.cs",
        "CreateFineTuningJobRequest.Serialization.cs",
        "CreateFineTuningJobRequestHyperparameters.cs",
        "CreateFineTuningJobRequestHyperparameters.Serialization.cs",
        "CreateFineTuningJobRequestIntegration.cs",
        "CreateFineTuningJobRequestIntegration.Serialization.cs",
        "CreateFineTuningJobRequestIntegrationType.cs",
        "CreateFineTuningJobRequestIntegrationType.Serialization.cs",
        "CreateFineTuningJobRequestIntegrationWandb.cs",
        "CreateFineTuningJobRequestIntegrationWandb.Serialization.cs",
        "CreateFineTuningJobRequestModel.cs",
        "FineTuningIntegration.cs",
        "FineTuningIntegration.Serialization.cs",
        "FineTuningIntegrationType.cs",
        "FineTuningIntegrationWandb.cs",
        "FineTuningIntegrationWandb.Serialization.cs",
        "FineTuningJob.cs",
        "FineTuningJob.Serialization.cs",
        "FineTuningJobCheckpoint.cs",
        "FineTuningJobCheckpoint.Serialization.cs",
        "FineTuningJobCheckpointMetrics.cs",
        "FineTuningJobCheckpointMetrics.Serialization.cs",
        "FineTuningJobCheckpointObject.cs",
        "FineTuningJobError.cs",
        "FineTuningJobError.Serialization.cs",
        "FineTuningJobEvent.cs",
        "FineTuningJobEvent.Serialization.cs",
        "FineTuningJobEventLevel.cs",
        "FineTuningJobEventObject.cs",
        "FineTuningJobHyperparameters.cs",
        "FineTuningJobHyperparameters.Serialization.cs",
        "FineTuningJobObject.cs",
        "FineTuningJobStatus.cs",
        "ListFineTuningJobCheckpointsResponse.cs",
        "ListFineTuningJobCheckpointsResponse.Serialization.cs",
        "ListFineTuningJobCheckpointsResponseObject.cs",
        "ListFineTuningJobEventsResponse.cs",
        "ListFineTuningJobEventsResponse.Serialization.cs",
        "ListFineTuningJobEventsResponseObject.cs",

        "CreateImageEditRequestModel.cs",
        "CreateImageRequestModel.cs",
        "CreateImageVariationRequestModel.cs",
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
        "ImageVariationOptionsResponseFormat.cs",
        "ImageVariationOptionsSize.cs",

        "CreateCompletionRequest.cs",
        "CreateCompletionRequest.Serialization.cs",
        "CreateCompletionRequestModel.cs",
        "CreateCompletionResponse.cs",
        "CreateCompletionResponse.Serialization.cs",
        "CreateCompletionResponseChoice.cs",
        "CreateCompletionResponseChoice.Serialization.cs",
        "CreateCompletionResponseChoiceFinishReason.cs",
        "CreateCompletionResponseChoiceLogprobs.cs",
        "CreateCompletionResponseChoiceLogprobs.Serialization.cs",
        "CreateCompletionResponseObject.cs",
        "CompletionUsage.cs",
        "CompletionUsage.Serialization.cs",

        "InternalChatCompletionStreamOptions.cs",
        "InternalChatCompletionStreamOptions.Serialization.cs",

        "DeleteModelResponse.cs",
        "DeleteModelResponse.Serialization.cs",
        "DeleteModelResponseObject.cs",
        "ListModelsResponseObject.cs",
        "ModelObject.cs",
        "OpenAIModelInfo.cs",
        "OpenAIModelInfo.Serialization.cs",
        "OpenAIModelInfoCollection.cs",
        "OpenAIModelInfoCollection.Serialization.cs",

        "CreateModerationRequestModel.cs",
        "Moderation.cs",
        "Moderation.Serialization.cs",
        "ModerationCategories.cs",
        "ModerationCategories.Serialization.cs",
        "ModerationCategoryScores.cs",
        "ModerationCategoryScores.Serialization.cs",
        "ModerationCollection.cs",
        "ModerationCollection.Serialization.cs",
        "ModerationOptions.cs",
        "ModerationOptions.Serialization.cs",

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
        
        "VectorStoreFileStatusFilter.cs"
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
