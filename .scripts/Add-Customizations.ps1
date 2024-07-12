function Make-Mutable-Collections-Initable([ref]$FileContentReference) {
    $pattern = '(.*public (IList<|IDictionary<)[^{]*){ get;( set;)? }'
    $matches = [regex]::Matches($FileContentReference.Value, $pattern)

    foreach ($match in $matches) {
        $propertyDeclaration = $match.Groups[1].Value
        $newPropertyDeclaration = "$propertyDeclaration{ get; init; }"
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

    Make-Mutable-Collections-Initable -FileContentReference ([ref]$currentFileContent)

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
