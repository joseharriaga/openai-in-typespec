function Edit-GeneratedOpenAIClient {
    $root = Split-Path $PSScriptRoot -Parent

    $directory = Join-Path -Path $root -ChildPath "src\Generated"
    $file = Get-ChildItem -Path $directory -Filter "OpenAIClient.cs"

    $content = Get-Content -Path $file -Raw

    Write-Output "Editing $($file.FullName)"

    $content = $content -creplace "private (OpenAI.)?(?<var>\w+) _cached(\w+);", "private OpenAI.Internal.`${var} _cached`${var};"
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.AudioClient _cachedAudioClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.EmbeddingClient _cachedEmbeddingClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.FileClient _cachedFileClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.FineTuningClient _cachedFineTuningClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.ImageClient _cachedImageClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.LegacyCompletionClient _cachedLegacyCompletionClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.ModelClient _cachedModelClient;", ""
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.ModerationClient _cachedModerationClient;", ""
    $content = $content -creplace "public virtual (OpenAI.)?(?<var>\w+) Get(\w+)Client", "internal OpenAI.Internal.`${var} Get`${var}Client"
    $content = $content -creplace "ref _cached(\w+), new (OpenAI.)?(?<var>\w+)", "ref _cached`${var}, new OpenAI.Internal.`${var}"

    $content | Set-Content -Path $file.FullName -NoNewline
}

function Edit-GeneratedSubclients {
    $root = Split-Path $PSScriptRoot -Parent

    $directory = Join-Path -Path $root -ChildPath "src\Generated"
    $files = Get-ChildItem -Path $($directory + "\*") -Include "*.cs" -Exclude "OpenAIClient.cs", "OpenAIClientOptions.cs", "OpenAIModelFactory.cs"

    $exclusions = @(
        "AudioClient.cs",
        "EmbeddingClient.cs",
        "FileClient.cs",
        "FineTuningClient.cs",
        "ImageClient.cs",
        "LegacyCompletionClient.cs",
        "ModelClient.cs",
        "ModerationClient.cs"
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
        "CreateFineTuningJobRequestModel.cs",
        "FineTuningJob.cs",
        "FineTuningJob.Serialization.cs",
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
        "ModerationOptions.Serialization.cs"
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
