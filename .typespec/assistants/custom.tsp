import "@azure-tools/typespec-client-generator-core";

using Azure.ClientGenerator.Core;
using TypeSpec.OpenAPI;

namespace OpenAI;

// This customization allows us to concretely specify that the file_search object must provide
// either ID references --or-- in-line creation helpers, but not both.

alias CreateAssistantRequestToolResourcesFileSearch = CreateAssistantRequestToolResourcesFileSearchVectorStoreIdReferences | CreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers;

model CreateAssistantRequestToolResourcesFileSearchVectorStoreIdReferences {
  ...CreateAssistantRequestToolResourcesFileSearchBase;

  /**
   * The [vector store](/docs/api-reference/vector-stores/object) attached to this assistant.
   * There can be a maximum of 1 vector store attached to the assistant.
   */
  @maxItems(1)
  vector_store_ids?: string[];
}

model CreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelpers {
  ...CreateAssistantRequestToolResourcesFileSearchBase;

  /**
   * A helper to create a [vector store](/docs/api-reference/vector-stores/object) with
   * file_ids and attach it to this assistant. There can be a maximum of 1 vector store
   * attached to the assistant.
   */
  @maxItems(1)
  vector_stores?: CreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelper[];
}

model CreateAssistantRequestToolResourcesFileSearchBase {
  // Common fields (currently none)
}

alias CreateAssistantRequestToolResourcesFileSearchVectorStoreCreationHelper = {
  /**
   * A list of [file](/docs/api-reference/files) IDs to add to the vector store. There can be
   * a maximum of 10000 files in a vector store.
   */
  @maxItems(10000)
  file_ids?: string[];

  /**
   * Set of 16 key-value pairs that can be attached to a vector store. This can be useful for
   * storing additional information about the vector store in a structured format. Keys can
   * be a maximum of 64 characters long and values can be a maxium of 512 characters long.
   */
  @extension("x-oaiTypeLabel", "map")
  metadata?: Record<string>;
};

@discriminator("type")
model AssistantToolDefinition {
  type: string;
}

model AssistantResponseFormat {}
