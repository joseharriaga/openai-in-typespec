namespace OpenAI.Assistants;

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

public partial class StreamingMessageCreation
{
    internal static StreamingRunUpdate DeserializeSseMessageCreation(
        JsonElement sseDataJson,
        ModelReaderWriterOptions options = null)
    {
        string id = null;
        string assistantId = null;
        string threadId = null;
        string runId = null;
        DateTimeOffset? createdAt = null;
        MessageRole? role = null;
        List<MessageContent> contentItems = [];
        List<string> fileIds = [];

        foreach (JsonProperty property in sseDataJson.EnumerateObject())
        {
            if (property.NameEquals("id"u8))
            {
                id = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("assistant_id"u8))
            {
                assistantId = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("thread_id"u8))
            {
                threadId = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("run_id"u8))
            {
                runId = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("created_at"u8))
            {
                createdAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                continue;
            }
            if (property.NameEquals("role"u8))
            {
                role = MessageRoleSerialization.DeserializeMessageRole(property.Value);
                continue;
            }
            if (property.NameEquals("content"u8))
            {
                foreach (JsonElement contentElement in property.Value.EnumerateArray())
                {
                    contentItems.Add(MessageContent.DeserializeMessageContent(contentElement));
                }
                continue;
            }
            if (property.NameEquals("file_ids"u8))
            {
                foreach (JsonElement fileIdElement in  property.Value.EnumerateArray())
                {
                    fileIds.Add(fileIdElement.GetString());
                }
                continue;
            }
        }

        return new StreamingMessageCreation(
            id,
            assistantId,
            threadId,
            runId,
            createdAt.Value,
            role.Value,
            contentItems,
            fileIds);

    }
}
