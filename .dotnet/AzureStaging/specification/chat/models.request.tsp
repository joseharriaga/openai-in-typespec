import "./models.oyd.auth.tsp";
import "./models.oyd.vectorization.tsp";
import "../../../../chat";

using OpenAI;

namespace AzureOpenAI;

model AzureCreateChatCompletionRequest extends CreateChatCompletionRequest {
  data_sources?: AzureChatDataSource[];
}

/**
 * A representation of configuration data for a single Azure OpenAI chat data source.
 * This will be used by a chat completions request that should use Azure OpenAI chat extensions to augment the
 * response behavior.
 * The use of this configuration is compatible only with Azure OpenAI.
 */
@discriminator("type")
model AzureChatDataSource {
  type: string;
}

/** Represents a data source configuration that will use an Azure Search resource. */
model AzureChatSearchDataSource extends AzureChatDataSource {
  /** The discriminated type identifier, which is always 'azure_search'. */
  type: "azure_search";

  /** The parameter information to control the use of the Azure Search data source. */
  parameters: {
    ...AzureChatDataSourceCommonParameters;

    /** The absolute endpoint path for the Azure Search resource to use. */
    endpoint: url;

    /** The name of the index to use, as specified in the Azure Search resource. */
    index_name: string;

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

      /** THe names of fields that represent vector data. */
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

    /**  */
    embedding_dependency: AzureChatDataSourceVectorizationSource;
  };
}

/** Represents a data source configuration that will use an Azure Machine Learning vector index. */
model AzureChatMachineLearningIndexDataSource extends AzureChatDataSource {
  type: "azure_ml_index";
  parameters: {
    ...AzureChatDataSourceCommonParameters;

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
model AzureChatCosmosDBDataSource extends AzureChatDataSource {
  type: "AzureCosmosDB";
  parameters: {
    ...AzureChatDataSourceCommonParameters;
    container_name: string;
    database_name: string;
    embedding_dependency: AzureChatDataSourceVectorizationSource;
    index_name: string;
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

model AzureChatElasticsearchDataSource extends AzureChatDataSource {
  type: "elasticsearch";
  parameters: {
    ...AzureChatDataSourceCommonParameters;
    endpoint: url;
    index_name: string;
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

model AzureChatPineconeDataSource extends AzureChatDataSource {
  type: "pinecone";
  ...AzureChatDataSourceCommonParameters;
  environment: string;
  index_name: string;
  embedding_dependency: AzureChatDataSourceVectorizationSource;
  fields_mapping: {
    content_fields: string[];
    title_field?: string;
    url_field?: string;
    filepath_field?: string;
    content_fields_separator?: string;
  };
}

alias AzureChatDataSourceCommonParameters = {
  /** The authentication mechanism to use with the data source. */
  authentication?: AzureChatDataSourceAuthenticationOptions;

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
  allow_partial_result: boolean = false;

  /**
   * The output context properties to include on the response.
   * By default, citations and intent will be requested.
   */
  @maxItems(3)
  include_contexts?: ("citations" | "intent" | "all_retrieved_documents")[] = [
    "citations",
    "intent"
  ];
};
