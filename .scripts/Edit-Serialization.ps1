. $PSScriptRoot\Helpers.ps1

$root = Split-Path $PSScriptRoot -Parent
$directory = Join-Path -Path $root -ChildPath ".dotnet\src\Generated\Models"

Update-In-File-With-Retry `
    -FilePath "$directory\InternalChatCompletionResponseMessage.Serialization.cs" `
    -SearchPatternLines @(
        "return new InternalChatCompletionResponseMessage\("
        "    refusal,"
        "    toolCalls \?\? new ChangeTrackingList<ChatToolCall>\(\),"
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
        "    role,"
        "    content,"
        "    additionalBinaryDataProperties,"
        "    refusal,"
        "    participantName,"
        "    toolCalls \?\? new ChangeTrackingList<ChatToolCall>\(\),"
        "    functionCall\);"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Initialize Content collection property."
        "return new AssistantChatMessage("
        "    role,"
        "    content ?? new ChatMessageContent(),"
        "    additionalBinaryDataProperties,"
        "    refusal,"
        "    participantName,"
        "    toolCalls ?? new ChangeTrackingList<ChatToolCall>(),"
        "    functionCall);"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

Update-In-File-With-Retry `
    -FilePath "$directory\FunctionChatMessage.Serialization.cs" `
    -SearchPatternLines @(
        "return new FunctionChatMessage\(role, content, additionalBinaryDataProperties, functionName\);"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Initialize Content collection property."
        "return new FunctionChatMessage(role, content ?? new ChatMessageContent(), additionalBinaryDataProperties, functionName);"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

Update-In-File-With-Retry `
    -FilePath "$directory\SystemChatMessage.Serialization.cs" `
    -SearchPatternLines @(
        "return new SystemChatMessage\(role, content, additionalBinaryDataProperties, participantName\);"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Initialize Content collection property."
        "return new SystemChatMessage(role, content ?? new ChatMessageContent(), additionalBinaryDataProperties, participantName);"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

Update-In-File-With-Retry `
    -FilePath "$directory\ToolChatMessage.Serialization.cs" `
    -SearchPatternLines @(
        "return new ToolChatMessage\(role, content, additionalBinaryDataProperties, toolCallId\);"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Initialize Content collection property."
        "return new ToolChatMessage(role, content ?? new ChatMessageContent(), additionalBinaryDataProperties, toolCallId);"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

Update-In-File-With-Retry `
    -FilePath "$directory\UserChatMessage.Serialization.cs" `
    -SearchPatternLines @(
        "return new UserChatMessage\(role, content, additionalBinaryDataProperties, participantName\);"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Initialize Content collection property."
        "return new UserChatMessage(role, content ?? new ChatMessageContent(), additionalBinaryDataProperties, participantName);"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

Update-In-File-With-Retry `
    -FilePath "$directory\InternalUnknownChatMessage.Serialization.cs" `
    -SearchPatternLines @(
        "return new InternalUnknownChatMessage\(role, content, additionalBinaryDataProperties\);"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Initialize Content collection property."
        "return new InternalUnknownChatMessage(role, content ?? new ChatMessageContent(), additionalBinaryDataProperties);"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

Update-In-File-With-Retry `
    -FilePath "$directory\InternalFineTuneChatCompletionRequestAssistantMessage.Serialization.cs" `
    -SearchPatternLines @(
        "return new InternalFineTuneChatCompletionRequestAssistantMessage\("
        "    role,"
        "    content,"
        "    additionalBinaryDataProperties,"
        "    refusal,"
        "    participantName,"
        "    toolCalls \?\? new ChangeTrackingList<ChatToolCall>\(\),"
        "    functionCall\);"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Initialize Content collection property."
        "return new InternalFineTuneChatCompletionRequestAssistantMessage("
        "    role,"
        "    content ?? new ChatMessageContent(),"
        "    additionalBinaryDataProperties,"
        "    refusal,"
        "    participantName,"
        "    toolCalls ?? new ChangeTrackingList<ChatToolCall>(),"
        "    functionCall);"
    ) `
    -OutputIndentation 12 `
    -RequirePresence