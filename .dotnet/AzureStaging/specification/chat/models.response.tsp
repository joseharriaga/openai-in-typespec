import "../common";
import "../../../../chat";

using OpenAI;

namespace AzureOpenAI;

model AzureCreateChatCompletionResponse extends CreateChatCompletionResponse {
  prompt_filter_results?: {
    prompt_index: int32;
    content_filter_results: AzureContentFilterResultForPrompt;
  }[];
}

model AzureChatMessageContext {
  intent?: string;
  citations?: AzureChatDataSourceCitation[];
  all_retrieved_documents?: {
    ...AzureChatDataSourceCitation;
    search_queries: string[];
    data_source_index: int32;
    original_search_score?: float64;
    rerank_score?: float64;
    filter_reason?: "score" | "rerank";
  };
}

model AzureChatCompletionResponseMessage extends ChatCompletionResponseMessage {
  context?: AzureChatMessageContext;
}

model AzureChatCompletionStreamResponseDelta
  extends ChatCompletionStreamResponseDelta {
  context?: AzureChatMessageContext;
}

alias AzureChatDataSourceCitation = {
  content: string;
  title?: string;
  url?: string;
  filepath?: string;
  chunk_id?: string;
};
