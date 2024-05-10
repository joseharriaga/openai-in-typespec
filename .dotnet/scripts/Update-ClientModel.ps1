function Remove-MultipartFormDataBinaryContent {
    $root = Split-Path $PSScriptRoot -Parent
    $filePath = Join-Path -Path $root -ChildPath "src\Generated\Internal\MultipartFormDataBinaryContent.cs"
    $file = Get-ChildItem -Path $filePath

    Write-Output "Removing $($file.FullName)"

    Remove-Item $file
}

Remove-MultipartFormDataBinaryContent