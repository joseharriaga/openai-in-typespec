/*
 * This file was automatically generated from an OpenAPI .yaml file.
 * Edits made directly to this file will be lost.
 */

import "../assistants";

using TypeSpec.OpenAPI;

namespace OpenAI;

/**
 * Represents a single piece of content in an Assistants API request message.
 */
@discriminator("type")
model RequestMessageContentItem {
  /** The discriminated type identifier for the content item. */
  type: string;
}

/**
 * Represents a single piece of content in an Assistants API response.
 */
model ResponseMessageContentItem {
  /** The discriminated type identifier for the content item. */
  type: string;
}

/**
 * Represents a single piece of incremental content in an Assistants API streaming respnse.
 */
@discriminator("type")
model MessageDeltaContentItem {
  /** The discriminated type identifier for the content item. */
  type: string;
}
