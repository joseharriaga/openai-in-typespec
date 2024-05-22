$generatedCodeRoot = Join-Path $PSScriptRoot .. src Generated -Resolve

Get-ChildItem $generatedCodeRoot -File -Filter "Internal*.cs" | ForEach-Object {
    $content = Get-Content $_.FullName -Raw
    $newContent = $content -replace 'public(.*?)\{ get; \}', 'internal$1{ get; set; }'
    Set-Content -Path $_.FullName -Value $newContent
}