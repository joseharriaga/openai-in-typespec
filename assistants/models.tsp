/*
 * This file was automatically generated from an OpenAPI .yaml file.
 * Edits made directly to this file will be lost.
 */

import "../common";

using TypeSpec.OpenAPI;

namespace OpenAI;

/** Specifies a tool the model should use. Use to force the model to call a specific tool. */
model AssistantsApiNamedToolChoice {
  @doc("""
  The type of the tool. If type is `function`, the function name must be set
  """)
  type: "function" | "code_interpreter" | "retrieval";

  function?: {
    /** The name of the function to call. */
    name: string;
  };
}

@doc("""
Specifies the format that the model must output. Compatible with [GPT-4 Turbo](/docs/models/gpt-4-and-gpt-4-turbo) and all GPT-3.5 Turbo models newer than `gpt-3.5-turbo-1106`.

Setting to `{ "type": "json_object" }` enables JSON mode, which guarantees the message the model generates is valid JSON.

**Important:** when using JSON mode, you **must** also instruct the model to produce JSON yourself via a system or user message. Without this, the model may generate an unending stream of whitespace until the generation reaches the token limit, resulting in a long-running and seemingly "stuck" request. Also note that the message content may be partially cut off if `finish_reason="length"`, which indicates the generation exceeded `max_tokens` or the conversation exceeded the max context length.
""")
@extension("x-oaiExpandable", true)
union AssistantsApiResponseFormatOption {
  "none" | "auto",
  AssistantsApiResponseFormat,
}

@doc("""
An object describing the expected output of the model. If `json_object` only `function` type `tools` are allowed to be passed to the Run. If `text` the model can return text or any value needed.
""")
model AssistantsApiResponseFormat {
  @doc("""
  Must be one of `text` or `json_object`.
  """)
  type?: "text" | "json_object" = "text";
}

model CreateAssistantRequest {
  /**
   * ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to
   * see all of your available models, or see our [Model overview](/docs/models/overview) for
   * descriptions of them.
   */
  @extension("x-oaiTypeLabel", "string")
  `model`:
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
    | "gpt-3.5-turbo-16k-0613";

  /** The name of the assistant. The maximum length is 256 characters. */
  @maxLength(256)
  name?: string | null;

  /** The description of the assistant. The maximum length is 512 characters. */
  @maxLength(512)
  description?: string | null;

  /** The system instructions that the assistant uses. The maximum length is 256,000 characters. */
  @maxLength(256000)
  instructions?: string | null;

  @doc("""
  A list of tool enabled on the assistant. There can be a maximum of 128 tools per assistant. Tools can be of types `code_interpreter`, `retrieval`, or `function`.
  """)
  @maxItems(128)
  @extension("x-oaiExpandable", true)
  tools?: (AssistantToolsCode | AssistantToolsRetrieval | AssistantToolsFunction)[] = [
  ];

  /**
   * A list of [file](/docs/api-reference/files) IDs attached to this assistant. There can be a
   * maximum of 20 files attached to the assistant. Files are ordered by their creation date in
   * ascending order.
   */
  @maxItems(20)
  file_ids?: string[] = [];

  /**
   * Set of 16 key-value pairs that can be attached to an object. This can be useful for storing
   * additional information about the object in a structured format. Keys can be a maximum of 64
   * characters long and values can be a maxium of 512 characters long.
   */
  @extension("x-oaiTypeLabel", "map")
  metadata?: Record<string> | null;
}

model ModifyAssistantRequest {
  /**
   * ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to
   * see all of your available models, or see our [Model overview](/docs/models/overview) for
   * descriptions of them.
   */
  `model`?: string;

  /** The name of the assistant. The maximum length is 256 characters. */
  @maxLength(256)
  name?: string | null;

  /** The description of the assistant. The maximum length is 512 characters. */
  @maxLength(512)
  description?: string | null;

  /** The system instructions that the assistant uses. The maximum length is 256,000 characters. */
  @maxLength(256000)
  instructions?: string | null;

  @doc("""
  A list of tool enabled on the assistant. There can be a maximum of 128 tools per assistant. Tools can be of types `code_interpreter`, `retrieval`, or `function`.
  """)
  @maxItems(128)
  @extension("x-oaiExpandable", true)
  tools?: (AssistantToolsCode | AssistantToolsRetrieval | AssistantToolsFunction)[] = [
  ];

  /**
   * A list of [File](/docs/api-reference/files) IDs attached to this assistant. There can be a
   * maximum of 20 files attached to the assistant. Files are ordered by their creation date in
   * ascending order. If a file was previously attached to the list but does not show up in the
   * list, it will be deleted from the assistant.
   */
  @maxItems(20)
  file_ids?: string[] = [];

  /**
   * Set of 16 key-value pairs that can be attached to an object. This can be useful for storing
   * additional information about the object in a structured format. Keys can be a maximum of 64
   * characters long and values can be a maxium of 512 characters long.
   */
  @extension("x-oaiTypeLabel", "map")
  metadata?: Record<string> | null;
}

model CreateAssistantFileRequest {
  @doc("""
  A [File](/docs/api-reference/files) ID (with `purpose="assistants"`) that the assistant should use. Useful for tools like `retrieval` and `code_interpreter` that can access files.
  """)
  file_id: string;
}

model ListAssistantsResponse {
  object: string;
  data: AssistantObject[];
  first_id: string;
  last_id: string;
  has_more: boolean;
}

model DeleteAssistantResponse {
  id: string;
  deleted: boolean;
  object: "assistant.deleted";
}

model ListAssistantFilesResponse {
  object: string;
  data: AssistantFileObject[];
  first_id: string;
  last_id: string;
  has_more: boolean;
}

/**
 * Deletes the association between the assistant and the file, but does not delete the
 * [File](/docs/api-reference/files) object itself.
 */
model DeleteAssistantFileResponse {
  id: string;
  deleted: boolean;
  object: "assistant.file.deleted";
}

model AssistantToolsCode {
  @doc("""
  The type of tool being defined: `code_interpreter`
  """)
  type: "code_interpreter";
}

model AssistantToolsRetrieval {
  @doc("""
  The type of tool being defined: `retrieval`
  """)
  type: "retrieval";
}

model AssistantToolsFunction {
  @doc("""
  The type of tool being defined: `function`
  """)
  type: "function";

  function: FunctionObject;
}

@doc("""
Represents an `assistant` that can call the model and use tools.
""")
model AssistantObject {
  /** The identifier, which can be referenced in API endpoints. */
  id: string;

  @doc("""
  The object type, which is always `assistant`.
  """)
  object: "assistant";

  // Tool customization: _at and created are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the assistant was created. */
  @encode("unixTimestamp", int32)
  created_at: utcDateTime;

  /** The name of the assistant. The maximum length is 256 characters. */
  @maxLength(256)
  name: string | null;

  /** The description of the assistant. The maximum length is 512 characters. */
  @maxLength(512)
  description: string | null;

  /**
   * ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to
   * see all of your available models, or see our [Model overview](/docs/models/overview) for
   * descriptions of them.
   */
  `model`: string;

  /** The system instructions that the assistant uses. The maximum length is 256,000 characters. */
  @maxLength(256000)
  instructions: string | null;

  @doc("""
  A list of tool enabled on the assistant. There can be a maximum of 128 tools per assistant. Tools can be of types `code_interpreter`, `retrieval`, or `function`.
  """)
  @maxItems(128)
  @extension("x-oaiExpandable", true)
  tools: (AssistantToolsCode | AssistantToolsRetrieval | AssistantToolsFunction)[] = [
  ];

  /**
   * A list of [file](/docs/api-reference/files) IDs attached to this assistant. There can be a
   * maximum of 20 files attached to the assistant. Files are ordered by their creation date in
   * ascending order.
   */
  @maxItems(20)
  file_ids: string[] = [];

  /**
   * Set of 16 key-value pairs that can be attached to an object. This can be useful for storing
   * additional information about the object in a structured format. Keys can be a maximum of 64
   * characters long and values can be a maxium of 512 characters long.
   */
  @extension("x-oaiTypeLabel", "map")
  metadata: Record<string> | null;
}

model TruncationObject {
  @doc("""
  The truncation strategy to use for the thread. The default is `auto`. If set to `last_messages`, the thread will be truncated to the n most recent messages in the thread. When set to `auto`, messages in the middle of the thread will be dropped to fit the context length of the model, `max_prompt_tokens`.
  """)
  type?: "auto" | "last_messages";

  /**
   * The number of most recent messages from the thread when constructing the context for the run.
   */
  @minValue(1)
  last_messages?: int32 | null;
}

@doc("""
Controls which (if any) tool is called by the model.
`none` means the model will not call any tools and instead generates a message.
`auto` is the default value and means the model can pick between generating a message or calling a tool.
Specifying a particular tool like `{"type": "TOOL_TYPE"}` or `{"type": "function", "function": {"name": "my_function"}}` forces the model to call that tool.
""")
@extension("x-oaiExpandable", true)
union AssistantsApiToolChoiceOption {
  "none" | "auto",
  AssistantsApiNamedToolChoice,
}

@doc("""
A list of [Files](/docs/api-reference/files) attached to an `assistant`.
""")
model AssistantFileObject {
  /** The identifier, which can be referenced in API endpoints. */
  id: string;

  @doc("""
  The object type, which is always `assistant.file`.
  """)
  object: "assistant.file";

  // Tool customization: _at and created are Unix encoded utcDateTime
  /** The Unix timestamp (in seconds) for when the assistant file was created. */
  @encode("unixTimestamp", int32)
  created_at: utcDateTime;

  /** The assistant ID that the file is attached to. */
  assistant_id: string;
}
