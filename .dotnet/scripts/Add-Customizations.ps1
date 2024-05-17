function Edit-RunObjectSerialization {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath "src\Generated\Models"

    $targets = @(
        "RunStep.Serialization.cs"
        "ThreadMessage.Serialization.cs",
        "ThreadRun.Serialization.cs",
        "VectorStore.Serialization.cs"
    )
    foreach ($target in $targets) {
        $file = Get-ChildItem -Path $directory -Filter $target
        $content = Get-Content -Path $file -Raw

        Write-Output "Editing $($file.FullName)"

        $content = $content -creplace "expiresAt = property\.Value\.GetDateTimeOffset\(`"O`"\);", "// BUG: https://github.com/Azure/autorest.csharp/issues/4296`r`n                    // expiresAt = property.Value.GetDateTimeOffset(`"O`");`r`n                    expiresAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());"
        $content = $content -creplace "startedAt = property\.Value\.GetDateTimeOffset\(`"O`"\);", "// BUG: https://github.com/Azure/autorest.csharp/issues/4296`r`n                    // startedAt = property.Value.GetDateTimeOffset(`"O`");`r`n                    startedAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());"
        $content = $content -creplace "cancelledAt = property\.Value\.GetDateTimeOffset\(`"O`"\);", "// BUG: https://github.com/Azure/autorest.csharp/issues/4296`r`n                    // cancelledAt = property.Value.GetDateTimeOffset(`"O`");`r`n                    cancelledAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());"
        $content = $content -creplace "failedAt = property\.Value\.GetDateTimeOffset\(`"O`"\);", "// BUG: https://github.com/Azure/autorest.csharp/issues/4296`r`n                    // failedAt = property.Value.GetDateTimeOffset(`"O`");`r`n                    failedAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());"
        $content = $content -creplace "completedAt = property\.Value\.GetDateTimeOffset\(`"O`"\);", "// BUG: https://github.com/Azure/autorest.csharp/issues/4296`r`n                    // completedAt = property.Value.GetDateTimeOffset(`"O`");`r`n                    completedAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());"
        $content = $content -creplace "lastActiveAt = property\.Value\.GetDateTimeOffset\(`"O`"\);", "// BUG: https://github.com/Azure/autorest.csharp/issues/4296`r`n                    // lastActiveAt = property.Value.GetDateTimeOffset(`"O`");`r`n                    lastActiveAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());"

        $content | Set-Content -Path $file.FullName -NoNewline
    }
}

function Remove-PseudoSuppressedTypes {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath "src\Generated\Models"
    $targets = @(
        # "Unknown",
        "AssistantApiResponseFormat",
        "AssistantObjectObject",
        "AssistantResponseFormat",
        "AssistantsApiResponseFormat",
        "AssistantsNamedToolChoiceFunction",
        "AssistantToolsCodeType",
        "AssistantToolsFileSearchType",
        "AssistantToolsFunctionType",
        "CreateThreadAndRunRequestToolResources",
        "CreateThreadRequestToolResources",
        "DeleteAssistantResponseObject",
        "DeleteMessageResponseObject",
        "DeleteThreadResponseObject",
        "InternalMessageContentImageUrlObjectImageUrlDetail",
        "InternalMessageContentItemFileObjectImageFileDetail",
        "ListAssistantsResponseObject",
        "ListBatchesResponseObject",
        "ListMessagesResponseObject",
        "ListRunsResponseObject",
        "ListRunStepsResponseObject",
        "ListThreadsResponseObject",
        "MessageContentImageUrlObjectImageUrlDetail",
        "MessageDeltaContentImageFileObjectImageFileDetail",
        "MessageDeltaContentImageUrlObjectImageUrlDetail",
        "MessageDeltaObjectDeltaRole",
        "MessageObjectObject",
        "MessageRequestContentTextObjectType",
        "ModifyAssistantRequestToolResources",
        "ModifyThreadRequestToolResources",
        "RunObjectObject",
        "RunStepObjectObject",
        "ThreadObjectObject",
        "ToolConstraint",
        "VectorStoreObjectObject",
        "DeleteVectorStoreResponseObject"
    )
    foreach ($target in $targets) {
        Get-ChildItem -Path $directory -Filter "$target*" | ForEach-Object {
            Write-Output "Virtual [CodeGenSuppressType]: Removing $($_.Name)"
            $_ | Remove-Item
        }
    }
}

Edit-RunObjectSerialization
Remove-PseudoSuppressedTypes