/*
 * This file was automatically generated from an OpenAPI .yaml file.
 * Edits made directly to this file will be lost.
 */

import "../uploads";

using TypeSpec.OpenAPI;

namespace OpenAI;

model ApiKeyList {
  object?: string;
  data?: AdminApiKey[];
  has_more?: boolean;
  first_id?: string;
  last_id?: string;
}
