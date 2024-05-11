/*
 * This file was automatically generated from an OpenAPI .yaml file.
 * Edits made directly to this file will be lost.
 */

import "../assistants";

using TypeSpec.OpenAPI;

namespace OpenAI;

@discriminator("type")
model MessageContentItem {
  type: string;
}
