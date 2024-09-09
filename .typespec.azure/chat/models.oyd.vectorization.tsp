import "@typespec/versioning";
import "../../.typespec/chat/models.tsp";
import "./models.oyd.auth.tsp";

using TypeSpec.Versioning;

namespace AzureOpenAI;

/**
 * A representation of a data vectorization source usable as an embedding resource with a data source.
 */
@discriminator("type")
model AzureChatDataSourceVectorizationSource {
  /** The differentiating identifier for the concrete vectorization source. */
  type: string;
}

/**
 * Represents a vectorization source that makes public service calls against an Azure OpenAI embedding model deployment.
 */
model AzureChatDataSourceEndpointVectorizationSource
  extends AzureChatDataSourceVectorizationSource {
  /** The type identifier, always 'endpoint' for this vectorization source type. */
  type: "endpoint";

  /**
   * Specifies the resource endpoint URL from which embeddings should be retrieved.
   * It should be in the format of:
   * https://YOUR_RESOURCE_NAME.openai.azure.com/openai/deployments/YOUR_DEPLOYMENT_NAME/embeddings.
   * The api-version query parameter is not allowed.
   */
  endpoint: url;

  /**
   * The authentication mechanism to use with the endpoint-based vectorization source.
   * Endpoint authentication supports API key and access token mechanisms.
   */
  authentication: AzureChatDataSourceApiKeyAuthenticationOptions | AzureChatDataSourceAccessTokenAuthenticationOptions;

  /**
   * The number of dimensions to request on embeddings.
   * Only supported in 'text-embedding-3' and later models.
   */
  dimensions?: int32;
}

/**
 * Represents a vectorization source that makes internal service calls against an Azure OpenAI embedding model
 * deployment. In contrast with the endpoint-based vectorization source, a deployment-name-based vectorization source
 * must be part of the same Azure OpenAI resource but can be used even in private networks.
 */
model AzureChatDataSourceDeploymentNameVectorizationSource
  extends AzureChatDataSourceVectorizationSource {
  /** The type identifier, always 'deployment_name' for this vectorization source type. */
  type: "deployment_name";

  /**
   * The embedding model deployment to use for vectorization. This deployment must exist within the same Azure OpenAI
   * resource as the model deployment being used for chat completions.
   */
  deployment_name: string;

  /**
   * The number of dimensions to request on embeddings.
   * Only supported in 'text-embedding-3' and later models.
   */
  dimensions?: int32;
}

/**
 * Represents a vectorization source that makes service calls based on a search service model ID.
 * This source type is currently only supported by Elasticsearch.
 */
model AzureChatDataSourceModelIdVectorizationSource
  extends AzureChatDataSourceVectorizationSource {
  /** The type identifier, always 'model_id' for this vectorization source type. */
  type: "model_id";

  /** The embedding model build ID to use for vectorization. */
  model_id: string;
}

/**
 * Represents an integrated vectorization source as defined within the supporting search resource.
 */
@added(AzureOpenAIServiceApiVersion.v2024_08_01_preview)
model AzureChatDataSourceIntegratedVectorizationSource
  extends AzureChatDataSourceVectorizationSource {
  /** The type identifier, always 'integrated' for this vectorization source type. */
  type: "integrated";
}
