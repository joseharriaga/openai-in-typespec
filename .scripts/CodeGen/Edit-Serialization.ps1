. $PSScriptRoot\Helpers.ps1

$repoRootPath = Join-Path $PSScriptRoot ..\.. -Resolve
$generatedModelsFolderPath = Join-Path -Path $repoRootPath -ChildPath ".dotnet\src\Generated\Models"

Update-In-File-With-Retry `
    -FilePath "$generatedModelsFolderPath\InternalChatCompletionResponseMessage.Serialization.cs" `
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
    -FilePath "$generatedModelsFolderPath\InternalChatCompletionStreamResponseDelta.Serialization.cs" `
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
    -FilePath "$generatedModelsFolderPath\InternalChatCompletionStreamResponseDelta.Serialization.cs" `
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
    -FilePath "$generatedModelsFolderPath\ChatMessage.Serialization.cs" `
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
    -FilePath "$generatedModelsFolderPath\AssistantChatMessage.Serialization.cs" `
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
    -FilePath "$generatedModelsFolderPath\FunctionChatMessage.Serialization.cs" `
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
    -FilePath "$generatedModelsFolderPath\SystemChatMessage.Serialization.cs" `
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
    -FilePath "$generatedModelsFolderPath\ToolChatMessage.Serialization.cs" `
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
    -FilePath "$generatedModelsFolderPath\UserChatMessage.Serialization.cs" `
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
    -FilePath "$generatedModelsFolderPath\InternalUnknownChatMessage.Serialization.cs" `
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
    -FilePath "$generatedModelsFolderPath\InternalFineTuneChatCompletionRequestAssistantMessage.Serialization.cs" `
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

Update-In-File-With-Retry `
    -FilePath "$generatedModelsFolderPath\InternalChatOutputPredictionContent.Serialization.cs" `
    -SearchPatternLines @(
        "if \(_additionalBinaryDataProperties\?\.ContainsKey\(`"content`"\) != true\)"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Check inner collection is defined."
        "if (Content.IsInnerCollectionDefined() && _additionalBinaryDataProperties?.ContainsKey(`"content`") != true)"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

Update-In-File-With-Retry `
    -FilePath "$generatedModelsFolderPath\ChatCompletionOptions.Serialization.cs" `
    -SearchPatternLines @(
        "if \(_additionalBinaryDataProperties\?\.ContainsKey\(`"messages`"\) != true\)"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Check collection is defined so Messages can behave like an optional."
        "if (Optional.IsCollectionDefined(Messages) && _additionalBinaryDataProperties?.ContainsKey(`"messages`") != true)"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

Update-In-File-With-Retry `
    -FilePath "$generatedModelsFolderPath\ChatCompletionOptions.Serialization.cs" `
    -SearchPatternLines @(
        "if \(_additionalBinaryDataProperties\?\.ContainsKey\(`"model`"\) != true\)"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Add a null check to allow Model to behave like an optional"
        "if (Optional.IsDefined(Model) && _additionalBinaryDataProperties?.ContainsKey(`"model`") != true)"
    ) `
    -OutputIndentation 12 `
    -RequirePresence

Update-In-File-With-Retry `
    -FilePath "$generatedModelsFolderPath\ChatCompletionOptions.Serialization.cs" `
    -SearchPatternLines @(
        "return new ChatCompletionOptions\("
        "    frequencyPenalty,"
        "    presencePenalty,"
        "    responseFormat,"
        "    temperature,"
        "    topP,"
        "    tools \?\? new ChangeTrackingList<ChatTool>\(\),"
        "    messages,"
        "    model,"
        "    n,"
        "    stream,"
        "    streamOptions,"
        "    includeLogProbabilities,"
        "    topLogProbabilityCount,"
        "    stopSequences \?\? new ChangeTrackingList<string>\(\),"
        "    logitBiases \?\? new ChangeTrackingDictionary<int, int>\(\),"
        "    toolChoice,"
        "    functionChoice,"
        "    allowParallelToolCalls,"
        "    endUserId,"
        "    seed,"
        "    deprecatedMaxTokens,"
        "    maxOutputTokenCount,"
        "    functions \?\? new ChangeTrackingList<ChatFunction>\(\),"
        "    metadata \?\? new ChangeTrackingDictionary<string, string>\(\),"
        "    storedOutputEnabled,"
        "    reasoningEffortLevel,"
        "    internalModalities \?\? new ChangeTrackingList<InternalCreateChatCompletionRequestModality>\(\),"
        "    audioOptions,"
        "    outputPrediction,"
        "    serviceTier,"
        "    additionalBinaryDataProperties\);"
    ) `
    -ReplacePatternLines @(
        "// CUSTOM: Ensure messages collection is initialized."
        "return new ChatCompletionOptions("
        "    frequencyPenalty,"
        "    presencePenalty,"
        "    responseFormat,"
        "    temperature,"
        "    topP,"
        "    tools ?? new ChangeTrackingList<ChatTool>(),"
        "    messages ?? new ChangeTrackingList<ChatMessage>(),"
        "    model,"
        "    n,"
        "    stream,"
        "    streamOptions,"
        "    includeLogProbabilities,"
        "    topLogProbabilityCount,"
        "    stopSequences ?? new ChangeTrackingList<string>(),"
        "    logitBiases ?? new ChangeTrackingDictionary<int, int>(),"
        "    toolChoice,"
        "    functionChoice,"
        "    allowParallelToolCalls,"
        "    endUserId,"
        "    seed,"
        "    deprecatedMaxTokens,"
        "    maxOutputTokenCount,"
        "    functions ?? new ChangeTrackingList<ChatFunction>(),"
        "    metadata ?? new ChangeTrackingDictionary<string, string>(),"
        "    storedOutputEnabled,"
        "    reasoningEffortLevel,"
        "    internalModalities ?? new ChangeTrackingList<InternalCreateChatCompletionRequestModality>(),"
        "    audioOptions,"
        "    outputPrediction,"
        "    serviceTier,"
        "    additionalBinaryDataProperties);"
    ) `
    -OutputIndentation 12 `
    -RequirePresence