$repoRoot = Join-Path $PSScriptRoot .. -Resolve
$sourceFolder = Join-Path $repoRoot .dotnet\src
$apiFolder = Join-Path $repoRoot .dotnet\api

$platformTarget = "netstandard2.0"
$projectPath = Join-Path $sourceFolder OpenAI.csproj
$assemblyPath = Join-Path $sourceFolder bin\Debug $platformTarget OpenAI.dll
$outputPath = Join-Path $apiFolder "OpenAI.$($platformTarget).cs"

Write-Output "Building OpenAI.dll"

dotnet build $projectPath

Write-Output "Generating OpenAI.netstandard2.0.cs"

genapi --assembly $assemblyPath --output-path $outputPath `
    --assembly-reference "$($env:ProgramFiles)\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.7\ref\net8.0" `
    --assembly-reference "$($env:UserProfile)\.nuget\packages\system.memory.data\1.0.2\lib\netstandard2.0" `
    --assembly-reference "$($env:UserProfile)\.nuget\packages\system.clientmodel\1.1.0-beta.5\lib\netstandard2.0" `
    --assembly-reference "$($env:UserProfile)\.nuget\packages\microsoft.bcl.asyncinterfaces\1.1.0\lib\netstandard2.0"

Write-Output "Cleaning up OpenAI.netstandard2.0.cs"

$content = Get-Content $outputPath -Raw

# Remove empty lines.
$content = $content -creplace '//.*\r?\n', ''
$content = $content -creplace '\r?\n\r?\n', "`n"
$content = $content -creplace '\r?\n *{', " {"

# Remove fully-qualified names.
$content = $content -creplace "System\.ComponentModel\.", ""
$content = $content -creplace "System\.ClientModel.Primitives\.", ""
$content = $content -creplace "System\.ClientModel\.", ""
$content = $content -creplace "System\.Collections\.Generic\.", ""
$content = $content -creplace "System\.Collections\.", ""
$content = $content -creplace "System\.Threading.Tasks\.", ""
$content = $content -creplace "System\.Threading\.", ""
$content = $content -creplace "System\.Text.Json\.", ""
$content = $content -creplace "System\.Text\.", ""
$content = $content -creplace "System\.IO\.", ""
$content = $content -creplace "System\.", ""
$content = $content -creplace "Assistants\.", ""
$content = $content -creplace "Audio\.", ""
$content = $content -creplace "Batch\.", ""
$content = $content -creplace "Chat\.", ""
$content = $content -creplace "Embeddings\.", ""
$content = $content -creplace "Files\.", ""
$content = $content -creplace "FineTuning\.", ""
$content = $content -creplace "Images\.", ""
$content = $content -creplace "Models\.", ""
$content = $content -creplace "Moderations\.", ""
$content = $content -creplace "VectorStores\.", ""

# Remove Diagnostics.DebuggerStepThrough attribute.
$content = $content -creplace ".*Diagnostics.DebuggerStepThrough.*\n", ""

# Remove internal APIs.
$content = $content -creplace "  * internal.*`n", ""

# Other cosmetic simplifications.
$content = $content -creplace "partial class", "class"
$content = $content -creplace " { throw null; }", ";"
$content = $content -creplace " { }", ";"

Set-Content -Path $outputPath -Value $content -NoNewline