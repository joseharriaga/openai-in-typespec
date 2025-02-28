$repoRoot = Join-Path $PSScriptRoot .. -Resolve

function Invoke([scriptblock]$script) {
  $scriptString = $script | Out-String
  Write-Host "--------------------------------------------------------------------------------`n> $scriptString"
  & $script
}

$scriptStartTime = Get-Date

Push-Location $repoRoot

try {
  Invoke { npm ci }
  Invoke { npm run build -w .plugin.azure }
  Set-Location $repoRoot/.typespec.azure
  Invoke { npm exec --no -- tsp format **/*tsp }
  Invoke { npm exec --no -- tsp compile . }
}
finally {
  Pop-Location
}

$scriptElapsed = $(Get-Date) - $scriptStartTime
$scriptElapsedSeconds = [math]::Round($scriptElapsed.TotalSeconds, 1)
$scriptName = $MyInvocation.MyCommand.Name

Write-Host "${scriptName} complete. Time: ${scriptElapsedSeconds}s"