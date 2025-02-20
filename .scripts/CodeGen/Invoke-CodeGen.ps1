$repoRootPath = Join-Path $PSScriptRoot ..\.. -Resolve
$typeSpecFolderPath = Join-Path $repoRootPath .typespec

function Invoke([scriptblock]$script) {
  $scriptString = $script | Out-String
  Write-Host "--------------------------------------------------------------------------------`n> $scriptString"
  & $script
}

$scriptStartTime = Get-Date

Push-Location $repoRootPath

try {
  Invoke { npm ci }
  Invoke { npm run build -w .plugin }
  Set-Location $typeSpecFolderPath
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