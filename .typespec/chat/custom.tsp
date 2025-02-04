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

/**
 * Base representation of predicted output from a model.
 */
@discriminator("type")
model ChatOutputPrediction {
  type: string | "content";
}

model ChatCompletionFunctionChoice {}

model ChatCompletionToolChoice {}

model ChatMessageContent {}

model ChatMessageContentPart {}

model ChatCompletionMessageAudioChunk {
  id?: string;
  transcript?: string;

  @encode("base64")
  data?: bytes;

  @encode("unixTimestamp", int32)
  expires_at?: utcDateTime;
}
