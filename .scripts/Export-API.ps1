$repoRoot = Join-Path $PSScriptRoot .. -Resolve
$sourceFolder = Join-Path $repoRoot .dotnet\src
$apiFolder = Join-Path $repoRoot .dotnet\api

$platformTarget = "netstandard2.0"
$projectPath = Join-Path $sourceFolder OpenAI.csproj
$assemblyPath = Join-Path $sourceFolder bin\Debug $platformTarget OpenAI.dll
$outputPath = Join-Path $apiFolder "OpenAI.$($platformTarget).cs"

Write-Output "Building OpenAI.dll..."
Write-Output ""

dotnet build $projectPath
Write-Output ""

Write-Output "Generating OpenAI.netstandard2.0.cs..."
Write-Output ""

$net80ref = Get-ChildItem -Recurse `
    -Path "$($env:ProgramFiles)\dotnet\packs\Microsoft.NETCore.App.Ref" `
    -Include "net8.0" | Select-Object -Last 1
$systemMemoryDataRef = Get-ChildItem -Recurse `
    -Path "$($env:UserProfile)\.nuget\packages\system.memory.data" `
    -Include "netstandard2.0" | Select-Object -Last 1
$systemClientmodelRef = Get-ChildItem -Recurse `
    -Path "$($env:UserProfile)\.nuget\packages\system.clientmodel" `
    -Include "netstandard2.0" | Select-Object -Last 1
$microsoftBclAsyncinterfacesRef = Get-ChildItem -Recurse `
    -Path "$($env:UserProfile)\.nuget\packages\microsoft.bcl.asyncinterfaces\1.1.0" `
    -Include "netstandard2.0" | Select-Object -Last 1

Write-Output "Assembly reference paths:"
Write-Output "* NETCore:                       $($net80ref)"
Write-Output "* System.Memory.Data:            $($systemMemoryDataRef)"
Write-Output "* System.ClientModel:            $($systemClientmodelRef)"
Write-Output "* Microsoft.Bcl.AsyncInterfaces: $($microsoftBclAsyncinterfacesRef)"
Write-Output "NOTE: if any of the above are empty, tool output may be inaccurate."
Write-Output ""

genapi --assembly $assemblyPath --output-path $outputPath `
    --assembly-reference $net80ref `
    --assembly-reference $systemMemoryDataRef `
    --assembly-reference $systemClientmodelRef `
    --assembly-reference $microsoftBclAsyncinterfacesRef

Write-Output "Cleaning up OpenAI.netstandard2.0.cs..."
Write-Output ""

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