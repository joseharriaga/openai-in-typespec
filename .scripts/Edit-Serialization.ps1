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
        "    refusal,"
        "    toolCalls \?\? new ChangeTrackingList<ChatToolCall>\(\),"
        "    role,"
        "    content,"
        "    functionCall,"
        "    additionalBinaryDataProperties\);"
    )
    $outputString = @(
        "// CUSTOM: Initialize Content collection property."
        "return new InternalChatCompletionResponseMessage("
        "    refusal,"
        "    toolCalls ?? new ChangeTrackingList<ChatToolCall>(),"
        "    role,"
        "    content ?? new ChatMessageContent(),"
        "    functionCall,"
        "    additionalBinaryDataProperties);"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12
}

function Edit-InternalChatCompletionStreamResponseDeltaSerialization {
    $filename = "InternalChatCompletionStreamResponseDelta.Serialization.cs"

    # content serialization
    $inputRegex = @(
        "if \(Optional\.IsDefined\(Content\) && _additionalBinaryDataProperties\?\.ContainsKey\(`"content`"\) != true\)"
    )
    $outputString = @(
        "// CUSTOM: Check inner collection is defined."
        "if (Optional.IsDefined(Content) && _additionalBinaryDataProperties?.ContainsKey(`"content`") != true && Content.IsInnerCollectionDefined())"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12

    # content deserialization
    $inputRegex = @(
        "return new InternalChatCompletionStreamResponseDelta\("
        "    functionCall,"
        "    toolCalls \?\? new ChangeTrackingList<StreamingChatToolCallUpdate>\(\),"
        "    refusal,"
        "    role,"
        "    content,"
        "    additionalBinaryDataProperties\);"
    )
    $outputString = @(
        "// CUSTOM: Initialize Content collection property."
        "return new InternalChatCompletionStreamResponseDelta("
        "    functionCall,"
        "    toolCalls ?? new ChangeTrackingList<StreamingChatToolCallUpdate>(),"
        "    refusal,"
        "    role,"
        "    content ?? new ChatMessageContent(),"
        "    additionalBinaryDataProperties);"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12
}

function Edit-ChatMessageSerialization {
    $filename = "ChatMessage.Serialization.cs"

    # content serialization
    $inputRegex = @(
        "if \(true && Optional\.IsDefined\(Content\) && _additionalBinaryDataProperties\?\.ContainsKey\(`"content`"\) != true\)"
    )
    $outputString = @(
        "// CUSTOM: Check inner collection is defined."
        "if (true && Optional.IsDefined(Content) && Content.IsInnerCollectionDefined() && _additionalBinaryDataProperties?.ContainsKey(`"content`") != true)"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12

    # content deserialization
    # no-op
}


function Edit-AssistantChatMessageSerialization {
    $filename = "AssistantChatMessage.Serialization.cs"

    # content serialization
    # no-op

    # content deserialization
    $inputRegex = @(
        "return new AssistantChatMessage\("
        "    refusal,"
        "    participantName,"
        "    toolCalls \?\? new ChangeTrackingList<ChatToolCall>\(\),"
        "    functionCall,"
        "    role,"
        "    content,"
        "    additionalBinaryDataProperties\);"
    )
    $outputString = @(
        "// CUSTOM: Initialize Content collection property."
        "return new AssistantChatMessage("
        "    refusal,"
        "    participantName,"
        "    toolCalls ?? new ChangeTrackingList<ChatToolCall>(),"
        "    functionCall,"
        "    role,"
        "    content ?? new ChatMessageContent(),"
        "    additionalBinaryDataProperties);"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12
}

function Edit-FunctionChatMessageSerialization {
    $filename = "FunctionChatMessage.Serialization.cs"

    # content serialization
    # no-op

    # content deserialization
    $inputRegex = @(
        "return new FunctionChatMessage\(functionName, role, content, additionalBinaryDataProperties\);"
    )
    $outputString = @(
        "// CUSTOM: Initialize Content collection property."
        "return new FunctionChatMessage(functionName, role, content ?? new ChatMessageContent(), additionalBinaryDataProperties);"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12
}

function Edit-SystemChatMessageSerialization {
    $filename = "SystemChatMessage.Serialization.cs"

    # content serialization
    # no-op

    # content deserialization
    $inputRegex = @(
        "return new SystemChatMessage\(participantName, role, content, additionalBinaryDataProperties\);"
    )
    $outputString = @(
        "// CUSTOM: Initialize Content collection property."
        "return new SystemChatMessage(participantName, role, content ?? new ChatMessageContent(), additionalBinaryDataProperties);"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12
}

function Edit-ToolChatMessageSerialization {
    $filename = "ToolChatMessage.Serialization.cs"

    # content serialization
    # no-op

    # content deserialization
    $inputRegex = @(
        "return new ToolChatMessage\(toolCallId, role, content, additionalBinaryDataProperties\);"
    )
    $outputString = @(
        "// CUSTOM: Initialize Content collection property."
        "return new ToolChatMessage(toolCallId, role, content ?? new ChatMessageContent(), additionalBinaryDataProperties);"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12
}

function Edit-UserChatMessageSerialization {
    $filename = "UserChatMessage.Serialization.cs"

    # content serialization
    # no-op

    # content deserialization
    $inputRegex = @(
        "return new UserChatMessage\(participantName, role, content, additionalBinaryDataProperties\);"
    )
    $outputString = @(
        "// CUSTOM: Initialize Content collection property."
        "return new UserChatMessage(participantName, role, content ?? new ChatMessageContent(), additionalBinaryDataProperties);"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12
}

function Edit-InternalUnknownChatMessageSerialization {
    $filename = "InternalUnknownChatMessage.Serialization.cs"

    # content serialization
    # no-op

    # content deserialization
    $inputRegex = @(
        "return new InternalUnknownChatMessage\(role, content, additionalBinaryDataProperties\);"
    )
    $outputString = @(
        "// CUSTOM: Initialize Content collection property."
        "return new InternalUnknownChatMessage(role, content ?? new ChatMessageContent(), additionalBinaryDataProperties);"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12
}

function Edit-InternalFineTuneChatCompletionRequestAssistantMessageSerialization {
    $filename = "InternalFineTuneChatCompletionRequestAssistantMessage.Serialization.cs"

    # content serialization
    # no-op

    # content deserialization
    $inputRegex = @(
        "return new InternalFineTuneChatCompletionRequestAssistantMessage\("
        "    refusal,"
        "    participantName,"
        "    toolCalls \?\? new ChangeTrackingList<ChatToolCall>\(\),"
        "    functionCall,"
        "    role,"
        "    content,"
        "    additionalBinaryDataProperties\);"
    )
    $outputString = @(
        "// CUSTOM: Initialize Content collection property."
        "return new InternalFineTuneChatCompletionRequestAssistantMessage("
        "    refusal,"
        "    participantName,"
        "    toolCalls ?? new ChangeTrackingList<ChatToolCall>(),"
        "    functionCall,"
        "    role,"
        "    content ?? new ChatMessageContent(),"
        "    additionalBinaryDataProperties);"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12
}

Edit-InternalChatCompletionResponseMessageSerialization
Edit-InternalChatCompletionStreamResponseDeltaSerialization
Edit-ChatMessageSerialization
Edit-AssistantChatMessageSerialization
Edit-FunctionChatMessageSerialization
Edit-SystemChatMessageSerialization
Edit-ToolChatMessageSerialization
Edit-UserChatMessageSerialization
Edit-InternalUnknownChatMessageSerialization
Edit-InternalFineTuneChatCompletionRequestAssistantMessageSerialization