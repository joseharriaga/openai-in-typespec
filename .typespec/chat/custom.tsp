import "../common";

using TypeSpec.OpenAPI;

namespace OpenAI;

@encodedName("application/json", "")
@discriminator("type")
model ChatResponseFormat {
  ...OmniTypedResponseFormat;
}

model ChatResponseFormatText extends ChatResponseFormat {
  ...ResponseFormatText;
}

model ChatResponseFormatJsonObject extends ChatResponseFormat {
  ...ResponseFormatJsonObject;
}

model ChatResponseFormatJsonSchema extends ChatResponseFormat {
  ...ResponseFormatJsonSchema;
}

model ChatCompletionFunctionChoice {}

model ChatCompletionToolChoice {}

model ChatMessageContent {}

model ChatMessageContentPart {}
