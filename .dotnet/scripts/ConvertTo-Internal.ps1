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
        "ListOrder.cs",
        "FunctionDefinition.cs",
        "FunctionDefinition.Serialization.cs",

        "Assistant.cs",
        "Assistant.Serialization.cs",
        "AssistantCreationOptions.cs",
        "AssistantCreationOptions.Serialization.cs",
        "AssistantModificationOptions.cs",
        "AssistantModificationOptions.Serialization.cs",
        "AssistantThread.cs",
        "AssistantThread.Serialization.cs",
        "AssistantToolResources.cs",
        "AssistantToolResources.Serialization.cs",
        "AssistantFileSearchToolResources.cs",
        "AssistantFileSearchToolResources.Serialization.cs",
        "AssistantCodeInterpreterToolResources.cs",
        "AssistantCodeInterpreterToolResources.Serialization.cs",
        "CodeInterpreterToolDefinition.cs",
        "CodeInterpreterToolDefinition.Serialization.cs",
        "CodeInterpreterToolResourceDefinitions.cs",
        "CodeInterpreterToolResourceDefinitions.Serialization.cs",
        "FileSearchToolDefinition.cs",
        "FileSearchToolDefinition.Serialization.cs",
        "FileSearchToolResourceDefinitions.cs",
        "FileSearchToolResourceDefinitions.Serialization.cs",
        "FunctionToolDefinition.cs",
        "FunctionToolDefinition.Serialization.cs",
        "InternalCreateAssistantRequestModel.cs",
        "InternalDeleteAssistantResponse.cs",
        "InternalDeleteAssistantResponse.Serialization.cs",
        "InternalDeleteMessageResponse.cs",
        "InternalDeleteMessageResponse.Serialization.cs",
        "InternalDeleteThreadResponse.cs",
        "InternalDeleteThreadResponse.Serialization.cs",
        "InternalCreateThreadAndRunRequest.cs",
        "InternalCreateThreadAndRunRequest.Serialization.cs",
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
        "InternalMessageContentItemFileObjectImageFile.cs",
        "InternalMessageContentItemFileObjectImageFile.Serialization.cs",
        "InternalMessageContentImageUrlObjectImageUrl.cs",
        "InternalMessageContentImageUrlObjectImageUrl.Serialization.cs",
        "InternalSubmitToolOutputsRunRequest.cs",
        "InternalSubmitToolOutputsRunRequest.Serialization.cs",
        "InternalUnknownAssistantToolDefinition.cs",
        "InternalUnknownAssistantToolDefinition.Serialization.cs",
        "InternalUnknownRequestMessageContentItem.cs",
        "InternalUnknownRequestMessageContentItem.Serialization.cs",
        "RequestMessageContentItem.cs",
        "RequestMessageContentItem.Serialization.cs",
        "MessageCreationAttachment.cs",
        "MessageCreationAttachment.Serialization.cs",
        "MessageCreationOptions.cs",
        "MessageCreationOptions.Serialization.cs",
        "MessageFailureDetails.cs",
        "MessageFailureDetails.Serialization.cs",
        "MessageFailureReason.cs",
        "MessageImageDetail.Serialization.cs",
        "MessageImageFileContentItem.cs",
        "MessageImageFileContentItem.Serialization.cs",
        "MessageImageUrlContentItem.cs",
        "MessageImageUrlContentItem.Serialization.cs",
        "MessageTextContentItem.cs",
        "MessageTextContentItem.Serialization.cs",
        "MessageModificationOptions.cs",
        "MessageModificationOptions.Serialization.cs",
        "MessageRole.Serialization.cs",
        "MessageStatus.cs",
        "ThreadCreationOptions.cs",
        "ThreadCreationOptions.Serialization.cs",
        "ThreadMessage.cs",
        "ThreadMessage.Serialization.cs",
        "ThreadRun.cs",
        "ThreadRun.Serialization.cs",
        "RunCreationOptions.cs",
        "RunCreationOptions.Serialization.cs",
        "RunModificationOptions.cs",
        "RunModificationOptions.Serialization.cs",
        "RunStatus.cs",
        "RunStep.cs",
        "RunStep.Serialization.cs",
        "RunTokenUsage.cs",
        "RunTokenUsage.Serialization.cs",
        "ThreadCreationOptions.cs",
        "ThreadCreationOptions.Serialization.cs",
        "ThreadModificationOptions.cs",
        "ThreadModificationOptions.Serialization.cs",
        "ToolDefinition.cs",
        "ToolDefinition.Serialization.cs",
        "ToolResourceDefinitions.cs",
        "ToolResourceDefinitions.Serialization.cs",

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
        "ChatLogProbabilityInfo.cs",
        "ChatLogProbabilityInfo.Serialization.cs",
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
        "InternalCreateChatCompletionResponseObject.cs",
        "SystemChatMessage.cs",
        "SystemChatMessage.Serialization.cs",
        "ToolChatMessage.cs",
        "ToolChatMessage.Serialization.cs",
        "UnknownChatMessage.cs",
        "UnknownChatMessage.Serialization.cs",
        "UserChatMessage.cs",
        "UserChatMessage.Serialization.cs", 

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
        "InternalBatchStatus.cs",
        "InternalBatchErrors.cs",
        "InternalBatchErrors.Serialization.cs",
        "InternalBatchErrorsObject.cs",
        "InternalBatchRequestCounts.cs",
        "InternalBatchRequestCounts.Serialization.cs",
        "InternalCreateBatchRequest.cs",
        "InternalCreateBatchRequest.Serialization.cs",
        "InternalListBatchesResponse.cs",
        "InternalListBatchesResponse.Serialization.cs",
        "InternalListBatchesResponseObject.cs",
        "InternalListBatchesResponseObject.Serialization.cs",
        
        "VectorStoreFileStatusFilter.cs"
    )

    foreach ($file in $files) {
        if ($exclusions -contains $file.Name) {
            continue
        }

        $content = Get-Content -Path $file -Raw

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
