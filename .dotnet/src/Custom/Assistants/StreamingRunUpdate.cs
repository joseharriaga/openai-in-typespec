using OpenAI.Internal.Models;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenAI.Assistants;

/*
 NOTE:
    This whole class is temporary and not meant to be merged as-is.
    It's merely intended to prototype possible patterns and facilitate
    discussion.
*/

public partial class StreamingRunUpdate
{
    private readonly object _updatePayload;

    public StreamingRunUpdateKind UpdateKind { get; }

    internal StreamingRunUpdate(StreamingRunUpdateKind updateKind, object updatePayload)
    {
        UpdateKind = updateKind;
        _updatePayload = updatePayload;
    }

    public T GetValue<T>() where T : class => _updatePayload as T;

    internal static async Task<StreamingRunUpdate> TemporaryCreateFromReaderAsync(StreamReader reader)
        => TemporaryCreateFromLines(await reader.ReadLineAsync(), await reader.ReadLineAsync(), await reader.ReadLineAsync());

    internal static StreamingRunUpdate TemporaryCreateFromReader(StreamReader reader)
        => TemporaryCreateFromLines(reader.ReadLine(), reader.ReadLine(), reader.ReadLine());

    private static StreamingRunUpdate TemporaryCreateFromLines(string eventLine, string dataLine, string emptyLine)
    {
        if (eventLine?.StartsWith("event: ") != true || dataLine?.StartsWith("data: ") != true || emptyLine != string.Empty)
        {
            throw new InvalidOperationException();
        }

        if (eventLine == "event: done" && dataLine == "data: [DONE]") return null;

        string eventName = eventLine.Substring("event: ".Length);
        string data = dataLine.Substring("data: ".Length);
        JsonDocument dataDocument = JsonDocument.Parse(data);
        JsonElement e = dataDocument.RootElement;

        return eventName switch
        {
            "thread.created"
                => new StreamingRunUpdate<AssistantThread>(AssistantThread.DeserializeAssistantThread(e), StreamingRunUpdateKind.ThreadCreated),
            "thread.run.created"
                => new StreamingRunUpdate<ThreadRun>(ThreadRun.DeserializeThreadRun(e), StreamingRunUpdateKind.RunCreated),
            "thread.run.queued"
                => new StreamingRunUpdate<ThreadRun>(ThreadRun.DeserializeThreadRun(e), StreamingRunUpdateKind.RunQueued),
            "thread.run.in_progress"
                => new StreamingRunUpdate<ThreadRun>(ThreadRun.DeserializeThreadRun(e), StreamingRunUpdateKind.RunInProgress),
            "thread.run.requires_action"
                => new StreamingRunUpdate<ThreadRun>(ThreadRun.DeserializeThreadRun(e), StreamingRunUpdateKind.RunRequiresAction),
            "thread.run.completed"
                => new StreamingRunUpdate<ThreadRun>(ThreadRun.DeserializeThreadRun(e), StreamingRunUpdateKind.RunCompleted),
            "thread.run.failed"
                => new StreamingRunUpdate<ThreadRun>(ThreadRun.DeserializeThreadRun(e), StreamingRunUpdateKind.RunFailed),
            "thread.run.cancelling"
                => new StreamingRunUpdate<ThreadRun>(ThreadRun.DeserializeThreadRun(e), StreamingRunUpdateKind.RunCancelling),
            "thread.run.cancelled"
                => new StreamingRunUpdate<ThreadRun>(ThreadRun.DeserializeThreadRun(e), StreamingRunUpdateKind.RunCancelled),
            "thread.run.expired"
                => new StreamingRunUpdate<ThreadRun>(ThreadRun.DeserializeThreadRun(e), StreamingRunUpdateKind.RunExpired),
            "thread.run.step.created"
                => new StreamingRunUpdate<RunStep>(RunStep.DeserializeRunStep(e), StreamingRunUpdateKind.RunStepCreated),
            "thread.run.step.in_progress"
                => new StreamingRunUpdate<RunStep>(RunStep.DeserializeRunStep(e), StreamingRunUpdateKind.RunStepInProgress),
            "thread.run.step.delta"
                => new StreamingRunUpdate<RunStepDeltaObject>(
                    RunStepDeltaObject.DeserializeRunStepDeltaObject(e),
                    StreamingRunUpdateKind.RunStepUpdated),
            "thread.run.step.completed"
                => new StreamingRunUpdate<RunStep>(RunStep.DeserializeRunStep(e), StreamingRunUpdateKind.RunStepCompleted),
            "thread.run.step.failed"
                => new StreamingRunUpdate<RunStep>(RunStep.DeserializeRunStep(e), StreamingRunUpdateKind.RunStepFailed),
            "thread.run.step.cancelled"
                => new StreamingRunUpdate<RunStep>(RunStep.DeserializeRunStep(e), StreamingRunUpdateKind.RunStepCancelled),
            "thread.run.step.expired"
                => new StreamingRunUpdate<RunStep>(RunStep.DeserializeRunStep(e), StreamingRunUpdateKind.RunStepExpired),
            "thread.message.created"
                => new StreamingRunUpdate<ThreadMessage>(ThreadMessage.DeserializeThreadMessage(e), StreamingRunUpdateKind.MessageCreated),
            "thread.message.in_progress"
                => new StreamingRunUpdate<ThreadMessage>(ThreadMessage.DeserializeThreadMessage(e), StreamingRunUpdateKind.MessageInProgress),
            "thread.message.delta"
                => new StreamingRunUpdate<StreamingRunMessageDelta>(
                    StreamingRunMessageDelta.DeserializeStreamingRunMessageDelta(e),
                    StreamingRunUpdateKind.MessageUpdated),
            "thread.message.completed"
                => new StreamingRunUpdate<ThreadMessage>(ThreadMessage.DeserializeThreadMessage(e), StreamingRunUpdateKind.MessageCompleted),
            "thread.message.incomplete"
                => new StreamingRunUpdate<ThreadMessage>(ThreadMessage.DeserializeThreadMessage(e), StreamingRunUpdateKind.MessageFailed),
            "error"
                => new StreamingRunUpdate<Error>(Error.DeserializeError(e), StreamingRunUpdateKind.Error),
            _ => throw new NotImplementedException()
        };
    }
}

public partial class StreamingRunUpdate<T> : StreamingRunUpdate
    where T : class
{
    public T Value => GetValue<T>();

    internal StreamingRunUpdate(T updatePayload, StreamingRunUpdateKind updateKind)
        : base(updateKind, updatePayload)
    {
    }
}

public enum StreamingRunUpdateKind
{
    ThreadCreated,
    RunCreated,
    RunQueued,
    RunInProgress,
    RunRequiresAction,
    RunCompleted,
    RunFailed,
    RunCancelling,
    RunCancelled,
    RunExpired,
    RunStepCreated,
    RunStepInProgress,
    RunStepUpdated,
    RunStepCompleted,
    RunStepFailed,
    RunStepCancelled,
    RunStepExpired,
    MessageCreated,
    MessageInProgress,
    MessageUpdated,
    MessageCompleted,
    MessageFailed,
    Error,
    Done
}