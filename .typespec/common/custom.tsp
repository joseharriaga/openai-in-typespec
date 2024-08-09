using TypeSpec.OpenAPI;

namespace OpenAI;

union ListOrder {
  string,
  asc: "asc",
  desc: "desc",
}

@discriminator("type")
model OmniTypedResponseFormat {
  type: string;
}
