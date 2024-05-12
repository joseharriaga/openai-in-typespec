namespace OpenAI.Assistants;

internal static class StreamingUpdateKindExtensions
{
    internal static string ToSseEventLabel(this StreamingUpdateKind value) => value switch
    {
        StreamingUpdateKind.ThreadCreated => "thread.created",
        StreamingUpdateKind.RunCreated => "thread.run.created",
        StreamingUpdateKind.RunQueued => "thread.run.queued",
        StreamingUpdateKind.RunInProgress => "thread.run.in_progress",
        StreamingUpdateKind.RunRequiresAction => "thread.run.requires_action",
        StreamingUpdateKind.RunCompleted => "thread.run.completed",
        StreamingUpdateKind.RunFailed => "thread.run.failed",
        StreamingUpdateKind.RunCancelling => "thread.run.cancelling",
        StreamingUpdateKind.RunCancelled => "thread.run.cancelled",
        StreamingUpdateKind.RunExpired => "thread.run.expired",
        StreamingUpdateKind.RunStepCreated => "thread.run.step.created",
        StreamingUpdateKind.RunStepInProgress => "thread.run.step.in_progress",
        StreamingUpdateKind.RunStepUpdated => "thread.run.step.delta",
        StreamingUpdateKind.RunStepCompleted => "thread.run.step.completed",
        StreamingUpdateKind.RunStepFailed => "thread.run.step.failed",
        StreamingUpdateKind.RunStepCancelled => "thread.run.step.cancelled",
        StreamingUpdateKind.RunStepExpired => "thread.run.step.expired",
        StreamingUpdateKind.MessageCreated => "thread.message.created",
        StreamingUpdateKind.MessageInProgress => "thread.message.in_progress",
        StreamingUpdateKind.MessageUpdated => "thread.message.delta",
        StreamingUpdateKind.MessageCompleted => "thread.message.completed",
        StreamingUpdateKind.MessageFailed => "thread.message.incomplete",
        StreamingUpdateKind.Error => "error",
        StreamingUpdateKind.Done => "done",
        _ => string.Empty
    };

    internal static StreamingUpdateKind FromSseEventLabel(string label) => label switch
    {
        "thread.created" => StreamingUpdateKind.ThreadCreated,
        "thread.run.created" => StreamingUpdateKind.RunCreated,
        "thread.run.queued" => StreamingUpdateKind.RunQueued,
        "thread.run.in_progress" => StreamingUpdateKind.RunInProgress,
        "thread.run.requires_action" => StreamingUpdateKind.RunRequiresAction,
        "thread.run.completed" => StreamingUpdateKind.RunCompleted,
        "thread.run.failed" => StreamingUpdateKind.RunFailed,
        "thread.run.cancelling" => StreamingUpdateKind.RunCancelling,
        "thread.run.cancelled" => StreamingUpdateKind.RunCancelled,
        "thread.run.expired" => StreamingUpdateKind.RunExpired,
        "thread.run.step.created" => StreamingUpdateKind.RunStepCreated,
        "thread.run.step.in_progress" => StreamingUpdateKind.RunStepInProgress,
        "thread.run.step.delta" => StreamingUpdateKind.RunStepUpdated,
        "thread.run.step.completed" => StreamingUpdateKind.RunStepCompleted,
        "thread.run.step.failed" => StreamingUpdateKind.RunStepFailed,
        "thread.run.step.cancelled" => StreamingUpdateKind.RunStepCancelled,
        "thread.run.step.expired" => StreamingUpdateKind.RunStepExpired,
        "thread.message.created" => StreamingUpdateKind.MessageCreated,
        "thread.message.in_progress" => StreamingUpdateKind.MessageInProgress,
        "thread.message.delta" => StreamingUpdateKind.MessageUpdated,
        "thread.message.completed" => StreamingUpdateKind.MessageCompleted,
        "thread.message.incomplete" => StreamingUpdateKind.MessageFailed,
        "error" => StreamingUpdateKind.Error,
        "done" => StreamingUpdateKind.Done,
        _ => StreamingUpdateKind.Unknown,
    };
}