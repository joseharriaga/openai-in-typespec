/*
 * This file was automatically generated from an OpenAPI .yaml file.
 * Edits made directly to this file will be lost.
 */

import "../assistants";

using TypeSpec.OpenAPI;

namespace OpenAI;

/**
 * Represents a single piece of content in an Assistants API message.
 */
// TODO: @discriminator("type")
model MessageContent {}

@discriminator("type")
model MessageContentTextObjectAnnotation {
  /** The discriminated type identifier for the content item. */
  type: string;
}

/**
 * Represents a single piece of incremental content in an Assistants API streaming response.
 */
@discriminator("type")
model MessageDeltaContent {
  /** The discriminated type identifier for the content item. */
  type: string;
}

@discriminator("type")
model MessageDeltaTextContentAnnotation {
  /** The discriminated type identifier for the content item. */
  type: string;
}
