import "../common";

using TypeSpec.OpenAPI;
using TypeSpec.Http;

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

@discriminator("placeholder_discriminator")
model ClientOnlyChatCompletionToolChoiceOption {
  placeholder_discriminator: string | "predefined" | "named";
}
model ClientOnlyChatCompletionToolChoiceOptionPredefined
  extends ClientOnlyChatCompletionToolChoiceOption {
  placeholder_discriminator: "predefined";
  value: string | "none" | "auto" | "required";
}
model ClientOnlyChatCompletionToolChoiceOptionNamed
  extends ClientOnlyChatCompletionToolChoiceOption {
  placeholder_discriminator: "named";
  ...ChatCompletionNamedToolChoice;
}

@discriminator("type")
model ChatCompletionRequestMessageContentPart {
  type: string | "text" | "image_url" | "refusal";
}

@discriminator("type")
model ChatCompletionMessageToolCall {
  type: string | "function";
}

union ChatCompletionToolType {
  string,
  function: "function",
}

@discriminator("type")
model ChatCompletionTool {
  type: ChatCompletionToolType;
}

@discriminator("type")
model ChatCompletionMessageToolCallChunk {
  type: string | "function";
}
