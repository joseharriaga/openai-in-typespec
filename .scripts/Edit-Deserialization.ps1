$repoRoot = Join-Path $PSScriptRoot .. -Resolve
$generatedModelFolder = Join-Path $repoRoot .dotnet\src\Generated\Models

$files = Get-ChildItem -Path $generatedModelFolder -Filter "*Serialization.cs"

$editedFilesCount = 0
    
foreach ($file in $files) {
    $statusText = "{0:D3}/{1:D3} : Processing codegen fixup for response deserialization..." -f $editedFilesCount, $files.Count
    $percentComplete = [math]::Round(($editedFilesCount / $files.Count) * 100)
    Write-Progress -Activity "Editing" -Status $statusText -PercentComplete $percentComplete
    $content = Get-Content -Path $file.FullName
    $updatedContent = $content -replace "options.Format != `"W`"", "true"
    if ($content -ne $updatedContent) {
        Set-Content -Path $file.FullName -Value $updatedContent
    }
    $editedFilesCount++
}

Write-Progress -Activity "Complete" -PercentComplete 100
