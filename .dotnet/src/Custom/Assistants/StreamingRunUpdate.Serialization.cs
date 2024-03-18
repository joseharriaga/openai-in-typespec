namespace OpenAI.Assistants;

using System;
using System.Collections.Generic;
using System.Text.Json;

public partial class StreamingRunUpdate
{
    internal static IEnumerable<StreamingRunUpdate> DeserializeSseRunUpdates(
        ReadOnlyMemory<char> sseEventName,
        JsonElement sseDataJson)
    {
        IEnumerable<StreamingRunUpdate> results = [];
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

        foreach (StreamingRunUpdate baseUpdate in results)
        {
            baseUpdate._originalJson = sseDataJson.Clone();
        }
        return results;
    }

    private static readonly ReadOnlyMemory<char> s_threadMessageCreationEventName = "thread.message.created".AsMemory();
    private static readonly ReadOnlyMemory<char> s_threadMessageDeltaEventName = "thread.message.delta".AsMemory();
    private static readonly ReadOnlyMemory<char> s_threadMessageCompletionEventName = "thread.message.completed".AsMemory();
}
