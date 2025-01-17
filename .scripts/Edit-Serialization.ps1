. $PSScriptRoot\Helpers.ps1

$root = Split-Path $PSScriptRoot -Parent
$directory = Join-Path -Path $root -ChildPath ".dotnet\src\Generated\Models"

Update-In-File-With-Retry `
    -FilePath "$directory\InternalChatCompletionResponseMessage.Serialization.cs" `
    -SearchPatternLines @(
        "return new InternalChatCompletionResponseMessage\("
        "    refusal,"
        "    toolCalls \?\? new ChangeTrackingList<ChatToolCall>\(\),"
        "    audio,"
        "    role,"
        "    content,"
        "    functionCall,"
        "    additionalBinaryDataProperties\);"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Initialize Content collection property."
        "return new InternalChatCompletionResponseMessage("
        "    refusal,"
        "    toolCalls ?? new ChangeTrackingList<ChatToolCall>(),"
        "    audio,"
        "    role,"
        "    content ?? new ChatMessageContent(),"
        "    functionCall,"
        "    additionalBinaryDataProperties);"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

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
    -FilePath "$directory\InternalChatCompletionStreamResponseDelta.Serialization.cs" `
    -SearchPatternLines @(
        "return new InternalChatCompletionStreamResponseDelta\("
        "    audio,"
        "    functionCall,"
        "    toolCalls \?\? new ChangeTrackingList<StreamingChatToolCallUpdate>\(\),"
        "    refusal,"
        "    role,"
        "    content,"
        "    additionalBinaryDataProperties\);"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Initialize Content collection property."
        "return new InternalChatCompletionStreamResponseDelta("
        "    audio,"
        "    functionCall,"
        "    toolCalls ?? new ChangeTrackingList<StreamingChatToolCallUpdate>(),"
        "    refusal,"
        "    role,"
        "    content ?? new ChatMessageContent(),"
        "    additionalBinaryDataProperties);"
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

Update-In-File-With-Retry `
    -FilePath "$directory\AssistantChatMessage.Serialization.cs" `
    -SearchPatternLines @(
        "return new AssistantChatMessage\("
        "    content,"
        "    role,"
        "    additionalBinaryDataProperties,"
        "    refusal,"
        "    participantName,"
        "    toolCalls \?\? new ChangeTrackingList<ChatToolCall>\(\),"
        "    functionCall,"
        "    outputAudioReference\);"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Initialize Content collection property."
        "return new AssistantChatMessage("
        "    content ?? new ChatMessageContent(),"
        "    role,"
        "    additionalBinaryDataProperties,"
        "    refusal,"
        "    participantName,"
        "    toolCalls ?? new ChangeTrackingList<ChatToolCall>(),"
        "    functionCall,"
        "    outputAudioReference);"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

Update-In-File-With-Retry `
    -FilePath "$directory\FunctionChatMessage.Serialization.cs" `
    -SearchPatternLines @(
        "return new FunctionChatMessage\(content, role, additionalBinaryDataProperties, functionName\);"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Initialize Content collection property."
        "return new FunctionChatMessage(content ?? new ChatMessageContent(), role, additionalBinaryDataProperties, functionName);"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

Update-In-File-With-Retry `
    -FilePath "$directory\SystemChatMessage.Serialization.cs" `
    -SearchPatternLines @(
        "return new SystemChatMessage\(content, role, additionalBinaryDataProperties, participantName\);"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Initialize Content collection property."
        "return new SystemChatMessage(content ?? new ChatMessageContent(), role, additionalBinaryDataProperties, participantName);"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

Update-In-File-With-Retry `
    -FilePath "$directory\ToolChatMessage.Serialization.cs" `
    -SearchPatternLines @(
        "return new ToolChatMessage\(content, role, additionalBinaryDataProperties, toolCallId\);"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Initialize Content collection property."
        "return new ToolChatMessage(content ?? new ChatMessageContent(), role, additionalBinaryDataProperties, toolCallId);"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

Update-In-File-With-Retry `
    -FilePath "$directory\UserChatMessage.Serialization.cs" `
    -SearchPatternLines @(
        "return new UserChatMessage\(content, role, additionalBinaryDataProperties, participantName\);"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Initialize Content collection property."
        "return new UserChatMessage(content ?? new ChatMessageContent(), role, additionalBinaryDataProperties, participantName);"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

Update-In-File-With-Retry `
    -FilePath "$directory\InternalUnknownChatMessage.Serialization.cs" `
    -SearchPatternLines @(
        "return new InternalUnknownChatMessage\(content, role, additionalBinaryDataProperties\);"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Initialize Content collection property."
        "return new InternalUnknownChatMessage(content ?? new ChatMessageContent(), role, additionalBinaryDataProperties);"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

Update-In-File-With-Retry `
    -FilePath "$directory\InternalFineTuneChatCompletionRequestAssistantMessage.Serialization.cs" `
    -SearchPatternLines @(
        "return new InternalFineTuneChatCompletionRequestAssistantMessage\("
        "    content,"
        "    role,"
        "    additionalBinaryDataProperties,"
        "    refusal,"
        "    participantName,"
        "    toolCalls \?\? new ChangeTrackingList<ChatToolCall>\(\),"
        "    functionCall,"
        "    outputAudioReference\);"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Initialize Content collection property."
        "return new InternalFineTuneChatCompletionRequestAssistantMessage("
        "    content ?? new ChatMessageContent(),"
        "    role,"
        "    additionalBinaryDataProperties,"
        "    refusal,"
        "    participantName,"
        "    toolCalls ?? new ChangeTrackingList<ChatToolCall>(),"
        "    functionCall,"
        "    outputAudioReference);"
    ) `
    -OutputIndentation 12 `
    -RequirePresence
