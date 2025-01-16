. $PSScriptRoot\Helpers.ps1

function Remove-MultipartFormDataBinaryContent {
    $root = Split-Path $PSScriptRoot -Parent
    $filePath = Join-Path -Path $root -ChildPath ".dotnet/src/Generated/Internal/MultiPartFormDataBinaryContent.cs"
    $file = Get-ChildItem -Path $filePath

    Write-Output "Removing $($file.FullName)"

    Remove-Item $file
}

function Remove-ChatMessageContentSerialization {
    $root = Split-Path $PSScriptRoot -Parent
    $filePath = Join-Path -Path $root -ChildPath ".dotnet/src/Generated/Models/ChatMessageContent.Serialization.cs"
    $file = Get-ChildItem -Path $filePath

    Write-Output "Removing $($file.FullName)"

    Remove-Item $file
}

Remove-MultipartFormDataBinaryContent
Remove-ChatMessageContentSerialization
