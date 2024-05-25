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
        "AssistantResponseFormat",
        "AssistantsApiResponseFormat",
        "AssistantsNamedToolChoiceFunction",
        "AssistantToolsCodeType",
        "AssistantToolsFileSearchType",
        "AssistantToolsFunctionType",
        "CreateThreadAndRunRequestToolResources",
        "CreateThreadRequestToolResources",
        "InternalBatchJobObject",
        "InternalMessageContentImageUrlObjectImageUrlDetail",
        "InternalMessageContentItemFileObjectImageFileDetail",
        "MessageContentImageUrlObjectImageUrlDetail",
        "MessageDeltaContentImageFileObjectImageFileDetail",
        "MessageDeltaContentImageUrlObjectImageUrlDetail",
        "MessageDeltaObjectDeltaRole",
        "MessageRequestContentTextObjectType",
        "ModifyAssistantRequestToolResources",
        "ModifyThreadRequestToolResources",
        "ToolConstraint"
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

function Update-Set-Accessors {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath "src\Generated\Models"
    Get-ChildItem -Path $directory -Filter "*.cs" | Where-Object { $_.Name -notlike 'Internal*' } | ForEach-Object {
        $content = Get-Content -Path $_.FullName -Raw

        $pattern = '([^{]*){ get; set; }'
        $matches = [regex]::Matches($content, $pattern)

        if ($matches) {
            Write-Output "Editing $($_.Name): adjusting { set; } accessors"
        }
        foreach ($match in $matches) {
            $propertyDeclaration = $match.Groups[1].Value
            if ($propertyDeclaration -like "*List<*" -or $propertyDeclaration -like "*Dictionary<*") {
                $newPropertyDeclaration = "$propertyDeclaration{ get; }"
            } else {
                $newPropertyDeclaration = "$propertyDeclaration{ get; init; }"
            }
            $content = $content -replace [regex]::Escape($match.Value), $newPropertyDeclaration
        }

        Set-Content -Path $_.FullName -Value $content -NoNewline
    }
}

function Remove-Generated-Comments {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath "src\Generated"
    Get-ChildItem -Recurse -File -Path $directory -Filter "*.cs" | ForEach-Object {
        Write-Output $_.Name
        $content = Get-Content -Path $_.FullName -Raw
        $content = $content -replace " *///.*[\r\n]*", ""
        Set-Content -Path $_.FullName -Value $content -NoNewLine
    }
}

Edit-RunObjectSerialization
Remove-PseudoSuppressedTypes
Internalize-SerializedAdditionalRawData
Enable-Global-AdditionalRawDataSerialization
Update-Set-Accessors
Remove-Generated-Comments
