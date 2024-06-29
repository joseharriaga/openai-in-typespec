$applicableDateTimeOffsetFilenames = @(
    "RunStep.Serialization.cs"
    "ThreadMessage.Serialization.cs",
    "ThreadRun.Serialization.cs",
    "VectorStore.Serialization.cs",
    "VectorStoreFileAssociation.Serialization.cs"
)
function Edit-DateTimeOffset-Serialization([string]$Filename, [ref]$FileContentReference) {
    if ($applicableDateTimeOffsetFilenames -contains $Filename) {
        $FileContentReference.Value = $FileContentReference.Value -creplace "expiresAt = property\.Value\.GetDateTimeOffset\(`"O`"\);", "// BUG: https://github.com/Azure/autorest.csharp/issues/4296`r`n                    // expiresAt = property.Value.GetDateTimeOffset(`"O`");`r`n                    expiresAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());"
        $FileContentReference.Value = $FileContentReference.Value -creplace "expiredAt = property\.Value\.GetDateTimeOffset\(`"O`"\);", "// BUG: https://github.com/Azure/autorest.csharp/issues/4296`r`n                    // expiredAt = property.Value.GetDateTimeOffset(`"O`");`r`n                    expiredAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());"
        $FileContentReference.Value = $FileContentReference.Value -creplace "startedAt = property\.Value\.GetDateTimeOffset\(`"O`"\);", "// BUG: https://github.com/Azure/autorest.csharp/issues/4296`r`n                    // startedAt = property.Value.GetDateTimeOffset(`"O`");`r`n                    startedAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());"
        $FileContentReference.Value = $FileContentReference.Value -creplace "cancelledAt = property\.Value\.GetDateTimeOffset\(`"O`"\);", "// BUG: https://github.com/Azure/autorest.csharp/issues/4296`r`n                    // cancelledAt = property.Value.GetDateTimeOffset(`"O`");`r`n                    cancelledAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());"
        $FileContentReference.Value = $FileContentReference.Value -creplace "failedAt = property\.Value\.GetDateTimeOffset\(`"O`"\);", "// BUG: https://github.com/Azure/autorest.csharp/issues/4296`r`n                    // failedAt = property.Value.GetDateTimeOffset(`"O`");`r`n                    failedAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());"
        $FileContentReference.Value = $FileContentReference.Value -creplace "completedAt = property\.Value\.GetDateTimeOffset\(`"O`"\);", "// BUG: https://github.com/Azure/autorest.csharp/issues/4296`r`n                    // completedAt = property.Value.GetDateTimeOffset(`"O`");`r`n                    completedAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());"
        $FileContentReference.Value = $FileContentReference.Value -creplace "lastActiveAt = property\.Value\.GetDateTimeOffset\(`"O`"\);", "// BUG: https://github.com/Azure/autorest.csharp/issues/4296`r`n                    // lastActiveAt = property.Value.GetDateTimeOffset(`"O`");`r`n                    lastActiveAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());"
    }
}

function Replace-Collection-Set-With-Init([ref]$FileContentReference) {
    $pattern = '(.*(List<|Dictionary<)[^{]*){ get; set; }'
    $matches = [regex]::Matches($FileContentReference.Value, $pattern)

    foreach ($match in $matches) {
        $propertyDeclaration = $match.Groups[1].Value
        $newPropertyDeclaration = "$propertyDeclaration{ get; }"
        $FileContentReference.Value = $FileContentReference.Value -replace [regex]::Escape($match.Value), $newPropertyDeclaration
    }
}

$root = Split-Path $PSScriptRoot -Parent
$directory = Join-Path -Path $root -ChildPath ".dotnet\src\Generated"
$generatedFiles = Get-ChildItem -Recurse -File -Path $directory -Filter "*.cs"
$processedCount = 0
foreach ($generatedFile in $generatedFiles) {
    $currentFilename = $generatedFile.Name
    $currentFileContent = Get-Content -Path $generatedFile.FullName -Raw

    Write-Progress -Activity "Customizing generated code" `
        -Status $currentFilename `
        -PercentComplete ((($processedCount++) / $generatedFiles.Count) * 100)

    Edit-DateTimeOffset-Serialization -Filename $currentFilename -FileContentReference ([ref]$currentFileContent)
    Replace-Collection-Set-With-Init -FileContentReference ([ref]$currentFileContent)

    $currentFileContent = $currentFileContent -creplace `
        "private IDictionary<string, BinaryData> _serializedAdditionalRawData", `
        "internal IDictionary<string, BinaryData> _serializedAdditionalRawData"
    $currentFileContent = $currentFileContent -creplace `
        "options.Format != `"W`"", `
        "true"
    $currentFileContent = $currentFileContent -replace " *///.*[\r\n]*", ""

    $attempt = 0
    while ($true) {
        try {
            $currentFileContent | Set-Content -Path $generatedFile.FullName -NoNewline
            break
        } catch {
            if ($attempt++ -gt 3) {
                throw
            } else {
                Start-Sleep -Seconds 1
            }
        }
    }
}