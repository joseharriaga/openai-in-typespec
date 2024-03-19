namespace OpenAI.Assistants;

using System;
using System.Collections.Generic;
using System.Text.Json;

public partial class StreamingUpdate
{
    internal static IEnumerable<StreamingUpdate> DeserializeSseRunUpdates(
        ReadOnlyMemory<char> sseEventName,
        JsonElement sseDataJson)
    {
        IEnumerable<StreamingUpdate> results = [];
        if (sseEventName.Span.SequenceEqual(s_threadMessageCreationEventName.Span))
        {
            results = [StreamingMessageCreation.DeserializeSseMessageCreation(sseDataJson)];
        }
        else if (sseEventName.Span.SequenceEqual(s_threadMessageDeltaEventName.Span))
        {
            results = StreamingMessageUpdate.DeserializeSseMessageUpdates(sseDataJson);
        }
        else if (sseEventName.Span.SequenceEqual(s_threadMessageCompletionEventName.Span))
        {
            results = [StreamingMessageCompletion.DeserializeStreamingMessageCompletion(sseDataJson)];
        }
        else if (sseEventName.Span.SequenceEqual(s_runCreatedEventName.Span))
        {
            results = [StreamingRunCreation.DeserializeStreamingRunCreation(sseDataJson)];
        }

        else if (sseEventName.Span.SequenceEqual(s_runRequiredActionEventName.Span))
        {
            results = StreamingRequiredAction.DeserializeStreamingRequiredActions(sseDataJson);
        }
        else
        {
            results = [new StreamingUpdate()];
        }

        JsonElement rawElementClone = sseDataJson.Clone();
        foreach (StreamingUpdate baseUpdate in results)
        {
            baseUpdate._originalJson = rawElementClone;
        }
        return results;
    }

    private static readonly ReadOnlyMemory<char> s_threadMessageCreationEventName = "thread.message.created".AsMemory();
    private static readonly ReadOnlyMemory<char> s_threadMessageDeltaEventName = "thread.message.delta".AsMemory();
    private static readonly ReadOnlyMemory<char> s_threadMessageCompletionEventName = "thread.message.completed".AsMemory();
    private static readonly ReadOnlyMemory<char> s_runCreatedEventName = "thread.run.created".AsMemory();
    private static readonly ReadOnlyMemory<char> s_runRequiredActionEventName = "thread.run.requires_action".AsMemory();
}
