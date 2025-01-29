$repoRoot = Join-Path $PSScriptRoot .. -Resolve
$dotnetFolder = Join-Path $repoRoot .dotnet\src

function Invoke([scriptblock]$script) {
  $scriptString = $script | Out-String
  Write-Host "--------------------------------------------------------------------------------`n> $scriptString"
  & $script
}

$scriptStartTime = Get-Date

Push-Location $repoRoot

try {
  Invoke { npm ci }
  Invoke { npm run build -w .plugin }
  Set-Location $repoRoot/.typespec
  Invoke { npm exec --no -- tsp format **/*tsp }
  Invoke { npm exec --no -- tsp compile . }
  Invoke { .$PSScriptRoot\Update-ClientModel.ps1 }
  Invoke { .$PSScriptRoot\Edit-Deserialization.ps1 }
  Invoke { .$PSScriptRoot\Remove-Abstract.ps1 }
  Invoke { .$PSScriptRoot\Edit-Serialization.ps1 }
  Invoke { .$PSScriptRoot\Run-Checks.ps1 }
}
finally {
  Pop-Location
}

$scriptElapsed = $(Get-Date) - $scriptStartTime
$scriptElapsedSeconds = [math]::Round($scriptElapsed.TotalSeconds, 1)
$scriptName = $MyInvocation.MyCommand.Name

Write-Host "${scriptName} complete. Time: ${scriptElapsedSeconds}s"