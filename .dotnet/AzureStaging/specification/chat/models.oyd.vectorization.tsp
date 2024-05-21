import "../../../../chat";
import "./models.oyd.auth.tsp";

using OpenAI;

namespace AzureOpenAI;

@discriminator("type")
model AzureChatDataSourceVectorizationSource {
  type: string;
}

model AzureChatDataSourceEndpointVectorizationSource
  extends AzureChatDataSourceVectorizationSource {
  type: "endpoint";
  endpoint: url;
  authentication: AzureChatDataSourceApiKeyAuthenticationOptions | AzureChatDataSourceAccessTokenAuthenticationOptions;
  dimensions?: int32;
}

model AzureChatDataSourceDeploymentNameVectorizationSource
  extends AzureChatDataSourceVectorizationSource {
  type: "deployment_name";
  deployment_name: string;
  dimensions?: int32;
}

model AzureChatDataSourceModelIdVectorizationSource
  extends AzureChatDataSourceVectorizationSource {
  type: "model_id";
  model_id: string;
}
