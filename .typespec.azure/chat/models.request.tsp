import "@typespec/versioning";

import "../../.typespec/chat/models.tsp";
import "../main.tsp";
import "./models.oyd.auth.tsp";
import "./models.oyd.vectorization.tsp";

using TypeSpec.Versioning;

namespace AzureOpenAI;

@withoutOmittedProperties("model")
@withoutOmittedProperties("service_tier")
model CreateChatCompletionRequestCommonBase
  is OpenAI.CreateChatCompletionRequest;

/**
 * The extended request model for chat completions against the Azure OpenAI service.
 * This adds the ability to provide data sources for the On Your Data feature.
 */
model AzureCreateChatCompletionRequest {
  ...CreateChatCompletionRequestCommonBase;

  /**
   * The data sources to use for the On Your Data feature, exclusive to Azure OpenAI.
   */
  data_sources?: AzureChatDataSource[];

  @added(AzureOpenAIServiceApiVersion.v2024_12_01_preview)
  user_security_context?: AzureUserSecurityContext;
}

/**
 * A representation of configuration data for a single Azure OpenAI chat data source.
 * This will be used by a chat completions request that should use Azure OpenAI chat extensions to augment the
 * response behavior.
 * The use of this configuration is compatible only with Azure OpenAI.
 */
@discriminator("type")
model AzureChatDataSource {
  /** The differentiating type identifier for the data source. */
  type: string;
}

/** Represents a data source configuration that will use an Azure Search resource. */
model AzureSearchChatDataSource extends AzureChatDataSource {
  /** The discriminated type identifier, which is always 'azure_search'. */
  type: "azure_search";

  /** The parameter information to control the use of the Azure Search data source. */
  parameters: {
    ...AzureChatDataSourceCommonParameters;

    /** The absolute endpoint path for the Azure Search resource to use. */
    endpoint: url;

    /** The name of the index to use, as specified in the Azure Search resource. */
    index_name: string;

    /**
     * The authentication mechanism to use with Azure Search.
     */
    authentication:
      | AzureChatDataSourceApiKeyAuthenticationOptions
      | AzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions
      | AzureChatDataSourceUserAssignedManagedIdentityAuthenticationOptions
      | AzureChatDataSourceAccessTokenAuthenticationOptions;

    /** The field mappings to use with the Azure Search resource. */
    fields_mapping?: {
      /** The name of the index field to use as a title. */
      title_field?: string;

      /** The name of the index field to use as a URL. */
      url_field?: string;

      /** The name of the index field to use as a filepath. */
      filepath_field?: string;

      /** The names of index fields that should be treated as content. */
      content_fields?: string[];

      /** The separator pattern that content fields should use. */
      content_fields_separator?: string;

      /** The names of fields that represent vector data. */
      vector_fields?: string[];

      /** The names of fields that represent image vector data. */
      image_vector_fields?: string[];
    };

    /** The query type for the Azure Search resource to use. */
    query_type?:
      | "simple"
      | "semantic"
      | "vector"
      | "vector_simple_hybrid"
      | "vector_semantic_hybrid";

    /** Additional semantic configuration for the query. */
    semantic_configuration?: string;

    /** A filter to apply to the search. */
    filter?: string;

    /**
     * The vectorization source to use with Azure Search.
     * Supported sources for Azure Search include endpoint, deployment name, and integrated.
     */
    @typeChangedFrom(
      AzureOpenAIServiceApiVersion.v2024_08_01_preview,
      AzureChatDataSourceEndpointVectorizationSource | AzureChatDataSourceDeploymentNameVectorizationSource
    )
    embedding_dependency?: AzureChatDataSourceEndpointVectorizationSource | AzureChatDataSourceDeploymentNameVectorizationSource | AzureChatDataSourceIntegratedVectorizationSource;
  };
}

/** Represents a data source configuration that will use an Azure Machine Learning vector index. */
@removed(AzureOpenAIServiceApiVersion.v2024_08_01_preview)
model AzureMachineLearningIndexChatDataSource extends AzureChatDataSource {
  /** The discriminated type identifier, which is always 'azure_ml_index'. */
  type: "azure_ml_index";

  /** The parameter information to control the use of the Azure Machine Learning Index data source. */
  parameters: {
    ...AzureChatDataSourceCommonParameters;
    authentication: AzureChatDataSourceAccessTokenAuthenticationOptions | AzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions | AzureChatDataSourceUserAssignedManagedIdentityAuthenticationOptions;

    /** The ID of the Azure Machine Learning index project to use. */
    project_resource_id: string;

    /** The name of the Azure Machine Learning index to use. */
    name: string;

    /** The version of the vector index to use. */
    version: string;

    /** A search filter, which is only applicable if the vector index is of the 'AzureSearch' type. */
    filter?: string;
  };
}

/** Represents a data source configuration that will use an Azure CosmosDB resource. */
model AzureCosmosDBChatDataSource extends AzureChatDataSource {
  /** The discriminated type identifier, which is always 'azure_cosmos_db'. */
  type: "azure_cosmos_db";

  /** The parameter information to control the use of the Azure CosmosDB data source. */
  parameters: {
    ...AzureChatDataSourceCommonParameters;
    container_name: string;
    database_name: string;
    embedding_dependency: AzureChatDataSourceVectorizationSource;
    index_name: string;
    authentication: AzureChatDataSourceConnectionStringAuthenticationOptions;
    fields_mapping: {
      content_fields: string[];
      vector_fields: string[];
      title_field?: string;
      url_field?: string;
      filepath_field?: string;
      content_fields_separator?: string;
    };
  };
}

model ElasticsearchChatDataSource extends AzureChatDataSource {
  /** The discriminated type identifier, which is always 'elasticsearch'. */
  type: "elasticsearch";

  /** The parameter information to control the use of the Elasticsearch data source. */
  parameters: {
    ...AzureChatDataSourceCommonParameters;
    endpoint: url;
    index_name: string;
    authentication: AzureChatDataSourceKeyAndKeyIdAuthenticationOptions | AzureChatDataSourceEncodedApiKeyAuthenticationOptions;
    fields_mapping?: {
      title_field?: string;
      url_field?: string;
      filepath_field?: string;
      content_fields?: string[];
      content_fields_separator?: string;
      vector_fields?: string[];
    };
    query_type?: "simple" | "vector";
    embedding_dependency?: AzureChatDataSourceVectorizationSource;
  };
}

model PineconeChatDataSource extends AzureChatDataSource {
  /** The discriminated type identifier, which is always 'pinecone'. */
  type: "pinecone";

  /** The parameter information to control the use of the Pinecone data source. */
  parameters: {
    ...AzureChatDataSourceCommonParameters;

    /** The environment name to use with Pinecone. */
    environment: string;

    /** The name of the Pinecone database index to use. */
    index_name: string;

    /**
     * The authentication mechanism to use with Pinecone.
     * Supported authentication mechanisms for Pinecone include: API key.
     */
    authentication: AzureChatDataSourceApiKeyAuthenticationOptions;

    /**
     * The vectorization source to use as an embedding dependency for the Pinecone data source.
     * Supported vectorization sources for Pinecone include: deployment name.
     */
    embedding_dependency: AzureChatDataSourceVectorizationSource;

    /**
     * Field mappings to apply to data used by the Pinecone data source.
     * Note that content field mappings are required for Pinecone.
     */
    fields_mapping: {
      content_fields: string[];
      title_field?: string;
      url_field?: string;
      filepath_field?: string;
      content_fields_separator?: string;
    };
  };
}

@added(AzureOpenAIServiceApiVersion.v2024_08_01_preview)
model MongoDBChatDataSource extends AzureChatDataSource {
  /** The discriminated type identifier, which is always 'mongo_db'. */
  type: "mongo_db";

  /** The parameter information to control the use of the MongoDB data source. */
  parameters: {
    ...AzureChatDataSourceCommonParameters;

    /** The name of the MongoDB cluster endpoint. */
    endpoint: string;

    /** The name of the MongoDB database. */
    database_name: string;

    /** The name of the MongoDB collection. */
    collection_name: string;

    /** The name of the MongoDB application. */
    app_name: string;

    /** The name of the MongoDB index. */
    index_name: string;

    /**
     * The authentication mechanism to use with Pinecone.
     * Supported authentication mechanisms for Pinecone include: username and password.
     */
    @added(AzureOpenAIServiceApiVersion.v2024_08_01_preview)
    authentication: AzureChatDataSourceUsernameAndPasswordAuthenticationOptions;

    /**
     * The vectorization source to use as an embedding dependency for the MongoDB data source.
     * Supported vectorization sources for MongoDB include: endpoint, deployment name.
     */
    embedding_dependency: AzureChatDataSourceEndpointVectorizationSource | AzureChatDataSourceDeploymentNameVectorizationSource;

    /**
     * Field mappings to apply to data used by the MongoDB data source.
     * Note that content and vector field mappings are required for MongoDB.
     */
    fields_mapping: {
      content_fields: string[];
      vector_fields: string[];
      title_field?: string;
      url_field?: string;
      filepath_field?: string;
      content_fields_separator?: string;
    };
  };
}

alias AzureChatDataSourceCommonParameters = {
  /** The configured number of documents to feature in the query. */
  top_n_documents?: int32;

  /** Whether queries should be restricted to use of the indexed data. */
  in_scope?: boolean;

  /**
   * The configured strictness of the search relevance filtering.
   * Higher strictness will increase precision but lower recall of the answer.
   */
  @minValue(1)
  @maxValue(5)
  strictness?: int32;

  /**
   * Additional instructions for the model to inform how it should behave and any context it should reference when
   * generating a response. You can describe the assistant's personality and tell it how to format responses.
   * This is limited to 100 tokens and counts against the overall token limit.
   */
  @removed(AzureOpenAIServiceApiVersion.v2024_08_01_preview)
  role_information?: string;

  /**
   * The maximum number of rewritten queries that should be sent to the search provider for a single user message.
   * By default, the system will make an automatic determination.
   */
  max_search_queries?: int32;

  /**
   * If set to true, the system will allow partial search results to be used and the request will fail if all
   * partial queries fail. If not specified or specified as false, the request will fail if any search query fails.
   */
  allow_partial_result?: boolean = false;

  /**
   * The output context properties to include on the response.
   * By default, citations and intent will be requested.
   */
  @maxItems(3)
  include_contexts?: ("citations" | "intent" | "all_retrieved_documents")[] = #[
    "citations",
    "intent"
  ];
};

/**
 * User security context contains several parameters that describe the application itself, and the end user that interacts with the application. These fields assist your security operations teams to investigate and mitigate security incidents by providing a comprehensive approach to protecting your AI applications. [Learn more](https://aka.ms/TP4AI/Documentation/EndUserContext) about protecting AI applications using Microsoft Defender for Cloud.
 */
@added(AzureOpenAIServiceApiVersion.v2024_12_01_preview)
model AzureUserSecurityContext {
  /** The name of the application. Sensitive personal information should not be included in this field. */
  application_name?: string;

  /** This identifier is the Microsoft Entra ID (formerly Azure Active Directory) user object ID used to authenticate end-users within the generative AI application. Sensitive personal information should not be included in this field. */
  end_user_id?: string;

  /** The Microsoft 365 tenant ID the end user belongs to. It's required when the generative AI application is multitenant. */
  end_user_tenant_id?: string;

  /** Captures the original client's IP address. */
  source_ip?: string;
}
