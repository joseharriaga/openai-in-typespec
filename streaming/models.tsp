import "../common/models.tsp";
import "../messages/models.tsp";
import "../runs/models.tsp";
import "../threads/models.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace OpenAI;

/**
 * Represents an event when streaming a run.
 *
 * Each event in a server-sent events stream has an `event` and `data` property:
 * ```
 * event: thread.created
 * data: {"id": "thread_123", "object": "thread", ...}
 * ```
 * We emit events whenever a new object is created, transitions to a new state, or is being
 * streamed in parts (deltas). For example, we emit `thread.run.created` when a new run
 * is created, `thread.run.completed` when a run completes, and so on. When an Assistant chooses
 * to create a message during a run, we emit a `thread.message.created event`, a
 * `thread.message.in_progress` event, many `thread.message.delta` events, and finally a
 * `thread.message.completed` event.
 *
 * We may add additional events over time, so we recommend handling unknown events gracefully
 * in your code. See the [Assistants API quickstart](/docs/assistants/overview) to learn how to
 * integrate the Assistants API with streaming.
 */
@oneOf
@extension("x-oaiExpandable", true)
union AssistantStreamEvent {
  ThreadStreamEvent,
  RunStreamEvent,
  RunStepStreamEvent,
  MessageStreamEvent,
  ErrorStreamEvent,
  DoneStreamEvent,
}

/**
 * Represents a thread-related server-sent event for streaming run operations.
 */
@oneOf
@extension("x-oaiExpandable", true)
union ThreadStreamEvent {
  ThreadCreatedStreamEvent,
}

/**
 * Represents the server-sent event raised when a new thread is created.
 */
model ThreadCreatedStreamEvent {
  /** The event label for the server-sent event, which is always `thread.created`. */
  event: "thread.created";

  /** The server-sent event data payload. */
  data: ThreadObject;
}

/**
 * Represents a run-related server-sent event for streaming run operations.
 */
@oneOf
@extension("x-oaiExpandable", true)
union RunStreamEvent {
  RunCreatedStreamEvent,
  RunQueuedStreamEvent,
  RunInProgressStreamEvent,
  RunRequiresActionStreamEvent,
  RunCompletedStreamEvent,
  RunFailedStreamEvent,
  RunCancellingStreamEvent,
  RunCancelledStreamEvent,
  RunExpiredStreamEvent,
}

/**
 * Represents the server-sent event raised when a new run is created.
 */
model RunCreatedStreamEvent {
  /** The event label for the server-sent event, which is always `thread.run.created`. */
  event: "thread.run.created";

  /** The server-sent event data payload. */
  data: RunObject;
}

/**
 * Represents the server-sent event raised when a run enters the `queued` status.
 */
model RunQueuedStreamEvent {
  /** The event label for the server-sent event, which is always `thread.run.queued`. */
  event: "thread.run.queued";

  /** The server-sent event data payload. */
  data: RunObject;
}

/**
 * Represents the server-sent event raised when a run enters the `in_progress` status.
 */
model RunInProgressStreamEvent {
  /** The event label for the server-sent event, which is always `thread.run.in_progress`. */
  event: "thread.run.in_progress";

  /** The server-sent event data payload. */
  data: RunObject;
}

/**
 * Represents the server-sent event raised when a run enters the `requires_action` status.
 */
model RunRequiresActionStreamEvent {
  /** The event label for the server-sent event, which is always `thread.run.requires_action`. */
  event: "thread.run.requires_action";

  /** The server-sent event data payload. */
  data: RunObject;
}

/**
 * Represents the server-sent event raised when a run enters the `completed` status.
 */
model RunCompletedStreamEvent {
  /** The event label for the server-sent event, which is always `thread.run.completed`. */
  event: "thread.run.completed";

  /** The server-sent event data payload. */
  data: RunObject;
}

/**
 * Represents the server-sent event raised when a run enters the `failed` status.
 */
model RunFailedStreamEvent {
  /** The event label for the server-sent event, which is always `thread.run.failed`. */
  event: "thread.run.failed";

  /** The server-sent event data payload. */
  data: RunObject;
}

/**
 * Represents the server-sent event raised when a run enters the `cancelling` status.
 */
model RunCancellingStreamEvent {
  /** The event label for the server-sent event, which is always `thread.run.cancelling`. */
  event: "thread.run.cancelling";

  /** The server-sent event data payload. */
  data: RunObject;
}

/**
 * Represents the server-sent event raised when a run enters the `cancelled` status.
 */
model RunCancelledStreamEvent {
  /** The event label for the server-sent event, which is always `thread.run.cancelled`. */
  event: "thread.run.cancelled";

  /** The server-sent event data payload. */
  data: RunObject;
}

/**
 * Represents the server-sent event raised when a run enters the `expired` status.
 */
model RunExpiredStreamEvent {
  /** The event label for the server-sent event, which is always `thread.run.expired`. */
  event: "thread.run.expired";

  /** The server-sent event data payload. */
  data: RunObject;
}

/**
 * Represents a run-step-related server-sent event for streaming run operations.
 */
@oneOf
@extension("x-oaiExpandable", true)
union RunStepStreamEvent {
  RunStepCreatedStreamEvent,
  RunStepInProgressStreamEvent,
  RunStepDeltaStreamEvent,
  RunStepCompletedStreamEvent,
  RunStepFailedStreamEvent,
  RunStepCancelledStreamEvent,
  RunStepExpiredStreamEvent,
}

/**
 * Represents the server-sent event raised when a new run step is created.
 */
model RunStepCreatedStreamEvent {
  /** The event label for the server-sent event, which is always `thread.run.step.created`. */
  event: "thread.run.step.created";

  /** The server-sent event data payload. */
  data: RunStepObject;
}

/**
 * Represents the server-sent event raised when a run step enters the `in_progress` status.
 */
model RunStepInProgressStreamEvent {
  /** The event label for the server-sent event, which is always `thread.run.step.in_progress`. */
  event: "thread.run.step.in_progress";

  /** The server-sent event data payload. */
  data: RunStepObject;
}

/**
 * Represents the server-sent event raised when a run step has new delta content.
 */
model RunStepDeltaStreamEvent {
  /** The event label for the server-sent event, which is always `thread.run.step.delta`. */
  event: "thread.run.step.delta";

  /** The server-sent event data payload. */
  data: RunStepDeltaObject;
}

/**
 * Represents the server-sent event raised when a run step enters the `completed` status.
 */
model RunStepCompletedStreamEvent {
  /** The event label for the server-sent event, which is always `thread.run.step.completed`. */
  event: "thread.run.step.completed";

  /** The server-sent event data payload. */
  data: RunStepObject;
}

/**
 * Represents the server-sent event raised when a run step enters the `failed` status.
 */
model RunStepFailedStreamEvent {
  /** The event label for the server-sent event, which is always `thread.run.step.failed`. */
  event: "thread.run.step.failed";

  /** The server-sent event data payload. */
  data: RunStepObject;
}

/**
 * Represents the server-sent event raised when a run step enters the `cancelled` status.
 */
model RunStepCancelledStreamEvent {
  /** The event label for the server-sent event, which is always `thread.run.step.cancelled`. */
  event: "thread.run.step.cancelled";

  /** The server-sent event data payload. */
  data: RunStepObject;
}

/**
 * Represents the server-sent event raised when a run step enters the `expired` status.
 */
model RunStepExpiredStreamEvent {
  /** The event label for the server-sent event, which is always `thread.run.step.expired`. */
  event: "thread.run.step.expired";

  /** The server-sent event data payload. */
  data: RunStepObject;
}

/**
 * Represents a message-related server-sent event for streaming run operations.
 */
@oneOf
@extension("x-oaiExpandable", true)
union MessageStreamEvent {
  MessageCreatedStreamEvent,
  MessageInProgressStreamEvent,
  MessageDeltaStreamEvent,
  MessageCompletedStreamEvent,
  MessageIncompleteStreamEvent,
}

/**
 * Represents the server-sent event raised when a new message is created.
 */
model MessageCreatedStreamEvent {
  /** The event label for the server-sent event, which is always `thread.message.created`. */
  event: "thread.message.created";

  /** The server-sent event data payload. */
  data: MessageObject;
}

/**
 * Represents the server-sent event raised when a message enters in the `in_progress` status.
 */
model MessageInProgressStreamEvent {
  /** The event label for the server-sent event, which is always `thread.message.in_progress`. */
  event: "thread.message.in_progress";

  /** The server-sent event data payload. */
  data: MessageObject;
}

/**
 * Represents the server-sent event raised when a message has new delta content.
 */
model MessageDeltaStreamEvent {
  /** The event label for the server-sent event, which is always `thread.message.delta`. */
  event: "thread.message.delta";

  /** The server-sent event data payload. */
  data: MessageDeltaObject;
}

/**
 * Represents the server-sent event raised when a message enters in the `completed` status.
 */
model MessageCompletedStreamEvent {
  /** The event label for the server-sent event, which is always `thread.message.completed`. */
  event: "thread.message.completed";

  /** The server-sent event data payload. */
  data: MessageObject;
}

/**
 * Represents the server-sent event raised when a message enters in the `incomplete` status.
 */
model MessageIncompleteStreamEvent {
  /** The event label for the server-sent event, which is always `thread.message.incomplete`. */
  event: "thread.message.incomplete";

  /** The server-sent event data payload. */
  data: MessageObject;
}

/**
 * Represents the server-sent event raised when a run enters an error state.
 */
model ErrorStreamEvent {
  /** The event label for the server-sent event, which is always `error`. */
  event: "thread.run.cancelling";

  /** The server-sent event data payload. */
  data: Error;
}

/**
 * Represents the server-sent event raised when the event stream is at its end.
 */
model DoneStreamEvent {
  /** The event label for the server-sent event, which is always `error`. */
  event: "done";

  /** The server-sent event data payload. */
  data: "[DONE]";
}
