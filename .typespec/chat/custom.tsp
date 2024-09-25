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

model ChatMessageContentPart {}

@discriminator("placeholder_discriminator")
model ClientOnlyChatCompletionToolChoiceOption {
  placeholder_discriminator: string;
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
