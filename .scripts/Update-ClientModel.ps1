function Remove-MultipartFormDataBinaryContent {
    $root = Split-Path $PSScriptRoot -Parent
    $filePath = Join-Path -Path $root -ChildPath ".dotnet\src\Generated\Internal\MultipartFormDataBinaryContent.cs"
    $file = Get-ChildItem -Path $filePath

    Write-Output "Removing $($file.FullName)"

    Remove-Item $file
}

function Partialize-ClientPipelineExtensions {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath ".dotnet\src\Generated\Internal"
    $file = Get-ChildItem -Path $directory -Filter "ClientPipelineExtensions.cs"
    $content = Get-Content -Path $file -Raw

    Write-Output "Editing $($file.FullName)"

    $content = $content -creplace "internal static class ClientPipelineExtensions", "internal static partial class ClientPipelineExtensions"

    $content | Set-Content -Path $file.FullName -NoNewline
}

Remove-MultipartFormDataBinaryContent
Partialize-ClientPipelineExtensions
