function Update-In-File-With-Retry {
    param(
        [string]$filePath,
        [string]$searchPattern,
        [string[]]$searchPatternLines,
        [string]$replacePattern,
        [string[]]$replacePatternLines,
        [switch]$RequirePresence,
        [int]$outputIndentation = 0,
        [int]$maxRetries = 5,
        [int]$delayMilliseconds = 200
    )

    $multilineIndent = (" " * $outputIndentation)

    if ($searchPatternLines) {
        $searchPattern = "(?s)"
        foreach ($line in $searchPatternLines) { $searchPattern += "\s+" + $line }
    }

    if ($replacePatternLines) {
        $replacePattern = ""
        foreach ($line in $replacePatternLines) { $replacePattern += "`n" + $multilineIndent + $line }
    }

    $retryCount = 0
    $success = $false

    while (-not $success -and $retryCount -lt $maxRetries) {
        try {
            $content = Get-Content -Path $filePath -Raw
            $updatedContent = $content -replace $searchPattern, $replacePattern
            if ($content -ne $updatedContent) {
                Set-Content -Path $filePath -Value $updatedContent -NoNewLine
                $success = $true
            } elseif ($RequirePresence) {
                $retryCount = $maxRetries
                throw "Failed to find pattern '$searchPattern' in file '$filePath'."
            } else {
                $success = $true
            }
        }
        catch {
            $exceptionMessage = $_.Exception.Message
            Write-Warning "Retrying for error: $exceptionMessage"
            Start-Sleep -Milliseconds $delayMilliseconds
            $retryCount++
        }
    }

    if (-not $success) {
        throw "Failed to replace content in file '$filePath' after $maxRetries attempts."
    }
}