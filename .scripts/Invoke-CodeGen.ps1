$repoRoot = Join-Path $PSScriptRoot .. -Resolve
$dotnetFolder = Join-Path $repoRoot .dotnet\src

function Invoke([scriptblock]$script) {
  $scriptString = $script | Out-String
  Write-Host "--------------------------------------------------------------------------------`n> $scriptString"
  & $script
}

Push-Location $repoRoot/.typespec
try {
  Invoke { npm ci }
  Invoke { npm exec --no -- tsp format **/*tsp }
  Invoke { npm exec --no -- tsp compile main.tsp --emit @typespec/openapi3 }
  Invoke { npm exec --no -- tsp compile client.tsp --emit @azure-tools/typespec-csharp --option @azure-tools/typespec-csharp.emitter-output-dir="$dotnetFolder" }
  Invoke { .$PSScriptRoot\Update-ClientModel.ps1 }
  Invoke { .$PSScriptRoot\ConvertTo-Internal.ps1 }
  Invoke { .$PSScriptRoot\Add-Customizations.ps1 }
}
finally {
  Pop-Location
}
