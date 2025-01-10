. $PSScriptRoot\Helpers.ps1

$root = Split-Path $PSScriptRoot -Parent
$directory = Join-Path -Path $root -ChildPath ".dotnet\src\Generated\Models"

Update-In-File-With-Retry `
    -FilePath "$directory\InternalChatCompletionStreamResponseDelta.Serialization.cs" `
    -SearchPatternLines @(
        "if \(Optional\.IsDefined\(Content\) && _additionalBinaryDataProperties\?\.ContainsKey\(`"content`"\) != true\)"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Check inner collection is defined."
        "if (Optional.IsDefined(Content) && _additionalBinaryDataProperties?.ContainsKey(`"content`") != true && Content.IsInnerCollectionDefined())"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

Update-In-File-With-Retry `
    -FilePath "$directory\ChatMessage.Serialization.cs" `
    -SearchPatternLines @(
        "if \(true && Optional\.IsDefined\(Content\) && _additionalBinaryDataProperties\?\.ContainsKey\(`"content`"\) != true\)"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Check inner collection is defined."
        "if (true && Optional.IsDefined(Content) && Content.IsInnerCollectionDefined() && _additionalBinaryDataProperties?.ContainsKey(`"content`") != true)"
    ) `
    -OutputIndentation 12 `
    -RequirePresence