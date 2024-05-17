import "./models.oyd.auth.tsp";
import "./models.oyd.vectorization.tsp";
import "../../../../chat";

using OpenAI;

namespace AzureOpenAI;

model AzureCreateChatCompletionRequest extends CreateChatCompletionRequest {
  data_sources?: AzureChatDataSource[];
}

@discriminator("type")
model AzureChatDataSource {
  type: string;
}

model AzureChatSearchDataSource extends AzureChatDataSource {
  type: "azure_search";
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
      image_vector_fields?: string[];
    };
    query_type?:
      | "simple"
      | "semantic"
      | "vector"
      | "vector_simple_hybrid"
      | "vector_semantic_hybrid";
    semantic_configuration?: string;
    filter?: string;
    embedding_dependency: AzureChatDataSourceVectorizationSource;
  };
}

model AzureChatCosmosDBDataSource extends AzureChatDataSource {
  type: "AzureCosmosDB";
  parameters: {
    ...AzureChatDataSourceCommonParameters;
    database_name: string;
    container_name: string;
    index_name: string;
    fields_mapping: {
      title_field?: string;
      url_field?: string;
      filepath_field?: string;
      content_fields: string[];
      content_fields_separator?: string;
      vector_fields: string[];
    };
    embedding_dependency: AzureChatDataSourceVectorizationSource;
  };
}

model AzureChatMachineLearningIndexDataSource extends AzureChatDataSource {
  type: "azure_ml_index";
  parameters: {
    ...AzureChatDataSourceCommonParameters;
    project_resource_id: string;
    name: string;
    version: string;
    filter?: string;
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
    embedding_dependency: AzureChatDataSourceVectorizationSource;
  };
}

model AzureChatPineconeDataSource extends AzureChatDataSource {
  type: "pinecone";
  ...AzureChatDataSourceCommonParameters;
  environment: string;
  index_name: string;
  fields_mapping?: {
    title_field?: string;
    url_field?: string;
    filepath_field?: string;
    content_fields: string[];
    content_fields_separator?: string;
  };
  embedding_dependency: AzureChatDataSourceVectorizationSource;
}

alias AzureChatDataSourceCommonParameters = {
  authentication?: unknown;
  top_n_documents?: int32;
  in_scope?: boolean;
  strictness?: int32;
  role_information?: string;
};
