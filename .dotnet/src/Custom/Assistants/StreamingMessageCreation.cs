namespace OpenAI.Assistants;

using System;
using System.Collections.Generic;
using System.Text.Json;

public partial class StreamingMessageCreation : StreamingRunUpdate
{
    public string Id { get; }
    public string AssistantId { get; }
    public string ThreadId { get; }
    public string RunId { get; }
    public DateTimeOffset CreatedAt { get; }
    public MessageRole Role { get; }
    public IReadOnlyList<MessageContent> ContentItems { get; }
    public IReadOnlyList<string> FileIds { get; }

    internal StreamingMessageCreation(
        string id,
        string assistantId,
        string threadId,
        string runId,
        DateTimeOffset createdAt,
        MessageRole role,
        IReadOnlyList<MessageContent> contentItems,
        IReadOnlyList<string> fileIds)
    {
        Id = id;
        AssistantId = assistantId;
        ThreadId = threadId;
        RunId = runId;
        CreatedAt = createdAt;
        Role = role;
        ContentItems = contentItems;
        FileIds = fileIds;
    }
}
