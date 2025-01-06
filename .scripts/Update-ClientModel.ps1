function Remove-MultipartFormDataBinaryContent {
    $root = Split-Path $PSScriptRoot -Parent
    $filePath = Join-Path -Path $root -ChildPath ".dotnet\src\Generated\Internal\MultiPartFormDataBinaryContent.cs"
    $file = Get-ChildItem -Path $filePath

    Write-Output "Removing $($file.FullName)"

    Remove-Item $file
}

function Remove-ObsoleteAttribute {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath ".dotnet\src\Generated\Models"

    $targets = @(
        "ChatFunction.cs",
        "FunctionChatMessage.cs")
        
    foreach ($target in $targets) {
        $file = Get-ChildItem -Path $directory -Filter $target
        $content = Get-Content -Path $file -Raw

        Write-Output "Editing $($file.FullName)"

        $content = $content -creplace "\s+\[Obsolete\((`")+(.*)(`")+\)\]", ""

        $content | Set-Content -Path $file.FullName -NoNewline
    }
}

function Remove-ChatMessageContentSerialization {
    $root = Split-Path $PSScriptRoot -Parent
    $filePath = Join-Path -Path $root -ChildPath ".dotnet\src\Generated\Models\ChatMessageContent.Serialization.cs"
    $file = Get-ChildItem -Path $filePath

    Write-Output "Removing $($file.FullName)"

    Remove-Item $file
}

Remove-MultipartFormDataBinaryContent
Remove-ObsoleteAttribute
Remove-ChatMessageContentSerialization
