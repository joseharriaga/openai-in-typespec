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

function Experimentally-Publicize-SerializedAdditionalRawData {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath "src\Generated\Models"

    $originalString = "private IDictionary<string, BinaryData> _serializedAdditionalRawData;"
    $publicString = "public IDictionary<string, BinaryData> SerializedAdditionalRawData"
    $additionalLines = @(
        "/// <summary>"
        "/// Gets the dictionary containing additional raw data to serialize."
        "/// </summary>"
        "/// <remarks>"
        "/// NOTE: This mechanism added for subclients pending availability of a C# language feature."
        "///       It is subject to change and not intended for stable use."
        "/// </remarks>"
        "[Experimental(`"OPENAI002`")]"
        "[EditorBrowsable(EditorBrowsableState.Never)]"
        $publicString
        "    => _serializedAdditionalRawData ??= new ChangeTrackingDictionary<string, BinaryData>();"
    )

    Get-ChildItem -Path $directory -Filter "*.cs" | ForEach-Object {
        $file = $_
        $filename = $_.FullName
        $match = Select-String -Path $filename -Pattern "^(\s*)$originalString([`r`n]*)"
        $alreadyMatched = Select-String -Path $filename -Pattern "^.*$publicString.*"
        if ($match -and (-not $alreadyMatched)) {
            Write-Output "Adding SerializedAdditionalRawData: $($_.Name)"
            $line = $match.Matches[0].Groups[0]
            $spaces = $match.Matches[0].Groups[1]
            $trailingNewlines = $match.Matches[0].Groups[2]
            $replacement = "$line`n"
            foreach ($additionalLine in $additionalLines) {
                $replacement += "`n$spaces$additionalLine"
            }
            $replacement += "$trailingNewlines"
            $content = Get-Content -Path $file -Raw
            $content = $content -creplace "$line", "$replacement"

            $componentModelMatch = Select-String -Path $filename -Pattern "^using System.ComponentModel"
            if (-not $componentModelMatch) {
                $content = $content -creplace `
                    "using System.Collections.Generic;", `
                    ("using System.Collections.Generic;`n" `
                    + "using System.ComponentModel;`n" `
                    + "using System.Diagnostics.CodeAnalysis;")
            }

            Set-Content $filename -Value $content
        }
    }
}

Edit-RunObjectSerialization
Remove-PseudoSuppressedTypes
Experimentally-Publicize-SerializedAdditionalRawData
