$repoRoot = Join-Path $PSScriptRoot .. -Resolve
$dotnetAzureFolder = Join-Path $repoRoot .dotnet.azure
$dotnetAzureOpenAIFolder = Join-Path $dotnetAzureFolder sdk/openai

if (-not $env:AZURE_SDK_FOR_NET_REPO_ROOT) {
    Write-Error "This script requires setting the AZURE_SDK_FOR_NET_REPO_ROOT environment variable."
    break
}

$azsdkDestRoot = Join-Path $env:AZURE_SDK_FOR_NET_REPO_ROOT sdk/openai

if (-not $(Test-Path $azsdkDestRoot)) {
    Write-Error "The location specified in AZURE_SDK_FOR_NET_REPO_ROOT does not appear to be a valid azure-sdk-for-net repository clone."
    Write-Error $azsdkDestRoot
    break
}

function Invoke([scriptblock]$script) {
    $scriptString = $script | Out-String
    Write-Host "--------------------------------------------------------------------------------`n> $scriptString"
    & $script
}

function ReflectItems {
    foreach ($reflectedItem in @(
            "tools",
            "Azure.AI.OpenAI/src",
            "Azure.AI.OpenAI/tests",
            "Azure.AI.OpenAI/README.md",
            "Azure.AI.OpenAI/CHANGELOG.md"
        )) {
        $itemSource = Join-Path $azsdkDestRoot $reflectedItem
        $itemDestination = Join-Path $dotnetAzureOpenAIFolder $reflectedItem
        $itemDestinationParent = Join-Path $itemDestination .. -Resolve

        Write-Host "Mirroring:"
        Write-Host "        From: $itemSource"
        Write-Host "          To: $itemDestination"

        if (Test-Path $itemDestination) {
            Remove-Item -Force -Recurse $itemDestination
        }

        Copy-Item -Recurse -Path $itemSource -Destination $itemDestinationParent
    }
}

ReflectItems