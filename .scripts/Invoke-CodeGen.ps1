#!/usr/bin/env pwsh

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
  Invoke { npm exec --no -- tsp compile . --pretty }
  Invoke { .$PSScriptRoot\Update-ClientModel.ps1 }
  Invoke { .$PSScriptRoot\Edit-Serialization.ps1 }
  Invoke { .$PSScriptRoot\Run-Checks.ps1 }
}
finally {
  Pop-Location
}
