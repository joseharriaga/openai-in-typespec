namespace OpenAI.Assistants;

using System.Collections.Generic;
using System.Text.Json;

/// <summary>
/// Represents an incremental item of new data in a streaming response when running a thread with an assistant.
/// </summary>
public partial class StreamingRunUpdate
{
    // To be implemented: properties/pattern for non-streaming objects (e.g. thread and run creation)
    //public string AssistantId { get; }
    //public string ThreadId { get; }
    //public DateTimeOffset? ThreadCreatedAt { get; }
    //public IReadOnlyDictionary<string, string> ThreadMetadata;
    //public string RunId { get; }
    //public DateTimeOffset? RunCreatedAt { get; }
    //public DateTimeOffset? RunStartedAt { get; }
    //public RunStatus? RunStatus { get; }

    public string AssistantId { get; }
    public string ThreadId { get; }
    public string MessageId { get; }
    public string RunId { get; }
    public string RunStepId { get; }
    public MessageRole? MessageRole { get; }
    public MessageContent MessageContentUpdate { get; }
    public int? MessageContentIndex { get; }

    internal static List<StreamingRunUpdate> DeserializeStreamingRunUpdates(JsonElement element)
    {
        List<StreamingRunUpdate> results = [];
        if (element.ValueKind == JsonValueKind.Null)
        {
            return results;
        }
        string objectLabel = null;
        string assistantId = null;
        string threadId = null;
        string messageId = null;
        string runId = null;
        string runStepId = null;
        MessageRole? role = null;
        List<(MessageContent, int?)?> deltaContentItems = [null];
        foreach (JsonProperty property in element.EnumerateObject())
        {
            if (property.NameEquals("object"u8))
            {
                objectLabel = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("id"u8))
            {
                if (objectLabel?.Contains("run.step") == true)
                {
                    runStepId = property.Value.GetString();
                }
                else if (objectLabel?.Contains("run") == true)
                {
                    runId = property.Value.GetString();
                }
                else if (objectLabel?.Contains("message") == true)
                {
                    messageId = property.Value.GetString();
                }
                else if (objectLabel?.Contains("thread") == true)
                {
                    threadId = property.Value.GetString();
                }
                continue;
            }
            if (property.NameEquals("assistant_id"))
            {
                assistantId = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("role"))
            {
                string roleText = property.Value.GetString();
                if (roleText == "user")
                {
                    role = Assistants.MessageRole.User;
                }
                else if (roleText == "assistant")
                {
                    role = Assistants.MessageRole.Assistant;
                }
                continue;
            }
            if (property.NameEquals("delta"u8))
            {
                foreach (JsonProperty messageDeltaProperty in property.Value.EnumerateObject())
                {
                    if (messageDeltaProperty.NameEquals("content"u8))
                    {
                        deltaContentItems.Clear();
                        int? contentIndex = null;
                        foreach (JsonElement contentArrayElement in messageDeltaProperty.Value.EnumerateArray())
                        {
                            foreach (JsonProperty contentItemProperty in contentArrayElement.EnumerateObject())
                            {
                                if (contentItemProperty.NameEquals("index"u8))
                                {
                                    contentIndex = contentItemProperty.Value.GetInt32();
                                    continue;
                                }
                            }
                            deltaContentItems.Add((MessageContent.DeserializeMessageContent(contentArrayElement), contentIndex));
                        }
                        continue;
                    }
                }
                continue;
            }
        }
        foreach ((MessageContent, int?)? deltaContentItem in deltaContentItems)
        {
            results.Add(
                new StreamingRunUpdate(
                    assistantId,
                    threadId,
                    runId,
                    runStepId,
                    role,
                    deltaContentItem));
        }
        return results;
    }

    internal StreamingRunUpdate(
        string assistantId,
        string threadId,
        string runId,
        string runStepId,
        MessageRole? role,
        (MessageContent, int?)? indexedContentUpdate)
    {
        AssistantId = assistantId;
        ThreadId = threadId;
        RunId = runId;
        RunStepId = runStepId;
        MessageRole = role;
        MessageContentUpdate = indexedContentUpdate?.Item1 ?? null;
        MessageContentIndex = indexedContentUpdate?.Item2 ?? null;
    }
}
