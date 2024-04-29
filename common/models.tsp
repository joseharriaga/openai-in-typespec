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

/**
 * The parameters the functions accepts, described as a JSON Schema object. See the
 * [guide](/docs/guides/text-generation/function-calling) for examples, and the [JSON Schema
 * reference](https://json-schema.org/understanding-json-schema/) for documentation about the
 * format. 
 * 
 * Omitting 'parameters' defines a function with an empty parameter list.
 */
alias FunctionParameters = Record<unknown>;

model FunctionObject {
  /**
   * A description of what the function does, used by the model to choose when and how to call the
   * function.
   */
  description?: string;

  /**
   * The name of the function to be called. Must be a-z, A-Z, 0-9, or contain underscores and
   * dashes, with a maximum length of 64.
   */
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

