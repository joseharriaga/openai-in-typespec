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

/**
 * Abstractly represents a run step tool call details inner object.
 */
@discriminator("type")
model RunStepDetailsToolCallsObjectToolCallsObject {
  /** The discriminated type identifier for the details object. */
  type: string;
}

/**
 * Abstractly represents a run step tool call details code interpreter output.
 */
@discriminator("type")
model RunStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject {
  /** The discriminated type identifier for the details object. */
  type: string;
}
