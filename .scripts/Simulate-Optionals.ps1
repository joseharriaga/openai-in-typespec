. $PSScriptRoot\Helpers.ps1

$root = Split-Path $PSScriptRoot -Parent
$directory = Join-Path -Path $root -ChildPath ".dotnet\src\Generated\Models"

Update-In-File-With-Retry `
    -FilePath "$directory\ChatCompletionOptions.Serialization.cs" `
    -SearchPatternLines @(
        "if \(_additionalBinaryDataProperties\?\.ContainsKey\(`"messages`"\) != true\)"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Add a null check to allow Messages to behave like an optional"
        "if (Messages is not null && _additionalBinaryDataProperties?.ContainsKey(`"messages`") != true)"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

Update-In-File-With-Retry `
    -FilePath "$directory\ChatCompletionOptions.Serialization.cs" `
    -SearchPatternLines @(
        "if \(_additionalBinaryDataProperties\?\.ContainsKey\(`"model`"\) != true\)"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Add a null check to allow Model to behave like an optional"
        "if (Optional.IsDefined(Model) && _additionalBinaryDataProperties?.ContainsKey(`"model`") != true)"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

