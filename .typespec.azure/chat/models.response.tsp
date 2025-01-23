import "../../.typespec/chat/models.tsp";
import "../common";

namespace AzureOpenAI;

/**
 * The extended top-level chat completion response model for the Azure OpenAI service.
 * This model adds Responsible AI content filter annotations for prompt input.
 */
model AzureCreateChatCompletionResponse {
  ...OpenAI.CreateChatCompletionResponse;

  /**
   * The Responsible AI content filter annotations associated with prompt inputs into chat completions.
   */
  prompt_filter_results?: {
    /**
     * The index of the input prompt that this content filter result corresponds to.
     */
    prompt_index: int32;

    /**
     * The content filter results associated with the indexed input prompt.
     */
    content_filter_results: AzureContentFilterResultForPrompt;
  }[];
}

/**
 * An additional property, added to chat completion response messages, produced by the Azure OpenAI service when using
 * extension behavior. This includes intent and citation information from the On Your Data feature.
 */
model AzureChatMessageContext {
  /** The detected intent from the chat history, which is used to carry conversation context between interactions */
  intent?: string;

  /** The citations produced by the data retrieval. */
  citations?: AzureChatDataSourceCitation[];

  /** Summary information about documents retrieved by the data retrieval operation. */
  all_retrieved_documents?: {
    ...AzureChatDataSourceCitation;

    /** The search queries executed to retrieve documents. */
    search_queries: string[];

    /** The index of the data source used for retrieval. */
    data_source_index: int32;

    /** The original search score for the retrieval. */
    original_search_score?: float64;

    /** If applicable, an indication of why the document was filtered. */
    filter_reason?: "score" | "rerank";
  };
}

/**
 * The extended response model component for chat completion response messages on the Azure OpenAI service.
 * This model adds support for chat message context, used by the On Your Data feature for intent, citations, and other
 * information related to retrieval-augmented generation performed.
 */
model AzureChatCompletionResponseMessage {
  ...OpenAI.ChatCompletionResponseMessage;

  /**
   * The Azure-specific context information associated with the chat completion response message.
   */
  context?: AzureChatMessageContext;
}

/**
 * The extended response model for a streaming chat response message on the Azure OpenAI service.
 * This model adds support for chat message context, used by the On Your Data feature for intent, citations, and other
 * information related to retrieval-augmented generation performed.
 */
model AzureChatCompletionStreamResponseDelta {
  ...OpenAI.ChatCompletionStreamResponseDelta;

  /**
   * The Azure-specific context information associated with the chat completion response message.
   */
  context?: AzureChatMessageContext;
}

alias AzureChatDataSourceCitation = {
  /** The content of the citation. */
  content: string;

  /** The title for the citation. */
  title?: string;

  /** The URL of the citation. */
  url?: string;

  /** The file path for the citation. */
  filepath?: string;

  /** The chunk ID for the citation. */
  chunk_id?: string;

  /** The rerank score for the retrieval. */
  rerank_score?: float64;
};
