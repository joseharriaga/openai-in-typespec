using TypeSpec.OpenAPI;

namespace OpenAI;

@encodedName("application/json", "")
union ChatResponseFormat {
  "auto",
}

model ChatCompletionFunctionChoice {}

model ChatCompletionToolChoice {}

model ChatMessageContentPart {}
