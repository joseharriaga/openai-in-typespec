$repoRoot = Join-Path $PSScriptRoot .. -Resolve
$dotnetFolder = Join-Path $repoRoot .dotnet\src
$apiFolder = Join-Path $repoRoot .dotnet\api

$platformTarget = "netstandard2.0"

$assemblyPath = Join-Path $dotnetFolder bin\Debug $platformTarget OpenAI.dll
$outputPath = Join-Path $apiFolder "OpenAI.$($platformTarget).cs"

genapi --assembly $assemblyPath --output-path $outputPath `
    --assembly-reference "$($env:ProgramFiles)\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.5\ref\net8.0" `
    --assembly-reference "$($env:ProgramFiles)\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.7\ref\net8.0" `
    --assembly-reference "$($env:UserProfile)\.nuget\packages\system.memory.data\1.0.2\lib\netstandard2.0" `
    --assembly-reference "$($env:UserProfile)\.nuget\packages\system.clientmodel\1.1.0-beta.5\lib\netstandard2.0" `
    --assembly-reference "$($env:UserProfile)\.nuget\packages\microsoft.bcl.asyncinterfaces\1.1.0\lib\netstandard2.0"

$content = Get-Content $outputPath -Raw

$content = $content -replace '//.*\r?\n', ''
$content = $content -replace '\r?\n\r?\n', "`n"

$content = $content -replace '.*Diagnostics.DebuggerStepThrough.*\n', ''
$content = $content -replace 'ComponentModel.', ''

$content = $content -replace 'System.ClientModel.Primitives.', ''
$content = $content -replace 'System.ClientModel.', ''
$content = $content -replace 'System.Collections.Generic.', ''
$content = $content -replace 'System.Collections.', ''
$content = $content -replace 'System.Threading.Tasks.', ''
$content = $content -replace 'System.Threading.', ''
$content = $content -replace 'System.Text.Json.', ''
$content = $content -replace 'System.Text.', ''
$content = $content -replace 'System.IO.', ''
$content = $content -replace 'System\.', ''

$content = $content -replace "partial class", "class"
$content = $content -replace '\r?\n *{', " {"
$content = $content -replace 'throw null;', ''
$content = $content -replace ' { *}', ';'
$content = $content -replace ' *public int value__;\r?\n', ''
$content = $content -replace "  * internal.*`n", ""
$content = $content -replace '(virtual )[^ \.]*\.', '$1'
$content = $content -replace "cancellationToken = null", "cancellationToken = default"

Set-Content -Path $outputPath -Value $content -NoNewline

# For PR diff only
$markdownContent = "``````csharp`n$($content)`n``````"
Set-Content -Path "$($apiFolder)\api.md" -Value $markdownContent -NoNewline