function Edit-Serialization {
    param(
        [string] $Filename,
        [string[]] $InputRegex,
        [string[]] $OutputString,
        [int] $OutputIndentation
    )
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath ".dotnet\src\Generated\Models"
    $file = Get-ChildItem -Path $directory -Filter $Filename
    $content = Get-Content -Path $file -Raw

    Write-Output "Editing $($file.FullName)"

    $regex = "(?s)"
    foreach ($line in $InputRegex) { $regex += "\s+" + $line }

    if ($content -cnotmatch $regex)
    {
        throw "The code does not match the expected pattern. If this is by design, please update or disable this edit."
    }
    else
    {
        $output = ""
        foreach ($line in $OutputString) { $output += "`r`n" + $line.PadLeft($line.Length + $OutputIndentation) }

        $content = $content -creplace $regex, $output
        $content | Set-Content -Path $file.FullName -NoNewline
    }
}

function Edit-InternalChatCompletionResponseMessageSerialization {
    $filename = "InternalChatCompletionResponseMessage.Serialization.cs"

    # content serialization
    # no-op

    # content deserialization
    $inputRegex = @(
        "return new InternalChatCompletionResponseMessage\("
        "    content,"
        "    refusal,"
        "    toolCalls \?\? new ChangeTrackingList<ChatToolCall>\(\),"
        "    role,"
        "    functionCall,"
        "    serializedAdditionalRawData\);"
    )
    $outputString = @(
        "// CUSTOM: Initialize Content collection property."
        "return new InternalChatCompletionResponseMessage("
        "    content ?? new ChatMessageContent(),"
        "    refusal,"
        "    toolCalls ?? new ChangeTrackingList<ChatToolCall>(),"
        "    role,"
        "    functionCall,"
        "    serializedAdditionalRawData);"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12
}

function Edit-InternalChatCompletionStreamResponseDeltaSerialization {
    $filename = "InternalChatCompletionStreamResponseDelta.Serialization.cs"

    # content serialization
    $inputRegex = @(
        "if \(SerializedAdditionalRawData\?\.ContainsKey\(`"content`"\) != true && Optional\.IsDefined\(Content\)\)"
    )
    $outputString = @(
        "// CUSTOM: Check inner collection is defined."
        "if (SerializedAdditionalRawData?.ContainsKey(`"content`") != true && Optional.IsDefined(Content) && Content.IsInnerCollectionDefined())"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12

    # content deserialization
    $inputRegex = @(
        "return new InternalChatCompletionStreamResponseDelta\("
        "    content,"
        "    functionCall,"
        "    toolCalls \?\? new ChangeTrackingList<StreamingChatToolCallUpdate>\(\),"
        "    role,"
        "    refusal,"
        "    serializedAdditionalRawData\);"
    )
    $outputString = @(
        "// CUSTOM: Initialize Content collection property."
        "return new InternalChatCompletionStreamResponseDelta("
        "    content ?? new ChatMessageContent(),"
        "    functionCall,"
        "    toolCalls ?? new ChangeTrackingList<StreamingChatToolCallUpdate>(),"
        "    role,"
        "    refusal,"
        "    serializedAdditionalRawData);"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12
}

Edit-InternalChatCompletionResponseMessageSerialization
Edit-InternalChatCompletionStreamResponseDeltaSerialization