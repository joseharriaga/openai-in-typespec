import "../../../../chat";

using OpenAI;

namespace AzureOpenAI;

@discriminator("type")
model AzureChatDataSourceAuthenticationOptions {
  type: string;
}

model AzureChatDataSourceApiKeyAuthenticationOptions
  extends AzureChatDataSourceAuthenticationOptions {
  type: "api_key";
  key: string;
}
