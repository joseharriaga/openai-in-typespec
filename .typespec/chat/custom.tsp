import "../common";

using TypeSpec.OpenAPI;

namespace OpenAI;

@encodedName("application/json", "")
model ChatResponseFormat {}

model ChatResponseFormatJsonSchema {
  ...ResponseFormatJsonSchema;
}

model ChatCompletionFunctionChoice {}

model ChatCompletionToolChoice {}

model ChatMessageContentPart {}
