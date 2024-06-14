$specRoot = Join-Path $PSScriptRoot .. specification -Resolve
$generatedCodeRoot = Join-Path $PSScriptRoot .. src Generated -Resolve

function Invoke([scriptblock]$script) {
  $scriptString = $script | Out-String
  Write-Host "--------------------------------------------------------------------------------`n> $scriptString"
  & $script
}

function Partialize-ClientPipelineExtensions {
    $file = Get-ChildItem -Path "$generatedCodeRoot\Internal\ClientPipelineExtensions.cs"
    $content = Get-Content -Path $file -Raw
    Write-Output "Editing $($file.FullName)"
    $content = $content -creplace "internal static class ClientPipelineExtensions", "internal static partial class ClientPipelineExtensions"
    $content | Set-Content -Path $file.FullName -NoNewline
}

function Partialize-ClientUriBuilder {
    $file = Get-ChildItem -Path "$generatedCodeRoot\Internal\ClientUriBuilder.cs"
    $content = Get-Content -Path $file -Raw
    Write-Output "Editing $($file.FullName)"
    $content = $content -creplace "internal class ClientUriBuilder", "internal partial class ClientUriBuilder"
    $content | Set-Content -Path $file.FullName -NoNewline
}

Push-Location $specRoot
try {
  Invoke { npm ci }
  Invoke { npm exec --no -- tsp format **/*tsp }
  Invoke { npm exec --no -- tsp compile . }
  Invoke { .$PSScriptRoot/Prune-Generated-Files.ps1 }
  Invoke { .$PSScriptRoot/Make-Internals-Settable.ps1 }
  Partialize-ClientPipelineExtensions
  Partialize-ClientUriBuilder
}
finally {
  Pop-Location
}
