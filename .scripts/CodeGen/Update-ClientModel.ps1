. $PSScriptRoot\Helpers.ps1

function Remove-MultipartFormDataBinaryContent {
    $repoRootPath = Join-Path $PSScriptRoot ..\.. -Resolve
    $filePath = Join-Path -Path $repoRootPath -ChildPath ".dotnet/src/Generated/Internal/MultiPartFormDataBinaryContent.cs"
    $file = Get-ChildItem -Path $filePath

    Write-Output "Removing $($file.FullName)"

    Remove-Item $file
}

function Remove-ChatMessageContentSerialization {
    $repoRootPath = Join-Path $PSScriptRoot ..\.. -Resolve
    $filePath = Join-Path -Path $repoRootPath -ChildPath ".dotnet/src/Generated/Models/ChatMessageContent.Serialization.cs"
    $file = Get-ChildItem -Path $filePath

    Write-Output "Removing $($file.FullName)"

    Remove-Item $file
}

Remove-MultipartFormDataBinaryContent
Remove-ChatMessageContentSerialization
