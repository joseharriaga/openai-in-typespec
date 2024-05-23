function Edit-RunObjectSerialization {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath "src\Generated\Models"

    $targets = @(
        "RunStep.Serialization.cs"
        "ThreadMessage.Serialization.cs",
        "ThreadRun.Serialization.cs",
        "VectorStore.Serialization.cs",
        "VectorStoreFileAssociation.Serialization.cs"
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
        "DeleteFileResponseObject",
        "DeleteMessageResponseObject",
        "DeleteModelResponseObject",
        "DeleteThreadResponseObject",
        "DeleteVectorStoreFileResponseObject",
        "DeleteVectorStoreResponseObject",
        "ImageEditOptionsResponseFormat",
        "ImageEditOptionsSize",
        "InternalBatchJobObject",
        "InternalMessageContentImageUrlObjectImageUrlDetail",
        "InternalMessageContentItemFileObjectImageFileDetail",
        "ListAssistantsResponseObject",
        "ListBatchesResponseObject",
        "ListMessagesResponseObject",
        "ListRunsResponseObject",
        "ListRunStepsResponseObject",
        "ListThreadsResponseObject",
        "ListVectorStoreFilesResponseObject",
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
        "VectorStoreFileObjectObject",
        "VectorStoreObjectObject"
    )
    foreach ($target in $targets) {
        Get-ChildItem -Path $directory -Filter "$target*" | ForEach-Object {
            Write-Output "Virtual [CodeGenSuppressType]: Removing $($_.Name)"
            $_ | Remove-Item
        }
    }
}

function Internalize-SerializedAdditionalRawData {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath "src\Generated\Models"
    Get-ChildItem -Path $directory -Filter "*.cs" | ForEach-Object {
        $file = $_
        $filename = $_.FullName
        $match = Select-String -Path $filename -Pattern "^(\s*)private (IDictionary<string, BinaryData> _serializedAdditionalRawData)"
        if ($match) {
            Write-Output "Internalizing _serializedAdditionalRawData: $($_.Name)"
            $content = Get-Content -Path $file -Raw
            $content = $content -creplace $match.Matches[0].Groups[0], "$($match.Matches[0].Groups[1])internal $($match.Matches[0].Groups[2])"
            $content | Set-Content -Path $filename -NoNewline
        }
    }
}

function Enable-Global-AdditionalRawDataSerialization {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath "src\Generated\Models"
    Get-ChildItem -Path $directory -Filter "*.cs" | ForEach-Object {
        $match = Select-String -Path $_.FullName -Pattern "options.Format != `"W`""
        if ($match) {
            Write-Output "Removing `"W`"-format serialization restriction: $($_.Name)"
            $content = Get-Content -Path $_ -Raw
            $content = $content -creplace "options.Format != `"W`"", "true"
            Set-Content $_ -Value $content -NoNewline
        }
    }
}

function Change-Set-To-Init {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath "src\Generated\Models"
    Get-ChildItem -Path $directory -Filter "*.cs" | Where-Object { $_.Name -notlike 'Internal*' } | ForEach-Object {
        $match = Select-String -Path $_.FullName -Pattern "(.*public.*) (.*) { get; set; }"
        if ($match) {
            foreach ($fileMatch in $match.Matches)
            {
                Write-Output "Editing $($_.Name) : $($fileMatch.Groups[2]): set --> init"
                $content = Get-Content -Path $_ -Raw
                $content = $content -creplace $fileMatch.Groups[0], "$($fileMatch.Groups[1]) $($fileMatch.Groups[2]) { get; init; }"
                Set-Content $_ -Value $content -NoNewline
            }
        }
    }
}

Edit-RunObjectSerialization
Remove-PseudoSuppressedTypes
Internalize-SerializedAdditionalRawData
Enable-Global-AdditionalRawDataSerialization
Change-Set-To-Init
