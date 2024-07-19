import "../../.typespec/runs";

using TypeSpec.OpenAPI;

namespace AzureOpenAI;

model AzureRunStepObject is OpenAI.RunStepObject;

model AzureRunStepDetailsToolCallsObjectToolCallsObject
  extends OpenAI.RunStepDetailsToolCallsObjectToolCallsObject {}

// Tool customization: apply custom, common base type to union items
model RunStepDetailsToolCallsBingSearchObject
  extends AzureRunStepDetailsToolCallsObjectToolCallsObject {
  /** The ID of the tool call object. */
  id: string;

  @doc("""
  The type of tool call. This is always going to be `browser` for this type of tool call.
  """)
  type: "browser";

  /** For now, this is always going to be an empty object. */
  @extension("x-oaiTypeLabel", "map")
  browser: Record<unknown>;
}

// Tool customization: apply custom, common base type to union items
model RunStepDeltaStepDetailsToolCallsBingSearchObject
  extends OpenAI.RunStepDeltaStepDetailsToolCallsObjectToolCallsObject {
  /** The index of the tool call in the tool calls array. */
  index: int32;

  /** The ID of the tool call object. */
  id?: string;

  @doc("""
  The type of tool call. This is always going to be `browser` for this type of tool call.
  """)
  type: "browser";

  /** For now, this is always going to be an empty object. */
  @extension("x-oaiTypeLabel", "map")
  browser: Record<unknown>;
}
