function Update-In-File-With-Lock-And-Retry {
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

    $indent = (" " * $outputIndentation)

    if ($searchPatternLines) {
        $searchPattern = "(?s)"
        foreach ($line in $searchPatternLines) { $searchPattern += "\s+" + $line }
    }

    if ($replacePatternLines) {
        $replacePattern = ""
        foreach ($line in $replacePatternLines) { $replacePattern += "`n" + $indent + $line }
    }

    $retryCount = 0
    $success = $false

    while (-not $success -and $retryCount -lt $maxRetries) {
        try {
            $fileStream = [System.IO.File]::Open($filePath, [System.IO.FileMode]::Open, [System.IO.FileAccess]::Read, [System.IO.FileShare]::Read)
            try {
                $reader = New-Object System.IO.StreamReader($fileStream)
                $content = $reader.ReadToEnd()
                $reader.Close()
                $updatedContent = $content -replace $searchPattern, $replacePattern
                if ($content -ne $updatedContent) {
                    $fileStream.Close()  # Close the read stream before writing
                    $writerStream = [System.IO.File]::Open($filePath, [System.IO.FileMode]::Create, [System.IO.FileAccess]::Write, [System.IO.FileShare]::None)
                    $writer = New-Object System.IO.StreamWriter($writerStream)
                    $writer.Write($updatedContent)
                    $writer.Flush()  # Ensure all data is written to the file
                    $writer.Close()
                    $success = $true
                }
                elseif ($requirePresence) {
                    $retryCount = $maxRetries
                    throw "Failed to find pattern '$searchPattern' in file '$filePath'."
                }
                else {
                    $success = $true
                }
            } finally {
                $fileStream.Close()
            }
        } catch {
            $exceptionMessage = $_.Exception.Message
            Write-Host "Retrying for error: $exceptionMessage"
            Start-Sleep -Milliseconds $delayMilliseconds
            $retryCount++
        }
    }

    if (-not $success) {
        throw "Failed to replace content in file '$filePath' after $maxRetries attempts."
    }
}