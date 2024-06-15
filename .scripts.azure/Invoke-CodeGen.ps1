$repoRoot = Join-Path $PSScriptRoot .. -Resolve
$dotnetAzureFolder = Join-Path $repoRoot .dotnet.azure

function Invoke([scriptblock]$script) {
  $scriptString = $script | Out-String
  Write-Host "--------------------------------------------------------------------------------`n> $scriptString"
  & $script
}

function Make-Internals-Settable {
  Get-ChildItem "$dotnetAzureFolder\src\Generated" -File -Filter "Internal*.cs" | ForEach-Object {
      $content = Get-Content $_.FullName -Raw
      $newContent = $content -replace 'public(.*?)\{ get; \}', 'internal$1{ get; set; }'
      Set-Content -Path $_.FullName -Value $newContent
  }
}

function Partialize-ClientPipelineExtensions {
    $file = Get-ChildItem -Path "$dotnetAzureFolder\src\Generated\Internal\ClientPipelineExtensions.cs"
    $content = Get-Content -Path $file -Raw
    Write-Output "Editing $($file.FullName)"
    $content = $content -creplace "internal static class ClientPipelineExtensions", "internal static partial class ClientPipelineExtensions"
    $content | Set-Content -Path $file.FullName -NoNewline
}

function Partialize-ClientUriBuilder {
    $file = Get-ChildItem -Path "$dotnetAzureFolder\src\Generated\Internal\ClientUriBuilder.cs"
    $content = Get-Content -Path $file -Raw
    Write-Output "Editing $($file.FullName)"
    $content = $content -creplace "internal class ClientUriBuilder", "internal partial class ClientUriBuilder"
    $content | Set-Content -Path $file.FullName -NoNewline
}

function Prune-Generated-Files {
  $patternsToKeep = @(
      "*DataSource*",
      "*ContentFilter*",
      "*OpenAI*Error*",
      "*Context*",
      "*RetrievedDoc*",
      "*Citation*"
  )
  $patternsToDelete = @(
      "*Elasticsearch*QueryType*",
      "*FieldsMapping*"
  )

  Get-ChildItem "$dotnetAzureFolder\src\Generated" -File | ForEach-Object {
      $generatedFile = $_;
      $generatedFilename = $_.Name;
      $keepFile = $false
      foreach ($pattern in $patternsToKeep) {
          if ($generatedFilename -like "$pattern") {
              $keepFile = $true
              foreach ($deletePattern in $patternsToDelete) {
                  if ($generatedFilename -like $deletePattern) {
                      $keepFile = $false
                      break
                  }
              }
              break
          }
      }
      if (-not $keepFile) {
          Write-Output "Removing: $generatedFilename"
          Remove-Item $generatedFile
      }
  }
}

Push-Location $repoRoot/.typespec.azure
try {
  Invoke { npm ci }
  Invoke { npm exec --no -- tsp format **/*tsp }
  Invoke { npm exec --no -- tsp compile . }
  Prune-Generated-Files
  Make-Internals-Settable
  Partialize-ClientPipelineExtensions
  Partialize-ClientUriBuilder
}
finally {
  Pop-Location
}
