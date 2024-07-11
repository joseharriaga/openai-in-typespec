import "../../.typespec/chat/models.tsp";

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

model AzureChatDataSourceKeyAndKeyIdAuthenticationOptions
  extends AzureChatDataSourceAuthenticationOptions {
  type: "key_and_key_id";
  key: string;
  key_id: string;
}

model AzureChatDataSourceEncodedApiKeyAuthenticationOptions
  extends AzureChatDataSourceAuthenticationOptions {
  type: "encoded_api_key";
  encoded_api_key: string;
}

model AzureChatDataSourceAccessTokenAuthenticationOptions
  extends AzureChatDataSourceAuthenticationOptions {
  type: "access_token";
  access_token: string;
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
