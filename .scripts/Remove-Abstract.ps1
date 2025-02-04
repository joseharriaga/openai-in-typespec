. $PSScriptRoot\Helpers.ps1

$repoRoot = Join-Path $PSScriptRoot .. -Resolve
$generatedModelFolder = Join-Path $repoRoot .dotnet\src\Generated\Models

$targetFilenames = (
    "ChatMessage.cs",
    "ChatMessage.Serialization.cs",
    "ChatResponseFormat.cs",
    "ChatResponseFormat.Serialization.cs",
    "ChatOutputPrediction.cs",
    "ChatOutputPrediction.Serialization.cs"
)

foreach ($targetFilename in $targetFilenames) {
    $filePath = Join-Path $generatedModelFolder $targetFilename -Resolve
    Update-In-File-With-Retry `
        -FilePath $filePath `
        -SearchPattern "public abstract" `
        -ReplacePattern "public" `
        -RequirePresence
}