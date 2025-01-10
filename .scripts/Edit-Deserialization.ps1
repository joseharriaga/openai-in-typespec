. $PSScriptRoot\Helpers.ps1

$repoRoot = Join-Path $PSScriptRoot .. -Resolve
$generatedModelFolder = Join-Path $repoRoot .dotnet\src\Generated\Models

$files = Get-ChildItem -Path $generatedModelFolder -Filter "*Serialization.cs"

$editedFilesCount = 0

foreach ($file in $files) {
    $statusText = "{0:D3}/{1:D3} : Processing codegen fixup for response deserialization..." -f $editedFilesCount, $files.Count
    $percentComplete = [math]::Round(($editedFilesCount / $files.Count) * 100)
    Write-Progress -Activity "Editing" -Status $statusText -PercentComplete $percentComplete
    Update-In-File-With-Lock-And-Retry `
        -FilePath $file.FullName `
        -SearchPattern "options.Format != `"W`"" `
        -ReplacePattern "true"
    $editedFilesCount++
}

Write-Progress -Activity "Editing" -Status "Complete" -Completed
Write-Output "Complete: deserialization edited."