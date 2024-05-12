using OpenAI.Internal.Models;
using System;
using System.Collections.Generic;

namespace OpenAI.Assistants;

public enum StreamingUpdateKind
{
    Unknown,
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
    Done,
}