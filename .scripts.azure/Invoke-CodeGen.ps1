$repoRoot = Join-Path $PSScriptRoot .. -Resolve

function Invoke([scriptblock]$script) {
  $scriptString = $script | Out-String
  Write-Host "--------------------------------------------------------------------------------`n> $scriptString"
  & $script
}

Push-Location $repoRoot
try {
  Set-Location $repoRoot/.typespec.azure
  Invoke { npm ci }
  Invoke { npm exec --no -- tsp format **/*tsp }
  Invoke { npm exec --no -- tsp compile . }
  Set-Location $repoRoot
  Invoke { npm run build -w .plugin.azure }
}
finally {
  Pop-Location
}
