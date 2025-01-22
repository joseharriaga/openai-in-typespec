function Run-ModelsSubnamespaceCheck {
    Write-Output ""
    Write-Output "Checking for unknown files using the OpenAI.Models namespace..."

    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath ".dotnet\src"
    $files = Get-ChildItem -Path $($directory + "\*") -Include "*.cs" -Recurse

    $exclusions = @(
        "GeneratorStubs.cs",
        "InternalDeleteModelResponseObject.cs",
        "InternalListModelsResponseObject.cs",
        "InternalModelObject.cs",
        "ModelDeletionResult.cs",
        "ModelDeletionResult.Serialization.cs",
        "OpenAIModel.cs",
        "OpenAIModel.Serialization.cs",
        "OpenAIModelClient.cs",
        "OpenAIModelClient.Protocol.cs",
        "OpenAIModelCollection.cs",
        "OpenAIModelCollection.Serialization.cs",
        "OpenAIModelsModelFactory.cs",
        "OpenAIModelClient.RestClient.cs"
    )

    $failures = @()

    foreach ($file in $files) {
        $content = Get-Content -Path $file -Raw

        if ($file.Name -in $exclusions) {
            Write-Output "Skipped $($file.FullName)"
            continue
        }

        if ($content -cmatch '(?m)^namespace OpenAI\.Models(;)?(\r)?$') {
            $failures += $file
        }
    }

    if ($failures.Length -gt 0) {
        $message = ""

        foreach ($failure in $failures) {
            $message += "$failure "
        }

        $exception = ("One or more unknown files with the OpenAI.Models namespace were detected." +
            " The OpenAI.Models namespace is reserved for OpenAI's Models API." +
            " If this change is intentional, please add the filenames to the exclusion list:" +
            " $($message)")
        
        throw $exception
    }

    Write-Output ""
    Write-Output "The check was successful."
}

function Run-TopLevelNamespaceCheck {
    Write-Output ""
    Write-Output "Checking for unknown files using the OpenAI namespace..."

    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath ".dotnet\src"
    $files = Get-ChildItem -Path $($directory + "\*") -Include "*.cs" -Recurse

    $exclusions = @(
        # Public types
        "ListOrder.cs",
        "OpenAIClient.cs",
        "OpenAIClientOptions.cs",
        "OpenAIModelFactory.cs",
        
        # Internal types
        "Argument.cs",
        "BinaryContentHelper.cs",
        "CancellationTokenExtensions.cs",
        "ChangeTrackingDictionary.cs",
        "ChangeTrackingList.cs",
        "ClientPipelineExtensions.cs",
        "ClientUriBuilder.cs",
        "ErrorResult.cs",
        "IEnumerableExtensions.cs",
        "IInternalListResponseOfT.cs",
        "InternalFunctionDefinition.cs",
        "InternalFunctionDefinition.Serialization.cs",
        "ModelSerializationExtensions.cs",
        "OpenAIClient.RestClient.cs",
        "Optional.cs",
        "PipelineRequestHeadersExtensions.cs",
        "TelemetryDetails.cs",
        "TypeFormatters.cs",
        "Utf8JsonBinaryContent.cs",

        # Utilities
        "AppContextSwitchHelper.cs",
        "CodeGenClientAttribute.cs",
        "CodeGenMemberAttribute.cs",
        "CodeGenModelAttribute.cs",
        "CodeGenSerializationAttribute.cs",
        "CodeGenSuppressAttribute.cs",
        "CodeGenTypeAttribute.cs",
        "CustomSerializationHelpers.cs",
        "GenericActionPipelinePolicy.cs",
        "MultiPartFormDataBinaryContent.cs",
        "PageCollectionHelpers.cs",
        "PageEnumerator.cs",
        "PageResultEnumerator.cs",
        "SemaphoreSlimExtensions.cs",
        "SourceGenerationContext.cs"
    )

    $failures = @()

    foreach ($file in $files) {
        $content = Get-Content -Path $file -Raw

        if ($file.Name -in $exclusions) {
            Write-Output "Skipped $($file.FullName)"
            continue
        }

        if ($content -cmatch '(?m)^namespace OpenAI(;)?(\r)?$') {
            $failures += $file
        }
    }

    if ($failures.Length -gt 0) {
        $message = ""

        foreach ($failure in $failures) {
            $message += "$failure "
        }

        $exception = ("One or more unknown files with the OpenAI namespace were detected." +
            " If this change is intentional, please add the filenames to the exclusion list:\:" +
            " $($message)")
        
        throw $exception
    }

    Write-Output ""
    Write-Output "The check was successful."
}

Run-ModelsSubnamespaceCheck
Run-TopLevelNamespaceCheck