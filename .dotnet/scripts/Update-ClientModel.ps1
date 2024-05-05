function Update-Subclients {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath "src\Generated"
    $files = Get-ChildItem -Path $($directory + "\*") -Include "*.cs" -Exclude "OpenAIClient.cs", "OpenAIClientOptions.cs"

    foreach ($file in $files) {
        $content = Get-Content -Path $file -Raw

        Write-Output "Editing $($file.FullName)"

        $content = $content -creplace "message\.Apply\(options\);", "if (options != null) { message.Apply(options); }"

        $content | Set-Content -Path $file.FullName -NoNewline
    }
}

function Remove-Utf8JsonBinaryContent {
    $root = Split-Path $PSScriptRoot -Parent
    $filePath = Join-Path -Path $root -ChildPath "src\Generated\Internal\Utf8JsonBinaryContent.cs"
    $file = Get-ChildItem -Path $filePath

    Write-Output "Removing $($file.FullName)"

    Remove-Item $file
}

function Remove-BinaryContentHelper {
    $root = Split-Path $PSScriptRoot -Parent
    $filePath = Join-Path -Path $root -ChildPath "src\Generated\Internal\BinaryContentHelper.cs"
    $file = Get-ChildItem -Path $filePath

    Write-Output "Removing $($file.FullName)"

    Remove-Item $file
}

function Remove-MultipartFormDataBinaryContent {
    $root = Split-Path $PSScriptRoot -Parent
    $filePath = Join-Path -Path $root -ChildPath "src\Generated\Internal\MultipartFormDataBinaryContent.cs"
    $file = Get-ChildItem -Path $filePath

    Write-Output "Removing $($file.FullName)"

    Remove-Item $file
}

function Partialize-ClientPipelineExtensions {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath "src\Generated\Internal"
    $file = Get-ChildItem -Path $directory -Filter "ClientPipelineExtensions.cs"
    $content = Get-Content -Path $file -Raw

    Write-Output "Editing $($file.FullName)"

    $content = $content -creplace "internal static class ClientPipelineExtensions", "internal static partial class ClientPipelineExtensions"

    $content | Set-Content -Path $file.FullName -NoNewline
}

Update-Subclients
Remove-Utf8JsonBinaryContent
Remove-BinaryContentHelper
Remove-MultipartFormDataBinaryContent
Partialize-ClientPipelineExtensions
