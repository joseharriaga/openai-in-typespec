. $PSScriptRoot\Helpers.ps1

$root = Split-Path $PSScriptRoot -Parent
$directory = Join-Path -Path $root -ChildPath ".dotnet\src\Generated"

foreach ($filename in @(
    "AssistantClient.RestClient.cs"
    "InternalAssistantRunClient.RestClient.cs"
    "InternalAssistantThreadClient.RestClient.cs"
    "InternalAssistantMessageClient.RestClient.cs"
    "VectorStoreClient.RestClient.cs"
))
{
    Update-In-File-With-Retry `
        -SearchPattern "\r?\n( *)internal PipelineMessage (Create.*Request\()" `
        -FilePath "$directory\$filename" `
        -ReplacePatternLines @(
            "`$1// CUSTOM: Make message creation method virtual."
            "`$1internal virtual PipelineMessage `$2"
        ) `
        -OutputIndentation 0 `
        -RequirePresence
}
