function Invoke-GenAPI {
    param (
        [string]$TargetFramework
    )

    $repoRootPath = Join-Path $PSScriptRoot ..\.. -Resolve
    $assemblyPath = Join-Path $repoRootPath .dotnet\src\bin\Debug $TargetFramework OpenAI.dll

    $outputName = "OpenAI.$($TargetFramework).cs"
    $outputPath = Join-Path $repoRootPath .dotnet\api $outputName

    Write-Output "Generating $($outputName)..."
    Write-Output ""

    Write-Output "  Assembly reference paths:"
    Write-Output ""

    # .NET
    $netRef = Get-ChildItem -Recurse `
        -Path "$($env:ProgramFiles)\dotnet\packs\Microsoft.NETCore.App.Ref" `
        -Include "net8.0" | Select-Object -Last 1

    Write-Output "  * .NET:"
    Write-Output "    $($netRef)"
    Write-Output ""

    # System.ClientModel
    $systemClientModelRef = Get-ChildItem `
        -Path "$($env:UserProfile)\.nuget\packages\system.clientmodel\1.2.1" `
        -Include $(($TargetFramework -eq "netstandard2.0") ? "netstandard2.0" : "net6.0") `
        -Recurse |
            Select-Object -Last 1

    Write-Output "  * System.ClientModel:"
    Write-Output "    $($systemClientModelRef)"
    Write-Output ""

    # System.Memory.Data
    $systemMemoryDataRef = Get-ChildItem `
        -Path "$($env:UserProfile)\.nuget\packages\system.memory.data\6.0.0" `
        -Include  $(($TargetFramework -eq "netstandard2.0") ? "netstandard2.0" : "net6.0") `
        -Recurse |
            Select-Object -Last 1

    Write-Output "  * System.Memory.Data:"
    Write-Output "    $($systemMemoryDataRef)"
    Write-Output ""

    # System.Diagnostics.DiagnosticSource
    $systemDiagnosticsDiagnosticSourceRef = Get-ChildItem `
        -Path "$($env:UserProfile)\.nuget\packages\system.diagnostics.diagnosticsource\6.0.1" `
        -Include $(($TargetFramework -eq "netstandard2.0") ? "netstandard2.0" : "net5.0") `
        -Recurse |
            Select-Object -Last 1

    Write-Output "  * System.Diagnostics.DiagnosticSource:"
    Write-Output "    $($systemDiagnosticsDiagnosticSourceRef)"
    Write-Output ""

    if ($TargetFramework -eq "netstandard2.0") {
        # Microsoft.Bcl.AsyncInterfaces
        $microsoftBclAsyncInterfacesRef = Get-ChildItem `
            -Path "$($env:UserProfile)\.nuget\packages\microsoft.bcl.asyncinterfaces\1.1.0" `
            -Include "netstandard2.0" `
            -Recurse |
                Select-Object -Last 1

        Write-Output "  * Microsoft.Bcl.AsyncInterfaces:"
        Write-Output "    $($microsoftBclAsyncInterfacesRef)"
        Write-Output ""
    }

    Write-Output "  NOTE: if any of the above are empty, tool output may be inaccurate."
    Write-Output ""

    genapi --assembly $assemblyPath --output-path $outputPath `
        --assembly-reference $netRef `
        --assembly-reference $systemClientModelRef `
        --assembly-reference $systemMemoryDataRef `
        --assembly-reference $systemDiagnosticsDiagnosticSourceRef `
        --assembly-reference $microsoftBclAsyncInterfacesRef

    Write-Output "Cleaning up $($outputName)..."
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

    # Remove IJsonModel/IPersistableModel interface method entries.
    $content = $content -creplace "        .*(IJsonModel|IPersistableModel).*`n", ""
    $content = $content -creplace "        protected (virtual|override) .* (Json|Persistable)Model(Create|Write)Core.*`n", ""

    # Other cosmetic simplifications.
    $content = $content -creplace "partial class", "class"
    $content = $content -creplace ".*private.*dummy.*`n", ""
    $content = $content -creplace " { throw null; }", ";"
    $content = $content -creplace " { }", ";"
    $content = $content -creplace "Diagnostics.CodeAnalysis.Experimental", "Experimental"
    $content = $content -creplace "Diagnostics.CodeAnalysis.SetsRequiredMembers", "SetsRequiredMembers"

    Set-Content -Path $outputPath -Value $content -NoNewline
}

$repoRootPath = Join-Path $PSScriptRoot ..\.. -Resolve
$projectPath = Join-Path $repoRootPath .dotnet\src\OpenAI.csproj

Write-Output "Building OpenAI.csproj..."
Write-Output ""
dotnet build $projectPath
Write-Output ""

Invoke-GenAPI -TargetFramework "netstandard2.0"
Invoke-GenAPI -TargetFramework "net8.0"