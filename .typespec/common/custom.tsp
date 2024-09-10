using TypeSpec.OpenAPI;

namespace OpenAI;

@discriminator("type")
model OmniTypedResponseFormat {
  type: string;
}
