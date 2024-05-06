/*
 * This file was automatically generated from an OpenAPI .yaml file.
 * Edits made directly to this file will be lost.
 */

import "../assistants";
import "../messages";
import "../threads";

using TypeSpec.OpenAPI;

namespace OpenAI;

// Tool generated type. Extracts CreateRunRequest.additional_messages
model CreateRunRequestAdditional_messages is CreateMessageRequest[];

// Tool generated type. Extracts CreateRunRequest.tools
@maxItems(20)
@extension("x-oaiExpandable", true)
model CreateRunRequestTools
  is (AssistantToolsCode | AssistantToolsRetrieval | AssistantToolsFunction)[];

// Tool generated type. Extracts CreateThreadAndRunRequest.tools
@maxItems(20)
model CreateThreadAndRunRequestTools
  is (AssistantToolsCode | AssistantToolsRetrieval | AssistantToolsFunction)[];

model CreateRunRequest {
  /** The ID of the [assistant](/docs/api-reference/assistants) to use to execute this run. */
  assistant_id: string;

  /**
   * The ID of the [Model](/docs/api-reference/models) to be used to execute this run. If a value
   * is provided here, it will override the model associated with the assistant. If not, the model
   * associated with the assistant will be used.
   */
  @extension("x-oaiTypeLabel", "string")
  `model`?:
    | string
    | "gpt-4-turbo"
    | "gpt-4-turbo-2024-04-09"
    | "gpt-4-0125-preview"
    | "gpt-4-turbo-preview"
    | "gpt-4-1106-preview"
    | "gpt-4-vision-preview"
    | "gpt-4"
    | "gpt-4-0314"
    | "gpt-4-0613"
    | "gpt-4-32k"
    | "gpt-4-32k-0314"
    | "gpt-4-32k-0613"
    | "gpt-3.5-turbo"
    | "gpt-3.5-turbo-16k"
    | "gpt-3.5-turbo-0613"
    | "gpt-3.5-turbo-1106"
    | "gpt-3.5-turbo-0125"
    | "gpt-3.5-turbo-16k-0613"
    | null;

  /**
   * Overrides the [instructions](/docs/api-reference/assistants/createAssistant) of the assistant.
   * This is useful for modifying the behavior on a per-run basis.
   */
  instructions?: string | null;

  /**
   * Appends additional instructions at the end of the instructions for the run. This is useful for
   * modifying the behavior on a per-run basis without overriding other instructions.
   */
  additional_instructions?: string | null;

  /** Adds additional messages to the thread before creating the run. */
  additional_messages?: CreateRunRequestAdditional_messages | null;

  /**
   * Override the tools the assistant can use for this run. This is useful for modifying the
   * behavior on a per-run basis.
   */
  tools?: CreateRunRequestTools | null;

  /**
   * Set of 16 key-value pairs that can be attached to an object. This can be useful for storing
   * additional information about the object in a structured format. Keys can be a maximum of 64
   * characters long and values can be a maxium of 512 characters long.
   */
  @extension("x-oaiTypeLabel", "map")
  metadata?: Record<string> | null;

  /**
   * What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output
   * more random, while lower values like 0.2 will make it more focused and deterministic.
   */
  @minValue(0)
  @maxValue(2)
  temperature?: float32 | null = 1;

  @doc("""
  If `true`, returns a stream of events that happen during the Run as server-sent events, terminating when the Run enters a terminal state with a `data: [DONE]` message.
  """)
  stream?: boolean | null;

  @doc("""
  The maximum number of prompt tokens that may be used over the course of the run. The run will make a best effort to use only the number of prompt tokens specified, across multiple turns of the run. If the run exceeds the number of prompt tokens specified, the run will end with status `complete`. See `incomplete_details` for more info.
  """)
  @minValue(256)
  max_prompt_tokens?: int32 | null;

  @doc("""
  The maximum number of completion tokens that may be used over the course of the run. The run will make a best effort to use only the number of completion tokens specified, across multiple turns of the run. If the run exceeds the number of completion tokens specified, the run will end with status `complete`. See `incomplete_details` for more info.
  """)
  @minValue(256)
  max_completion_tokens?: int32 | null;

  truncation_strategy?: TruncationObject | null;
  tool_choice?: AssistantsApiToolChoiceOption | null;
  response_format?: AssistantsApiResponseFormatOption | null;
}

model ModifyRunRequest {
  /**
   * Set of 16 key-value pairs that can be attached to an object. This can be useful for storing
   * additional information about the object in a structured format. Keys can be a maximum of 64
   * characters long and values can be a maxium of 512 characters long.
   */
  @extension("x-oaiTypeLabel", "map")
  metadata?: Record<string> | null;
}

model CreateThreadAndRunRequest {
  /** The ID of the [assistant](/docs/api-reference/assistants) to use to execute this run. */
  assistant_id: string;

  /** If no thread is provided, an empty thread will be created. */
  thread?: CreateThreadRequest;

  /**
   * The ID of the [Model](/docs/api-reference/models) to be used to execute this run. If a value
   * is provided here, it will override the model associated with the assistant. If not, the model
   * associated with the assistant will be used.
   */
  @extension("x-oaiTypeLabel", "string")
  `model`?:
    | string
    | "gpt-4-turbo"
    | "gpt-4-turbo-2024-04-09"
    | "gpt-4-0125-preview"
    | "gpt-4-turbo-preview"
    | "gpt-4-1106-preview"
    | "gpt-4-vision-preview"
    | "gpt-4"
    | "gpt-4-0314"
    | "gpt-4-0613"
    | "gpt-4-32k"
    | "gpt-4-32k-0314"
    | "gpt-4-32k-0613"
    | "gpt-3.5-turbo"
    | "gpt-3.5-turbo-16k"
    | "gpt-3.5-turbo-0613"
    | "gpt-3.5-turbo-1106"
    | "gpt-3.5-turbo-0125"
    | "gpt-3.5-turbo-16k-0613"
    | null;

  /**
   * Override the default system message of the assistant. This is useful for modifying the
   * behavior on a per-run basis.
   */
  instructions?: string | null;

  /**
   * Override the tools the assistant can use for this run. This is useful for modifying the
   * behavior on a per-run basis.
   */
  tools?: CreateThreadAndRunRequestTools | null;

  /**
   * Set of 16 key-value pairs that can be attached to an object. This can be useful for storing
   * additional information about the object in a structured format. Keys can be a maximum of 64
   * characters long and values can be a maxium of 512 characters long.
   */
  @extension("x-oaiTypeLabel", "map")
  metadata?: Record<string> | null;

  /**
   * What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output
   * more random, while lower values like 0.2 will make it more focused and deterministic.
   */
  @minValue(0)
  @maxValue(2)
  temperature?: float32 | null = 1;

  @doc("""
  If `true`, returns a stream of events that happen during the Run as server-sent events, terminating when the Run enters a terminal state with a `data: [DONE]` message.
  """)
  stream?: boolean | null;

  @doc("""
  The maximum number of prompt tokens that may be used over the course of the run. The run will make a best effort to use only the number of prompt tokens specified, across multiple turns of the run. If the run exceeds the number of prompt tokens specified, the run will end with status `complete`. See `incomplete_details` for more info.
  """)
  @minValue(256)
  max_prompt_tokens?: int32 | null;

  @doc("""
  The maximum number of completion tokens that may be used over the course of the run. The run will make a best effort to use only the number of completion tokens specified, across multiple turns of the run. If the run exceeds the number of completion tokens specified, the run will end with status `incomplete`. See `incomplete_details` for more info.
  """)
  @minValue(256)
  max_completion_tokens?: int32 | null;

  truncation_strategy?: TruncationObject | null;
  tool_choice?: AssistantsApiToolChoiceOption | null;
  response_format?: AssistantsApiResponseFormatOption | null;
}

model SubmitToolOutputsRunRequest {
  /** A list of tools for which the outputs are being submitted. */
  tool_outputs: {
    @doc("""
    The ID of the tool call in the `required_action` object within the run object the output is being submitted for.
    """)
    tool_call_id?: string;

    /** The output of the tool call to be submitted to continue the run. */
    output?: string;
  }[];

  @doc("""
  If `true`, returns a stream of events that happen during the Run as server-sent events, terminating when the Run enters a terminal state with a `data: [DONE]` message.
  """)
  stream?: boolean | null;
}

model ListRunsResponse {
  object: string;
  data: RunObject[];
  first_id: string;
  last_id: string;
  has_more: boolean;
}

model ListRunStepsResponse {
  object: string;
  data: RunStepObject[];
  first_id: string;
  last_id: string;
  has_more: boolean;
}

/** Details of the message creation by the run step. */
model RunStepDetailsMessageCreationObject {
  @doc("""
  Always `message_creation`.
  """)
  type: "message_creation";

  message_creation: {
    /** The ID of the message that was created by this run step. */
    message_id: string;
  };
}

/** Details of the tool call. */
model RunStepDetailsToolCallsObject {
  @doc("""
  Always `tool_calls`.
  """)
  type: "tool_calls";

  @doc("""
  An array of tool calls the run step was involved in. These can be associated with one of three types of tools: `code_interpreter`, `retrieval`, or `function`.
  """)
  @extension("x-oaiExpandable", true)
  tool_calls: (RunStepDetailsToolCallsCodeObject | RunStepDetailsToolCallsRetrievalObject | RunStepDetailsToolCallsFunctionObject)[];
}

/** Details of the Code Interpreter tool call the run step was involved in. */
model RunStepDetailsToolCallsCodeObject {
  /** The ID of the tool call. */
  id: string;

  @doc("""
  The type of tool call. This is always going to be `code_interpreter` for this type of tool call.
  """)
  type: "code_interpreter";

  /** The Code Interpreter tool call definition. */
  code_interpreter: {
    /** The input to the Code Interpreter tool call. */
    input: string;

    @doc("""
    The outputs from the Code Interpreter tool call. Code Interpreter can output one or more items, including text (`logs`) or images (`image`). Each of these are represented by a different object type.
    """)
    @extension("x-oaiExpandable", true)
    outputs: (RunStepDetailsToolCallsCodeOutputLogsObject | RunStepDetailsToolCallsCodeOutputImageObject)[];
  };
}

/** Text output from the Code Interpreter tool call as part of a run step. */
model RunStepDetailsToolCallsCodeOutputLogsObject {
  @doc("""
  Always `logs`.
  """)
  type: "logs";

  /** The text output from the Code Interpreter tool call. */
  logs: string;
}

model RunStepDetailsToolCallsCodeOutputImageObject {
  @doc("""
  Always `image`.
  """)
  type: "image";

  image: {
    /** The [file](/docs/api-reference/files) ID of the image. */
    file_id: string;
  };
}

model RunStepDetailsToolCallsRetrievalObject {
  /** The ID of the tool call object. */
  id: string;

  @doc("""
  The type of tool call. This is always going to be `retrieval` for this type of tool call.
  """)
  type: "retrieval";

  /** For now, this is always going to be an empty object. */
  @extension("x-oaiTypeLabel", "map")
  retrieval: Record<string>;
}

model RunStepDetailsToolCallsFunctionObject {
  /** The ID of the tool call object. */
  id: string;

  @doc("""
  The type of tool call. This is always going to be `function` for this type of tool call.
  """)
  type: "function";

  /** The definition of the function that was called. */
  function: {
    /** The name of the function. */
    name: string;

    /** The arguments passed to the function. */
    arguments: string;

    @doc("""
    The output of the function. This will be `null` if the outputs have not been [submitted](/docs/api-reference/runs/submitToolOutputs) yet.
    """)
    output: string | null;
  };
}

@doc("""
Usage statistics related to the run. This value will be `null` if the run is not in a terminal state (i.e. `in_progress`, `queued`, etc.).
""")
model RunCompletionUsage {
  /** Number of completion tokens used over the course of the run. */
  completion_tokens: int32;

  /** Number of prompt tokens used over the course of the run. */
  prompt_tokens: int32;

  /** Total number of tokens used (prompt + completion). */
  total_tokens: int32;
}

@doc("""
Usage statistics related to the run step. This value will be `null` while the run step's status is `in_progress`.
""")
model RunStepCompletionUsage {
  /** Number of completion tokens used over the course of the run step. */
  completion_tokens: int32;

  /** Number of prompt tokens used over the course of the run step. */
  prompt_tokens: int32;

  /** Total number of tokens used (prompt + completion). */
  total_tokens: int32;
}

/** Represents an execution run on a [thread](/docs/api-reference/threads). */
model RunObject {
  /** The identifier, which can be referenced in API endpoints. */
  id: string;

  @doc("""
  The object type, which is always `thread.run`.
  """)
  object: "thread.run";

  // Tool customization: _at and created are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the run was created. */
  @encode("unixTimestamp", int32)
  created_at: utcDateTime;

  /**
   * The ID of the [thread](/docs/api-reference/threads) that was executed on as a part of this run.
   */
  thread_id: string;

  /** The ID of the [assistant](/docs/api-reference/assistants) used for execution of this run. */
  assistant_id: string;

  @doc("""
  The status of the run, which can be either `queued`, `in_progress`, `requires_action`, `cancelling`, `cancelled`, `failed`, `completed`, or `expired`.
  """)
  status:
    | "queued"
    | "in_progress"
    | "requires_action"
    | "cancelling"
    | "cancelled"
    | "failed"
    | "completed"
    | "expired";

  @doc("""
  Details on the action required to continue the run. Will be `null` if no action is required.
  """)
  required_action: {
    @doc("""
    For now, this is always `submit_tool_outputs`.
    """)
    type: "submit_tool_outputs";

    /** Details on the tool outputs needed for this run to continue. */
    submit_tool_outputs: {
      /** A list of the relevant tool calls. */
      tool_calls: RunToolCallObject[];
    };
  } | null;

  @doc("""
  The last error associated with this run. Will be `null` if there are no errors.
  """)
  last_error: {
    @doc("""
    One of `server_error`, `rate_limit_exceeded`, or `invalid_prompt`.
    """)
    code: "server_error" | "rate_limit_exceeded" | "invalid_prompt";

    /** A human-readable description of the error. */
    message: string;
  } | null;

  // Tool customization: _at and created are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the run will expire. */
  @encode("unixTimestamp", int32)
  expires_at: utcDateTime | null;

  // Tool customization: _at and created are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the run was started. */
  @encode("unixTimestamp", int32)
  started_at: utcDateTime | null;

  // Tool customization: _at and created are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the run was cancelled. */
  @encode("unixTimestamp", int32)
  cancelled_at: utcDateTime | null;

  // Tool customization: _at and created are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the run failed. */
  @encode("unixTimestamp", int32)
  failed_at: utcDateTime | null;

  // Tool customization: _at and created are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the run was completed. */
  @encode("unixTimestamp", int32)
  completed_at: utcDateTime | null;

  @doc("""
  Details on why the run is incomplete. Will be `null` if the run is not incomplete.
  """)
  incomplete_details: {
    /**
     * The reason why the run is incomplete. This will point to which specific token limit was
     * reached over the course of the run.
     */
    reason?: "max_completion_tokens" | "max_prompt_tokens";
  } | null;

  /** The model that the [assistant](/docs/api-reference/assistants) used for this run. */
  `model`: string;

  /** The instructions that the [assistant](/docs/api-reference/assistants) used for this run. */
  instructions: string;

  /** The list of tools that the [assistant](/docs/api-reference/assistants) used for this run. */
  @maxItems(20)
  @extension("x-oaiExpandable", true)
  tools: (AssistantToolsCode | AssistantToolsRetrieval | AssistantToolsFunction)[] = [
  ];

  /**
   * The list of [File](/docs/api-reference/files) IDs the
   * [assistant](/docs/api-reference/assistants) used for this run.
   */
  file_ids: string[] = [];

  /**
   * Set of 16 key-value pairs that can be attached to an object. This can be useful for storing
   * additional information about the object in a structured format. Keys can be a maximum of 64
   * characters long and values can be a maxium of 512 characters long.
   */
  @extension("x-oaiTypeLabel", "map")
  metadata: Record<string> | null;

  usage: RunCompletionUsage;

  /** The sampling temperature used for this run. If not set, defaults to 1. */
  temperature?: float32 | null;

  /** The maximum number of prompt tokens specified to have been used over the course of the run. */
  @minValue(256)
  max_prompt_tokens: int32 | null;

  /**
   * The maximum number of completion tokens specified to have been used over the course of the run.
   */
  @minValue(256)
  max_completion_tokens: int32 | null;

  truncation_strategy: TruncationObject | null;
  tool_choice: AssistantsApiToolChoiceOption | null;
  response_format: AssistantsApiResponseFormatOption | null;
}

/** Represents a step in execution of a run. */
model RunStepObject {
  /** The identifier of the run step, which can be referenced in API endpoints. */
  id: string;

  @doc("""
  The object type, which is always `thread.run.step`.
  """)
  object: "thread.run.step";

  // Tool customization: _at and created are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the run step was created. */
  @encode("unixTimestamp", int32)
  created_at: utcDateTime;

  /** The ID of the [assistant](/docs/api-reference/assistants) associated with the run step. */
  assistant_id: string;

  /** The ID of the [thread](/docs/api-reference/threads) that was run. */
  thread_id: string;

  /** The ID of the [run](/docs/api-reference/runs) that this run step is a part of. */
  run_id: string;

  @doc("""
  The type of run step, which can be either `message_creation` or `tool_calls`.
  """)
  type: "message_creation" | "tool_calls";

  @doc("""
  The status of the run step, which can be either `in_progress`, `cancelled`, `failed`, `completed`, or `expired`.
  """)
  status: "in_progress" | "cancelled" | "failed" | "completed" | "expired";

  /** The details of the run step. */
  @extension("x-oaiExpandable", true)
  step_details: RunStepDetailsMessageCreationObject | RunStepDetailsToolCallsObject;

  @doc("""
  The last error associated with this run step. Will be `null` if there are no errors.
  """)
  last_error: {
    @doc("""
    One of `server_error` or `rate_limit_exceeded`.
    """)
    code: "server_error" | "rate_limit_exceeded";

    /** A human-readable description of the error. */
    message: string;
  } | null;

  // Tool customization: _at and created are Unix encoded utcDateTime
  /**
   * The Unix timestamp (in seconds) for when the run step expired. A step is considered expired if
   * the parent run is expired.
   */
  @encode("unixTimestamp", int32)
  expired_at: utcDateTime | null;

  // Tool customization: _at and created are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the run step was cancelled. */
  @encode("unixTimestamp", int32)
  cancelled_at: utcDateTime | null;

  // Tool customization: _at and created are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the run step failed. */
  @encode("unixTimestamp", int32)
  failed_at: utcDateTime | null;

  // Tool customization: _at and created are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the run step completed. */
  @encode("unixTimestamp", int32)
  completed_at: utcDateTime | null;

  /**
   * Set of 16 key-value pairs that can be attached to an object. This can be useful for storing
   * additional information about the object in a structured format. Keys can be a maximum of 64
   * characters long and values can be a maxium of 512 characters long.
   */
  @extension("x-oaiTypeLabel", "map")
  metadata: Record<string> | null;

  usage: RunStepCompletionUsage;
}

/** Tool call objects */
model RunToolCallObject {
  /**
   * The ID of the tool call. This ID must be referenced when you submit the tool outputs in using
   * the [Submit tool outputs to run](/docs/api-reference/runs/submitToolOutputs) endpoint.
   */
  id: string;

  @doc("""
  The type of tool call the output is required for. For now, this is always `function`.
  """)
  type: "function";

  /** The function definition. */
  function: {
    /** The name of the function. */
    name: string;

    /** The arguments that the model expects you to pass to the function. */
    arguments: string;
  };
}

/** Represents a run step delta i.e. any changed fields on a run step during streaming. */
model RunStepDeltaObject {
  /** The identifier of the run step, which can be referenced in API endpoints. */
  id: string;

  @doc("""
  The object type, which is always `thread.run.step.delta`.
  """)
  object: "thread.run.step.delta";

  /** The delta containing the fields that have changed on the run step. */
  delta: {
    /** The details of the run step. */
    @extension("x-oaiExpandable", true)
    step_details?: RunStepDeltaStepDetailsMessageCreationObject | RunStepDeltaStepDetailsToolCallsObject;
  };
}

/** Details of the message creation by the run step. */
model RunStepDeltaStepDetailsMessageCreationObject {
  @doc("""
  Always `message_creation`.
  """)
  type: "message_creation";

  message_creation?: {
    /** The ID of the message that was created by this run step. */
    message_id?: string;
  };
}

/** Details of the tool call. */
model RunStepDeltaStepDetailsToolCallsObject {
  @doc("""
  Always `tool_calls`.
  """)
  type: "tool_calls";

  @doc("""
  An array of tool calls the run step was involved in. These can be associated with one of three types of tools: `code_interpreter`, `retrieval`, or `function`.
  """)
  @extension("x-oaiExpandable", true)
  tool_calls?: (RunStepDeltaStepDetailsToolCallsCodeObject | RunStepDeltaStepDetailsToolCallsRetrievalObject | RunStepDeltaStepDetailsToolCallsFunctionObject)[];
}

/** Details of the Code Interpreter tool call the run step was involved in. */
model RunStepDeltaStepDetailsToolCallsCodeObject {
  /** The index of the tool call in the tool calls array. */
  index: int32;

  /** The ID of the tool call. */
  id?: string;

  @doc("""
  The type of tool call. This is always going to be `code_interpreter` for this type of tool call.
  """)
  type: "code_interpreter";

  /** The Code Interpreter tool call definition. */
  code_interpreter?: {
    /** The input to the Code Interpreter tool call. */
    input?: string;

    @doc("""
    The outputs from the Code Interpreter tool call. Code Interpreter can output one or more items, including text (`logs`) or images (`image`). Each of these are represented by a different object type.
    """)
    @extension("x-oaiExpandable", true)
    outputs?: (RunStepDeltaStepDetailsToolCallsCodeOutputLogsObject | RunStepDeltaStepDetailsToolCallsCodeOutputImageObject)[];
  };
}

/** Text output from the Code Interpreter tool call as part of a run step. */
model RunStepDeltaStepDetailsToolCallsCodeOutputLogsObject {
  /** The index of the output in the outputs array. */
  index: int32;

  @doc("""
  Always `logs`.
  """)
  type: "logs";

  /** The text output from the Code Interpreter tool call. */
  logs?: string;
}

model RunStepDeltaStepDetailsToolCallsCodeOutputImageObject {
  /** The index of the output in the outputs array. */
  index: int32;

  @doc("""
  Always `image`.
  """)
  type: "image";

  image?: {
    /** The [file](/docs/api-reference/files) ID of the image. */
    file_id?: string;
  };
}

model RunStepDeltaStepDetailsToolCallsFunctionObject {
  /** The index of the tool call in the tool calls array. */
  index: int32;

  /** The ID of the tool call object. */
  id?: string;

  @doc("""
  The type of tool call. This is always going to be `function` for this type of tool call.
  """)
  type: "function";

  /** The definition of the function that was called. */
  function?: {
    /** The name of the function. */
    name?: string;

    /** The arguments passed to the function. */
    arguments?: string;

    @doc("""
    The output of the function. This will be `null` if the outputs have not been [submitted](/docs/api-reference/runs/submitToolOutputs) yet.
    """)
    output?: string | null;
  };
}

model RunStepDeltaStepDetailsToolCallsRetrievalObject {
  /** The index of the tool call in the tool calls array. */
  index: int32;

  /** The ID of the tool call object. */
  id?: string;

  @doc("""
  The type of tool call. This is always going to be `retrieval` for this type of tool call.
  """)
  type: "retrieval";

  /** For now, this is always going to be an empty object. */
  @extension("x-oaiTypeLabel", "map")
  retrieval?: Record<string>;
}
