$generatedCodeRoot = Join-Path $PSScriptRoot .. src Generated -Resolve

$patternsToKeep = @(
    "*DataSource*",
    "*ContentFilter*",
    "*OpenAI*Error*",
    "*Context*",
    "*RetrievedDoc*",
    "*Citation*"
)
$patternsToDelete = @(
    "*Elasticsearch*QueryType*",
    "*FieldsMapping*"
)

Get-ChildItem $generatedCodeRoot -File | ForEach-Object {
    $generatedFile = $_;
    $generatedFilename = $_.Name;
    $keepFile = $false
    foreach ($pattern in $patternsToKeep) {
        if ($generatedFilename -like "$pattern") {
            $keepFile = $true
            foreach ($deletePattern in $patternsToDelete) {
                if ($generatedFilename -like $deletePattern) {
                    $keepFile = $false
                    break
                }
            }
            break
        }
    }
    if (-not $keepFile) {
        Write-Output "Removing: $generatedFilename"
        Remove-Item $generatedFile
    }
}