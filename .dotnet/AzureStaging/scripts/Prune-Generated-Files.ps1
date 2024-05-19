$generatedCodeRoot = Join-Path $PSScriptRoot .. src Generated -Resolve

$patternsToKeep = @(
    "*ChatDataSource",
    "ContentFilter",
    "OpenAI*Error"
)

Get-ChildItem $generatedCodeRoot -File | ForEach-Object {
    $generatedFile = $_;
    $generatedFilename = $_.Name;
    $keepFile = $false
    foreach ($pattern in $patternsToKeep) {
        if ($generatedFilename -like "*$pattern*") {
            $keepFile = $true
            break
        }
    }
    if (-not $keepFile) {
        Write-Output "Removing: $generatedFilename"
        Remove-Item $generatedFile
    }
}