import "@typespec/versioning";
import "../../.typespec/chat/models.tsp";

using TypeSpec.Versioning;

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

model AzureChatDataSourceConnectionStringAuthenticationOptions
  extends AzureChatDataSourceAuthenticationOptions {
  type: "connection_string";
  connection_string: string;
}

model AzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions
  extends AzureChatDataSourceAuthenticationOptions {
  type: "system_assigned_managed_identity";
}

model AzureChatDataSourceUserAssignedManagedIdentityAuthenticationOptions
  extends AzureChatDataSourceAuthenticationOptions {
  type: "user_assigned_managed_identity";
  managed_identity_resource_id: string;
}

@added(AzureOpenAIServiceApiVersion.v2024_08_01_preview) // from 2024-07-01-preview
@removed(AzureOpenAIServiceApiVersion.v2024_10_21)
@added(AzureOpenAIServiceApiVersion.v2024_12_01_preview)
model AzureChatDataSourceKeyAndKeyIdAuthenticationOptions
  extends AzureChatDataSourceAuthenticationOptions {
  type: "key_and_key_id";
  key: string;
  key_id: string;
}

@added(AzureOpenAIServiceApiVersion.v2024_08_01_preview) // from 2024-07-01-preview
@removed(AzureOpenAIServiceApiVersion.v2024_10_21)
@added(AzureOpenAIServiceApiVersion.v2024_12_01_preview)
model AzureChatDataSourceEncodedApiKeyAuthenticationOptions
  extends AzureChatDataSourceAuthenticationOptions {
  type: "encoded_api_key";
  encoded_api_key: string;
}

@added(AzureOpenAIServiceApiVersion.v2024_08_01_preview) // from 2024-07-01-preview
@removed(AzureOpenAIServiceApiVersion.v2024_10_21)
@added(AzureOpenAIServiceApiVersion.v2024_12_01_preview)
model AzureChatDataSourceAccessTokenAuthenticationOptions
  extends AzureChatDataSourceAuthenticationOptions {
  type: "access_token";
  access_token: string;
}

@added(AzureOpenAIServiceApiVersion.v2024_08_01_preview)
@removed(AzureOpenAIServiceApiVersion.v2024_10_21)
@added(AzureOpenAIServiceApiVersion.v2024_12_01_preview)
model AzureChatDataSourceUsernameAndPasswordAuthenticationOptions
  extends AzureChatDataSourceAuthenticationOptions {
  type: "username_and_password";
  username: string;
  password: string;
}
