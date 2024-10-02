$repoRoot = Join-Path $PSScriptRoot .. -Resolve
$generatedModelFolder = Join-Path $repoRoot .dotnet\src\Generated\Models

$targetFilenames = (
    "ChatMessage.cs",
    "ChatMessage.Serialization.cs",
    "ChatResponseFormat.cs",
    "ChatResponseFormat.Serialization.cs"
)

foreach ($targetFilename in $targetFilenames) {
    $filePath = Join-Path $generatedModelFolder $targetFilename -Resolve
    $content = Get-Content -Path $filePath
    $updatedContent = $content -replace "public abstract", "public"
    if ($content -ne $updatedContent) {
        Write-Output "Removing abstract class modifier from file: $targetFilename"
        Set-Content -Path $filePath -Value $updatedContent
    }
}