. $PSScriptRoot\Helpers.ps1

$repoRootPath = Join-Path $PSScriptRoot ..\.. -Resolve
$generatedModelsFolderPath = Join-Path $repoRootPath .dotnet\src\Generated\Models

$targetFilenames = (
    "ChatMessage.cs",
    "ChatMessage.Serialization.cs",
    "ChatResponseFormat.cs",
    "ChatResponseFormat.Serialization.cs",
    "ChatOutputPrediction.cs",
    "ChatOutputPrediction.Serialization.cs"
)

foreach ($targetFilename in $targetFilenames) {
    $filePath = Join-Path $generatedModelsFolderPath $targetFilename -Resolve
    Update-In-File-With-Retry `
        -FilePath $filePath `
        -SearchPattern "public abstract" `
        -ReplacePattern "public" `
        -RequirePresence
}