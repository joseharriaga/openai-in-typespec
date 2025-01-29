/*
 * This file was automatically generated from an OpenAPI .yaml file.
 * Edits made directly to this file will be lost.
 */

import "../assistants";

using TypeSpec.OpenAPI;

namespace OpenAI;

/**
 * Abstractly represents a run step details object.
 */
@discriminator("type")
model RunStepObjectStepDetails {
  /** The discriminated type identifier for the details object. */
  type: string;
}

union RunStepDetailsToolCallKind {
  string,
  code_interpreter: "code_interpreter",
  file_search: "file_search",
  function: "function",
}

/**
 * Abstractly represents a run step tool call details inner object.
 */
@discriminator("type")
model RunStepDetailsToolCallsObjectToolCallsObject {
  /** The discriminated type identifier for the details object. */
  type: RunStepDetailsToolCallKind;

  /** The ID of the tool call object. */
  id: string;
}

/**
 * Abstractly represents a run step tool call details code interpreter output.
 */
@discriminator("type")
model RunStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject {
  /** The discriminated type identifier for the details object. */
  type: string;
}

@discriminator("type")
model RunStepDeltaStepDetails {
  /** The discriminated type identifier for the details object. */
  type: string;
}

/**
 * Abstractly represents a run step tool call details inner object.
 */
@discriminator("type")
model RunStepDeltaStepDetailsToolCallsObjectToolCallsObject {
  /** The discriminated type identifier for the details object. */
  type: string;
}

/**
 * Abstractly represents a run step tool call details code interpreter output.
 */
@discriminator("type")
model RunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject {
  /** The discriminated type identifier for the details object. */
  type: string;
}

union IncludedRunStepProperty {
  string,
  file_search_result_content: "step_details.tool_calls[*].file_search.results[*].content",
}
