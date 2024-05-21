using TypeSpec.OpenAPI;

namespace OpenAI;

@discriminator("role")
model ChatCompletionRequestMessage {
  @doc("""
  The role of the author of this message.
  """)
  role: string;
}

model ChatMessageContentPart {}

model ChatCompletionToolChoice {}

model ChatCompletionFunctionChoice {}
