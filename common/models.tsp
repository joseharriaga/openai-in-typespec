/*
 * This file was automatically generated from an OpenAPI .yaml file.
 * Edits made directly to this file will be lost.
 */

import "./custom.tsp";

using TypeSpec.OpenAPI;

namespace OpenAI;

model Error {
  code: string | null;
  message: string;
  param: string | null;
  type: string;
}

model ErrorResponse {
  error: Error;
}

@doc("""
The parameters the functions accepts, described as a JSON Schema object. See the [guide](/docs/guides/function-calling) for examples, and the [JSON Schema reference](https://json-schema.org/understanding-json-schema/) for documentation about the format. 

Omitting `parameters` defines a function with an empty parameter list.
""")
model FunctionParameters is Record<unknown>;

model FunctionObject {
  /** A description of what the function does, used by the model to choose when and how to call the function. */
  description?: string;

  /** The name of the function to be called. Must be a-z, A-Z, 0-9, or contain underscores and dashes, with a maximum length of 64. */
  name: string;

  parameters?: FunctionParameters;
}

/** Usage statistics for the completion request. */
model CompletionUsage {
  /** Number of tokens in the generated completion. */
  completion_tokens: int32;

  /** Number of tokens in the prompt. */
  prompt_tokens: int32;

  /** Total number of tokens used in the request (prompt + completion). */
  total_tokens: int32;
}

@doc("""
Options for streaming response. Only set this when you set `stream: true`.
""")
model ChatCompletionStreamOptions {
  @doc("""
  If set, an additional chunk will be streamed before the `data: [DONE]` message. The `usage` field on this chunk shows the token usage statistics for the entire request, and the `choices` field will always be an empty array. All other chunks will also include a `usage` field, but with a null value.
  """)
  include_usage?: boolean;
}
