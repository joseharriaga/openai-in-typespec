[CmdletBinding()] param()

$repoRoot = Join-Path $PSScriptRoot .. -Resolve
$dotnetAzureFolder = Join-Path $repoRoot .dotnet.azure
$Verbose = $PSCmdlet.MyInvocation.BoundParameters["Verbose"].IsPresent

function Invoke([scriptblock]$script) {
  $scriptString = $script | Out-String
  if ($Verbose) {
    Write-Host "--------------------------------------------------------------------------------`n"
  }
  Write-Host "> $scriptString"
  if ($Verbose) {
    & $script
  } else {
    & $script > $null
  }
  if ($LastExitCode -ne 0) {
    Write-Error "Command returned non-zero exit code. Run with -Verbose for full output."
    exit 1
  }
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
    if ($Verbose) {
      Write-Output "Editing $($file.FullName)"
    }
    $content = $content -creplace "internal static class ClientPipelineExtensions", "internal static partial class ClientPipelineExtensions"
    $content | Set-Content -Path $file.FullName -NoNewline
}

function Partialize-ClientUriBuilder {
    $file = Get-ChildItem -Path "$dotnetAzureFolder\src\Generated\Internal\ClientUriBuilder.cs"
    $content = Get-Content -Path $file -Raw
    if ($Verbose) {
      Write-Output "Editing $($file.FullName)"
    }
    $content = $content -creplace "internal class ClientUriBuilder", "internal partial class ClientUriBuilder"
    $content | Set-Content -Path $file.FullName -NoNewline
}

function Prune-Generated-Files {
  $patternsToKeep = @(
      "*BingSearchTool*",
      "*DataSource*",
      "*ContentFilter*",
      "*OpenAI*Error*",
      "*Context*",
      "*RetrievedDoc*",
      "*Citation*",
      "*Version*"
  )
  $patternsToDelete = @(
      "BingSearchToolDefinition.cs",
      "*Elasticsearch*QueryType*",
      "*FieldsMapping*",
      "*ContentTextAnnotationsFileCitation*"
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
          if ($Verbose) {
            Write-Output "Removing: $generatedFilename"
          }
          Remove-Item $generatedFile
      }
  }
}

Push-Location $repoRoot/.typespec.azure
try {
  if ($Verbose) {
    Write-Output "Running with verbose output."
  } else {
    Write-Output "Running with minimal output. Use -Verbose for full output."
  }

  Invoke { npm ci }
  Invoke { npm exec --no -- tsp format **/*tsp }
  Invoke { npm exec --no -- tsp compile . }
  Invoke { Prune-Generated-Files }
  Invoke { Make-Internals-Settable }
  Invoke { Partialize-ClientPipelineExtensions }
  Invoke { Partialize-ClientUriBuilder }
}
finally {
  Pop-Location
}
