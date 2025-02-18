
function Invoke-APICompat {
    param (
        [string]$BaselineVersion,
        [string[]]$IgnoredNamespaces
    )
    $repoRootPath = Join-Path $PSScriptRoot .. -Resolve
    $dotnetFolderPath = Join-Path $repoRootPath .dotnet
    $projectPath = Join-Path $repoRootPath .dotnet\src\OpenAI.csproj

    # Extract the values of VersionPrefix and VersionSuffix from the .csproj XML file.
    $xml = [xml](Get-Content $projectPath)
    $versionPrefix = $($xml.Project.PropertyGroup[0].VersionPrefix)
    $versionSuffix = $($xml.Project.PropertyGroup[0].VersionSuffix)
    $currentVersion = [string]::IsNullOrEmpty($versionSuffix) ? "$($versionPrefix)" : "$($versionPrefix)-$($versionSuffix)"

    $packageName = "OpenAI"
    $currentNuGetPackagePath = Join-Path $repoRootPath .dotnet\src\bin\Release\$($packageName).$($currentVersion).nupkg
    $currentNuGetSymbolsPath = Join-Path $repoRootPath .dotnet\src\bin\Release\$($packageName).$($currentVersion).snupkg

    try
    {
        # Create temporary folder
        $tempFolderPath = Join-Path $dotnetFolderPath "\TempApiCompatibility"
        New-Item -ItemType Directory -Path $tempFolderPath | Out-Null

        # Download OpenAI NuGet package version 2.0.0
        $baselineNuGetPackageName = "$($packageName).$($baselineVersion).nupkg"
        $baselineNuGetPackagePath = Join-Path $tempFolderPath $baselineNuGetPackageName
        $baselineNuGetPackageUrl = "https://www.nuget.org/api/v2/package/$($packageName)/$($baselineVersion)"
        Invoke-RestMethod -Uri $baselineNuGetPackageUrl -OutFile $baselineNuGetPackagePath
        Sleep 3

        Write-Output "Testing API compatibility between versions $($currentVersion) (current) and $($baselineVersion) (baseline)..."
        Write-Output ""

        # Run apicompat and redirect the error output to a variable
        $output = apicompat package $currentNuGetPackagePath --baseline-package $baselineNuGetPackagePath 2>&1

        # Individual warnings from apicompat have identifiers such as "CP0001", "CP0002", etc.
        $warningRegex = "CP\d\d\d\d"

        # Concatenate the ignored namespaces into a single string, delimiting them by "|" and escaping the "."
        $ignoredRegex = $IgnoredNamespaces -join "|" -creplace "\.", "\."

        Write-Output $excludedRegex

        $warningsFound = 0

        foreach ($line in $($output -split "`r`n")) {
            if ($line -cmatch $warningRegex) {
                if ($($line -cnotmatch $ignoredRegex)) {
                    $warningsFound++
                }
            }
        }

        if ($warningsFound -eq 0) {
            Write-Output "No API breaking changes found."
            Write-Output ""
        }
        else {
            foreach ($line in $($output -split "`r`n")) {
                if ($line -cmatch $warningRegex) {
                    if ($($line -cnotmatch $ignoredRegex)){
                        Write-Warning "$line"
                        Write-Output ""
                    }
                }
                else {
                    Write-Output "$line"
                    Write-Output ""
                }
            }
        }
    }
    finally {
        Remove-Item -Path $tempFolderPath -Recurse -Force
        Remove-Item -Path $currentNuGetPackagePath -Force
        Remove-Item -Path $currentNuGetSymbolsPath -Force
    }
}

$repoRootPath = Join-Path $PSScriptRoot .. -Resolve
$projectPath = Join-Path $repoRootPath .dotnet\src\OpenAI.csproj

Write-Output "Building OpenAI.csproj..."
Write-Output ""
dotnet build $projectPath
Write-Output ""

Write-Output "Packing OpenAI.csproj..."
Write-Output ""
dotnet pack $projectPath
Write-Output ""

Invoke-APICompat -BaselineVersion "2.1.0" -IgnoredNamespaces "OpenAI.Assistants", "OpenAI.Batch", "OpenAI.FineTuning", "OpenAI.RealtimeConversation", "OpenAI.VectorStores"