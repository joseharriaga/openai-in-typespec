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

        # Retry Set-Content until it succeeds
        # Set-Content -Path $file.FullName -Value $updatedContent
        $retryCount = 0
        $retryLimit = 5
        $retryDelay = 1
        $retry = $true
        while ($retry -and $retryCount -lt $retryLimit) {
            try {
                Set-Content -Path $file.FullName -Value $updatedContent
                $retry = $false
            } catch {
                $retryCount++
                Write-Output "Failed to write to file. Retrying in $retryDelay seconds..."
                Start-Sleep -Seconds $retryDelay
            }
        }
    }
    $editedFilesCount++
}

Write-Progress -Activity "Editing" -Status "Complete" -Completed
Write-Output "Complete: deserialization edited."